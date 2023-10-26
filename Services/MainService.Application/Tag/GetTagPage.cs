using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeArt.DTO;
using CodeArt.ServiceModel;
using CodeArt.Concurrent;

using MainSubsystem;
using CodeArt.DomainDriven;

namespace MainService.Application
{
    [SafeAccess]
    [Service("getTagPage")]
    public class GetTagPage : ServiceProvider
    {
        protected override DTObject InvokeDynamic(dynamic arg)
        {
            var items = TagCommon.FindPage(arg.Name, arg.PageIndex, arg.PageSize);
            return DTObjectPro.Create("{id,name,markedCode,color}", items);

        }
    }
}