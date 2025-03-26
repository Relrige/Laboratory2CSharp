using System;
using System.Windows.Controls;
using Laboratory2.ViewModel;
using Laboratory2.Model;

namespace Laboratory2.View
{
    public partial class FormView : UserControl
    {
        private readonly FormViewModel _viewModel;

        public FormView(Action<Person> gotoOutputView)
        {
            InitializeComponent();
            DataContext = _viewModel = new FormViewModel(gotoOutputView);
        }
    }
}
