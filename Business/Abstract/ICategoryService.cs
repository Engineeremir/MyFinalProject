using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //Category ile ilgili dış dünyaya dönmek istediğim operasyonlarımı yazıyorum
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int categoryId);  //Id ye göre çektiğim için tek bir kategori gelecek o yüzden liste dönmedi
    }
}
