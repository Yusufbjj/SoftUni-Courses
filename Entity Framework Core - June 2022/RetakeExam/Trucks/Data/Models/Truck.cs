using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Trucks.Data.Models;
using Trucks.Data.Models.Enums;

namespace Trucks.Data
{
    public class Truck
    {
        public Truck()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(GlobalConstants.TruckRegistrationNumberLength)]
        public string RegistrationNumber  { get; set; }

        [Required]
        [StringLength(GlobalConstants.TruckVinNumberLength)]
        public string VinNumber { get; set; }

        [MaxLength(GlobalConstants.TruckTankCapacityMaxLength)]
        public int TankCapacity  { get; set; }

        [MaxLength(GlobalConstants.TruckCargoCapacityMaxLength)]
        public int CargoCapacity  { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public MakeType MakeType { get; set; }

        [Required]
        [ForeignKey(nameof(Despatcher))]
        public int DespatcherId  { get; set; }

        public virtual Despatcher Despatcher  { get; set; }

        public virtual ICollection<ClientTruck> ClientsTrucks  { get; set; }

    }
}
