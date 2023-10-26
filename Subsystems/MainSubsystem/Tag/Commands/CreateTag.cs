using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeArt.DomainDriven;
using CodeArt.DomainDriven.DataAccess;

namespace MainSubsystem
{
    /// <summary>
    /// 创建标签
    /// </summary>
    public class CreateTag : Command<Tag>
    {
        private string _name;

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

        public CreateTag(string name)
        {
            _name = name;
        }

        protected override Tag ExecuteProcedure()
        {
            var id = DataPortal.GetIdentity<Tag>();
            var taskTag = new Tag(id, _name)
            {
                Color = this.Color ?? string.Empty,
                MarkedCode = this.MarkedCode ?? string.Empty,
            };

            var repository = Repository.Create<ITagRepository>();
            repository.Add(taskTag);
            return taskTag;
        }
    }
}
