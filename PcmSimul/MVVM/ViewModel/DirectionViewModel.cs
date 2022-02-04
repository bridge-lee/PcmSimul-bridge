using PcmSimul.Handler;
using PcmSimul.MVVM.Model;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcmSimul.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class DirectionViewModel : BaseViewModel
    {
        private const string _type = "TYP_DIR";

        public List<DataViewModel> Datas { get; private set; }
        public string DirectionValue { get; set; }
        public RelayCommand CmdGetMenuValue { get; set; }

        public DirectionViewModel()
        {
            CmdGetMenuValue = new RelayCommand(GetMenuValue);

            DataTable _datas = SqliteHandler.sqliteHandler.GetTypeDatas(SqliteHandler.sqliteHandler.CommTableName, _type);
            this.Datas = new List<DataViewModel>();

            foreach (DataRow row in _datas.Rows)
            {
                var a = row[0] as string;
                var b = row[1] as string;
                var c = row[2] as string;
                var d = row[3] as string;

                DataModel model = new DataModel(_type, b, c, d);
                Datas.Add(new DataViewModel(model));
            }

            this.Datas.First().IsChecked = true;
            DirectionValue = this.Datas.First().Data.LABEL;
        }

        private void GetMenuValue(object obj)
        {
            var dm = obj as DataModel;
            DirectionValue = dm.LABEL;
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
