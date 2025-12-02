using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stockify.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stockify.Controllers
{
    public class LoadController : Controller
    {
        private readonly LoadDbContext _lcontext;
        private readonly OrganisationDbContext _ocontext;

        public LoadController(LoadDbContext context1, OrganisationDbContext context2)
        {
            _lcontext = context1;
            _ocontext = context2;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: Load/Create
        [HttpGet]
        public async Task<IActionResult> Create(string id)
        {
            var org = await _ocontext.Organisations.FindAsync(id);

            if (org == null)
            {
                return NotFound();
            }

            var viewModel = new LoadViewModel
            {
                LoadId = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                LoadOrgId = org.OrgId,
                OrgName = org.Name
            };

            ViewBag.NewLoad = true;

            return View("NewLoad", viewModel);
        }

        [HttpGet]
        public JsonResult CheckLoadName(string name, string orgId)
        {
            var exists = _lcontext.Loads.Any(l => l.Name == name && l.OrgId == orgId);
            return Json(new { exists = exists });
        }

        // POST: Load/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewLoad(LoadViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var load = new Load
                {
                    LoadId = viewModel.LoadId,
                    Name = viewModel.Name,
                    OrgId = viewModel.LoadOrgId,
                    LoadGroup = viewModel.LoadGroup,
                    VehicleNo = viewModel.VehicleNo
                };

                viewModel.CreationDate = load.CreationDate;

                _lcontext.Add(load);
                await _lcontext.SaveChangesAsync();
            }

            return View("NewLoad", viewModel);
        }

        public async Task<IActionResult> ListLoads(string id)
        {
            var org = await _ocontext.Organisations.FindAsync(id);

            if (org == null)
            {
                return NotFound();
            }

            List<Load> loads = _lcontext.Loads.Where(l => l.OrgId == id).ToList();

            var model = new LoadListViewModel
            {
                OrgName = org.Name,
                LoadList = loads
            };

            // bind products to view
            return View("ViewLoads", model);
        }
    }
}

