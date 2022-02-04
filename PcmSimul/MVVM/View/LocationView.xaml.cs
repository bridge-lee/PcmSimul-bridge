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
    /// LocationView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LocationView : UserControl
    {
        public LocationView()
        {
            InitializeComponent();

            var foundTextBLock = FindChild<TextBlock>(gridMap, "서울");
            foundTextBLock.FontWeight = FontWeights.UltraBold;
            Brush brush = new SolidColorBrush(Colors.Black);
            foundTextBLock.Foreground = brush;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var rb = sender as RadioButton;
            var dm = rb.Content as DataModel;
            
            var viewModel = DataContext as LocationViewModel;

            viewModel.CmdGetMenuValue.Execute(dm);

            var list = FindChilds<TextBlock>(gridMap);

            Brush brush = null;

            foreach (var item in list)
            {
                item.FontWeight = FontWeights.Normal;
                var converter = new System.Windows.Media.BrushConverter();
                brush = (Brush)converter.ConvertFromString("#7F7F7F");
                item.Foreground = brush;
            }

            var foundTextBLock = FindChild<TextBlock>(this, dm.LABEL);
            foundTextBLock.FontWeight = FontWeights.UltraBold;
            brush = new SolidColorBrush(Colors.Black);
            foundTextBLock.Foreground = brush;
        }

        public T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }

        public List<T> FindChilds<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent == null) return null;

            List<T> foundChilds = new List<T>();

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                T childType = child as T;
                if (childType != null)
                {
                    var frameworkElement = child as FrameworkElement;
                    foundChilds.Add((T)child);
                }
            }

            return foundChilds;
        }
    }
}
