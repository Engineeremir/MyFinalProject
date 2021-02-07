using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //EntityFramework buraya da dahil edilmelidir.

    //Bu RepositoryBase'i oluşturma sebebim, her yeni tablo eklendiğinde özel olarak operasyonları tekrar tekrar yazmak istemiyorum.Bu yüzden 
    //bütün tablolarımı kapsayacak bir evrensel Core sınıfını oluşturdum 
    public class EfEntityRepositoryBase<TEntity,TContext>: IEntityRepository<TEntity>  //Productlar TEntity,NorthwindContextler TContext olmak zorunda artık
        where TEntity: class,IEntity,new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //Burada using kullanmadan sadece Northwindi newlesek de olurdu ancak Context nesnesi pahalı bir nesne olduğunda using metodunu kullanıyoruz.
            //Using metodu çalışmayı bıraktığı anda GarbageCollecter ı çağırır ve nesneyi bellekten siler.Böylelikle projemizin perforasnını güçlendirmiş oluyoruz.

            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //Veri kaynağındaki entity referansını al
                addedEntity.State = EntityState.Added; //Bu bir eklenecek değerdir anlamına gelir ve son alarak
                context.SaveChanges(); //ekle anlamına gelir
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                //Filtre null mu diye bak eğer null ise context product a yerleşsin ve bana bütün değerleri liste olarak döndürsün.
                //null değilse context Product a yerleşşsin filtreyi uygulasın (burada sql deki select * from komutu gibi filtre yapabiliriz) ve bana liste olarak bunu döndürsün. 
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
