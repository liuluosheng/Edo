using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using Serenity;
using Serenity.Abstractions;
using Serenity.Caching;
using System.Web.Optimization;
using Edo.Data.Entity;
using Edo.IRepository;
using Edo.ViewModels;

namespace Edo.Web
{
    public static class CommonInitialization
    {
        public static void Run()
        {
            InitLocalTextData();
        }
        private static void InitLocalTextData()
        {
            //如果有汉字，需要设置编码格式
            //System.IO.File.WriteAllText(HostingEnvironment.MapPath("~/Scripts/Common/Q.LT.js"), content, Encoding.UTF8);
        }


    }
}