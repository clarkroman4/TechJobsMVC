using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        private readonly dynamic columnChoices;

        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results


        public IActionResult Results(string searchType, string searchTerm)
        {
        
            List <Dictionary<string, string>> Jobs = new List<Dictionary<string, string>>();
            ViewBag.columns = ListController.columnChoices;

         

            if (searchType == "all") {
                Jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = Jobs;
            } else
            {
                Jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = Jobs;
            }
            
            return View("Index");
        }

    }
}
