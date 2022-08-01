using System;

namespace Backend.Helpers
{
    public static class DateTimeHelper
    {
        public static int CalculateAgeFromDateOfBirth(this DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Subtract(dateOfBirth).Days;
            age = age / 365;
            return age;
        }
    }
}
