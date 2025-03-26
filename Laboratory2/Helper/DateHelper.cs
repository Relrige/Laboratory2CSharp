using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory2.Helper
{
    public static class DateHelper
    {
        public static int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            return age;
        }
        public static ZodiacSigns GetWesternZodiac(DateTime birthDate)
        {
            int day = birthDate.Day;
            int month = birthDate.Month;

            return month switch
            {
                1 => (day <= 19) ? ZodiacSigns.Capricorn : ZodiacSigns.Aquarius,
                2 => (day <= 18) ? ZodiacSigns.Aquarius : ZodiacSigns.Pisces,
                3 => (day <= 20) ? ZodiacSigns.Pisces : ZodiacSigns.Aries,
                4 => (day <= 19) ? ZodiacSigns.Aries : ZodiacSigns.Taurus,
                5 => (day <= 20) ? ZodiacSigns.Taurus : ZodiacSigns.Gemini,
                6 => (day <= 20) ? ZodiacSigns.Gemini : ZodiacSigns.Cancer,
                7 => (day <= 22) ? ZodiacSigns.Cancer : ZodiacSigns.Leo,
                8 => (day <= 22) ? ZodiacSigns.Leo : ZodiacSigns.Virgo,
                9 => (day <= 22) ? ZodiacSigns.Virgo : ZodiacSigns.Libra,
                10 => (day <= 22) ? ZodiacSigns.Libra : ZodiacSigns.Scorpio,
                11 => (day <= 21) ? ZodiacSigns.Scorpio : ZodiacSigns.Sagittarius,
                12 => (day <= 21) ? ZodiacSigns.Sagittarius : ZodiacSigns.Capricorn,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        public static ChineseZodiacSigns GetChineseZodiac(DateTime birthDate)
        {
            return (ChineseZodiacSigns)(birthDate.Year % 12);
        }

    }

}
