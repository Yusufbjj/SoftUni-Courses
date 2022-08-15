using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatcherDto
    {
        [Required]
        [MinLength(GlobalConstants.DespatcherNameMinLength)]
        [MaxLength(GlobalConstants.DespatcherNameMaxLength)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Position")]
        [Required]
        public string Position { get; set; }

        [XmlArray("Trucks")]
        public ImportDespatcherTruckDto[] Trucks { get; set; }
    }
}
