using SqlTable.Contexts;
using SqlTable.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTable.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> AsEnumerable(string query);
    }
    public class BaseRepository<TModel> : IBaseRepository<TModel>
        where TModel : class, new()
    {
        private DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<TModel> AsEnumerable(string query)
        {
            foreach (var reader in _dbContext.Execute(query))
            {
                yield return reader.ToModel<TModel>();
            }
        }

        public int Add(TModel model)
        {
            string tableName = model.GetTableName();
            //_dbContext.Insert()
            return 0;
        }
    }
}
