using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category: IEntity //IEntity artık Categorynin referansını tutar 


    //---------Ne olursa olsun her zaman İş yapan sınıflarımızın interfacelerini oluşturmalıyız.Bunları DataAccess'te oluşturacağız
    {
        //Category nesnemizin özelliklerini oluşturduk

        //Çıplak class kalmasın------Eğer bir class bir inheritance almıyorsa ilerde problem çıkartır.
        // burda işaretleme tekniği kullanacağız 

        //Concrete deki sınıflar bir veritabanının tablolarına karşılık gelir 
    
        //Category nesnemizi oluşturduk ve propertylerini verdik
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
