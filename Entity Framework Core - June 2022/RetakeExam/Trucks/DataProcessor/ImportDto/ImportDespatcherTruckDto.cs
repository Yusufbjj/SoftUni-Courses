using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportDespatcherTruckDto
    {
        [XmlElement("RegistrationNumber")]
        [RegularExpression(GlobalConstants.RegexTruckRegistrationNumber)]
        public string RegistrationNumber { get; set; }

        [XmlElement("VinNumber")]
        [StringLength(GlobalConstants.TruckVinNumberLength)]
        [Required]
        public string VinNumber { get; set; }


        [XmlElement("TankCapacity")]
        [Range(GlobalConstants.TruckTankCapacityMinLength,GlobalConstants.TruckTankCapacityMaxLength)]
        public int TankCapacity { get; set; }


        [XmlElement("CargoCapacity")]
        [Range(GlobalConstants.TruckCargoCapacityMinLength, GlobalConstants.TruckCargoCapacityMaxLength)]
        public int CargoCapacity { get; set; }


        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }


        [XmlElement("MakeType")]
        public int MakeType { get; set; }

    }
}

/*< RegistrationNumber > CB0796TP </ RegistrationNumber >
    < VinNumber > YS2R4X211D5318181 </ VinNumber >
    < TankCapacity > 1000 </ TankCapacity >
    < CargoCapacity > 23999 </ CargoCapacity >
    < CategoryType > 0 </ CategoryType >
    < MakeType > 3 </ MakeType >*/
