using System;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stockify.Models;

namespace Stockify.Controllers
{
	public class JobWorkController : Controller
    {
        private readonly LoadDbContext _lcontext;
        private readonly JobWorkDbContext _jwcontext;
        private readonly OrganisationDbContext _ocontext;

        public JobWorkController(LoadDbContext context1, JobWorkDbContext context2, OrganisationDbContext context3)
        {
            _lcontext = context1;
            _jwcontext = context2;
            _ocontext = context3;
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

            List<string> loadGroups = _lcontext.Loads
                .Where(l => l.OrgId == org.OrgId)
                .Select(l => l.LoadGroup)
                .Distinct()
                .ToList();

            var viewModel = new JobWorkViewModel
            {
                JobWorkId = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                JobWorkOrgId = org.OrgId,
                OrgName = org.Name,
                Status = "Open",
                LoadGroupList = loadGroups
            };

            ViewBag.NewLoad = true;

            return View("NewJobWork", viewModel);
        }

        // POST: Load/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewJobWork(JobWorkViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var jobwork = new JobWork
                {
                    JobWorkId = viewModel.JobWorkId,
                    Name = viewModel.Name,
                    OrgId = viewModel.JobWorkOrgId,
                    LoadGroup = viewModel.LoadGroup,
                    Description = viewModel.Description,
                    Status = viewModel.Status,
                    CustomerName = viewModel.CustomerName,
                    CustomerEmail = viewModel.CustomerEmail,
                    CustomerAddress = viewModel.CustomerAddress,
                    CustomerGSTIN = viewModel.CustomerGSTIN,
                    CustomerPAN = viewModel.CustomerPAN,
                };

                viewModel.CreationDate = jobwork.CreationDate;

                _jwcontext.Add(jobwork);
                await _jwcontext.SaveChangesAsync();
            }

            return View("NewJobWork", viewModel);
        }

        //public async Task<IActionResult> ListLoads(string id)
        //{
        //    var org = await _ocontext.Organisations.FindAsync(id);

        //    if (org == null)
        //    {
        //        return NotFound();
        //    }

        //    List<Load> loads = _lcontext.Loads.Where(l => l.OrgId == id).ToList();

        //    var model = new LoadListViewModel
        //    {
        //        OrgName = org.Name,
        //        LoadList = loads
        //    };

        //    // bind products to view
        //    return View("ViewLoads", model);
        //}
    }
}

