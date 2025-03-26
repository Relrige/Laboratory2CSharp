using Laboratory2.Model;
using Laboratory2.ViewModel;
using System.Windows.Controls;

namespace Laboratory2.View
{
    /// <summary>
    /// Interaction logic for OutputView.xaml
    /// </summary>
    public partial class OutputView : UserControl
    {
        private readonly OutputViewModel _viewModel;
        public OutputView(Person person, Action gotoFormView)
        {
            InitializeComponent();
            DataContext = _viewModel = new OutputViewModel(person, gotoFormView);
        }
    }
}
