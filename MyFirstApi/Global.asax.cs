﻿using System;
using System.Web.Http;
using MyFirstApi.Configuration;

namespace MyFirstApi
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}