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
            int choice = 1;
            Console.Title = "ChemInfo";
            Console.WriteLine("CTRL + C To Quit.");
            ConnectToDatabase();
            Console.ReadKey();
        }
    }
}
