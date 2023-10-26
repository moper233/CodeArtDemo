using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeArt.AppSetting;
using CodeArt.DomainDriven;
using CodeArt.DomainDriven.DataAccess;
using CodeArt;
using CodeArt.ServiceModel;

[assembly: PreApplicationEnd(typeof(MainService.Application.PreApplicationEnd), "Initialize")]

namespace MainService.Application
{
    internal class PreApplicationEnd
    {
        public static void Initialize()
        {
            //MealScheduler.Dispose();
        }
    }
}
