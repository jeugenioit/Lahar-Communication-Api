using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

using JE.Common.LogService.Services.Interfaces;
using JE.Common.LogService.Services;

using Lahar.Api.Integration.Services.Interfaces;
using Lahar.Api.Integration.Services;
using Lahar.Api.Integration.Data;
using Lahar.Api.Integration.Helpers;

namespace MyWebSiteMVC.Controllers
{
    public class LaharController : Controller
    {
        private readonly ILogServices log = new LogServices();
        private readonly ILaharServices laharServices = new LaharServices();


        // GET: Lahar
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Register()
        {
            //--> Add Lahar
            Thread threadLahar;
            threadLahar = new Thread(delegate ()
            {
                try
                {
                    Lead lead = new Lead();
                    lead.Name = "JAIME EUGENIO";
                    lead.Email = "jaime.eugenio@gmail.com";
                    lead.Stage = eStageLead.Lead;
                    lead.Tags = new string[] { "Trial", "Library.NET" };
                    //TODO: Fill the remaining properties
                    lead.FormNameOrigin = "Register Account";
                    lead.UrlOrigin = "www.mysite.com";

                    if (laharServices.SaveLead(lead))
                    {
                        //TODO: Success
                    }
                    
                }
                catch (Exception ex)
                {
                    log.LogError(ex);
                }

            });
            threadLahar.IsBackground = true;
            threadLahar.Start();

            return RedirectToAction("Index", "Home");
        }


        public ActionResult Update()
        {
            //--> Update Stage
            Thread threadLahar;
            threadLahar = new Thread(delegate ()
            {
                try
                {
                    Lead lead = new Lead();
                    lead.Name = "JAIME EUGENIO";
                    lead.Email = "jaime.eugenio@gmail.com";                    
                    lead.Tags = new string[] { "Opportunity" };
                    //TODO: Fill the remaining properties
                    lead.FormNameOrigin = "Update Account";
                    lead.UrlOrigin = "www.mysite.com/myaccount";
                    lead.Stage = eStageLead.Opportunity; //--> New stage set on the property


                    if (laharServices.UpdateStageLead(lead))
                    {
                        //TODO: Success
                    }

                }
                catch (Exception ex)
                {
                    log.LogError(ex);
                }

            });
            threadLahar.IsBackground = true;
            threadLahar.Start();

            return RedirectToAction("Index", "Home");
        }
    }
}