using CommunityToolkit.Mvvm.Input;
using Laboratory2.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

public class FormViewModel : INotifyPropertyChanged
{

    #region Fields_ Properties_Constructor
    private readonly Action<Person> _gotoResultView;

    public FormViewModel(Action<Person> gotoResultView)
    {
        _gotoResultView = gotoResultView ?? throw new ArgumentNullException(nameof(gotoResultView));
    }

    private string _firstName;
    private string _lastName;
    private string _email;
    private DateTime _dateOfBirth = DateTime.Today;

    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            OnPropertyChanged();
            ProceedCommand.NotifyCanExecuteChanged();
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            OnPropertyChanged();
            ProceedCommand.NotifyCanExecuteChanged();
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged();
            ProceedCommand.NotifyCanExecuteChanged();
        }
    }
    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            _dateOfBirth = value;
            OnPropertyChanged();
            ProceedCommand.NotifyCanExecuteChanged();
        }
    }
    #endregion

    #region relayCommand
    private RelayCommand _proceedCommand;
    public RelayCommand ProceedCommand =>
        _proceedCommand ??= new RelayCommand(async () => await ProceedAsync(), IsFormFilled);
    #endregion
    private async Task ProceedAsync()
    {
        Thread.Sleep(2000); // to Test UI blocking
        if (!ValidForm()) return;
        var _person = new Person(FirstName, LastName, Email, DateOfBirth);
        _gotoResultView?.Invoke(_person);
    }

    #region Validation
    private bool IsFormFilled()
    {
        return !(string.IsNullOrWhiteSpace(FirstName) ||
            string.IsNullOrWhiteSpace(LastName) ||
            string.IsNullOrWhiteSpace(Email) || DateOfBirth == DateTime.Today);
    }
    private bool ValidForm()
    {
        if (!IsFormFilled())
        {
            return false;
        }

        DateTime today = DateTime.Today;
        int age = DateTime.Today.Year - DateOfBirth.Year;

        if (DateTime.Today < DateOfBirth.AddYears(age))
        {
            age--;
        }
        if (DateOfBirth > today)
        {
            MessageBox.Show("BirthDate cant be in future!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        if (age > 135)
        {
            MessageBox.Show("User age cant be more than 135!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        return true;
    }
    #endregion

    #region PropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}
