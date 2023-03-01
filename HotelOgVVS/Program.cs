using HotelOgVVS;
using System;
using System.Diagnostics;
using static HotelOgVVS.Rum;
using static HotelOgVVS.Værelse;

namespace HotelOgVVSafts;

class Program : Indentation
{
    static void Main(string[] args)
    {
        MainMenu();           
    }

    static Ejer CreateEjer()
    {
        Ejer ejer = new Ejer();
        Console.WriteLine("Hello new owner. What is your name? ");
        Console.Write("-> ");
        string ejerName = Console.ReadLine();
        if (ejer.Name == "")
            ejer.Name = "Unknown Ejer";
        else
            ejer.Name = ejerName;

        ColorMessage(ConsoleColor.Green, "Welcome " + ejer.Name, true);
        Console.Write("Press any key to go to Create Hotel Menu...");
        Console.ReadKey();
        Console.Clear();   
        return ejer;
    }

    static Guest CreateGuest()
    {
        Guest guest = new Guest();
        Console.WriteLine(@"
░██████╗░██╗░░░██╗███████╗░██████╗████████╗  ███╗░░░███╗███████╗███╗░░██╗██╗░░░██╗
██╔════╝░██║░░░██║██╔════╝██╔════╝╚══██╔══╝  ████╗░████║██╔════╝████╗░██║██║░░░██║
██║░░██╗░██║░░░██║█████╗░░╚█████╗░░░░██║░░░  ██╔████╔██║█████╗░░██╔██╗██║██║░░░██║
██║░░╚██╗██║░░░██║██╔══╝░░░╚═══██╗░░░██║░░░  ██║╚██╔╝██║██╔══╝░░██║╚████║██║░░░██║
╚██████╔╝╚██████╔╝███████╗██████╔╝░░░██║░░░  ██║░╚═╝░██║███████╗██║░╚███║╚██████╔╝
░╚═════╝░░╚═════╝░╚══════╝╚═════╝░░░░╚═╝░░░  ╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░╚═════╝░");
        Console.Write("\nEnter your name: ");
        string guestName = Console.ReadLine();
        if (guestName == "")
            guest.Name = "Unknown Guest";
        else
            guest.Name = guestName;

        ColorMessage(ConsoleColor.Green, "Hello " + guest.Name, true);
        Console.Write("Press any key to enter Main Menu");
        Console.ReadKey();
        Console.Clear();
        return guest;
    }

    static void MainMenu()
    {
        Ejer ejer = CreateEjer();

        Hotel hotel = ejer.CreateHotel();

        Guest guest = CreateGuest();

        LoginOptions(hotel, ejer, guest);

        

    }
   

    static void LoginOptions(Hotel hotel, Ejer ejer, Guest guest)
    {
        bool runLoop = true;

        do
        {
            Console.WriteLine("Login Options:");
            Console.WriteLine("1) Ejer");
            Console.WriteLine("2) Guest");
            Console.Write("-> ");
            int login = ValidNumberInputMaximum(Console.ReadLine(), 2);
            switch (login)
            {
                case 1:
                    ejer.EjerOptions(hotel, guest);
                    break;

                case 2:
                    Console.Clear();
                    guest.Options(hotel);
                    break;

                default:
                    break;

            }
            Console.Clear();
        } while (runLoop);
    }

    /*
     static void CheckRoomAvailability(Hotel hotel, List<Etager> etager, List<Værelse> værelse, Rum rum, Guest guest)
    {
        if (hotel.ListOfEtager.Contains())
        {
            if (etager.ListOfVærelse.Contains(værelse))
            {
                if (værelse.ListOfRum.Contains(rum))
                {
                    guest.StayRum = rum;
                }
                else
                    Console.WriteLine("Rum unavailable!!!");

            }
            else
            {
                Console.WriteLine("Værelse unavailable!!!");
            }
        }
        else
            Console.WriteLine("Etager unavailable!!!");


    
        if(hotel.ListOfEtager == etager)
        {
            Console.WriteLine("Etager available");

            for (int i = 0; i < etager.Count; i++)
            {
                if (etager[i].ListOfVærelse == værelse)
                {
                    Console.WriteLine("Værelse available");

                    for (int j = 0; j < værelse.Count; j++)
                    {
                        if (værelse[i].ListOfRum.Contains(rum))
                        {
                            Console.WriteLine("Room available!");
                            guest.StayRum = rum;
                        }
                        else
                        {
                            Console.WriteLine("Room not found");
                        }

                    }

                }


            }
        }



    List<TypeOfRum> availableTypes = new List<TypeOfRum>();

        //Tjeker hvis nummer af rum er 1 eller 2 eller mere end 2. Værelse der har 2 rum skal har soveværelse og badeværelse
        if (hotel.ListOfEtager[0].ListOfVærelse[0].ListOfRum.Count == 1)
            availableTypes.Add(TypeOfRum.Soveværelse);

        else if (hotel.ListOfEtager[0].ListOfVærelse[0].ListOfRum.Count == 2)
        {
            availableTypes.Add(TypeOfRum.Soveværelse);
            availableTypes.Add(TypeOfRum.Badeværelse);
        }
        else
        {
            availableTypes.Add(TypeOfRum.Soveværelse);
            availableTypes.Add(TypeOfRum.Badeværelse);
            availableTypes.Add(TypeOfRum.Køkken);
            availableTypes.Add(TypeOfRum.Opholdsstue);
        }

        Console.WriteLine("Available room types are: ");
        for (int i = 0; i < availableTypes.Count; i++)
        {      
            Console.WriteLine(Indent(1) + (i+1) + ") " + availableTypes[i]);
        }


    }*/

    /*
     for (int i = 0; i < etagerList.Count; i++)
     {
         for (int j = 0; j < etager.NumberOfRum; j++)
         {
             Console.Write(etagerList[i].ListOfRum[j].RumType + " ");
         }
         Console.WriteLine();
     }

  for (int i = 0; i < hotel.ListOfEtager.Count; i++)
     {
         for (int j = 0; j < hotel.ListOfEtager[i].ListOfVærelse.Count; j++)
         {
             for (int k = 0; k < hotel.ListOfEtager[i].ListOfVærelse[j].ListOfRum.Count; k++)
             {
                 Console.Write(hotel.ListOfEtager[i].ListOfVærelse[j].ListOfRum[k].RumType + " - ");
             }
             Console.WriteLine();
         }
     }


     Console.Write("\nWhich etager do you want to stay in? -> ");
     int stayEtager = ValidNumberInputMaximum(Console.ReadLine(), totalEtager);

     Console.Write("Which værelse do you want to stay in? -> ");
     int stayVærelse = ValidNumberInputMaximum(Console.ReadLine(), totalVærelse);

     Console.WriteLine("What type of room do you want to book? ");
     Console.WriteLine("1) Badeværelse");
     Console.WriteLine("2) Opholdsstue");
     Console.WriteLine("3) Køkken");
     Console.WriteLine("4) Soveværelse");
     Console.Write("--> ");
     int chooseRoom = ValidNumberInputMaximum(Console.ReadLine(), 4);
     TypeOfRum guestRumType =  GetGuestRoomType(chooseRoom);



  */


    /*
     Guest guest = CreateGuest();

        Værelse guestVærelse = GetGuestVærelse(hotel);

        guest.BookVærelse(guestVærelse);

        //List<Rum> allToiletNotWorkingList = CheckToiletCondition(guestVærelse);

        var notworkingToilets = guest.CheckToiletCondition();

        if (notworkingToilets.Count > 0)
        {
            guest.InformOwner();

            ColorMessage(ConsoleColor.Red, "\nThere are " + notworkingToilets.Count + " toilets that are out of order.", true);
            foreach (var item in notworkingToilets)
            {
                ColorMessage(ConsoleColor.Red, "Room no: " + item.Key + "| Toilet working: " + item.Value.IsToiletWorking, true);
            }

            ColorMessage(ConsoleColor.Red, "Do you want to fix them? ('y' or 'n')", true);
            Console.Write("-> ");
            bool hireVVS = GetBoolean(Console.ReadLine());

            if (hireVVS)
                ejer.HireVVS(notworkingToilets);

        }*/
}
