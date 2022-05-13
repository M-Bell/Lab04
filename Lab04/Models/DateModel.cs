using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab02.Models
{
    [Serializable]
    public class DateModel
    {
        private DateTime _date;

        public DateModel(DateTime dateOfBirth)
        {
            _date = dateOfBirth;
        }

        public DateModel() : this(new DateTime(2000, 1, 1))
        {

        }


        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public string GetChineseZodiacSign()
        {
            return ((ChineseZodiacSigns)(_date.Year % 12)).ToString();
        }

        public string GetWesternZodiacSign()
        {
            int signCode = _date.Date.Month - 1;
            int signStart = 0;
            switch (signCode)
            {
                case 1:
                    signStart = 19;
                    break;
                case 0:
                case 2:
                case 3:
                    signStart = 21;
                    break;
                case 4:
                case 5:
                case 11:
                    signStart = 22;
                    break;
                case 6:
                case 10:
                    signStart = 23;
                    break;
                case 7:
                case 8:
                case 9:
                    signStart = 24;
                    break;
            }
            if (_date.Date.Day >= signStart)
            {
                signCode++;
            }
            if (signCode >= 12) signCode = 0;
            return ((WesternZodiacSigns)signCode).ToString();
        }

        private enum WesternZodiacSigns
        {
            Capricorn,
            Aquarius,
            Pisces,
            Aries,
            Taurus,
            Gemini,
            Cancer,
            Leo,
            Virgo,
            Libra,
            Scorpio,
            Sagittarius
        }

        private enum ChineseZodiacSigns
        {
            Monkey,
            Rooster,
            Dog,
            Pig,
            Rat,
            Ox,
            Tiger,
            Rabbit,
            Dragon,
            Snake,
            Horse,
            Sheep
        }
    }
}
