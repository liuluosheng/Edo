using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using Newtonsoft.Json;
using Serenity;
using Serenity.Abstractions;
using Serenity.Localization;

namespace Edo.Web.Template
{
    public partial class RuntimeTextTemplate
    {
        private string Data { get; set; }

        public RuntimeTextTemplate()
        {          
            JsonLocalTextRegistration.AddFromFilesInFolder(HostingEnvironment.MapPath("~/Common/"));
            var registry = (LocalTextRegistry)Dependency.Resolve<ILocalTextRegistry>();
            string languageId = CultureInfo.CurrentUICulture.Name.TrimToNull() ?? "invariant";
            var data = registry.GetAllAvailableTextsInLanguage(languageId, false);
            Data = JSON.Stringify(data);         
        }
    }
}