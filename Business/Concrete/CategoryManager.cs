using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //Burada DataAccess e erişmem gerekiyor Business teyim çünkü ve bağımlılığımı constructor injection ile yapıyorum
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal) //Ben CategoryManager olarak veri erişimine bağımlıyım interface üzerinden
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            //Burada benim iş kodlarım var 
            return _categoryDal.GetAll();
        }

        //Select * from Categories where CategoryId = 2 veya 3 veya herhangi bir id verebilirim
        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }

        
    }
}
