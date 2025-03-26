using System;
using System.Windows;
using Laboratory2.Helper;

namespace Laboratory2.Model
{
    public class Person
    {
        #region Fields

        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _dateOfBirth;
        private bool _isAdult;
        private ZodiacSigns _westernSign;
        private ChineseZodiacSigns _chineseSign;
        private bool _isBirthday;

        #endregion

        #region Properties

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                CalculateProperties();
            }
        }

        public bool IsAdult => _isAdult;

        public ZodiacSigns WesternSign => _westernSign;

        public ChineseZodiacSigns ChineseSign => _chineseSign;

        public bool IsBirthday => _isBirthday;

        #endregion

        #region Constructors

        public Person(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public Person(string firstName, string lastName, string email)
            : this(firstName, lastName, email, DateTime.Today)
        {
        }

        public Person(string firstName, string lastName, DateTime dateOfBirth)
            : this(firstName, lastName, string.Empty, dateOfBirth)
        {
        }

        #endregion

        #region Calculate
        private void CalculateProperties()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateTime.Today < DateOfBirth.AddYears(age))
            {
                age--;
            }

            _isAdult = age >= 18;
            _westernSign = DateHelper.GetWesternZodiac(DateOfBirth);
            _chineseSign = DateHelper.GetChineseZodiac(DateOfBirth);
            _isBirthday = DateTime.Today.Month == DateOfBirth.Month && DateTime.Today.Day == DateOfBirth.Day;
            if (_isBirthday)
            {
                MessageBox.Show($"Happy Birthday, {FirstName}!", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion
    }
}