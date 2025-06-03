namespace Kalayci.Mvc.Areas.Admin.Views.Personel
{
    public class PersonelPointViewModel
    {
        public Kalayci.Entities.Concrete.Personel Personel { get; set; } = new();
        public Kalayci.Entities.Concrete.Point point { get; set; } = new();



        public byte TeamWorkPoint { get; set; }
        public byte JabTrackingPoint { get; set; }
        public byte ContinuityPoint { get; set; }

        public byte AveragePoint { get; set; }


        public DateTime GiveDateStart { get; set; }
        public string UserNameGivePoint { get; set; }

        public string UserId { get; set; }
        public int PersonelId { get; set; }

        public  string ProjectName{ get; set; }

        public ICollection<Kalayci.Entities.Concrete.KalayciUser> Users { get; set; } = new List<Kalayci.Entities.Concrete.KalayciUser>();
        public Kalayci.Entities.Concrete.PersonelProject personelProject{ get; set; } = new Kalayci.Entities.Concrete.PersonelProject();
        public ICollection<Kalayci.Entities.Concrete.Point> Points{ get; set; } = new List<Kalayci.Entities.Concrete.Point>();

    }
}
