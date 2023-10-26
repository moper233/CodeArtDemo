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
    [Service("getTag")]
    public class GetTag : ServiceProvider
    {
        protected override DTObject InvokeDynamic(dynamic arg)
        {
            var tag = TagCommon.FindBy(arg.GetValue<long>("Id"), QueryLevel.None);
            return DTObject.Create("{id,name,markedCode,color}", tag);
        }
    }
}