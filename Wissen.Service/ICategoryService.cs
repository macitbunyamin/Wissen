﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wissen.Model;

namespace Wissen.Service
{
    public interface ICategoryService
    {
        void Insert(Category categoryst);
        void Update(Category post);
        void Delete(int id);
        Category Find(int id);
        Category Find(Expression<Func<Category, bool>> where);
        Category FindByName(string name);
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetAll(Expression<Func<Category, bool>> where);
    }
}
