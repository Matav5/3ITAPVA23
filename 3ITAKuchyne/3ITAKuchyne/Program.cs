namespace _3ITAKuchyne
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Maminka maminka = new Maminka(5.3f,"Šišky s mákem", false);
            Otec otec = new Otec(2, 50);
            Syn syn = new Syn("Zikmund",100, 4);
            Syn syn2 = new Syn("Ferrero",50, 0);

            maminka.OnMaminkaUvarila += otec.OnMaminkaDovarila;
            maminka.OnMaminkaUvarila += syn.OnMaminkaUvarila;
            maminka.OnMaminkaUvarila += syn2.OnMaminkaUvarila;


            maminka.ZacniVarit();
        }
    }
}