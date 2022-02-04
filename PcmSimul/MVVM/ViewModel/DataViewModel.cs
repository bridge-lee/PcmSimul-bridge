using PcmSimul.MVVM.Model;
using PropertyChanged;

namespace PcmSimul.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class DataViewModel : BaseViewModel
    {
        public DataModel Data { get; private set; }

        public bool IsChecked { get; set; }

        public DataViewModel(DataModel data)
        {
            this.Data = data;
        }
        public override string ToString()
        {
            return Data.VALUE;
        }
    }
}
