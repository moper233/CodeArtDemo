using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeArt.DomainDriven;
using CodeArt.DomainDriven.DataAccess;

namespace MainSubsystem
{
    public class SortTags : CommandPro
    {
        private IEnumerable<(long Id, int Index)> _paras;

        public SortTags(IEnumerable<(long Id, int Index)> paras)
        {
            _paras = paras;
        }

        protected override void ExecuteProcedure()
        {
            var repository = Repository.Create<ITagRepository>();

            foreach(var para in _paras)
            {
                this.NewScope(()=>
                {
                    var obj = repository.Find(para.Id, QueryLevel.Single);
                    obj.OrderIndex = para.Index;
                    repository.Update(obj);
                });
            }
        }
    }
}
