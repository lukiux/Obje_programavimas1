using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1klausimas
{
    class Preke
    {
        private string pavVrd;
        private int kaina;
        public Preke(string pavVrd, int kaina)
        {
            this.pavVrd = pavVrd;
            this.kaina = kaina;
        }
        public string ImtiPav() { return pavVrd; }
        public int ImtiKaina() { return kaina; }

        public static bool operator ==(Preke preke1, Preke preke2)
        {
            return (preke1.pavVrd == preke2.pavVrd);
        }
        public static bool operator !=(Preke preke1, Preke preke2)
        {
            return (preke1.pavVrd != preke2.pavVrd);
        }
        public static bool operator <(Preke preke1, Preke preke2)
        {
            //int poz = String.Compare(preke1.pavVrd, preke2.pavVrd, StringComparison.CurrentCulture);
            //return (poz < 0);
            return preke1.kaina < preke2.kaina;
        }
        public static bool operator >(Preke preke1, Preke preke2)
        {
            //int poz = String.Compare(preke1.pavVrd, preke2.pavVrd, StringComparison.CurrentCulture);
            //return (poz > 0);
            return preke1.kaina > preke2.kaina;
        }
        public static Preke operator +(Preke preke1, Preke preke2)
        {
            Preke laik = new Preke("", 0);
            
            laik.kaina = preke1.kaina + preke2.kaina;
            return laik;
        }
    }
    class Prekes
    {
        const int Cn = 100;
        private Preke[] Prekiu;
        private Preke[] PrekiuA;
        private int kiek;
        private int kiekA;
        public Prekes()
        {
            Prekiu = new Preke[Cn];
            PrekiuA = new Preke[Cn];
            kiekA = 0;
            kiek = 0;
        }
        public Preke ImtiPreke(int i) { return Prekiu[i]; }
        public int ImtiKiek() { return kiek; }
        public void Deti(Preke ob) { Prekiu[kiek++] = ob; }

        public void Pasalinimas(Preke ob)
        {
            int k = 0;

            for (int i = 0; i < kiek && (Prekiu[i] != ob); i++)
            {
                k = i + 1;
            }
            if (k < kiek)
            {
                for (int i = k; i < kiek; i++)
                {
                    Prekiu[i] = Prekiu[i + 1];
                }
                kiek--;
            }
        }
        public void PasalintiNerik(Preke ob)
        {
            int k = 0;
            for (int i = 0; i < kiek && (Prekiu[i] != ob); i++)
                k = i + 1;
            if (k < kiek)
            {
                Prekiu[k] = Prekiu[kiek - 1];
                kiek--;
            }
        }
        public void Iterpiamas(Preke ob)
        {
            int k = 0;
            for (int i = 0; i < kiek && Prekiu[i] < ob; i++)
            {
                k = i + 1;
            }
            if (k < kiek)
            {
                for (int i = kiek; i > k; i--)
                    Prekiu[i] = Prekiu[i - 1];
                Prekiu[k] = ob;
                kiek++;
            }
        }
        public void IterpiamasNeri(Preke ob, int deti)
        {
            int k = deti;
            Prekiu[kiek] = Prekiu[k];
            Prekiu[k] = ob;
            kiek++;
        }
        public int NuosekliNerikiPaieska(Preke ob)
        {
            for (int i = 0; i < kiek; i++)
            {
                if (Prekiu[i] == ob)
                    return i;
            }
            return -1;
        }
        public int NuosekliPaieska(Preke ob)
        {
            for (int i = 0; i < kiek; i++)
            {
                if (Prekiu[i] == ob)
                    return i;
                else
                    if (Prekiu[i] > ob)
                        return -1;

            }
            return -1;
        }
        public void MinMax()
        {
            int maxInd;
            for (int i = 0; i < kiek - 1; i++)
            {
                maxInd = i;
                for (int j = i + 1; j < kiek; j++)
                {
                    if (Prekiu[j] > Prekiu[maxInd])
                        maxInd = j;
                }
                Preke pre = Prekiu[i];
                Prekiu[i] = Prekiu[maxInd];
                Prekiu[maxInd] = pre;
            }
        }
        public int DvejetainePaieska(Preke ob)
        {
            int pi, vi, gi;
            pi = 0; gi = kiek - 1;
            while (pi <= gi)
            {
                vi = (pi + gi) / 2;
                if (Prekiu[vi] == ob)
                    return vi;
                else
                    if (Prekiu[vi] < ob)
                        pi = vi + 1;
                    else
                        gi = vi - 1;
            }
            return -1;
        }
        public void Formuoti(int riba)
        {
            kiekA = 0;
            for (int i = 0; i < kiek; i++)
            {
                if (Prekiu[i].ImtiKaina() > riba)
                    PrekiuA[kiekA++] = Prekiu[i];
            }
        }
        public int Suma()
        {
            Preke laik = new Preke("", 0);
            for (int i = 0; i < kiek; i++)
                laik = laik + Prekiu[i];
            return laik.ImtiKaina();
        }
        public double Vid()
        {
            Preke laik = new Preke("", 0);
            for (int i = 0; i < kiek; i++)
                laik = laik + Prekiu[i];
            if (kiek != 0)
                return (double)laik.ImtiKaina() / kiek;
            else
                return 0.0;
        }
        public Preke Max()
        {
            int maxInd = 0;
            Preke pre = Prekiu[0];
            for (int i = 1; i < kiek; i++)
                if (Prekiu[i] > pre)
                {
                    pre = Prekiu[i];
                    maxInd = i;
                }
            return pre;
        }
        public bool DuMax(out Preke ob1, out Preke ob2)
        {
            ob1 = new Preke("", 0);
            ob2 = new Preke("", 0);
            if (kiek < 2)
                return false;
            if (Prekiu[0] > Prekiu[1])
            {
                ob1 = Prekiu[0];
                ob2 = Prekiu[1];
            }
            else
            {
                ob1 = Prekiu[1];
                ob2 = Prekiu[0];
            }
            for (int i = 2; i < kiek; i++)
            {
                if (Prekiu[i] > ob1)
                {
                    
                    ob2 = ob1;
                    ob1 = Prekiu[i];
                }
                else
                    if (Prekiu[i] > ob2)
                        ob2 = Prekiu[i];
            }
            return true;
        }
        public void SutrauktiVienodus()
        {
            for (int i = 0; i < kiek; i++)
                for (int j = i + 1; j < kiek; j++)
                    if (Prekiu[i] == Prekiu[j])
                    {
                        if (Prekiu[i].ImtiKaina() < Prekiu[j].ImtiKaina())
                            Prekiu[i] = Prekiu[j];
                        Prekiu[j] = Prekiu[kiek - 1];
                        kiek--;
                        j--;
                    }
        }
    }
    class Program
    {
        const string CFd = "..\\..\\Duomenys.txt";

        static void Skaityti(string fv, Prekes pz)
        {
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string pav = parts[0];
                    int kain = int.Parse(parts[1]);
                    Preke prek = new Preke(pav, kain);
                    pz.Deti(prek);
                }
            }
        }
        static void Rez(Prekes pz)
        {
            string bruk = new string('-', 40);
            
            string virsus = "|  Pav             |   Kaina     |";
            Console.WriteLine(virsus);
            Console.WriteLine(bruk);
            for (int i = 0; i < pz.ImtiKiek(); i++)
            {
                Preke pre = pz.ImtiPreke(i);
                Console.WriteLine("|{0,-20} | {1,5:d}  |", pre.ImtiPav(), pre.ImtiKaina());
            }
        }
        static void Main(string[] args)
        {
            Prekes pz = new Prekes();
            Prekes pzA = new Prekes();
            Skaityti(CFd, pz);
            Rez(pz);
            Preke pre = new Preke("Juozaitis Juozas", 4);
            pz.Pasalinimas(pre);
            Rez(pz);
            //pz.MinMax();
            //Rez(pz);
            //Preke prl = pz.Max();
            //Console.WriteLine("{0} {1}", prl.ImtiPav(), prl.ImtiKaina());
            Preke pry = new Preke("Guzauskas Lukas", 10);
            //pz.Iterpiamas(pry);
            //Rez(pz);
            //pz.IterpiamasNeri(pry, 4);
            //Rez(pz);
            //int ind = pz.NuosekliPaieska(pry);
            //Console.WriteLine(ind);

            //int ind2 = pz.DvejetainePaieska(pry);
            //Console.WriteLine(ind2);

            //int riba = 6;
            //pz.Formuoti(riba);
            //Rez(pz);

            //double vid = pz.Vid();
            //Console.WriteLine(vid);

            //pz.SutrauktiVienodus();
            //Rez(pz);

            //Preke ob1;
            //Preke ob2;
            //pz.DuMax(out ob1, out ob2);
            //Console.WriteLine("{0} {1}", ob1.ImtiKaina(), ob2.ImtiKaina());
        }
    }

}