using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDesign
{


    public interface IMpsEntity { }//işaretçi interfaEntitymizz


    public class MpsTinyBaseEntity // veri yükü hafifletmek için Kullandığımız Base sınıfı
    {
        public string Id { get; set; }
        public bool IsDelete { get; set; }//=> Nesnenin Silinip Silinmediğini Belirten Özellik
        public bool IsWork { get; set; } //=> Nesnenin Kullanılır olup Olmadığını Belirten özellik.
    }


    // Oluşturan Kullanıcının Önemli Olduğu Tablolar için
    public class MpsStandartBaseEntity : MpsTinyBaseEntity
    {
        public DateTime ModifiedTime { get; set; }//=>  En Son Güncellenme Tarihi.
        public string ModifiedUserName { get; set; }//=> En Son Güncelliyen Kişi.
        public string LastBackUpId { get; set; } //=> Son Yapılan Değişikliğin Kaydını Tutan Id.
        public DateTime CreateTime { get; set; } //==> Nesnenin ilk Oluşturulduğu Tarih.
        public string CreateUser { get; set; } //= => Nesneyi Oluşturan Kullanıcının Kullanıcı Adı.
    }

    // backup Tablolları için Kullanacağımız Base entity
    public class MpsBackUpBaseEntity : MpsStandartBaseEntity
    {
        // Base entitydeki veriler dosyanın kendisine aittir.
        // değiştirilmiş dosyanın BaseEntity verileri
        // Adlandırılırken principal olarak 
        // Her BackUp Alınan dosyada Yapılan işlemin açıklamasını ekliyen bir mesaj olacaktır.
        public string ChangeMessage { get; set; }

        // backup nesneleri  kendi kurtarma verilerini tutacaktır.

        public string PrincipalId { get; set; }
        public bool PrincipalIsDelete { get; set; }
        public bool PrincipalIsWork { get; set; }
        public DateTime PrincipalModifiedTime { get; set; }
        public string PrincipalModifiedUserName { get; set; }
        public string PrincipalLastBackUpId { get; set; }
        public DateTime PrincipalCreateTime { get; set; }
        public string PrincipalCreateUser { get; set; }
        public string PrincipalUserId { get; set; }
        public string PrincipalMessage { get; set; }
    }




    public class OtomaticSystemKode : MpsStandartBaseEntity
    {
        public int ManuelId { get; set; } //=> Oluşturulan veri yada koda özel erişim için                    
        public string Title { get; set; }  //=> Çalıştırılacak Kodun Başlığı
        public string Description { get; set; } //=> Açıklaması
        public string HashValue { get; set; } //=> eğer bir şifre kaydedilecek şifreyi şifrelemek için
        public string Value1 { get; set; } //=> Girilmesi gereken değer olursa
        public string Value2 { get; set; }//=> Girilmesi gereken değer olursa
    }

    public class BackUpOtomaticSystemKode : MpsBackUpBaseEntity
    {
        public int Recovery_ManuelId { get; set; } //=>                   
        public string Recovery_Title { get; set; }  //=> 
        public string Recovery_Description { get; set; } //=> 
        public string Recovery_HashValue { get; set; } //=> 
        public string Recovery_Value1 { get; set; } //=> 
        public string Recovery_Value2 { get; set; }//=> 

    }




    public class FileTable : MpsStandartBaseEntity
    {
        public string Name { get; set; } //=>  Dosyaya Orjinal Adı
        public string Path { get; set; } //=> Kaydedildiği adress
        //=> Kaydı yapılan dosyanın çakışmaması için oluşturulmuş isim. 
        public string RandomName { get; set; } 
        public byte Type { get; set; } //=>  => Dosyanın ne dosyasını Olduğu belirtir
        public string Value { get; set; } //=> => Dosyanın neyde kullanıldığını belirtir
    }


}
