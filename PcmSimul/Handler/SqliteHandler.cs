using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PcmSimul.Handler
{
    public class SqliteHandler
    {
        public static SqliteHandler sqliteHandler;

        private SQLiteConnection _con { get; set; }
        private SQLiteCommand _cmd { get; set; }
        private SQLiteDataAdapter _adapter { get; set; }

        public string DbFile { get { return "data_r1.db"; } }
        public string CommTableName { get { return "TBL_COMM"; } }
        public string ResultTableName { get { return "TBL_RESULT"; } }



        private string _path = System.Environment.CurrentDirectory;

        private void Connection()
        {
            string dbPath = Path.Combine(_path, DbFile);

            _con = new SQLiteConnection(string.Format("Data Source={0};Version=3;", dbPath));
        }


        public DataTable GetAllData(string tablename)
        {
            Connection();

            DataTable DT = new DataTable();

            try
            {
                _con.Open();
                _cmd = _con.CreateCommand();
                _cmd.CommandText = string.Format("SELECT * FROM {0}", tablename);
                _adapter = new SQLiteDataAdapter(_cmd);
                _adapter.AcceptChangesDuringFill = false;
                _adapter.Fill(DT);
                _con.Close();
                DT.TableName = tablename;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return DT;
        }

        public DataTable GetTypeDatas(string tablename, string typename)
        {
            Connection();

            DataTable DT = new DataTable();

            try
            {
                _con.Open();
                _cmd = _con.CreateCommand();
                _cmd.CommandText = string.Format("SELECT * FROM {0} WHERE TYPE = '{1}'", tablename, typename);
                _adapter = new SQLiteDataAdapter(_cmd);
                _adapter.AcceptChangesDuringFill = false;
                _adapter.Fill(DT);
                _con.Close();
                DT.TableName = tablename;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return DT;
        }

        public DataTable GetTypeDatas2(string tablename, string typename, string str)
        {
            Connection();

            DataTable DT = new DataTable();

            try
            {
                _con.Open();
                _cmd = _con.CreateCommand();
                _cmd.CommandText = string.Format("SELECT * FROM {0} WHERE TYPE = '{1}' AND OPTION = '{2}'", tablename, typename, str);
                _adapter = new SQLiteDataAdapter(_cmd);
                _adapter.AcceptChangesDuringFill = false;
                _adapter.Fill(DT);
                _con.Close();
                DT.TableName = tablename;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return DT;
        }

        public DataTable GetResult(string tablename, string TYP_PCM, string TYP_LOC, string TYP_ATTACH, string THK_PCM, string TYP_DIR, string TYP_SEASON)
        {
            Connection();

            DataTable DT = new DataTable();

            try
            {
                _con.Open();
                _cmd = _con.CreateCommand();
                _cmd.CommandText = string.Format(
                    "SELECT * from {0} WHERE TYP_PCM = '{1}' AND TYP_LOC = '{2}' AND TYP_ATTACH = '{3}' AND THK_PCM = '{4}' AND TYP_DIR = '{5}' AND TYP_SEASON = '{6}'",
                    tablename, TYP_PCM, TYP_LOC, TYP_ATTACH, THK_PCM, TYP_DIR, TYP_SEASON);
                _adapter = new SQLiteDataAdapter(_cmd);
                _adapter.AcceptChangesDuringFill = false;
                _adapter.Fill(DT);
                _con.Close();
                DT.TableName = tablename;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return DT;
        }


        // SELECT * from TBL_RESULT WHERE TYP_PCM = 'P1' AND TYP_LOC = 'A' AND TYP_ATTACH = 'IN' AND THK_PCM = '12.5' AND TYP_DIR = 'ALL' AND TYP_SEASON = 'S1';
    }
}
