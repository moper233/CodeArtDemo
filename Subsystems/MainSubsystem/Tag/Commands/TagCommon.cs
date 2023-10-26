using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeArt.DomainDriven;

namespace MainSubsystem
{
    public static class TagCommon
    {
        public static Tag FindBy(long id, QueryLevel level)
        {
            var repository = Repository.Create<ITagRepository>();
            return repository.Find(id, level);
        }

        public static Page<Tag> FindPage(string name, int pageIndex, int pageSize)
        {
            var repository = Repository.Create<ITagRepository>();
            return repository.FindPage(name, pageIndex, pageSize);
        }

        public static IEnumerable<Tag> Finds(IEnumerable<long> ids)
        {
            var repository = Repository.Create<ITagRepository>();
            return repository.Finds(ids);
        }


        public static IEnumerable<Tag> FindAll()
        {
            var repository = Repository.Create<ITagRepository>();
            return repository.FindAll();
        }

    }
}