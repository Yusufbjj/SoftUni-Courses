using System;
using System.Collections.Generic;
using System.Text;

namespace Trucks
{
    public class GlobalConstants
    {
        //truck
        public const string RegexTruckRegistrationNumber = @"^([A-Z]{2}\d{4}[A-Z]{2})$";
        public const int TruckRegistrationNumberLength = 8;

        public const int TruckVinNumberLength = 17;

        public const int TruckTankCapacityMinLength  = 950;
        public const int TruckTankCapacityMaxLength = 1420;

        public const int TruckCargoCapacityMinLength = 5000;
        public const int TruckCargoCapacityMaxLength = 29000;


        //client

        public const int ClientNameMinLength = 3;
        public const int ClientNameMaxLength = 40;

        public const int ClientNationalityMinLength = 2;
        public const int ClientNationalityMaxLength = 40;

        //despatcher

        public const int DespatcherNameMinLength = 2;
        public const int DespatcherNameMaxLength = 40;

    }
}
