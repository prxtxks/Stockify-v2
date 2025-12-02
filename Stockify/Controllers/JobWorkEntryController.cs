using System;
using Microsoft.AspNetCore.Mvc;
using Stockify.Models;

namespace Stockify.Controllers
{
	public class JobWorkEntryController : Controller
    {
        private readonly LoadDbContext _lcontext;
        private readonly LoadEntryDbContext _lecontext;
        private readonly ProductDbContext _pcontext;
        private readonly OrganisationDbContext _ocontext;
        private readonly JobWorkDbContext _jwcontext;
        private readonly JobWorkEntryDbContext _jwecontext;
        private readonly StockDbContext _scontext;

        public JobWorkEntryController(LoadDbContext context1, ProductDbContext context2, OrganisationDbContext context3, LoadEntryDbContext context4, JobWorkDbContext context5, JobWorkEntryDbContext context6, StockDbContext context7)
        {
            _lcontext = context1;
            _pcontext = context2;
            _ocontext = context3;
            _lecontext = context4;
            _jwcontext = context5;
            _jwecontext = context6;
            _scontext = context7;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: JobWorkEntry/Create
        [HttpGet]
        public async Task<IActionResult> CreateJobWorkEntry(string id)
        {
            var jobWork = await _jwcontext.JobWorks.FindAsync(id);

            if (jobWork == null)
            {
                return NotFound();
            }

            var org = await _ocontext.Organisations.FindAsync(jobWork.OrgId);

            if (org == null)
            {
                return NotFound();
            }

            // Create a dictionary to store the stock entries with ProductIds as keys
            Dictionary<string, List<Stock>> stockDict = new Dictionary<string, List<Stock>>();

            // Get all the stock entries in the Stocks table for a particular Org ID
            List<Stock> stockEntries = _scontext.Stocks
                .Where(st => st.OrgId == org.OrgId)
                .ToList();

            // Add each stock entry to the dictionary with its ProductId as the key
            foreach (Stock stockEntry in stockEntries)
            {
                if (!stockDict.ContainsKey(stockEntry.ProductId))
                {
                    stockDict.Add(stockEntry.ProductId, new List<Stock>());
                }
                stockDict[stockEntry.ProductId].Add(stockEntry);
            }

            // Get all the product IDs in the Stocks table for a particular Org ID
            List<string> productIds = _scontext.Stocks
                .Where(st => st.OrgId == org.OrgId)
                .Select(st => st.ProductId)
                .ToList();

            // Get all the product rows with the matching product IDs from the Products table
            List<Product> productlist = _pcontext.Products
                .Where(p => productIds.Contains(p.ProductId))
                .ToList();


            var viewModel = new JobWorkEntryViewModel
            {
                JobWorkEntryId = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                JobWorkName = jobWork.Name,
                JobWorkId = jobWork.JobWorkId,
                JobWorkEntryOrgId = org.OrgId,
                OrgName = org.Name,
                ProductStockDict = stockDict,
                ProductList = productlist
            };

            ViewBag.NewJobWorkEntry = true;

            return View("NewJobWorkEntry", viewModel);
        }

        // POST: JobWorkEntry/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddJobWorkEntry(JobWorkEntryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var jobworkentry = new JobWorkEntry
                {
                    JobWorkEntryId = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                    JobWorkId = viewModel.JobWorkId,
                    OrgId = viewModel.JobWorkEntryOrgId,
                    ProductId = viewModel.JobWorkEntryProductId,
                    Weight = viewModel.Weight,
                    Quantity = viewModel.Quantity,
                    Width = viewModel.Width,
                    Height = viewModel.Height,
                };

                viewModel.CreationDate = jobworkentry.CreationDate;

                _jwecontext.Add(jobworkentry);
                await _jwecontext.SaveChangesAsync();
            }

            return View("NewJobWorkEntry", viewModel);
        }

        public async Task<IActionResult> ListJobWorkEntries(string id)
        {
            var jobwork = await _jwcontext.JobWorks.FindAsync(id);

            if (jobwork == null)
            {
                return NotFound();
            }

            var org = await _ocontext.Organisations.FindAsync(jobwork.OrgId);

            if (org == null)
            {
                return NotFound();
            }

            List<JobWorkEntry> jobworkentries = _jwecontext.JobWorkEntries.Where(l => l.JobWorkId == id).ToList();

            var productNames = new Dictionary<string, string>();
            var productTypes = new Dictionary<string, string>();

            foreach (var jobworkentry in jobworkentries)
            {
                var product = await _pcontext.Products.FindAsync(jobworkentry.ProductId);

                if (product == null)
                {
                    productNames[jobworkentry.JobWorkEntryId] = "N/A";
                    productTypes[jobworkentry.JobWorkEntryId] = "N/A";
                }
                else
                {
                    productNames[jobworkentry.JobWorkEntryId] = product.Name;
                    productTypes[jobworkentry.JobWorkEntryId] = product.Type;
                }
            }

            var model = new JobWorkEntryListViewModel
            {
                OrgName = org.Name,
                JobWorkName = jobwork.Name,
                JobWorkEntryList = jobworkentries,
                JobWorkEntryProductNames = productNames,
                JobWorkEntryProductTypes = productTypes,
            };

            // bind products to view
            return View("ViewJobWorkEntries", model);
        }


        public IActionResult GetProductStockList(string productId, Dictionary<string, List<Stock>> productStDic)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return BadRequest("Product ID is required");
            }

            var product = _pcontext.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return BadRequest("Product not found");
            }

            var stockList = productStDic.ContainsKey(productId) ? productStDic[productId] : new List<Stock>();
            ViewBag.ProductStock = stockList;

            return PartialView("_StockList", GetProductStockDict(product.Type, stockList));
        }

        private Dictionary<string, List<Stock>> GetProductStockDict(string productType, List<Stock> stockList)
        {
            var result = new Dictionary<string, List<Stock>>();

            switch (productType)
            {
                case "ByDimension":
                    var dimensions = stockList.Select(s => $"{s.Width} x {s.Height}").Distinct();
                    foreach (var dimension in dimensions)
                    {
                        result[dimension] = stockList.Where(s => $"{s.Width} x {s.Height}" == dimension).ToList();
                    }
                    break;

                case "ByQuantity":
                    result["Quantity"] = stockList;
                    break;

                case "ByWeight":
                    result["Quantity"] = stockList;
                    result["Weight"] = stockList.Where(s => s.Weight.HasValue).ToList();
                    break;

                default:
                    break;
            }

            return result;
        }


        public PartialViewResult StockList()
        {
            return PartialView("_StockList");
        }

    }
}

