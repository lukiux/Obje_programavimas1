using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3klausimai
{
    class Elektr
    {
        const int Cn = 100;
        private int[,] Elek;
        public int N { get; set; }
        public int M {get; set;}
        public Elektr()
        {
            Elek = new int[Cn, 12];
            N = 0;
            M=0;
        }

        public void Deti(int i, int j, int sk) { Elek[i, j] = sk; }
        public int Imti(int i, int j) { return Elek[i, j]; }
    }
    class Program
    {
        static void Skaityti(string fv, Elektr E)
        {
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                int skaicius;
                string line = reader.ReadLine();
                char[] skyr = { ' ' };
                string[] skaiciai = line.Split(skyr, StringSplitOptions.RemoveEmptyEntries);
                E.N = int.Parse(skaiciai[0]);
                E.M = int.Parse(skaiciai[1]);
                for (int i = 0; i < E.N; i++)
                {
                    line = reader.ReadLine();
                    skaiciai = line.Split(skyr, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < skaiciai.Length; j++)
                    {
                        skaicius = int.Parse(skaiciai[j]);
                        E.Deti(i, j, skaicius);
                    }
                }
            }
        }
        static void Skaityti2(string fv, Elektr E)
        {
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                int skaicius;
                string line = reader.ReadLine();
                char[] skyr = { ' ' };
                string[] skaiciai = line.Split(skyr, StringSplitOptions.RemoveEmptyEntries);
                E.N = int.Parse(skaiciai[0]);
                for (int i = 0; i < E.N; i++)
                {
                    line = reader.ReadLine();
                    skaiciai = line.Split(skyr, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < skaiciai.Length; j++)
                    {
                        skaicius = int.Parse(skaiciai[j]);
                        E.Deti(i, j, skaicius);
                    }
                }
            }
        }
        const string CFd = "..\\..\\Duomenys.txt";
        const string CFr = "..\\..\\Kvadrata.txt";
        static void Main(string[] args)
        {
            Elektr Elek = new Elektr();
            int maxSuma;
            int maxMen;
            //Skaityti(CFd, Elek);
            //PaskutinMen(Elek, out maxSuma, out maxMen);
            //Console.WriteLine("{0} {1}", maxMen, maxSuma);

            Skaityti2(CFr, Elek);
            int suma = Kryziminis(Elek);
            Console.WriteLine(suma);
        }

        //---------------------------------------------------------------
        /** Suskaicuoja ir grazina vieno menesio gyventoju suvartota elektros kieki.
         @param E - konteinerio vardas
         @param k - menesiu skaiciai */
        //--------------------------------------------------------------------
        static int Menskaic(Elektr E, int k)
        {
            int suma = 0;
            for (int i = 0; i < E.N; i++)
                suma = suma + E.Imti(i, k - 1);
            return suma;
        }
        //--------------------------------------------------------------------
        /** Suskaiciuoja, kuri menesi buvo suvartota daugiausia elektros.
         @param E - konteinerio vardas
         @param maxSuma - daugiausiai suvartota elektros
         @param maxMen - menesio numeris */
        //-------------------------------------------------------------------
        static void PaskutinMen(Elektr E, out int maxSuma, out int maxMen)
        {
            int max = 0;
            int suma;
            maxSuma = 0;
            maxMen = 0;
            for (int j = 1; j <= 12; j++)
            {
                suma = Menskaic(E, j);
                if (suma > max)
                {
                    max = suma;
                    maxSuma = max;
                    maxMen = j;
                }
            }
        }
        //---------------------------------------------------------------------
        /** Suskaiciuoja ir grazina, vienos dienos kiek kartu matuota oro vidutines temperatura
         @param E - konteinerio vardas
         @param k - dienu skaiciai */
        //-------------------------------------------------------------------------
        static double VienaDiena(Elektr E, int k)
        {
            int suma = 0;
            for (int j = 0; j < E.M; j++)
                suma = suma + E.Imti(k - 1, j);
            if (E.M != 0)
                return (double)suma / E.M;
            else
                return 0.0;
        }
        //-----------------------------------------------------------------------------
        /** Suskaiciuoja, kuris rastu diena, kai vidutine dienos temperaturos yra didziausia
         @param E - konteinerio vardas
         @param maxVid - didziausia vidutines dienos temperatura
         @param maxDay - dienos numeris */
        //-----------------------------------------------------------------------------
        static void MaxVid(Elektr E, out double maxVid, out int maxDay)
        {
            double max = 0.0;
            double vid;
            maxVid = 0.0;
            maxDay = 0;
            for (int i = 1; i <= 7; i++)
            {
                vid = VienaDiena(E, i);
                if (vid > maxVid)
                {
                    //max = vid;
                    maxVid = vid;
                    maxDay = i;
                }
            }
        }

        static int Dalysistraizines1(Elektr E)
        {
            int suma = 0;
            for (int i = 0; i < E.N; i++)
                for (int j = 0; j <=i; j++)
                    suma = suma + E.Imti(i, j);
            return suma;
        }
        static int Dalysistraizines2(Elektr E)
        {
            int suma = 0;
            for (int j = 0; j < E.M; j++)
                for (int i = 0; i <= j; i++)
                    suma = suma + E.Imti(i, j);
            return suma;
        }
        static int Dalysistraizines3(Elektr E)
        {
            int suma = 0;
            for (int i = 0; i < E.N; i++)
                for (int j = E.N - 1; j >= E.N - i - 1; j--)
                    suma = suma + E.Imti(i, j);
            return suma;
        }
        static int Dalysistraizines4(Elektr E)
        {
            int suma = 0;
            for (int j = E.N - 1; j >= 0; j--)
                for (int i = 0; i <= E.N - j - 1; i++)
                    suma = suma + E.Imti(i, j);
            return suma;
        }
        static int Kryziminis(Elektr E)
        {
            int suma = 0;
            for (int i = 0; i < E.N / 2; i++)
                for (int j = i; j <= E.N - i - 1; j++)
                    suma = suma + E.Imti(i, j);
            return suma;
        }
        static int Kryziminis2(Elektr E)
        {
            int suma = 0;
            for (int i = E.N - 1; i > E.N / 2; i--)
                for (int j = i; j >= E.N - i - 1; j--)
                    suma = suma + E.Imti(i, j);
            return suma;
        }
    }
}
