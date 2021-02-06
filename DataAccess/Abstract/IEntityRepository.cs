using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //IEntity burada sınıflarımızdır.Product,Customer gibi daha sonra bunlara eklenebilecek employee gibi 
    public interface IEntityRepository<T>  //IEntity olmasını değil sadece iş sınıflarımızı istiyoruz bu yüzden newlenebilir kısıtını da koyalım ki interface olan IEntity olmasın.
    {
        //Operasyonları eklerken tek değişen kısım Tipler demiştik.Genericler sayesinde burda bir T tipi oluşturduğumda istediğim her tipte çalışmama olanak sağlayacak
        //Yukarıda GEneric Typemızın Değişibilir bi tip olduğunu söyledik anca herkes istediğini de vermemeli.Sadece kullanacağımız sınıf türlerini verebilmeliyiz.Bu yüzden içerisini bir Generic Constaint
        //yani Generic Kısıt vermeliyiz ki sadece Entity sınıflarımızdaki iş sınıflarımızın tipleri verilebilsin.


        //Where T:Class Bir referans tip olması gerekir demek yani int alalamaz artık 
    
        //IProductDal'da oluşturmuş olduğum ve bütün diğer sınıflarımız için de geçerli olacak operasyonları buraya taşıdım bir depo gibi.

        //Bütün Product tiplerimi aşağıdaki gibi T tipine ve product'ı da entity e çevirdik

        //Verilerimizi getirirken tamamını değil de bize filtre imkanı sunmasını sağlayacak yapıya da göz atalım buna Expression denir


        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter); //Tek bir veri getirmemizi sağlar filtre vermek zorunludur 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
