using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using InterviewTask.Models;
using InterviewTask.Services;

namespace InterviewTask.Controllers
{
    public class HomeController : Controller
    {
        /*
         * Prepare your opening times here using the provided HelperServiceRepository class.       
         */
        private readonly IHelperServiceRepository helperServiceRepository;
        public IEnumerable<InterviewTask.Models.HelperServiceModel> helperServiceModelEnum;
        

        public HomeController()
        {
            this.helperServiceRepository = new HelperServiceRepository();
        }

        public ViewResult Details(Guid id)
        {
            HelperServiceModel helperDetails = helperServiceRepository.Get(id);
            return View(helperDetails);
        }

        [HttpPost]
        public ActionResult Create(HelperServiceRepository model)
        {
            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}