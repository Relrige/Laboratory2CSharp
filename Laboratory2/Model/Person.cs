using System;
using System.Windows;
using Laboratory2.Helper;
using Laboratory2.Helper.Exceptions;
using Laboratory2.Helper.Validator;

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
            set => _dateOfBirth = value;
        }

        public bool IsAdult => _isAdult;

        public ZodiacSigns WesternSign => _westernSign;

        public ChineseZodiacSigns ChineseSign => _chineseSign;

        public bool IsBirthday => _isBirthday;

        #endregion

        #region Constructors

        public Person(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            try
            {
                ValidateInput(firstName, lastName, email, dateOfBirth);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            CalculateProperties();
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
        private void ValidateInput(string fName, string lName, string email, DateTime dateOfBirth)
        {
            if (String.IsNullOrWhiteSpace(email) || !EmailValidator.IsValidEmail(email))
                throw new InvalidEmailException();
            if (String.IsNullOrWhiteSpace(fName) ||
               String.IsNullOrWhiteSpace(lName) ||
               !NameValidator.IsValidName(fName) ||
               !NameValidator.IsValidName(lName))
                throw new InvalidPersonNameException();

            var age = CalculateAge(dateOfBirth);
            if (!AgeIsMoreThanZero(age))
                throw new FutureDateOfBirthException();
            if (!AgeIsLessThanPossible(age))
                throw new TooOldDateOfBirthException();
        }
        private int CalculateAge(DateTime dob)
        {
            int age = DateTime.Today.Year - dob.Year;
            if (DateTime.Today < DateOfBirth.AddYears(age))
            {
                age--;
            }
            if (dob.CompareTo(DateTime.Now) > 0)
                return -1;
            return age;
        }
        private bool AgeIsLessThanPossible(int age)
        {
            return (age < 135);
        }
        private bool AgeIsMoreThanZero(int age)
        {
            return (age >= 0);
        }
        private void CalculateProperties()
        {
            _isAdult = CalculateAge(DateOfBirth) >= 18;
            _westernSign = DateHelper.GetWesternZodiac(DateOfBirth);
            _chineseSign = DateHelper.GetChineseZodiac(DateOfBirth);
            _isBirthday = DateTime.Today.Month == DateOfBirth.Month && DateTime.Today.Day == DateOfBirth.Day;
            if (_isBirthday)
            {
                MessageBox.Show($"Happy Birthday, {FirstName}!", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public bool isPersonNull()
        {
            return String.IsNullOrWhiteSpace(FirstName) ||
                String.IsNullOrWhiteSpace(LastName) ||
                String.IsNullOrWhiteSpace(Email);
        }
        #endregion
    }
}