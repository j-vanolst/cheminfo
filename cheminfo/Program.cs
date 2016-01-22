using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace cheminfo
{
    class Program
    {
        SQLiteConnection m_dbConnection;

        static void Main(string[] args)
        {
            Program p = new Program();
        }
        public Program()
        {
            ConnectToDatabase();
            DisplayAllRecords();
        }
        void ConnectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=ChemicalInformation.db;Version=3;");
            m_dbConnection.Open();
        }
        void DisplayAllRecords()
        {
            string sql = "select * from BaseInformation";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
        }


        }
}
