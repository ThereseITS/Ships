using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    internal class VesselReporter
    {
        List<Vessel> _vessels;

        public VesselReporter(List<Vessel> vessels)
        {
            _vessels = vessels;
        }
/// <summary>
/// This report provides details of all vessels found.  We could alter or overload to provide parameters minimum and maximum  tonnage
/// <returns></returns>
        public string VesselReport()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{"Location",-15}  {"Name",-15}  {"Vessel Type",-25} {"Crew size",-10} {"Tonnage",-10} {"Monthly running cost",-10}");

            foreach (Vessel v in _vessels)
            {
                stringBuilder.AppendLine($"{v.Location,-15}  {v.Name,-15}  {v.VesselType,-25} {v.Crew,-10} {v.Tonnage,-10} {v.CalculateMonthlyRunningCost(),-10:C2}");
            }

            return stringBuilder.ToString();
        }
/// <summary>
/// Note that this method relies on the data being sorted by location. Can you think of any better ways to do this?
/// </summary>
/// <returns></returns>
        public string LocationAnalysisReport()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{"Location",-15} {"Number of Ships",-15}");

           
            int[] locationCounters = new int [Vessel.Locations.Length];
            int index = 0;

            foreach (Vessel v in _vessels)
            {
                if (v.Location == Vessel.Locations[index])
                {
                    locationCounters[index]++;
                }
                else if (index < locationCounters.Length - 1)
                {
                    index++;
                    locationCounters[index]++;
                }
            }
            int total = 0;

            for (int i = 0; i < locationCounters.Length; i++)
            {
                stringBuilder.AppendLine($"{Vessel.Locations[i],-15}  {locationCounters[i],-15}");
                total += locationCounters[i];
            }
            stringBuilder.AppendLine($"Total: {total}  checking all counted:  {_vessels.Count}");
            return stringBuilder.ToString();
        }

        
    }
}