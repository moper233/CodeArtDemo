using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeArt.DomainDriven;

namespace MainSubsystem
{
    public class UpdateTag : Command<Tag>
    {
        public string Name
        {
            get;
            set;
        }

        public string Color
        {
            get;
            set;
        }

        public string MarkedCode
        {
            get;
            set;
        }

        private long _id;

        public UpdateTag(long id)
        {
            _id = id;
        }

        protected override Tag ExecuteProcedure()
        {
            var repository = Repository.Create<ITagRepository>();
            var taskTag = repository.Find(_id, QueryLevel.Single);

            if (this.Name != null) taskTag.Name = this.Name;
            if (this.Color != null) taskTag.Color = this.Color;
            if (this.MarkedCode != null) taskTag.MarkedCode = this.MarkedCode;

            repository.Update(taskTag);
            return taskTag;
        }
    }
}