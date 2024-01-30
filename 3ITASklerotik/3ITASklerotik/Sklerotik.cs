using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ITASklerotik
{
    internal class Sklerotik<T> : IEnumerable<T> // where T : IList
    {
        List<T> pamet = new List<T>();
        int kapacitaMozku;
        int jednotkyPozornosti;
        public Sklerotik(int kapacitaMozku, int jednotkyPozornosti)
        {
            this.kapacitaMozku = kapacitaMozku;
            this.jednotkyPozornosti = jednotkyPozornosti;
        }
        public void Zapamatuj(T vec)
        {
            if(kapacitaMozku <= pamet.Count)
            {
                pamet.RemoveAt(Random.Shared.Next(pamet.Count));
            }
            if(Random.Shared.Next(101) <= jednotkyPozornosti)
                pamet.Add(vec);
        }
        public override string ToString()
        {
            string vystup = "";

            foreach(T prvek in this)
            {
                vystup += prvek.ToString() + "\n";


            }

            return vystup;

        }

        public IEnumerator<T> GetEnumerator()
        {
           return pamet.OrderBy(prvek => Random.Shared.Next()).GetEnumerator();

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return pamet.OrderBy(prvek => Random.Shared.Next()).GetEnumerator();
        }
    }
}
