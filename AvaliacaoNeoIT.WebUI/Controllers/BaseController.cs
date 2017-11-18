using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaliacaoNeoIT.WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["cnxTeste"].ConnectionString;
            }
        }
    }
}