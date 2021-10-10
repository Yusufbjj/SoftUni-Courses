using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public static class DateModifier
    {
        public static int CalculateDateDifferenceInDays(string firstDate,string secondDate)
        {
            var dateOne = DateTime.Parse(firstDate);
            DateTime dateTwo = DateTime.Parse(secondDate);

            int days = Math.Abs((dateOne - dateTwo).Days);


            return days;
        }
    }
}
