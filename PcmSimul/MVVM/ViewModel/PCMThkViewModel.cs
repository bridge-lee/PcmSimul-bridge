using PcmSimul.Handler;
using PcmSimul.MVVM.Model;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcmSimul.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class PCMThkViewModel : BaseViewModel
    {
        private const string _type = "THK_PCM";

        public ObservableCollection<DataViewModel> Datas { get; set; }
        public string PCMThkValue { get; set; }
        public RelayCommand CmdGetMenuValue { get; set; }
        public RelayCommand CmdGetMenuValue2 { get; set; }

        public PCMThkViewModel()
        {
            CmdGetMenuValue = new RelayCommand(GetMenuValue);
            CmdGetMenuValue2 = new RelayCommand(GetMenuValue2);

            DataTable _datas = SqliteHandler.sqliteHandler.GetTypeDatas(SqliteHandler.sqliteHandler.CommTableName, _type);
            var datas = new ObservableCollection<DataViewModel>();

            foreach (DataRow row in _datas.Rows)
            {
                var a = row[0] as string;
                var b = row[1] as string;
                var c = row[2] as string;
                var d = row[3] as string;

                DataModel model = new DataModel(_type, b, c, d);
                datas.Add(new DataViewModel(model));
            }

            datas.First().IsChecked = true;
            PCMThkValue = datas.First().Data.LABEL;

            Datas = datas;
        }

        private void GetMenuValue2(object obj)
        {
            DataTable _datas = SqliteHandler.sqliteHandler.GetTypeDatas2(SqliteHandler.sqliteHandler.CommTableName, _type, obj.ToString());
            var datas = new ObservableCollection<DataViewModel>();

            foreach (DataRow row in _datas.Rows)
            {
                var a = row[0] as string;
                var b = row[1] as string;
                var c = row[2] as string;
                var d = row[3] as string;

                DataModel model = new DataModel(_type, b, c, d);
                datas.Add(new DataViewModel(model));
            }

            datas.First().IsChecked = true;
            PCMThkValue = datas.First().Data.LABEL;

            Datas = datas;
        }

        private void GetMenuValue(object obj)
        {
            var dm = obj as DataModel;
            PCMThkValue = dm.LABEL;
        }

        public DataViewModel SelectedDataVM
        {
            get
            {
                DataViewModel selectedData = this.Datas.FirstOrDefault((c) => c.IsChecked == true);
                return selectedData;
            }
        }
    }
}
