using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //Business katmanı iş katmanıdır ve Service olarak adlandırılırlar. İş kurallarımızı Business katmanında yazarız yazarız.
    //Business katmanı hem DataAccess hem de Entity katmanını çağırdığından her ikisinden de referans almak zorundadır.
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
    }
}
