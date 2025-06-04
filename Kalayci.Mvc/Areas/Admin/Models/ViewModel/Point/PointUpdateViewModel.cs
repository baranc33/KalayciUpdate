using Kalayci.Entities.Concrete;

namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel.Point
{
    public class PointUpdateViewModel
    {

        public int PointId { get; set; }
        public byte TeamWorkPoint { get; set; }
        public byte JabTrackingPoint { get; set; }
        public byte ContinuityPoint { get; set; }

        public byte AveragePoint { get; set; }


        public DateTime GiveDateStart { get; set; }
        public DateTime GiveDateFinish { get; set; }


        // puanı veren kişi Oluşturan kişi
        public string UserNameGivePoint { get; set; }

        public string UserId { get; set; }


        //hangi personel
        public int PersonelId { get; set; }

        public ICollection<KalayciUser> Users = new List<KalayciUser>();


    }
}
