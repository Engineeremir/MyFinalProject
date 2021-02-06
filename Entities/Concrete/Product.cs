using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product: IEntity //IEntity artık Product nesnesinin referansını tutar

    //---------Ne olursa olsun her zaman İş yapan sınıflarımızın interfacelerini oluşturmalıyız.Bunları DataAccess'te oluşturacağız
    {
        //Product Nesnemizin özelliklerini oluşturduk 
        //Çıplak class kalmasın------Eğer bir class bir inheritance almıyorsa ilerde problem çıkartır.
        // burda işaretleme tekniği kullanacağız 
    
        //Product nesnemizi oluşturduk ve propertylerini verdik
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }



    }
}
