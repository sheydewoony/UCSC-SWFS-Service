using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Entity.Entities;

namespace UCSC.SWFS.SRV.Dto
{
    public class PlantDto : AuditFields
    {
            public int PlantId { get; set; }
            public string PlantName { get; set; }
            public string PlantType { get; set; }
            public string RowId { get; set; }
            public int ColumnId { get; set; }
            public DateTime PlantingDate { get; set; }
            public int WaterRequirement { get; set; }
            public int FertilizerRequirement { get; set; }
            public int RecTemperatureMin { get; set; }
            public int RecTemperatureMax { get; set; }
            public int RecLightIntensity { get; set; }
            public int RecSoilMoisture { get; set; }
            public string HealthStatus { get; set; }
        
    }
}
