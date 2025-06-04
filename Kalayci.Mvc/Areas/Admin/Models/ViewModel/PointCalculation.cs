namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel
{
    public class PointCalculation
    {
        public PointCalculation()
        {

        }
        public PointCalculation(int TotalTeamWorkPointAverage, int TotalJabTrackingPointAverage, int TotalContinuityPointAverage, int TotalPointCount)
        {
            _TotalTeamWorkPointAverage = TotalTeamWorkPointAverage;
            _TotalJabTrackingPointAverage = TotalJabTrackingPointAverage;
            _TotalContinuityPointAverage = TotalContinuityPointAverage;
            _TotalPointCount = TotalPointCount;
            _TotalPointAverage= (TotalTeamWorkPointAverage + TotalJabTrackingPointAverage + TotalContinuityPointAverage) / 3;
        }
        public int _TotalTeamWorkPointAverage { get; set; }
        public int _TotalJabTrackingPointAverage { get; set; }
        public int _TotalContinuityPointAverage { get; set; }
        public int _TotalPointAverage { get; set; }
        public int _TotalPointCount { get; set; }
        public string PersonelName { get; set; }
        public (string, bool) EntitlementTeamWork { get; set; }
        public (string, bool) EntitlementJabTracking { get; set; }
        public (string, bool) EntitlementContinuity { get; set; }
        public (string, bool) Entitlement { get; set; }



        public void GetEntitlementMesaj()
        {
            EntitlementTeamWork =(("Takım Çalışmasında "+ GetEntitlement(_TotalTeamWorkPointAverage).Item1), GetEntitlement(_TotalTeamWorkPointAverage).Item2);
            EntitlementJabTracking =(("  iş Takibinde "+ GetEntitlement(_TotalJabTrackingPointAverage).Item1), GetEntitlement(_TotalJabTrackingPointAverage).Item2);
            EntitlementContinuity =(("  Süreklilik Açısından  "+ GetEntitlement(_TotalContinuityPointAverage).Item1), GetEntitlement(_TotalContinuityPointAverage).Item2);
            Entitlement =(("  Genel Olarak  :  "+ GetEntitlement(_TotalPointAverage).Item1), GetEntitlement(_TotalPointAverage).Item2);

        }









        public (string, bool) GetEntitlement(int point)
        {
            switch (point)
            {
                case > 99:
                    return ("Sistemimi Hackledin ? %100 Hakediş Puanın var", true);
                case > 90:
                    return ("Süpersin %90 Hakediş Puanın var", true);
                case > 80:
                    return ("Gayet iyi  %80 Hakediş Puanın var", true);
                case > 70:
                    return ("Daha iyisini Yapabilirsin  %70 Hakediş Puanın var", true);
                case > 60:
                    return ("Kendini Zorlamalısın Sadece %60 Hakediş Puanın var", true);
                case > 50:
                    return ("Yöneticinle iyi geçinemiyorsun galiba  %50 Hakediş Puanın var", false);
                case > 40:
                    return ("Nerde Hata Yaptığını Düşünmelisin  %40 Hakediş Puanın var", false);
                case > 30:
                    return ("Durumun içler acısı  %30 Hakediş Puanın var", false);

                default:
                    return ("istifa Etmelisin Bu nedir puan yok", false);
            }
        }
    }
}
