using PcmSimul.Handler;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcmSimul.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel : BaseViewModel
    {
        //"지역구분 LocationVM"
        //"PCM종류 PCMTypeVM"
        //"부착위치 AttachVM"
        //"PCM두께 PCMThkVM"
        //"방위 DirectionVM"
        //"계절 SeasonVM"


        public RelayCommand LocationViewCommand { get; set; }
        public RelayCommand PCMTypeViewCommand { get; set; }
        public RelayCommand AttachViewCommand { get; set; }
        public RelayCommand PCMThkViewCommand { get; set; }
        public RelayCommand DirectionViewCommand { get; set; }
        public RelayCommand SeasonViewCommand { get; set; }



        public string Description { get; set; }



        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnOnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            if (SqliteHandler.sqliteHandler == null)
                SqliteHandler.sqliteHandler = new SqliteHandler();

            LocationVM = new LocationViewModel();
            PCMTypeVM = new PCMTypeViewModel();
            AttachVM = new AttachViewModel();
            PCMThkVM = new PCMThkViewModel();
            DirectionVM = new DirectionViewModel();
            SeasonVM = new SeasonViewModel();
            ResultVM = new ResultViewModel();
            PCMThkVM.CmdGetMenuValue2.Execute(AttachVM.Attach);


            //"지역구분LocationVM"
            //"PCM종류PCMTypeVM"
            //"부착위치AttachVM"
            //"PCM두께"PCMThkVM
            //"방위DirectionVM"
            //"계절SeasonVM"

            CurrentView = LocationVM;
            Description = "냉방도일(CDD), 난방도일(HDD), 일사량을 ASHRAE(지역구분법) 기준으로 14개의 지역로 구분함.";

            LocationViewCommand = new RelayCommand(o =>
            {
                CurrentView = LocationVM;
                Description = "냉방도일(CDD), 난방도일(HDD), 일사량을 ASHRAE(지역구분법) 기준으로 14개의 지역로 구분함.";
            });

            PCMTypeViewCommand = new RelayCommand(o =>
            {
                CurrentView = PCMTypeVM;
                Description = "국내에 생산 및 판매되는 제품으로 선정함.";
            });

            AttachViewCommand = new RelayCommand(o =>
            {
                CurrentView = AttachVM;
                Description = "벽체에 부착되는 형태로 내·외부로 구분함.";
            });

            PCMThkViewCommand = new RelayCommand(o =>
            {
                CurrentView = PCMThkVM;
                Description = "실제 내·외장제품의 두께로 선정함.";
            });

            DirectionViewCommand = new RelayCommand(o =>
            {
                CurrentView = DirectionVM;
                Description = "전체 부위 및 방위별 부위으로 구분함.";
            });

            SeasonViewCommand = new RelayCommand(o =>
            {
                CurrentView = SeasonVM;
                Description = "1년기준 및 계절별 기준으로 구분함.";
            });
        }
    }
}
