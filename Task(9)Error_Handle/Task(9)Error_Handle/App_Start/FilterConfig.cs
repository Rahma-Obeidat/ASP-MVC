﻿using System.Web;
using System.Web.Mvc;

namespace Task_9_Error_Handle
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}