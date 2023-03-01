
namespace HotelOgVVS
{
    public class Etager : Værelse
    {
        public int NumberOfEtager { get; set; }

        public List<Værelse> ListOfVærelse { get; set; } = new List<Værelse> ();
        public Etager()
        {
        }

        public List<Etager> GetEtagerList()
        {
            List<Etager> listOfEtager = new List<Etager>();

            for (int i = 0; i < this.NumberOfEtager; i++)
            {
                Etager etager = new Etager();
                etager.ListOfVærelse = GetVærelseList();
                listOfEtager.Add(etager);
            }
            return listOfEtager;
        }

        public override void WhoAmI()
        {
            Console.WriteLine("I am Etager");
        }


    }
}
