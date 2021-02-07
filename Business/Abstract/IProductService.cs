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
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetByUnitPrice(decimal min, decimal max);
        List<ProductDetailDto> GetProductDetails();
    }
}
