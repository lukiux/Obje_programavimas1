using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace U4_1
{
    /** Bukletas klase
     @class Bukletas */
    class Bukletas
    {
        private string formatas;    // bukleto formatas
        private int kaina,          // 500 lapu tokio formato popieriaus pakuotes kaina
            skaicius,               // bukleto lapu skaicius
            kiekis;                 // egzemplioriu kiekis

        //-----------------------------------------------------------------------
        /** Bukletas duomenys
         @param form   -  nauja bukleto formato reiksme
         @param kain   -  nauja popieriaus pakuotes kainos reiksme
         @param skaic  -  nauja bukleto lapu skaicio reiksme
         @param kiek   -  nauja egzemplioriu kiekio reiksme   */
        public Bukletas(string form, int kain, int skaic, int kiek)
        {
            formatas = form;
            kaina = kain;
            skaicius = skaic;
            kiekis = kiek;
        }
        
        //---------------------------------------------------------------------------
        // Spausdinimo metodas
        //---------------------------------------------------------------------------
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -4}                     {1, 3}                       {2, 4}                           {3, 2}",
                formatas, kaina, skaicius, kiekis);
            return eilute;
        }

        /** Grazina 500 lapu tokio formato popieriaus pakuotes kaina */
        public int ImtiKaina() { return kaina; }
        /** Grazina bukleto lapu skaiciu */
        public int ImtiSkaiciu() { return skaicius; }
        /** Grazina egzemplioriu kieki */
        public int ImtiKieki() { return kiekis; }
        /** Grazina bukleto formata */
        public string ImtiForm() { return formatas; }
        //--------------------------------------------------------------------------
        /** Operatorius grazina
         // true, jeigu skaicius yra didesnis uz kita skaiciu, arba skaiciai yra lygus,
         // o kiekis yra didesnis uz kita kieki;
         // false - kitais atvejais. */
        
        public static bool operator >=(Bukletas bu1, Bukletas bu2)
        {
            int p = String.Compare(bu1.formatas, bu2.formatas, StringComparison.CurrentCulture);
            return (bu1.skaicius > bu2.skaicius || (bu1.skaicius == bu2.skaicius && bu1.kiekis > bu2.kiekis));
        }
        //--------------------------------------------------------------------------
        /** Operatorius grazina
         // true, jeigu skaicius yra mazesnis uz kita skaiciu, arba skaiciai yra lygus,
         // o kiekis yra mazesnis uz kita kieki;
         // false - kitais atvejais. */
        public static bool operator <=(Bukletas bu1, Bukletas bu2)
        {
            int p = String.Compare(bu1.formatas, bu2.formatas, StringComparison.CurrentCulture);
            return (bu1.skaicius < bu2.skaicius || (bu1.skaicius == bu2.skaicius && bu1.kiekis < bu2.kiekis));
        }
    }

    //-----------------------------------------------------------------
    /** GamybaKaina 
     @class GamybaKaina  */
    class GamybaKaina
    {
        private string formatas;   // bukleto formatas
        private double kaina;      // bukleto gamybai reikalingo popieriaus kaina
        
        //-----------------------------------------------------------------------
        /** GamybaKaina duomenis
         @param form  -  nauja formatas reiksme
         @param kain  -  nauja kainos reiksme */
        public GamybaKaina(string form, double kain)
        {
            formatas = form;
            kaina = kain;
        }
        //---------------------------------------------------------------------------
        // Spausdinimo metodas
        //---------------------------------------------------------------------------
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -3}                             {1,4:f2}", formatas, kaina);
            return eilute;
        }
        /** Grazina kaina */
        public double ImtiVidurki() { return kaina; }
        /** Grazina formata */
        public string ImtiForma() { return formatas; }
    }
    //--------------------------------------------------------------
    /** Bukletas ir GamybaKaina duomenis saugoti
     @class Popierius  */
    class Popierius
    {
        const int CMax = 50;
        private Bukletas[] Bk;
        private Bukletas[] BkAtr;
        private GamybaKaina[] Gk;
        private int n;
        private int kiekAtr;
        private int m;
        public Popierius()
        {
            m = 0;
            n = 0;
            kiekAtr = 0;
            Bk = new Bukletas[CMax];
            BkAtr = new Bukletas[CMax];
            Gk = new GamybaKaina[CMax];

        }
        /** Grazina gamybaKaina kieki  */
        public int Imti() { return m; }
        /** Grazina bukletu kieki  */
        public int ImtiN() { return n; }
        /** Grazina atrinktu bukletu kieki  */
        public int ImtiKiekAtr() { return kiekAtr; }
        /** Grazina nurodyto indekso bukleto atrinkta objekta.
         @param i - atrinkto bukleto indeksas */
        public Bukletas ImtiAtr(int i) { return BkAtr[i]; }
        /** Grazina nurodyto indesko bukleto objekta.
         @param i - bukleto indeksas */
        public Bukletas Imti(int i) { return Bk[i]; }
        /** Grazina nurodyto indesko gamybaKaina objekta.
         @param i - gamybakaina indeksas */
        public GamybaKaina ImtiG(int i) {return Gk[i]; }
        /** Padeda i bukletu masyva nauja bukleta ir
         // masyvo dydi padidina vienetu.
         @param ob - bukleto objektas  */
        public void Deti(Bukletas ob) { Bk[n++] = ob; }
        /** Padeda i gamybaKaina masyva nauja gamybaKaina ir
         // masyvo dydi padidina vienetu.
         @param ob - gamybaKaina objektas  */
        public void DetiGamyba(GamybaKaina ob) {Gk[m++] = ob; }
        
        public void PopieriusKaina(ref Popierius lapus)
        {
            double lapas = 500.0;
            double vidurkis;
            string form;          
            
            for (int i = 0; i < n; i++)
            {                
                form = Bk[i].ImtiForm();
                vidurkis = Bk[i].ImtiSkaiciu() / lapas * Bk[i].ImtiKaina();                
                GamybaKaina ob = new GamybaKaina(form, vidurkis);                
                lapus.DetiGamyba(ob);
            }
        }        
        public double Pigiausiai()
        {
            double lapas = 500.0;
            double min = (Bk[0].ImtiSkaiciu() / lapas * Bk[0].ImtiKaina()) * Bk[0].ImtiKieki();
            double suma;
            double rez = 0.0;
            for (int i = 1; i < n; i++)
            {
                suma = Bk[i].ImtiSkaiciu() / lapas * Bk[i].ImtiKaina();
                rez = suma * Bk[i].ImtiKieki();
                if (rez < min)
                {
                    min = rez;
                   
                }
            }
            return min;            
        }

        public void Atrinkti()
        {
            int riba = 500;
            kiekAtr = 0;
            for (int i = 0; i < n; i++)
                if (Bk[i].ImtiSkaiciu() < riba)
                {
                    BkAtr[kiekAtr++] = Bk[i];
                }
        }


        public void Rikiuoti()
        {
            
            for (int i = 0; i < kiekAtr; i++)
            {
                        Bukletas max = BkAtr[i];
                        int im = i;
                        for (int l = i+1; l < kiekAtr; l++)
                            if (BkAtr[l]<= max)
                            {
                                max = BkAtr[l];
                                im = l;
                            }
                        BkAtr[im] = BkAtr[i];
                        BkAtr[i] = max;
                    }
                }
        
    }
        class Program
        {
            const string CFd = "...\\...\\U4-1.txt";
            const string CFr = "...\\...\\Rezult.txt";
            static void Skaityti(ref Popierius lapas, string fv)
            {
                string form;
                int kain, skaic, kiek, n;
                string line;
                using (StreamReader reader = new StreamReader(fv))
                {
                    n = int.Parse(reader.ReadLine());
                    for (int i = 0; i < n; i++)
                    {
                        line = reader.ReadLine();
                        string[] parts = line.Split(' ');
                        form = parts[0];
                        kain = int.Parse(parts[1]);
                        skaic = int.Parse(parts[2]);
                        kiek = int.Parse(parts[3]);
                        Bukletas ob = new Bukletas(form, kain, skaic, kiek);
                        lapas.Deti(ob);
                    }
                }
            }
            static void Spausdinti(Popierius lapas, string fv)
            {
                const string virsus = "--------------------------------------------------------------------------------------\r\n"
                    + "  Bukleto formatas     Popieriaus pakuotes kaina  Bukleto lapu skaicius  Egzemplioriu kiekis\r\n"
                    + "--------------------------------------------------------------------------------------";
                using (var fr = File.AppendText(fv))
                {
                    fr.WriteLine(virsus);
                    for (int i = 0; i < lapas.ImtiN(); i++)
                        fr.WriteLine("{0}", lapas.Imti(i).ToString());
                    fr.WriteLine("----------------------------------------------------------------------------------------");
                }
            }

            static void SpausdintiAtr(Popierius lapas, string fv)
            {
                const string virsus = "--------------------------------------------------------------------------------------\r\n"
                    + "  Bukleto formatas     Popieriaus pakuotes kaina  Bukleto lapu skaicius  Egzemplioriu kiekis\r\n"
                    + "--------------------------------------------------------------------------------------";
                using (var fr = File.AppendText(fv))
                {
                    fr.WriteLine(virsus);
                    for (int i = 0; i < lapas.ImtiKiekAtr(); i++)
                        fr.WriteLine("{0}", lapas.ImtiAtr(i).ToString());
                    fr.WriteLine("----------------------------------------------------------------------------------------");
                }
                Console.WriteLine(virsus);
                for (int i = 0; i < lapas.ImtiKiekAtr(); i++)
                    Console.WriteLine("{0}", lapas.ImtiAtr(i).ToString());
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }

            static void Spausdinti2(Popierius lapas, string fv, string antrastes)
            {
                const string virsus = "-----------------------------------------------------------------\r\n"
                    + "   Bukleto formantas         Gamybine kaina\r\n"
                    + "----------------------------------------------------------";
                using (var fr = File.AppendText(fv))
                {
                    fr.WriteLine(antrastes);
                    fr.WriteLine(virsus);
                    for (int i = 0; i < lapas.Imti(); i++)
                        fr.WriteLine("{0}", lapas.ImtiG(i).ToString());
                    fr.WriteLine("---------------------------------------------------");
                }
            }
            static void Main(string[] args)
            {
                Popierius lapas = new Popierius();
                if (File.Exists(CFr))
                    File.Delete(CFr);
                Skaityti(ref lapas, CFd);
                Spausdinti(lapas, CFr);
                
                lapas.PopieriusKaina(ref lapas);
                Spausdinti2(lapas, CFr, "Gamybai reikalingo popieriaus kaina");

                
                
                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine("Pigiausio uzsakymo kaina: {0:f2}", lapas.Pigiausiai());
                }
                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine("Rikiuoti bukletai, kuriu lapu skaicius <500");
                }
                lapas.Atrinkti();
                lapas.Rikiuoti();
                SpausdintiAtr(lapas, CFr);
                Console.WriteLine("Programa baige darba!");
            }
            

        }
    }
