using Microsoft.AspNetCore.Mvc;
using CodeArt.DTO;
using CodeArt.Concurrent;
using CodeArt.Web;
using CodeArt.ServiceModel;
using CodeArt.Log;

namespace DemoWebApi
{
    [SafeAccess()]
    public class AddShop : Procedure
    {
        protected override DTObject InvokeDynamic(dynamic arg)
        {

            //var ex = new Exception("test");
            //Logger.Fatal(ex);


            var data = ServiceContext.InvokeDynamic("AddCommodity", (g) =>
            {
                g.Id = arg.Id;
                g.Name = arg.Name;
                g.MarkedCode = arg.MarkedCode;
                g.Color = arg.Color;
            });


            //var dto = DTObject.Create();
            //dto["name"] = "test";
            return DTObject.Empty;
        }
    }
}