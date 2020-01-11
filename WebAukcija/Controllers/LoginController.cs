﻿using NeoDataLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAukcija.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(NeoDataLayer.DomainModel.User u)
        {
            bool temp = NeoDataLayer.DataProvider.ValidateUser(u.email, u.password);

            if(temp)
            {
                User user = NeoDataLayer.DataProvider.GetUser(u.email, u.password);
                NeoDataLayer.Store.GetInstance().SetUser(user);
                return Redirect("~/Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            bool temp = NeoDataLayer.Store.GetInstance().SetUser(null);
            return Redirect("~/Home");
        }
    }
}