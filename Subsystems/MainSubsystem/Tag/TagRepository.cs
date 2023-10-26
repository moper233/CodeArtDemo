using System;
using System.Collections.Generic;
using CodeArt.DomainDriven;

using CodeArt.Concurrent;
using CodeArt.DomainDriven.DataAccess;
using CodeArt.Util;

namespace MainSubsystem
{
    public interface ITagRepository : IRepository<Tag>
    {
        Page<Tag> FindPage(string name, int pageIndex, int pageSize);

        IEnumerable<Tag> Finds(IEnumerable<long> ids);

        IEnumerable<Tag> FindAll();
    }

    [SafeAccess]
    public class SqlTagRepository : SqlRepository<Tag>, ITagRepository
    {
        private SqlTagRepository() { }

        public static readonly SqlTagRepository Instance = new SqlTagRepository();

        public Page<Tag> FindPage(string name, int pageIndex, int pageSize)
        {
            return this.Query<Tag>("@name<name like %@name%>[order by orderIndex asc]", pageIndex, pageSize,
                (arg) =>
                {
                    arg.TryAdd("name", name);
                });
        }

        public IEnumerable<Tag> Finds(IEnumerable<long> ids)
        {
            return this.Query<Tag>("id in @ids[order by orderIndex]",
                (arg) =>
                {
                    arg.Add("ids", ids);
                }, QueryLevel.None);
        }

        public IEnumerable<Tag> FindAll()
        {
            return this.Query<Tag>("[order by orderIndex]",
                (arg) =>
                {
                }, QueryLevel.None);
        }
    }
}