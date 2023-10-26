using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CodeArt.AppSetting;
using CodeArt.DomainDriven;
using CodeArt.DomainDriven.DataAccess;
using CodeArt;
using CodeArt.ServiceModel;
using MainSubsystem;

[assembly: PreApplicationStart(typeof(MainService.Application.PreApplicationStart), "Initialize")]

namespace MainService.Application
{
    internal class PreApplicationStart
    {
        public static void Initialize()
        {

            Repository.Register<ITagRepository>(SqlTagRepository.Instance);

            //TypeDefine.Locate("User", typeof(StockSubsystem.User));
            //TypeDefine.Locate("VirtualFile", typeof(FoodSubsystem.VirtualFile));

            //orm配置
            SqlContext.RegisterAgent(SQLServerAgent.Instance);
            //基于配置文件的连接
            SqlContext.RegisterConnectionProvider(CodeArt.Data.SqlConnectionProvider.Instance);
            //#if DEBUG
            //            DataPortal.Dispose();
            //#endif
        }
    }
}
