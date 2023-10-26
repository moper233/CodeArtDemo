using Microsoft.AspNetCore.Mvc;
using CodeArt.DTO;
using CodeArt.Concurrent;
using CodeArt.Web;
using CodeArt.ServiceModel;
using CodeArt.Log;

namespace DemoWebApi
{
    [SafeAccess()]
    public class DeleteTag : Procedure
    {
        protected override DTObject InvokeDynamic(dynamic arg)
        {
            var data = ServiceContext.InvokeDynamic("DeleteTag", (g) =>
            {
                g.Id = arg.Id;
            });

            return DTObject.Empty;
        }
    }
}