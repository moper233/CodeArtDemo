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
    [Service("updateTag")]
    public class UpdateTag : ServiceProvider
    {
        protected override DTObject InvokeDynamic(dynamic arg)
        {
            var cmd = new MainSubsystem.UpdateTag(arg.GetValue<long>("id"))
            {
                Name = arg.Name,
                MarkedCode = arg.MarkedCode,
                Color = arg.Color
            };
            cmd.Execute();
            return DTObject.Empty;
        }
    }
}