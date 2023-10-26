using Microsoft.AspNetCore.Mvc;
using CodeArt.DTO;
using CodeArt.Concurrent;
using CodeArt.Web;
using CodeArt.ServiceModel;
using CodeArt.Log;

namespace DemoWebApi
{
    [SafeAccess()]
    public class AddTag : Procedure
    {
        protected override DTObject InvokeDynamic(dynamic arg)
        {

            var data = ServiceContext.InvokeDynamic("AddTag", (g) =>
            {
                g.Id = arg.Id;
                g.Name = arg.Name;
            });



            return data;
        }
    }
}