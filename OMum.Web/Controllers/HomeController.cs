﻿using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace OMum.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : OMumControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/newlayout/layout.cshtml"); //Layout of the angular application.
        }
	}
}