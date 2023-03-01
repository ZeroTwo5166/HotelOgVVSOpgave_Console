using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HotelOgVVS.Rum;

namespace HotelOgVVS
{
    public class Værelse : Rum
    {
        public enum RoomFeatures
        {
            Wifi = 1,
            Tv,
            Sofa,
            GreatView,
            AC,
            GamingSetup,
            Jacuzzi
        }

        public int NumberOfVærelse { get; set; }
        public List<Rum> ListOfRum { get; set; } = new List<Rum>();
        public Værelse() {        }
        public List<Værelse> GetVærelseList()
        {
            List<Værelse> værelseList = new List<Værelse> ();

            for (int i = 0; i < this.NumberOfVærelse; i++)
            {
                Værelse værelse = new Værelse();
                værelse.ListOfRum = GetRumType();
                værelseList.Add(værelse);
            }
            return værelseList;

        }

        public List<RoomFeatures> GuestRoomFeatures()
        {
            List<RoomFeatures> roomFeatures = new List<RoomFeatures>();
            Random random = new Random();

            int numberOfFeatures = random.Next(3,6);

            for (int i = 0; i < numberOfFeatures; i++)
            {
                int randomNumber = random.Next(1, 8);
                RoomFeatures rand = (RoomFeatures)randomNumber;
                roomFeatures.Add(rand);
            }
            var feature = roomFeatures.Distinct().ToList();
            return feature;

        }

        public override void WhoAmI()
        {
            Console.WriteLine("I am Værelse");
        }
    }
}
