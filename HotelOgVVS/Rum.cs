using System;
namespace HotelOgVVS
{
    public class Rum
    {
        public enum TypeOfRum
        {
            Badeværelse = 1,
            Opholdsstue,
            Køkken,
            Soveværelse
        }

        public int NumberOfRums { get; set; }
        public int RoomNumber { get; set; }
        public TypeOfRum RumType { get; set; }
        public bool IsToiletAvailable { get; set; }
        public bool IsToiletWorking { get; set; }
        public Rum()
        {
        }

        public List<Rum> GetRumType()
        {
            List<Rum> ListOfRums = new List<Rum>();

            if (this.NumberOfRums == 1)
            {
                Rum newRum = new Rum();
                newRum.RumType = TypeOfRum.Soveværelse;
                ListOfRums.Add(newRum);
            }
            else if (this.NumberOfRums == 2)
            {
                Rum rum1 = new Rum();
                rum1.RumType = TypeOfRum.Soveværelse;

                Rum rum2 = new Rum();
                rum2.RumType = TypeOfRum.Badeværelse;
                rum2.IsToiletAvailable = true;
                var random = new Random();
                int randomBool = random.Next(1, 6);
                if (randomBool >= 4 && randomBool <= 5)
                {
                    rum2.IsToiletWorking = true;
                }

                ListOfRums.Add(rum1);
                ListOfRums.Add(rum2);
            }
            else if (this.NumberOfRums == 3)
            {
                Rum rum1 = new Rum();
                rum1.RumType = TypeOfRum.Soveværelse;

                Rum rum2 = new Rum();
                rum2.RumType = TypeOfRum.Badeværelse;
                rum2.IsToiletAvailable = true;
                var random = new Random();
                int randomBool = random.Next(1, 6);
                if (randomBool >= 4 && randomBool <= 5)
                {
                    rum2.IsToiletWorking = true;
                }

                Rum rum3 = new Rum();
                rum3.RumType = TypeOfRum.Køkken;

                ListOfRums.Add(rum1);
                ListOfRums.Add(rum2);
                ListOfRums.Add(rum3);
            }
            else if (this.NumberOfRums == 4)
            {
                Rum rum1 = new Rum();
                rum1.RumType = TypeOfRum.Soveværelse;

                Rum rum2 = new Rum();
                rum2.RumType = TypeOfRum.Badeværelse;
                rum2.IsToiletAvailable = true;
                var random = new Random();
                int randomBool = random.Next(1, 6);
                if (randomBool >= 4 && randomBool <= 5)
                {
                    rum2.IsToiletWorking = true;
                }

                Rum rum3 = new Rum();
                rum3.RumType = TypeOfRum.Køkken;

                Rum rum4 = new Rum();
                rum4.RumType = TypeOfRum.Opholdsstue;

                ListOfRums.Add(rum1);
                ListOfRums.Add(rum2);
                ListOfRums.Add(rum3);
                ListOfRums.Add(rum4);
            }
            else
            {
                Rum rum1 = new Rum();
                rum1.RumType = TypeOfRum.Soveværelse;
                ListOfRums.Add(rum1);

                Rum rum2 = new Rum();
                rum2.RumType = TypeOfRum.Badeværelse;
                rum2.IsToiletAvailable = true;
                var random = new Random();
                int randomBool = random.Next(1, 6);
                if (randomBool >= 4 && randomBool <= 5)
                {
                    rum2.IsToiletWorking = true;
                }
                ListOfRums.Add(rum2);

                Rum rum3 = new Rum();
                rum3.RumType = TypeOfRum.Køkken;
                ListOfRums.Add(rum3);

                Rum rum4 = new Rum();
                rum4.RumType = TypeOfRum.Opholdsstue;
                ListOfRums.Add(rum4);


                for (int i = 0; i < (this.NumberOfRums - 4); i++)
                {
                    Random rand = new Random();
                    int randomNumber = rand.Next(1, 5);

                    TypeOfRum randomEnum = (TypeOfRum)randomNumber;

                    Rum newRoom = new Rum();
                    newRoom.RumType = randomEnum;

                    if(randomEnum == TypeOfRum.Badeværelse)
                    {
                        newRoom.IsToiletAvailable= true;
                        var _random = new Random();
                        int _randomBool = random.Next(1, 6);
                        if (_randomBool >= 4 && randomBool <= 5)
                        {
                            newRoom.IsToiletWorking = true;
                        }
                    }

                    ListOfRums.Add(newRoom);
                }
            }
            return ListOfRums;

        }

        public virtual void WhoAmI()
        {
            Console.WriteLine("I am room");
        }

    }
}
