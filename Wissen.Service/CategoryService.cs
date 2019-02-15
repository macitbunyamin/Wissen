using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wissen.Data;
using Wissen.Model;

namespace Wissen.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> Repository;
        public CategoryService(IRepository<Category> repository)
        {
            this.Repository = repository;

        }
        public void Delete(int id)
        {
            var dltcategory = Repository.Find(id);
            if (dltcategory != null)
            {
                Repository.Delete(dltcategory);
            }
        }

        public Category Find(int id)
        {
            return Repository.Find(id);
        }

        public Category Find(Expression<Func<Category, bool>> where)
        {
            return Repository.Find(where);
        }

        public Category FindByName(string name)
        {
            return null;
        }

        public IEnumerable<Category> GetAll()
        {
            return Repository.GetAll(r => true);
        }

        public IEnumerable<Category> GetAll(Expression<Func<Category, bool>> where)
        {
            return Repository.GetAll(where);
        }

        public void Insert(Category category)
        {
            Repository.Insert(category);
        }

        public void Update(Category category)
        {
            Repository.Update(category); ;
        }
    }
}
