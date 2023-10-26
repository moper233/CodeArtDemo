using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeArt.DTO;
using CodeArt.ServiceModel;
using CodeArt.Concurrent;

using CodeArt.DomainDriven;

namespace MainService.Application
{
    [SafeAccess]
    [Service("deleteTag")]
    public class DeleteTag : ServiceProvider
    {
        protected override DTObject InvokeDynamic(dynamic arg)
        {
            var cmd = new MainSubsystem.DeleteTag(arg.Id);
            cmd.Execute();
            return DTObject.Empty;
        }
    }
}