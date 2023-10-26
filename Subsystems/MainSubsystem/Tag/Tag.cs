using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using CodeArt.DomainDriven;
using CodeArt.Util;

namespace MainSubsystem
{
    [ObjectRepository(typeof(ITagRepository))]
    [ObjectValidator(typeof(TagSpecification))]
    public class Tag : AggregateRoot<Tag, long>
    {
        /// <summary>
        /// 标签的名称
        /// </summary>
        [PropertyRepository()]
        [NotEmpty()]
        [StringLength(1, 20)]
        public static readonly DomainProperty NameProperty = DomainProperty.Register<string, Tag>("Name");

        public string Name
        {
            get
            {
                return GetValue<string>(NameProperty);
            }
            set
            {
                SetValue(NameProperty, value);
            }
        }

        [PropertyRepository()]
        [StringLength(0, 50)]
        [ASCIIString()]
        public static readonly DomainProperty MarkedCodeProperty = DomainProperty.Register<string, Tag>("MarkedCode");
        public string MarkedCode
        {
            get
            {
                return GetValue<string>(MarkedCodeProperty);
            }
            set
            {
                SetValue(MarkedCodeProperty, value);
            }
        }
        
        [PropertyRepository()]
        public static readonly DomainProperty OrderIndexProperty = DomainProperty.Register<int, Tag>("OrderIndex");

        /// <summary>
        /// 排序序号
        /// </summary>
        public int OrderIndex
        {
            get
            {
                return GetValue<int>(OrderIndexProperty);
            }
            set
            {
                SetValue(OrderIndexProperty, value);
            }
        }

        [PropertyRepository()]
        [StringLength(0, 20)]
        [ASCIIString()]
        public static readonly DomainProperty ColorProperty = DomainProperty.Register<string, Tag>("Color");

        public string Color
        {
            get
            {
                return GetValue<string>(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }


        public Tag(long id, string name)
            : base(id)
        {
            this.Name = name;
            this.OnConstructed();
        }

        [ConstructorRepository()]
        public Tag(long id)
            : base(id)
        {
            this.OnConstructed();
        }

        private class TagEmpty : Tag
        {
            public TagEmpty()
                : base(0, string.Empty)
            {
                this.OnConstructed();
            }

            public override bool IsEmpty()
            {
                return true;
            }

        }

        public static readonly Tag Empty = new TagEmpty();
    }
}
