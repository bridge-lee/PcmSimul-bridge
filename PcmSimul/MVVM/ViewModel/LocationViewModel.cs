using PcmSimul.Handler;
using PcmSimul.MVVM.Model;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PcmSimul.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class LocationViewModel : BaseViewModel
    {
        private const string _type = "TYP_LOC";
        public List<DataViewModel> Datas1 { get; private set; }
        public List<DataViewModel> Datas2 { get; private set; }
        public FontWeight SelectedFontWeight { get { return FontWeights.Bold; }}
        public FontWeight FontWeight { get { return FontWeights.Normal; } }
        public string LocationValue { get; set; }
        public RelayCommand CmdGetMenuValue { get; set; }

        public LocationViewModel()
        {
            CmdGetMenuValue = new RelayCommand(GetMenuValue);

            DataTable _datas = SqliteHandler.sqliteHandler.GetTypeDatas(SqliteHandler.sqliteHandler.CommTableName, _type);
            this.Datas1 = new List<DataViewModel>();
            this.Datas2 = new List<DataViewModel>();

            int count = 0;
            foreach (DataRow row in _datas.Rows)
            {
                var a = row[0] as string;
                var b = row[1] as string;
                var c = row[2] as string;
                var d = row[3] as string;

                DataModel model = new DataModel(_type, b, c, d);

                if (count < _datas.Rows.Count / 2)
                    Datas1.Add(new DataViewModel(model));
                else
                    Datas2.Add(new DataViewModel(model));

                count++;
            }

            this.Datas1.First().IsChecked = true;
            LocationValue = this.Datas1.First().Data.LABEL;
        }

        private void GetMenuValue(object obj)
        {
            var dm = obj as DataModel;
            LocationValue = dm.LABEL;
        }

        public DataViewModel SelectedDataVM
        {
            get
            {
                List<DataViewModel> datas = new List<DataViewModel>();
                datas.AddRange(Datas1);
                datas.AddRange(Datas2);
                DataViewModel selectedData = datas.FirstOrDefault((c) => c.IsChecked == true);
                return selectedData;
            }
        }
    }
}
