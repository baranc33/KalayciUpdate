using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Dto
{
    public class ProjectPercentageCalculate
    {
        public int WorkPlaceCount { get; set; } = 0;
        public decimal WorkPlacePercentage { get; set; } = 0;
        public int WeldingCount { get; set; } = 0;
        public decimal WeldingPercentage { get; set; } = 0;
        public int CircuitDeliveryCount { get; set; } = 0;
        public decimal CircuitDeliveryPercentage { get; set; } = 0;
        public int SendingCount { get; set; } = 0;
        public decimal SendingPercentage { get; set; } = 0;
        public int ShipyardAssemblyCount { get; set; } = 0;
        public decimal ShipyardAssemblyPercentage { get; set; } = 0;
        public int FinishCount { get; set; } = 0;
        public decimal FinishPercentage { get; set; } = 0;
    }
}
