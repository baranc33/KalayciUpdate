namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel
{
    public class CaughtViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public string CreatedByName { get; set; } 
        public string ModifiedByName { get; set; } 
        public string CaughtUserName { get; set; } 
        public string CaughtUserId { get; set; }
        public string CaughtPersonelName { get; set; } 
        public string WhicProggress { get; set; } 
        public int PersonelId { get; set; }

    }
}
