using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tabloları ile kendi proje sınıflarımızıı eşleştirmemizi sağlayacak bir yapıdır.
    public class NorthwindContext: DbContext //EntitiyFrameworkteki DbContext i almış bulunuyoruz.
    {
        //Northwind çalıştığı anda DbContexte bakar ve altaki kod bloğunu çalıştırır
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  //Projemizin hangi databaseye bağlı olduğunu onConfiguring ile göstermiş oluyoruz.
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb;Database = Northwind;Trusted_Connection=true");
            //Burada SQl servere bağlanmak istediğimizi söylüyoruz sadece nasıl bağlanacağımızı göstermemiz gerekiyor,
            //yani veritabanımızın adresini girmemiz gerekiyor
        }
        public DbSet<Product> Products { get; set; }//Bendeki Product nesnesini veritabanındaki Products nesnesine eşitle    
        //Veritabanındaki hangi nesne Classlarımdaki hangi nesneye denk geleceğini söylemek için DbSet komutunu çağırmalıyız.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
