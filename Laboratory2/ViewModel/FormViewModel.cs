﻿using CommunityToolkit.Mvvm.Input;
using Laboratory2.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

public class FormViewModel : INotifyPropertyChanged
{

    #region Fields_Properties_Constructor
    private readonly Action<Person> _gotoResultView;

    public FormViewModel(Action<Person> gotoResultView)
    {
        _gotoResultView = gotoResultView ?? throw new ArgumentNullException(nameof(gotoResultView));
    }

    private string _firstName;
    private string _lastName;
    private string _email;
    private DateTime _dateOfBirth = DateTime.Today;

    private bool _isEnabled = true;
    private Visibility _loaderVisibility = Visibility.Hidden;

    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            ProceedCommand.NotifyCanExecuteChanged();
        }
    }
    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            ProceedCommand.NotifyCanExecuteChanged();
        }
    }
    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            ProceedCommand.NotifyCanExecuteChanged();
        }
    }
    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            _dateOfBirth = value;
            ProceedCommand.NotifyCanExecuteChanged();
        }
    }

    public bool IsEnabled
    {
        get => _isEnabled;
        set
        {
            _isEnabled = value;
            OnPropertyChanged();
        }
    }
    public Visibility LoaderVisibility
    {
        get => _loaderVisibility;
        set
        {
            _loaderVisibility = value;
            OnPropertyChanged();
        }
    }
    #endregion

    #region relayCommand
    private RelayCommand<object> _proceedCommand;
    public RelayCommand<object> ProceedCommand =>
           _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), IsFormFilled);
    #endregion 
    private async void Proceed()
    {
        IsEnabled = false;
        LoaderVisibility = Visibility.Visible;
        try
        {
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
                if (!ValidForm()) return;
                Person person = new Person(FirstName, LastName, Email, DateOfBirth);
                _gotoResultView?.Invoke(person);
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            IsEnabled = true;
            LoaderVisibility = Visibility.Hidden;
        }
    }

    #region Validation
    private bool IsFormFilled(object obj=null)
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
