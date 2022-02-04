
using PropertyChanged;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PcmSimul.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        protected void OnOnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public static LocationViewModel LocationVM { get; set; }
        public static PCMTypeViewModel PCMTypeVM { get; set; }
        public static AttachViewModel AttachVM { get; set; }
        public static PCMThkViewModel PCMThkVM { get; set; }
        public static DirectionViewModel DirectionVM { get; set; }
        public static SeasonViewModel SeasonVM { get; set; }
        public static ResultViewModel ResultVM { get; set; }

    }
}
