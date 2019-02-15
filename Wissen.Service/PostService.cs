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
    public class PostService : IPostService
    {
        private readonly IRepository<Post> Repository;
        public PostService(IRepository<Post> repository)
        {
            this.Repository = repository;

        }

        public void Delete(int id)
        {
            var dltpost = Repository.Find(id);
            if (dltpost!=null)
            {
                Repository.Delete(dltpost);
                Repository.SaveChanges();
            }
        }

        public void Delete(Post post)
        {
            Repository.Delete(post);
            Repository.SaveChanges();
        }

        public Post Find(int id)
        {
            return Repository.Find(id);
        }

        public Post Find(Expression<Func<Post, bool>> where)
        {
            return Repository.Find(where);
        }

        

        public IEnumerable<Post> GetAll()
        {
            return Repository.GetAll(r => true);
        }

        public IEnumerable<Post> GetAll(Expression<Func<Post, bool>> where)
        {
            return Repository.GetAll(where);
        }

        public void Insert(Post post)
        {
            Repository.Insert(post);
            Repository.SaveChanges();
        }

        public void Update(Post post)
        {
            Repository.Update(post);
            Repository.SaveChanges();
        }
    }
}
