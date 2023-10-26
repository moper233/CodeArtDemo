using System;
using System.Collections.Generic;
using System.Linq;

using CodeArt;
using CodeArt.DomainDriven;

namespace MainSubsystem
{
    public sealed class DeleteTags : Command
    {
        private IEnumerable<long> _ids;

        public DeleteTags(IEnumerable<long> ids)
        {
            _ids = ids;
        }

        protected override void ExecuteProcedure()
        {
            var repository = Repository.Create<ITagRepository>();
            foreach (var id in _ids)
            {
                var taskTag = repository.Find(id, QueryLevel.None);
                repository.Delete(taskTag);
            }
        }
    }


    public sealed class DeleteTag : Command
    {
        private long _id;

        public DeleteTag(long id)
        {
            _id = id;
        }

        protected override void ExecuteProcedure()
        {
            var repository = Repository.Create<ITagRepository>();
            var tag = repository.Find(_id, QueryLevel.Single);
            repository.Delete(tag);
        }
    }
}