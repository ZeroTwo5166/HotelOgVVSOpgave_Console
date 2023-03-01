using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static HotelOgVVS.Rum;
using static HotelOgVVS.Værelse;

namespace HotelOgVVS
{
    public class Guest : Indentation, IInform
    {
        public string Name { get; set; }
        public Værelse StayVærelse { get; set; } = new Værelse();
        public Guest() { }
        public bool IsSatisfied  { get; set; }

        public void BookVærelse(Værelse guestVærelse)
        {
            this.StayVærelse = guestVærelse;
        }

        public void Options(Hotel hotel)
        {
            bool runLoop = true;

            do
            {
                Console.WriteLine("Guest Options: ");
                Console.WriteLine("1) See hotel info");
                Console.WriteLine("2) Book a værelse");
                Console.WriteLine("3) Inform ejer about problem (if exists)");
                Console.WriteLine("4) Give review about hotel");
                Console.WriteLine("5) Go back to Main Menu");
                Console.Write("-> ");
                int guestOptions = ValidNumberInputMaximum(Console.ReadLine(), 5);

                switch (guestOptions)
                {
                    case 1:
                        Console.Clear();
                        ColorMessage(ConsoleColor.Cyan, "Hotel Info::", true);
                        ColorMessage(ConsoleColor.Cyan, " Name: " + hotel.HotelNavn, true);
                        ColorMessage(ConsoleColor.Cyan, " Location: " + hotel.Location, true);
                        ColorMessage(ConsoleColor.Cyan, " Etager: " + hotel.ListOfEtager.Count, true);
                        ColorMessage(ConsoleColor.Cyan, " Værelse per etager: " + hotel.ListOfEtager[0].ListOfVærelse.Count, true);
                        ColorMessage(ConsoleColor.Cyan, " Rum per værelse: " + hotel.ListOfEtager[0].ListOfVærelse[0].ListOfRum.Count, true);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        this.StayVærelse = GetGuestVærelse(hotel);
                        break;

                    case 3:
                        InformOwner();
                        break;

                    case 4:
                        GuestReview(this.StayVærelse);
                        break;

                    case 5:
                        runLoop = false;
                        break;

                    default:
                        break;
                }


            } while (runLoop);
        }

        public void InformOwner()
        {
            if(this.StayVærelse.ListOfRum.Count > 0)
            {
                for (int i = 0; i < this.StayVærelse.ListOfRum.Count; i++)
                {
                    if (this.StayVærelse.ListOfRum[i].IsToiletAvailable == true)
                    {
                        if(!this.StayVærelse.ListOfRum[i].IsToiletWorking == true)
                            ColorMessage(ConsoleColor.Red, "Toilet is out of order. Please fix it asap!!!", true);
                        else
                            ColorMessage(ConsoleColor.Green, "Everything looks fine!", true);

                        break;
                    }
                }
            }
            else
                ColorMessage(ConsoleColor.Yellow, "Værelse not booked yet!", true);

            Console.WriteLine();

        }

        public int GuestReview(Værelse værelse)
        {
            int reviewStars = 0;

            var noOfToiletNotFunctioning = CheckToiletCondition(this.StayVærelse);


            if (this.StayVærelse.ListOfRum.Count != 0)
            {
                if (noOfToiletNotFunctioning.Count > 0)
                {
                    ColorMessage(ConsoleColor.Red, "Guest gave the hotel a review of 1 star. :(", true);
                    reviewStars = 1;
                }

                else if (noOfToiletNotFunctioning.Count == 0)
                {
                    var features = værelse.GuestRoomFeatures();

                    if (features.Count == 5)
                    {

                        ColorMessage(ConsoleColor.Green, "Guest gave the hotel a review of 5 stars. WOOOO :D", true);
                        reviewStars = 5;
                    }
                    else
                    {
                        ColorMessage(ConsoleColor.Green, "Guest gave the hotel a review of 4 stars. Nicee :)", true);
                        reviewStars = 4;
                    }
                }

            }
            else
            {
                ColorMessage(ConsoleColor.Yellow, "Guest hasn't booked a værelse yet to give a review!", true);
            }
            Console.WriteLine();
            return reviewStars;              
        }

        public Dictionary<int, Rum> CheckToiletCondition(Værelse guestVærelse)
        {
            Dictionary<int, Rum> notWorkingToilets = new Dictionary<int, Rum>();


            for (int i = 0; i < guestVærelse.ListOfRum.Count; i++)
            {
                if (guestVærelse.ListOfRum[i].RumType == TypeOfRum.Badeværelse)
                {
                    if(guestVærelse.ListOfRum[i].IsToiletWorking == false)
                    {
                        notWorkingToilets.Add(guestVærelse.ListOfRum[i].RoomNumber, guestVærelse.ListOfRum[i]);
                    }
                }
            }

            return notWorkingToilets;
        }

        //Bede guest om deres ønsker værelse
        public Værelse GuestVærelse(Hotel hotel)
        {
            Console.WriteLine("\nWhich etager do you want to stay in? ");
            Console.Write("-> ");
            int guestEtager = ValidNumberInputMaximum(Console.ReadLine(), hotel.ListOfEtager.Count); //Fordi guest kan ikke vælg etager der eksistere ikke

            Console.WriteLine($"\nWhich værelse in etager '{guestEtager}' do you want to stay in? ");
            Console.Write("-> ");
            int guestVærelse = ValidNumberInputMaximum(Console.ReadLine(), hotel.ListOfEtager[guestEtager - 1].ListOfVærelse.Count); // guestEtager-1 fordi det er index og ikke nummer

            Console.WriteLine($"\nRooms in værelse '{guestVærelse}' are listed below: ");

            foreach (var item in hotel.ListOfEtager[guestEtager - 1].ListOfVærelse[guestVærelse - 1].ListOfRum)
            {
                Console.WriteLine("- " + item.RumType);
            }

            List<RoomFeatures> features = hotel.ListOfEtager[0].ListOfVærelse[0].GuestRoomFeatures(); //List der inholder alle features fra guests værelse

            Console.WriteLine("\nFeatures in your værelse are listed below.");
            foreach (var item in features)
            {
                Console.WriteLine("- " + item);
            }

            if (features.Count > 3)
                this.IsSatisfied = true;


            Værelse finalGuestVærelse = hotel.ListOfEtager[guestEtager - 1].ListOfVærelse[guestVærelse - 1];
  
            return finalGuestVærelse;

        }

        //Spørg hvis guest er glad for deres værelse. Hvis nej, giv dem lov til at vælge det igen
        public Værelse GetGuestVærelse(Hotel hotel)
        {
            bool guestSatisfied = false;
            Værelse guestVærelse = new Værelse();
            do
            {
                guestVærelse = GuestVærelse(hotel);
                Console.WriteLine("\nAre you satisfied with your værelse? ('y' or 'n')");
                Console.Write("-> ");
                bool userSatisfaction = GetBoolean(Console.ReadLine());

                if (userSatisfaction)
                    guestSatisfied = true;
                else
                {
                    guestSatisfied = false;
                    Console.Clear();
                }

            } while (!guestSatisfied);

            for (int i = 0; i < guestVærelse.ListOfRum.Count; i++)
            {
                guestVærelse.ListOfRum[i].RoomNumber = i + 1;
            }
            Console.WriteLine();

            var notworkingToilets = CheckToiletCondition(guestVærelse);

            if (notworkingToilets.Count > 0)
            {               
                ColorMessage(ConsoleColor.Red, "\nThere are " + notworkingToilets.Count + " toilets that are out of order.", true);
                foreach (var item in notworkingToilets)
                {
                    ColorMessage(ConsoleColor.Red, "Room no: " + item.Key + "| Toilet working: " + item.Value.IsToiletWorking, true);
                }

                Console.WriteLine("Do you want to inform ejer about it? (y or n)");
                Console.Write("-> ");
                bool problemReport = GetBoolean(Console.ReadLine());

                if (problemReport)
                {
                    Complain("Toilet is not working!!!");
                    ColorMessage(ConsoleColor.Red, "Complain sent to ejer.", true);
                }

                Console.WriteLine();
            }
            return guestVærelse;
        }

        


        public void ListAllRoomsInVærelse()
        {
            if (StayVærelse.ListOfRum.Count > 0)
            {
                ColorMessage(ConsoleColor.Cyan, " Rooms booked by guest are listed below: ", true);
                for (int i = 0; i < StayVærelse.ListOfRum.Count; i++)
                {
                    ColorMessage(ConsoleColor.Cyan, " - " + StayVærelse.ListOfRum[i].RumType, true);
                }
            }
            else
                ColorMessage(ConsoleColor.Yellow, " Værelse not booked yet", true);



        }

        public void CheckSatisfaction()
        {
            if (StayVærelse.ListOfRum.Count > 0)
            {
                ColorMessage(ConsoleColor.Cyan, " Satisfied: " + this.IsSatisfied, true);
            }
            else
                ColorMessage(ConsoleColor.Yellow, " Satsfied: Unknown (Værelse not booked yet)", true);
        }

    }
}
