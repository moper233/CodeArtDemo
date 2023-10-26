using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeArt.Concurrent;
using CodeArt.DomainDriven;
using CodeArt.DomainDriven.DataAccess;

namespace MainSubsystem
{
    [SafeAccess]
    public class TagSpecification : ObjectValidator<Tag>
    {
        public TagSpecification()
        {

        }

        protected override void Validate(Tag obj, ValidationResult result)
        {
            Validator.CheckPropertyRepeated(obj, Tag.NameProperty, result);
        }
    }
}
