using CommunityToolkit.Mvvm.Input;
using Laboratory2.Helper;
using Laboratory2.Model;
using System;
using System.Windows;

namespace Laboratory2.ViewModel
{
    internal class OutputViewModel
    {
        private readonly Action _gotoFormView;
        private readonly Person _person;
        private RelayCommand _returnCommand;

        public OutputViewModel(Person person, Action gotoFormView)
        {
            _person = person ?? throw new ArgumentNullException(nameof(person));
            _gotoFormView = gotoFormView ?? throw new ArgumentNullException(nameof(gotoFormView));

        }

        public Person Person => _person;
        public string FirstName => _person.FirstName;
        public string LastName => _person.LastName;
        public string Email => _person.Email;
        public DateTime DateOfBirth => _person.DateOfBirth;
        public bool IsAdult => _person.IsAdult;
        public ZodiacSigns SunSign => _person.WesternSign;
        public ChineseZodiacSigns ChineseSign => _person.ChineseSign;
        public bool IsBirthday => _person.IsBirthday;

        public RelayCommand ReturnCommand => _returnCommand ??= new RelayCommand(_gotoFormView);
    }
}
