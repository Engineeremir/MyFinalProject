using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //Burada using kullanmadan sadece Northwindi newlesek de olurdu ancak Context nesnesi pahalı bir nesne olduğunda using metodunu kullanıyoruz.
            //Using metodu çalışmayı bıraktığı anda GarbageCollecter ı çağırır ve nesneyi bellekten siler.Böylelikle projemizin perforasnını güçlendirmiş oluyoruz.

            //IDisposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //Veri kaynağındaki entity referansını al
                addedEntity.State = EntityState.Added; //Bu bir eklenecek değerdir anlamına gelir ve son alarak
                context.SaveChanges(); //ekle anlamına gelir
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
                //Filtre null mu diye bak eğer null ise context product a yerleşsin ve bana bütün değerleri liste olarak döndürsün.
                //null değilse context Product a yerleşşsin filtreyi uygulasın (burada sql deki select * from komutu gibi filtre yapabiliriz) ve bana liste olarak bunu döndürsün. 
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
