using PcmSimul.MVVM.Model;
using PcmSimul.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PcmSimul.MVVM.View
{
    /// <summary>
    /// AttachView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AttachView : UserControl
    {
        //AttachViewModel viewModel = null;

        public AttachView()
        {
            InitializeComponent();

            //viewModel = new AttachViewModel();
            //DataContext = viewModel;
        }

        private void showChoice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var rb = sender as RadioButton;
            var dm = rb.Content as DataModel;

            var viewModel = DataContext as AttachViewModel;

            viewModel.CmdGetMenuValue.Execute(dm);
        }
    }
}
