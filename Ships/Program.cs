using System.IO;
using System.Linq.Expressions;

namespace Ships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"../../../FrenchMF.txt";
            List<Vessel> vessels = ReadVessels(path);
            VesselReporter reporter = new VesselReporter(vessels);

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string[] menuOptions = { "French Vessel Information System", "Vessel Report", "Location Analysis Report", "Search for a vessel", "Exit" };
            Menu m = new Menu(menuOptions);

            int choice = 0;
            while (choice != menuOptions.Length)
            {
                switch (m.GetMenuChoice())
                {
                    case 1: Console.WriteLine(reporter.VesselReport()); break;
                    case 2: Console.WriteLine(reporter.LocationAnalysisReport()); break;
                    case 3: Console.WriteLine("Please enter the name of the vessel");

                        string input = Console.ReadLine();
                        int index = vessels.FindIndex(v => v.Name == input);
                        if (index != -1)
                        {
                            Console.WriteLine(vessels[index].Location);
                        }
                        else
                        {
                            Console.WriteLine($"Ship: {input}  not found");
                        }
                        break;

                    default: Console.WriteLine("Goodbye!");break;
                }
            }
        }


        static List<Vessel> ReadVessels(string path)
        {
            List<Vessel> vessels = new List<Vessel>();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string input;
                    string name;
                    int type;
                    int tonnage;
                    int crew;
                    int locationCode;

                    while ((input = sr.ReadLine()) != null)
                    {
                        string[] fields = input.Split(',');

                        // Note that the data is not sufficiently validated here. What additional checks would you add?

                        if (
                               (fields.Length == 5)
                            && (int.TryParse(fields[1], out type))
                            && (int.TryParse(fields[2], out tonnage))
                            && (int.TryParse(fields[3], out crew))
                            && (int.TryParse(fields[4], out locationCode)))

                        {
                            name = fields[0];
                            Vessel v = new Vessel(name, type, tonnage, crew, locationCode);
                            vessels.Add(v);
                        }
                        else
                        {
                            Console.WriteLine("Error in input");
                        }
                    }
                }
            }
           
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File: {path} not found: {ex.Message}");
            }
            return vessels;

        }
    }
            
}
    

