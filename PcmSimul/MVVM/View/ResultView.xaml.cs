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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PcmSimul.MVVM.View
{
    /// <summary>
    /// ResultView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ResultView : UserControl
    {
        protected Point TouchStart;

        ResultViewModel viewModel = null;

        public ResultView()
        {
            InitializeComponent();
            viewModel = new ResultViewModel();
            DataContext = viewModel;
        }

        private void resultCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (resultCard.HorizontalAlignment == HorizontalAlignment.Right)
            {
                viewModel.CmdCalcResult.Execute(null);
                if (viewModel.HAS == "결과 값이 없습니다.")
                {
                    MessageBox.Show(viewModel.HAS, "PCM Simul", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                resultCard.HorizontalAlignment = HorizontalAlignment.Left;

                resultPanel.Visibility = Visibility.Visible;

                resultCard.Width = 40;

                gridPath1.StartPoint = new Point(25, 0);
                gridPath2.Point = new Point(40, 0);
                gridPath3.Point = new Point(40, 25);
                gridPath4.StartPoint = new Point(25, 50);
                gridPath5.Point = new Point(40, 50);
                gridPath6.Point = new Point(40, 25);


                //MessageBox.Show("kkkk");
            }
            else
            {
                resultCard.HorizontalAlignment = HorizontalAlignment.Right;

                resultPanel.Visibility = Visibility.Hidden;

                gridPath1.StartPoint = new Point(0, 0);
                gridPath2.Point = new Point(0, 25);
                gridPath3.Point = new Point(15, 0);
                gridPath4.StartPoint = new Point(0, 25);
                gridPath5.Point = new Point(0, 50);
                gridPath6.Point = new Point(15, 50);
            }
        }

        private void resultCard_MouseEnter(object sender, MouseEventArgs e)
        {
            if (resultCard.HorizontalAlignment == HorizontalAlignment.Right)
            {
                resultCard.Width = 60;
            }
        }

        private void resultCard_MouseLeave(object sender, MouseEventArgs e)
        {
            if (resultCard.HorizontalAlignment == HorizontalAlignment.Right)
            {
                resultCard.Width = 40;
            }
        }
    }
}
