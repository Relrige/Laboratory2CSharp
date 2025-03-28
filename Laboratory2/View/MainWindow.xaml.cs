using System;
using System.Windows;
using Laboratory2.Model;

namespace Laboratory2.View
{
    public partial class MainWindow : Window
    {
        private Person _currentPerson;

        public MainWindow()
        {
            InitializeComponent();
            GoToFormView();
        }

        private void GoToFormView()
        {
            Dispatcher.Invoke(() =>
            {
                Content = new FormView(GoToOutputView);
            });
        }
        private void GoToOutputView(Person person)
        {
            _currentPerson = person;
            Dispatcher.Invoke(() =>
            {
                Content = new OutputView(_currentPerson, GoToFormView);
            });
        }

    }
}
