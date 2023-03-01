using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOgVVS
{
    public class VVS : Indentation
    {
        public bool IsHired { get; set; }
        public double HiringRate { get; set; } = 400;
        public double TimeUses { get; set; } = 2;
        public VVS() { }

        public VVS(bool _isHired, double _hiringRate, double timeUses)
        {
            this.IsHired = _isHired;
            this.HiringRate = _hiringRate;
            this.TimeUses = timeUses;
        }

        public double TotalCost(double hours)
        {
            double total = this.HiringRate * hours;
            return total;
        } 

        public double StartWork(Dictionary<int, Rum> brokenToilets)
        {
            this.IsHired = true;

            ColorMessage(ConsoleColor.Cyan, "VVS is fixing the broken toilets. Wait while it gets fixed...", true);
            foreach (var item in brokenToilets)
            {
                System.Threading.Thread.Sleep(2000);
                item.Value.IsToiletWorking = true;
                ColorMessage(ConsoleColor.Green, "Toilet at Room number '" + item.Key +"' is fixed.", true);
            }
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            ColorMessage(ConsoleColor.Green, "All the broken toilets are fixed. ", true);

            double totalHoursTaken = brokenToilets.Count * 2000;

            double totalCost = TotalCost(totalHoursTaken/ 1000);

            return totalCost;
        }



    }
}
