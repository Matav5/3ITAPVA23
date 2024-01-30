namespace _3ITASklerotik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sklerotik<int> financniSklerotik = new Sklerotik<int>(5, 40);
            financniSklerotik.Zapamatuj(10000);
            financniSklerotik.Zapamatuj(-2000);
            financniSklerotik.Zapamatuj(4000);
            financniSklerotik.Zapamatuj(666);
            financniSklerotik.Zapamatuj(5000);
            financniSklerotik.Zapamatuj(3000);
            financniSklerotik.Zapamatuj(-40000);
            Console.WriteLine(financniSklerotik);
            Console.WriteLine(financniSklerotik);
            /* foreach(int cislo in financniSklerotik)
             {
                 Console.WriteLine(cislo);
             }
             foreach (int cislo in financniSklerotik)
             {
                 Console.WriteLine(cislo);
             }*/

            Sklerotik<string> pribehovySklerotik = new Sklerotik<string>(3,1000);
            pribehovySklerotik.Zapamatuj("Older Bilbo Baggins:My dear Frodo:You asked me once if I had told you everything there was to know about my adventures. And while I can honestly say I have told you the truth I may not have told you all of it. I am old now, Frodo. I'm not the same Hobbit I once was. I think it is time for you to know what really happened. It began long ago in a land far away to the east the like of which you will not find in the world today. There was the city of Dale. Its markets known far and wide. Full of the bounties of vine and vale. Peaceful and prosperous");
            pribehovySklerotik.Zapamatuj("For this city lay before the doors of the greatest kingdom in Middle-earth: Erebor. Stronghold of Thror, King Under the Mountain. Mightiest of the Dwarf Lords. Thror ruled with utter surety never doubting his house would endure for his line lay secure in the lives of his son and grandson.");
            pribehovySklerotik.Zapamatuj("Ah, Frodo. Erebor. Built deep within the mountain itself the beauty of this fortress city was legend. Its wealth lay in the earth in precious gems hewn from rock and in great seams of gold running like rivers through stone. The skill of the Dwarves was unequaled fashioning objects of great beauty out of diamond, emerald, ruby and sapphire. Ever they delved deeper, down into the dark. And that is where they found it.");
            pribehovySklerotik.Zapamatuj("And that is where they found it. The Heart of the Mountain. The Arkenstone. Thror named it \"The King's Jewel.\" He took it as a sign, a sign that his right to rule was divine. All would pay homage to him. Even the great Elven King, Thranduil. As the great wealth of the Dwarves grew their store of good will ran thin. No one knows exactly what began the rift.");
            Console.WriteLine(pribehovySklerotik);
            Console.WriteLine(pribehovySklerotik);



            Console.ReadLine();
        }
    }
}
