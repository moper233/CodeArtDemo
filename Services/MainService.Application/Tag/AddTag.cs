using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeArt.DTO;
using CodeArt.ServiceModel;
using CodeArt.Concurrent;
using CodeArt.DomainDriven;

using MainSubsystem;

namespace MainService.Application
{
    /// <summary>
    /// 
    /// </summary>
    [SafeAccess]
    [Service("addTag")]
    public class AddTag : ServiceProvider
    {
        protected override DTObject InvokeDynamic(dynamic arg)
        {
            var cmd = new CreateTag(arg.Name)
            {
                MarkedCode = arg.MarkedCode,
                Color = arg.Color
            };
            var obj = cmd.Execute();
            return DTObject.Create("{id,name}", obj);
        }
    }
}