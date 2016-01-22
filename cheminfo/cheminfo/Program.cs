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
        SQLiteConnection MainDatabase;
        static void Main(string[] args)
        {
            Program p = new Program();
        }
        public Program()
        {
            Console.Title = "ChemInfo";
            Console.WriteLine("CTRL + C To Quit.");
            ConnectToDatabase();
            DBSchema();
            Console.ReadKey();
        }
        //Initiates the connect to the SQLite database file
        void ConnectToDatabase()
        {
            MainDatabase = new SQLiteConnection("Data Source=Elements.db;Version=3;");
            MainDatabase.Open();
        }
        public void DBSchema()
        {
            string sql = "select * from BaseInfo";
            SQLiteCommand command = new SQLiteCommand(sql, MainDatabase);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int AtomicNumber;
                string Name, Symbol, State;

                //Converts database objects to usable formats (strings, ints)
                AtomicNumber = Convert.ToInt32(reader["AtomicNumber"]);
                Name = Convert.ToString(reader["Name"]);
                Symbol = Convert.ToString(reader["Symbol"]);
                State = Convert.ToString(reader["State"]);
                //Console.WriteLine("Name: {0} Symbol: {1} State: {2} Atomic Number: {3}", Name, Symbol, State, AtomicNumber);

                List<string> ElementStrings = new List<string>();
                ElementStrings.Add(Name);
                ElementStrings.Add(Symbol);
                ElementStrings.Add(State);

                List<int> ElementInts = new List<int>();
                ElementInts.Add(AtomicNumber);

                Console.WriteLine(ElementStrings[0] + ElementStrings[1] + ElementStrings[2]);
                Console.WriteLine(ElementInts[0]);
            }
        }
    }
    class Chemical
    {

    }
}
