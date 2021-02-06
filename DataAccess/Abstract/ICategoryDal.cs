using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //DataAccessLayer'ın Abstract ve Concretelerinde referans aldığımız Entity katmanındaki sınıfların dalları yazılır
    public interface ICategoryDal:IEntityRepository<Category>
    {
        //IProductDal da oluşturmş olduğum operasyonlar ICategoryDal için de geçerli olacak ve tek değişen şey tipler olacak
    //Bu yüzden oluşan her yeni sınıf için bu operasyonları tek tek eklemek yerine bir GenericRepositoryDesignPattern interface'i oluşturmak mantıklı olacaktır
    

        //------ÖNEMLİ----- ******Aşağıda yazmış olduğumuz kodlar GenericRepositoryDesignPatterni'ni kullanmadan önce idi artık aşağıdaki kodları yazmamıza gerek yok******
        //******Aşağıda yazmış olduğumuz kodlar GenericRepositoryDesignPatterni'ni kullanmadan önce idi artık aşağıdaki kodları yazmamıza gerek yok******


        //List<Category> GetAll(); //Product listesinin tamamını getir



        //void Add(Category category); //Bir ekleme operasyonu oluşturduk ve parametre olarak Product tipinde bir değer almak zorundadır

        //void Update(Category category); //Bir güncelleme operasyonu oluşturduk ve parametre olarak Product tipinde bir değer almak zorundadır

        //void Delete(Category category); //Bir silme operasyonu oluşturduk ve parametre olarak Product tipinde bir değer almak zorundadır

        //List<Category> GetAllByCategoryId(int categoryId); //Product listesini, alınacak categoryId sine göre bize getirecek.
    
}
    }
