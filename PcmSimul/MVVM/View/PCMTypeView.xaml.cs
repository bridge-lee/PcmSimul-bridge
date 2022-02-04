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
    /// PCMView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PCMTypeView : UserControl
    {
        public PCMTypeView()
        {
            InitializeComponent();
        }

        //void rb_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    Console.Write((sender as RadioButton).Content.ToString() + " checked.");
        //}

        //void rb_Checked(object sender, RoutedEventArgs e)
        //{
        //    Console.Write((sender as RadioButton).Content.ToString() + " unchecked.");
        //}

        //private void showChoice_Click(object sender, RoutedEventArgs e)
        //{
        //    //Show selected choice in the ViewModel.
        //    DataViewModel selected = (sp.DataContext as PCMTypeViewModel).SelectedDataVM;
        //    if (selected != null)
        //        MessageBox.Show(selected.Data.ToString());
        //}

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var rb = sender as RadioButton;
            var dm = rb.Content as DataModel;

            var viewModel = DataContext as PCMTypeViewModel;

            viewModel.CmdGetMenuValue.Execute(dm);
        }
    }
}
