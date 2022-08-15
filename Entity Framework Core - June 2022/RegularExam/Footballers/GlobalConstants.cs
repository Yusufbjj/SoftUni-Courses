using System;
using System.Collections.Generic;
using System.Text;

namespace Footballers
{
    public class GlobalConstants
    {
        //footballer
        public const int FootballerNameMinLength = 2;
        public const int FootballerNameMaxLength = 40;

        //team
        public const int TeamNameMinLength = 3;
        public const int TeamNameMaxLength = 40;

        public const string TeamNameRegex = @"^([A-Za-z\t\f 0-9.-]+\s*)$";

        public const int TeamNationalityMinLength = 2;
        public const int TeamNationalityMaxLength = 40;

        //coach

        public const int CoachNameMinLength = 2;
        public const int CoachNameMaxLength = 40;

    }
}
