
using System;
namespace HotelOgVVS
{

    public class Hotel : Etager
    {
        public string HotelNavn { get; set; } = "";
        public string Location { get; set; }
        public List<Etager> ListOfEtager { get; set; } = new List<Etager>();
        public int ReviewStar { get; set; } = 0;
        public Hotel()
        {
            Console.WriteLine(@"
░█████╗░██████╗░███████╗░█████╗░████████╗███████╗  ██╗░░██╗░█████╗░████████╗███████╗██╗░░░░░
██╔══██╗██╔══██╗██╔════╝██╔══██╗╚══██╔══╝██╔════╝  ██║░░██║██╔══██╗╚══██╔══╝██╔════╝██║░░░░░
██║░░╚═╝██████╔╝█████╗░░███████║░░░██║░░░█████╗░░  ███████║██║░░██║░░░██║░░░█████╗░░██║░░░░░
██║░░██╗██╔══██╗██╔══╝░░██╔══██║░░░██║░░░██╔══╝░░  ██╔══██║██║░░██║░░░██║░░░██╔══╝░░██║░░░░░
╚█████╔╝██║░░██║███████╗██║░░██║░░░██║░░░███████╗  ██║░░██║╚█████╔╝░░░██║░░░███████╗███████╗
░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚══════╝  ╚═╝░░╚═╝░╚════╝░░░░╚═╝░░░╚══════╝╚══════╝");
        }

    }
}
