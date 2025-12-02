using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Stockify.Models;

namespace Stockify.Controllers
{
	public class LoadEntryController : Controller
    {
        private readonly LoadDbContext _lcontext;
        private readonly LoadEntryDbContext _lecontext;
        private readonly ProductDbContext _pcontext;
        private readonly OrganisationDbContext _ocontext;
        private readonly StockDbContext _scontext;

        public LoadEntryController(LoadDbContext context1, ProductDbContext context2, OrganisationDbContext context3, LoadEntryDbContext context4, StockDbContext context5)
        {
            _lcontext = context1;
            _pcontext = context2;
            _ocontext = context3;
            _lecontext = context4;
            _scontext = context5;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: LoadEntry/Create
        [HttpGet]
        public async Task<IActionResult> CreateLoadEntry(string id)
        {
            var load = await _lcontext.Loads.FindAsync(id);

            if (load == null)
            {
                return NotFound();
            }

            var org = await _ocontext.Organisations.FindAsync(load.OrgId);

            if (org == null)
            {
                return NotFound();
            }

            List<Product> productlist = _pcontext.Products.Where(l => l.OrgId == org.OrgId).ToList();

            var viewModel = new LoadEntryViewModel
            {
                LoadId = load.LoadId,
                LoadName = load.Name,
                LoadGroup = load.LoadGroup,
                LoadOrgId = org.OrgId,
                LoadOrgName = org.Name,
                ProductList = productlist
            };

            ViewBag.NewLoadEntry = true;

            return View("NewLoadEntry", viewModel);
        }


        // POST: LoadEntry/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLoadEntry(LoadEntryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var loadentry = new LoadEntry
                {
                    LoadEntryId = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                    LoadId = viewModel.LoadId,
                    OrgId = viewModel.LoadOrgId,
                    ProductId = viewModel.LoadEntryProductId,
                    Weight = viewModel.Weight,
                    Quantity = viewModel.Quantity,
                    Width = viewModel.Width,
                    Height = viewModel.Height,
                };

                viewModel.CreationDate = loadentry.CreationDate;

                _lecontext.Add(loadentry);
                await _lecontext.SaveChangesAsync();

                var existingStock = _scontext.Stocks.FirstOrDefault(stk => stk.ProductId == viewModel.LoadEntryProductId
                                                               && stk.OrgId == viewModel.LoadOrgId
                                                               && stk.LoadGroup == viewModel.LoadGroup);

                if (existingStock == null)
                {
                    var stock = new Stock
                    {
                        StockId = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                        OrgId = viewModel.LoadOrgId,
                        ProductId = viewModel.LoadEntryProductId,
                        LoadGroup = viewModel.LoadGroup,
                        Quantity = viewModel.Quantity
                    };
                    var productType = viewModel.LoadEntryProductType;
                    if (productType == "ByWeight")
                    {
                        stock.Weight = viewModel.Weight;
                        _scontext.Add(stock);
                    }
                    else if (productType == "ByDimension")
                    {
                        stock.Height = viewModel.Height;
                        stock.Width = viewModel.Width;
                        _scontext.Add(stock);
                    }
                    else if (productType == "ByQuantity")
                    {
                        _scontext.Add(stock);
                    }
                }
                else
                {
                    var productType = viewModel.LoadEntryProductType;
                    if (productType == "ByWeight")
                    {
                        if (existingStock.Weight == viewModel.Weight)
                        {
                            existingStock.Quantity += viewModel.Quantity;
                            _scontext.Update(existingStock);
                        }
                        else
                        {
                            var stock = new Stock
                            {
                                StockId = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                                OrgId = viewModel.LoadOrgId,
                                ProductId = viewModel.LoadEntryProductId,
                                LoadGroup = viewModel.LoadGroup,
                                Weight = viewModel.Weight,
                                Quantity = viewModel.Quantity
                            };
                            _scontext.Add(stock);
                        }
                    }
                    else if (productType == "ByDimension")
                    {
                        if (existingStock.Height == viewModel.Height && existingStock.Width == viewModel.Width)
                        {
                            existingStock.Quantity += viewModel.Quantity;
                            _scontext.Update(existingStock);
                        }
                        else
                        {
                            var stock = new Stock
                            {
                                StockId = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                                OrgId = viewModel.LoadOrgId,
                                ProductId = viewModel.LoadEntryProductId,
                                LoadGroup = viewModel.LoadGroup,
                                Height = viewModel.Height,
                                Width = viewModel.Width,
                                Quantity = viewModel.Quantity
                            };
                            _scontext.Add(stock);
                        }
                    }
                    else if (productType == "ByQuantity")
                    {
                        existingStock.Quantity += viewModel.Quantity;
                        _scontext.Update(existingStock);
                    }
                }
                await _scontext.SaveChangesAsync();
            }

            return View("NewLoadEntry", viewModel);
        }

        public async Task<IActionResult> ListLoadEntries(string id)
        {
            var load = await _lcontext.Loads.FindAsync(id);

            if (load == null)
            {
                return NotFound();
            }

            var org = await _ocontext.Organisations.FindAsync(load.OrgId);

            if (org == null)
            {
                return NotFound();
            }

            List<LoadEntry> loadentries = _lecontext.LoadEntries.Where(l => l.LoadId == id).ToList();

            var productNames = new Dictionary<string, string>();
            var productTypes = new Dictionary<string, string>();

            foreach (var loadentry in loadentries)
            {
                var product = await _pcontext.Products.FindAsync(loadentry.ProductId);

                if (product == null)
                {
                    productNames[loadentry.LoadEntryId] = "N/A";
                    productTypes[loadentry.LoadEntryId] = "N/A";
                }
                else
                {
                    productNames[loadentry.LoadEntryId] = product.Name;
                    productTypes[loadentry.LoadEntryId] = product.Type;
                }
            }

            var model = new LoadEntryListViewModel
            {
                OrgName = org.Name,
                LoadName = load.Name,
                LoadGroup = load.LoadGroup,
                LoadEntryList = loadentries,
                LoadEntryProductNames = productNames,
                LoadEntryProductTypes = productTypes,
            };

            // bind products to view
            return View("ViewLoadEntries", model);
        }
    }
}

