using Lab02.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab02.Models
{
    [Serializable]
    public class Person
    {
        #region fields
        private string _name;
        private string _surname;
        private string _email;
        private DateModel _birthday = new DateModel();
        private static Regex emailRegex = new Regex(@"^[\w]+@[\w]+\.[\w]+$");
        private static DateTime lowerLimit =
            new DateTime(DateTime.Now.Year - 135, DateTime.Now.Month, DateTime.Now.Day);

        #endregion

        #region properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (emailRegex.IsMatch(value))
                {
                    _email = value;
                }
                else
                {
                    throw new InvalidEmailException($"ERROR\nInvalid email...");
                }
            }
        }

        public DateTime Birthday
        {
            get { return _birthday.Date; }
            set
            {
                if (value.Date.CompareTo(lowerLimit) < 0)
                {
                    throw new InvalidEmailException($"ERROR\nAren't you too old for this?");
                }
                else if (DateTime.Now.CompareTo(value.Date) < 0)
                {
                    throw new InvalidEmailException($"ERROR\nYou couldn't even be born");
                }
                else
                {
                    _birthday.Date = value;
                }
            }
        }

        private int Age
        {
            get
            {
                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(Birthday.Date.ToString("yyyyMMdd"));
                int age = (now - dob) / 10000;
                return age;
            }
        }
        public string SunSign
        {
            get
            {
                return _birthday.GetWesternZodiacSign();
            }
        }

        public string ChineseSign
        {
            get
            {
                return _birthday.GetChineseZodiacSign();
            }
        }

        public bool IsAdult
        {
            get { return Age >= 18; }
        }

        public bool IsBirthday
        {
            get
            {
                return Birthday.Date.Day == DateTime.Now.Day
                  && Birthday.Date.Month == DateTime.Now.Month;
            }
        }
        #endregion

        #region constructors
        public Person(string name, string surname, string email, DateModel birthday)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Birthday = birthday.Date;
        }

        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
            _birthday = new DateModel();
        }

        public Person(string name, string surname, DateModel birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday.Date;
        }

        public Person()
        {
            Name = "";
            Surname = "";
            Email = "example@mail.com";
            _birthday = new DateModel();
        }

        #endregion

    }
}
