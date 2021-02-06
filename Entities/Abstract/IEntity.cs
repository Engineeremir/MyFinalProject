using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Abstract
{
    public interface IEntity 
     // Bu bir veritabanı nesnesidir anlamına gelir.
                             
     //Bu yüzden tablolar anlamına gelir dediğimiz classlarımızı burdan işaretleyelim

     //Abstract classımızdaki bu veritabanı nesnesi Concrete deki tüm nesneleri işaretler
     //Oluşturmuş olduğumuz Product,Category ve Customer nesnelerinin birEntity olduğunu göstermek için
     //IEntity adında bir interface oluşturduk
    {

    }
}
