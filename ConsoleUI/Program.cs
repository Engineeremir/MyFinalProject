using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal()); //Business katmanını newlemezsem olmaz,hangi veri tipinde çalışacağını sordu ve InMemoryi verdik 
            //Eğer bellekte değil de EntityFramework'te çalışmak istersem yapmam gereken InMemory'i newlemek yerine EntityFramework'ü yenilemek olacak
            foreach (var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
