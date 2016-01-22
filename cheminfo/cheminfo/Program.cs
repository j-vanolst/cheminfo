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

        public static List<double> ElementNumbers = new List<double>();
        public static List<string> ElementStrings = new List<string>();
        public static List<string> ClassInstances = new List<string>();

        static void Main(string[] args)
        {
            Program p = new Program();
        }
        public Program()
        {
            Console.Title = "ChemInfo";
            Console.WriteLine("CTRL + C To Quit.");
            ConnectToDatabase();
            GetClassInstances();
            ReadDatabase();
            Console.ReadKey();
        }
        //Initiates the connect to the SQLite database file
        void ConnectToDatabase()
        {
            MainDatabase = new SQLiteConnection("Data Source=Elements.db;Version=3;");
            MainDatabase.Open();
        }
        void GetClassInstances()
        {
            string sql = "select Symbol from BaseInfo";
            SQLiteCommand command = new SQLiteCommand(sql, MainDatabase);
            SQLiteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                string Symbol = Convert.ToString(reader["Symbol"]);
                ClassInstances.Add(Symbol);
            }
        }
        void ReadDatabase()
        {
            string sql = "select * from BaseInfo";
            SQLiteCommand command = new SQLiteCommand(sql, MainDatabase);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                double AtomicNumber, AtomicMass, MeltingPoint, BoilingPoint, Ionization, Radius, Density, YearDiscovered;
                string Name, Symbol, Series, State;

                //Converts database objects to usable formats (strings, ints)
                AtomicNumber = Convert.ToDouble(reader["AtomicNumber"]);
                AtomicMass = Convert.ToDouble(reader["AtomicMass"]);
                MeltingPoint = Convert.ToDouble(reader["MeltingPoint"]);
                BoilingPoint = Convert.ToDouble(reader["BoilingPoint"]);
                Ionization = Convert.ToDouble(reader["Ionization"]);
                Radius = Convert.ToDouble(reader["Radius"]);
                Density = Convert.ToDouble(reader["Density"]);
                YearDiscovered = Convert.ToDouble(reader["YearDiscovered"]);
                Name = Convert.ToString(reader["Name"]);
                Symbol = Convert.ToString(reader["Symbol"]);
                Series = Convert.ToString(reader["Series"]);
                State = Convert.ToString(reader["State"]);
                //Console.WriteLine("Name: {0} Symbol: {1} State: {2} Atomic Number: {3}", Name, Symbol, State, AtomicNumber);

                //Appends the properties from the database to an array
                ElementStrings.Add(Name);
                ElementStrings.Add(Symbol);
                ElementStrings.Add(Series);
                ElementStrings.Add(State);

                ElementNumbers.Add(AtomicNumber);
                ElementNumbers.Add(AtomicMass);
                ElementNumbers.Add(MeltingPoint);
                ElementNumbers.Add(BoilingPoint);
                ElementNumbers.Add(Ionization);
                ElementNumbers.Add(Radius);
                ElementNumbers.Add(Density);
                ElementNumbers.Add(YearDiscovered);
            }
        }
        public List<string> GetStringList()
        {
            return ElementStrings;
        }
        public List<double> GetNumberList()
        {
            return ElementNumbers;
        }
        }
    class Element
    {
        double AtomicNumber, AtomicMass, MeltingPoint, BoilingPoint, Ionization, Radius, Density, YearDiscovered;
        string Name, Symbol, Series, State;
        public void SetAttributes()
        {
        }
    }
}
