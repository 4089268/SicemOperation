using System;

namespace SicemOperation.Helpers {
    public class RangeDate {
        public static int[] GetRange(DateTime date){

            var response = new int[2];

            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);

            // Get the last day of the current month
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            var lastDayOfMonth = new DateTime(date.Year, date.Month, daysInMonth);

            response[0] = firstDayOfMonth.Day;
            response[1] = lastDayOfMonth.Day;

            return response;
        }
    }
}