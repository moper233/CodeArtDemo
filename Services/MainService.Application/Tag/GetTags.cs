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
    [SafeAccess]
    [Service("GetTags")]
    public class GetTags : ServiceProvider
    {
        protected override DTObject InvokeDynamic(dynamic arg)
        {
            var tags = TagCommon.FindAll();
            return DTObjectPro.Create("{id,name,markedCode,color}", tags);
        }
    }
}