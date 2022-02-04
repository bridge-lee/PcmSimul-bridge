using PcmSimul.Handler;
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
    public class ResultViewModel : BaseViewModel
    {
        public string TMP_FRM { get; set; }
        public string TMP_TO { get; set; }
        public string RATE_SAVE { get; set; }
        public string HAS { get; set; }

        public RelayCommand CmdCalcResult { get; set; }

        public ResultViewModel()
        {
            CmdCalcResult = new RelayCommand(CalcResult);
        }

        private void CalcResult(object obj)
        {
            HAS = "";

            var TYP_PCM = BaseViewModel.PCMTypeVM.SelectedDataVM;
            var TYP_LOC = BaseViewModel.LocationVM.SelectedDataVM;
            var TYP_ATTACH = BaseViewModel.AttachVM.SelectedDataVM;
            var THK_PCM = BaseViewModel.PCMThkVM.SelectedDataVM;
            var TYP_DIR = BaseViewModel.DirectionVM.SelectedDataVM;
            var TYP_SEASON = BaseViewModel.SeasonVM.SelectedDataVM;


            DataTable dt = SqliteHandler.sqliteHandler.GetResult(
                SqliteHandler.sqliteHandler.ResultTableName,
                TYP_PCM.ToString(),
                TYP_LOC.ToString(),
                TYP_ATTACH.ToString(),
                THK_PCM.ToString(),
                TYP_DIR.ToString(),
                TYP_SEASON.ToString());

            if (dt.Rows.Count > 0)
            {
                TMP_FRM = String.Format("{0:0.0}", dt.Rows[0][6]);
                TMP_TO = String.Format("{0:0.0}", dt.Rows[0][7]);
                RATE_SAVE = String.Format("{0:P2}", dt.Rows[0][8]);
            }
            else
            {
                HAS = "결과 값이 없습니다.";
            }
        }
    }
}
