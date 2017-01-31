using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MarketPlace.Repository
{
    public static class ConfigHelper
    {
        public static string FileSaveLocation = ConfigurationManager.AppSettings["FileSaveLocation"].ToString();
    }
}