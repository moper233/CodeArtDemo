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
    [Service("deleteTags")]
    public class DeleteTags : ServiceProvider
    {
        protected override DTObject InvokeDynamic(dynamic arg)
        {
            var cmd = new MainSubsystem.DeleteTags(arg.Ids.OfType<long>());
            cmd.Execute();
            return DTObject.Empty;
        }
    }
}