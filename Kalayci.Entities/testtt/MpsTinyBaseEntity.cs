using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.testtt
{
    public interface IMpsEntity { }//işaretçi interfaEntitymizz


    public class MpsTinyBaseEntity // veri yükü hafifletmek için Kullandığımız Base sınıfı
    {
        public string Id { get; set; }
        public bool IsDelete { get; set; }//=> Nesnenin Silinip Silinmediğini Belirten Özellik

        public bool IsWork { get; set; }  //=> Nesnenin Kullanılır olup Olmadığını Belirten özellik.


    }

    // oluşturan Kullanıcının Önemli olmadığı veri yükü hafifletmek için Kullandığımız Base sınıfı
    // 
    // Backupla işi Olmiyan Tabloalar için YAda Backup Sürekli Alınan tablolar için.
    public class MpsMediumBaseEntity : MpsTinyBaseEntity 
    {
        DateTime ModifiedTime { get; set; }//=>  En Son Güncellenme Tarihi.
        string ModifiedUserName { get; set; }//=> En Son Güncelliyen Kişi.
    }
    // Oluşturan Kullanıcının Önemli Olduğu Tablolar için
    public class MpsLargeBaseEntity : MpsMediumBaseEntity
    {
        string LastBackUpId { get; set; } //=> Son Yapılan Değişikliğin Kaydını Tutan Id.
        DateTime CreateTime { get; set; } //==> Nesnenin ilk Oluşturulduğu Tarih.
        string CreateUser { get; set; } //= => Nesneyi Oluşturan Kullanıcının Kullanıcı Adı.
    }

    // backup Tablolları için Kullanacağımız Base entity
    public class MpsBackUpBaseEntity : MpsLargeBaseEntity
    {
        string UserId { get; set; } //=> Değişikliği Yapan Kullanıcı.
        string Message { get; set; } //=> Kim Nezaman Neyi Değiştirdi.


    }



















}
