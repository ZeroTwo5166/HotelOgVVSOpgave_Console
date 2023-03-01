using System;
using System.Runtime.InteropServices;

namespace HotelOgVVS
{
    class Ejer : Indentation
    {
        public string Name { get; set; } = "";
        public string Location { get; set; } = "";
        public double NetWorth { get; set; } = 200_000;
        public bool HasHiredVVSMand { get; set; }


        public Ejer()
        {
            Console.WriteLine(@"
░█████╗░░██╗░░░░░░░██╗███╗░░██╗███████╗██████╗░  ███╗░░░███╗███████╗███╗░░██╗██╗░░░██╗
██╔══██╗░██║░░██╗░░██║████╗░██║██╔════╝██╔══██╗  ████╗░████║██╔════╝████╗░██║██║░░░██║
██║░░██║░╚██╗████╗██╔╝██╔██╗██║█████╗░░██████╔╝  ██╔████╔██║█████╗░░██╔██╗██║██║░░░██║
██║░░██║░░████╔═████║░██║╚████║██╔══╝░░██╔══██╗  ██║╚██╔╝██║██╔══╝░░██║╚████║██║░░░██║
╚█████╔╝░░╚██╔╝░╚██╔╝░██║░╚███║███████╗██║░░██║  ██║░╚═╝░██║███████╗██║░╚███║╚██████╔╝
░╚════╝░░░░╚═╝░░░╚═╝░░╚═╝░░╚══╝╚══════╝╚═╝░░╚═╝  ╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░╚═════╝░");
        }

        public Ejer(string _name, string _hotelName, double _netWorth, bool _hasHiredVVSMand)
        {
            this.Name = _name;
            this.NetWorth = _netWorth;
            this.HasHiredVVSMand = _hasHiredVVSMand;
        }

        public Hotel CreateHotel() 
        {
            Hotel hotel = new Hotel();
            Console.Write("\nEnter a hotel name: ");
            string hotelName = Console.ReadLine();
            if (hotelName == "")
                hotel.HotelNavn = "Unnamed Hotel";
            else
                hotel.HotelNavn = hotelName;

            Console.Write("\nEnter hotel location: ");
            string hotelLocation = Console.ReadLine();
            if (hotelLocation == "")
                hotel.Location = "Somewhere on Earth";
            else
                 hotel.Location = hotelLocation;

            Console.Write("\nEnter total number of etager: ");
            int totalEtager = ValidNumberInputMinimum(Console.ReadLine(), 3);

            Console.Write("\nEnter total number of værelse per etager: ");
            int totalVærelse = ValidNumberInputMinimum(Console.ReadLine(), 3);

            Console.Write("\nEnter total number of rum per værelse: ");
            int totalRum = ValidNumberInputMinimum(Console.ReadLine(), 1);

            Rum rum = new Rum();
            rum.NumberOfRums = totalRum;

            Værelse værelse = new Værelse();
            Etager etager = new Etager();
            Guest guest = new Guest();


            værelse.NumberOfVærelse = totalVærelse;
            værelse.NumberOfRums = totalRum;
            værelse.ListOfRum = rum.GetRumType();
            var værelseList = værelse.GetVærelseList();
            etager.ListOfVærelse = værelseList;

            etager.NumberOfEtager = totalEtager;
            etager.NumberOfRums = totalRum;
            etager.NumberOfVærelse = totalVærelse;
            var etagerList = etager.GetEtagerList();
            hotel.ListOfEtager = etagerList;

            Console.Clear();
            ColorMessage(ConsoleColor.Cyan, "Hotel Created...", true);
            ColorMessage(ConsoleColor.Cyan, " Name: " + hotel.HotelNavn, true);
            ColorMessage(ConsoleColor.Cyan, " Location: " + hotel.Location, true);
            ColorMessage(ConsoleColor.Cyan, " Etager: " + totalEtager, true);
            ColorMessage(ConsoleColor.Cyan, " Værelse per etager: " + totalVærelse, true);
            ColorMessage(ConsoleColor.Cyan, " Rum per værelse: " + totalRum, true);
            Console.Write("Press any key to enter Guest Menu...");
            Console.ReadKey();
            Console.Clear();
            return hotel;
        }

        public void HireVVS(Dictionary<int, Rum> brokenToilets)
        {
            VVS vvs = new VVS();

            this.HasHiredVVSMand = true;

            double totalCosts = vvs.StartWork(brokenToilets);

            ColorMessage(ConsoleColor.Yellow, "The total costs was " + totalCosts + "kr.", true);
            Console.WriteLine("Invoice sent to you via email. Do you want to pay the invoice now? ");
            Console.Write("-> ");
            bool payNow = GetBoolean(Console.ReadLine());
            if (payNow)
            {
                this.NetWorth = PayVVS(totalCosts);
                ColorMessage(ConsoleColor.Yellow, "Invoice paid. Your credit amount is now " + this.NetWorth + "kr.", true);
            }
            else
            {
                ColorMessage(ConsoleColor.Yellow, "Remember to pay the invoice in time!" , true);
            }
        }
        
        public double PayVVS(double invoiceCosts)
        {
            return this.NetWorth - invoiceCosts;
        }

        public void EjerOptions(Hotel hotel, Guest guest)
        {
            bool runLoop = true;
            Console.Clear();
            do
            {
                Console.WriteLine("Ejer Options: ");
                Console.WriteLine("1) Edit hotel info");
                Console.WriteLine("2) Check all Rooms");
                Console.WriteLine("3) See Guests Info");
                Console.WriteLine("4) See Hotel Info");
                Console.WriteLine("5) See Complains");
                Console.WriteLine("6) Fix Toilets in Guests Værelse");
                Console.WriteLine("7) Go to Main Menu");
                Console.Write("-> ");
                int adminInput = ValidNumberInputMaximum(Console.ReadLine(), 7);

                switch (adminInput)
                {
                    case 1:
                        EditHotelInfo(hotel);
                        break;

                    case 2:
                        CheckAllRooms(hotel);
                        break;

                    case 3:
                        Console.Clear();
                        ColorMessage(ConsoleColor.Cyan, "Guest Info: ", true);
                        ColorMessage(ConsoleColor.Cyan, " Name: " + guest.Name, true);
                        guest.ListAllRoomsInVærelse();
                        guest.CheckSatisfaction();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        ColorMessage(ConsoleColor.Cyan, "Hotel Info: ", true);
                        ColorMessage(ConsoleColor.Cyan, " Name: " + hotel.HotelNavn, true);
                        ColorMessage(ConsoleColor.Cyan, " Location: " + hotel.Location, true);
                        ColorMessage(ConsoleColor.Cyan, " Number of Etager in hotel: " + hotel.ListOfEtager.Count, true);
                        ColorMessage(ConsoleColor.Cyan, " Number of Værelse in hotel: " + hotel.ListOfEtager[0].ListOfVærelse.Count * hotel.ListOfEtager.Count, true);
                        ColorMessage(ConsoleColor.Cyan, " Number of Rum in hotel: " + hotel.ListOfEtager[0].ListOfVærelse.Count * hotel.ListOfEtager.Count * hotel.ListOfEtager[0].ListOfVærelse[0].ListOfRum.Count, true);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        if (Complains.Count > 0)
                        {
                            foreach (var item in Complains)
                            {
                                ColorMessage(ConsoleColor.Red, item, true);
                            }
                        }
                        else
                            ColorMessage(ConsoleColor.Green, "No complains yet.", true);

                        Console.WriteLine();
                        break;

                    case 6:
                        var toiletsThatNeedToBeFixed =  guest.CheckToiletCondition(guest.StayVærelse);
                        if (toiletsThatNeedToBeFixed.Count > 0)
                        {
                            foreach (var item in toiletsThatNeedToBeFixed)
                            {
                                ColorMessage(ConsoleColor.Red, "Room no: " + item.Key + " | Toilet Working: " + item.Value.IsToiletWorking, true);
                            }

                            ColorMessage(ConsoleColor.Red, "\nDo you want to fix them? ('y' or 'n')", true);
                            Console.Write("-> ");
                            bool hireVVS = GetBoolean(Console.ReadLine());
                            if (hireVVS)
                            {
                                HireVVS(toiletsThatNeedToBeFixed);
                                Complains.Clear();
                            }

                        }
                        else if(guest.StayVærelse.ListOfRum.Count != 0 &&  toiletsThatNeedToBeFixed.Count == 0)
                            ColorMessage(ConsoleColor.Green, "All toilets fixed", true);
                        
                        else 
                            ColorMessage(ConsoleColor.Yellow, "Guest hasn't booked værelse yet", true);

                        Console.WriteLine();
                        break;

                    case 7:
                        runLoop= false;
                        break;

                    default:
                        break;
                }

            } while (runLoop);
        }

        public void EditHotelInfo(Hotel hotel)
        {
            bool runLoop = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Edit Hotel Info::");
                Console.WriteLine("1) Change Hotel Name");
                Console.WriteLine("2) Change Hotel Location");
                Console.WriteLine("3) Go back to Ejer Options Menu");
                Console.Write("-> ");
                int editHotel = ValidNumberInputMaximum(Console.ReadLine(), 3);
                switch (editHotel)
                {
                    case 1:
                        Console.WriteLine("Current Hotel Name is '" + hotel.HotelNavn + "'");
                        Console.Write("Enter new Hotel Name : ");
                        string newHotelName = Console.ReadLine();
                        if (newHotelName == "")
                        {
                            hotel.HotelNavn = "UNNAMED HOTEL!";
                        }
                        else
                            hotel.HotelNavn = newHotelName;
                        break;

                    case 2:
                        Console.WriteLine("Current Hotel Location is '" + hotel.Location + "'");
                        Console.Write("Enter new Hotel Location : ");
                        string hotelLocation = Console.ReadLine();
                        if (hotelLocation == "")
                        {
                            hotel.Location = "SOMEWHERE ON EARTH!";
                        }
                        else
                            hotel.Location = hotelLocation;
                        break;

                    case 3:
                        runLoop = false;
                        break;

                    default:
                        break;

                }
            } while (runLoop);
            Console.Clear();
        }

        public void CheckAllRooms(Hotel hotel)
        {
            bool runLoop = true;
            do
            {
                Console.WriteLine("\nCheck everything inside hotel");
                Console.WriteLine("1) Get all info inside hotel");
                Console.WriteLine("2) Go back to Ejer Options Menu");
                Console.Write("-> ");
                int userInput = ValidNumberInputMaximum(Console.ReadLine(), 2);
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("\nNumber of Etager in hotel: " + hotel.ListOfEtager.Count);
                        Console.WriteLine("Number of Værelse in hotel: " + hotel.ListOfEtager[0].ListOfVærelse.Count * hotel.ListOfEtager.Count);
                        Console.WriteLine("Number of Rum in hotel: " + hotel.ListOfEtager[0].ListOfVærelse.Count * hotel.ListOfEtager.Count * hotel.ListOfEtager[0].ListOfVærelse[0].ListOfRum.Count);
                        break;

                    case 2:
                        
                        runLoop= false;
                        break;

                    default:
                        break;
                }

            } while (runLoop);
            Console.Clear();
        }

        
    }
}