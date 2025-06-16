namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel.ImportExcelFiless
{
    public class ExcelSpoolListViewModel
    {
     

        //public string No{ get; set; } = "";
        public int No{ get; set; } // "";

        //public string Block { get; set; } = "";
        public int Block { get; set; }
        public string CircutName { get; set; } = "";
        public string SpoolNo { get; set; } = "";
        //public string Diameter { get; set; } = "";// çap
        public int Diameter { get; set; } = "";// çap
        public string TotalKg { get; set; } ="0.00";


    }
}
