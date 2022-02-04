using PcmSimul.Handler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcmSimul.MVVM.ViewModel
{
    public class DataViewModel2 : BaseViewModel
    {
        public const string _dbFile = "data_r1.db";

        public DataView CommDataView { get; set; }

        public DataView ResultDataView { get; set; }

        public string Test { get; set; }

        public DataViewModel2()
        {
            //ctor();
            Task.Run(async () =>
            {
                int i = 0;

                while (true)
                {
                    await Task.Delay(200);
                    Test = (i++).ToString();
                }
            }
            );
        }

        private void ctor()
        {
            string path = System.Environment.CurrentDirectory;
            string dbPath = Path.Combine(path, _dbFile);

            //SqliteHandler.sqliteHandler = new SqliteHandler(dbPath);
            //
            //if (SqliteHandler.sqliteHandler != null)
            //{
                //DataTable dt = SqliteHandler.sqliteHandler.GetAllData("TBL_COMM");
                //CommDataView = dt.DefaultView;

                //dt = SqliteHandler.sqliteHandler.GetAllData("TBL_RESULT");
                //ResultDataView = dt.DefaultView;
            //}
        }
    }
}
