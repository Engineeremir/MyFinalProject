using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //----ÖNEMLİ----> Business katmanının EntityFramework ile veya bellek ile veya herhangi biri ile işi yoktur
    //Business'ın tek bildiği IProductDal'dır


    //İş kodlarımızı buraya yazacağız.Manager iş katmanının somut kısmıdır.
    //IPrpductService ' yi işaretlemeyi unutmayalım

    public class ProductManager : IProductService //Artık IProductService 'nin iş kodlarını yazabilirim 
    {

        //İş kodları çalıştıktan sonra DataAccess' i çağırırız.Peki Şunu yaparsak ne olur
        //InMemoryProductDal inMemoryProductDal = new InMemoryProductDal(); 
        //Eğer yukarıda yazmış olduğum şekilde DataAccesi çağırırsak sadece bellekte ürettiğimiz veritabanını çağırmış oluruz.
        //Ancak biz farklı veritabanlarında da çalışacağımız için her metotta ayrı ayrı DataAccessimizi böyle çağıramayız.
        //Bir iş sınıfı başka sınıfları newlemez


        IProductDal _productDal; //ProductManager çağırıldığı anda Constructor IPorductDal referansı istiyor neden ? Metodun yanında açıklandı

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {


            ValidationTool.Validate(new ProductValidator(), product);

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları var mı
            //İzin veriliyor mu yetkisi var mı 
            //Yukarıda bütün şartlar sağlandığında veritabanından GetAll metodu çalışacak
            if (DateTime.Now.Hour==16)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new  SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed); //IProductDal ın referansıyla artık GetAll metodu çalıştı
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
