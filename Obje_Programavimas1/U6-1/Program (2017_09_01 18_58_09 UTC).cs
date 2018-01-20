using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace U6_1
{
    //------------------------------------------------------------------------------------------
    /** Klase krepsininko duomenims saugoti
     @class Krepsininkas */
    class Krepsininkas
    {
        private string pava, vard;    // krepsininko pavarde ir vardas
        private int gim, ugis, poz, rez;   // krepsininko gimimo metai, ugis, zaidimo pozicija ir rezultatyviausia krepsininka

        //----------------------------------------------------------------
        /** Pradiniai krepsininko duomenys */
        //----------------------------------------------------------------
        public Krepsininkas()
        {
            pava = "";
            vard = "";
            gim = 0;
            ugis = 0;
            poz = 0;
            rez = 0;
        }

        //----------------------------------------------------------------------
        /** Krepsininko duomenu irasymas
         @param pava    - nauja pavardes reiksme
         @param var     - nauja vardo reiksme
         @param gim     - nauja gimimo metu reiksme
         @param ugis    - nauja ugio reiksme
         @param poz     - nauja zaidimo pozicijos reiksme  */
        //----------------------------------------------------------------------
        public void Deti(string pava, string var, int gim, int ugis, int poz)
        {
            this.pava = pava;
            this.vard = var;
            this.gim = gim;
            this.ugis = ugis;
            this.poz = poz;
        }

        /** iraso rezultatyviausia */
        public void DetiRez(int rezu) { rez = rezu; }

        /** Grazina krepsininko pavarde */
        public string ImtiPav() { return pava; }

        /** Grazina krepsininko varda */
        public string ImtiVard() { return vard; }

        /** Grazina krepsininko gimimo metus */
        public int ImtiGim() { return gim; }

        /** Grazina krepsininko ugi */
        public int ImtiUgi() { return ugis; }

        /** Grazina krepsininko pozicijas */
        public int ImtiPoz() { return poz; }

        /** Grazina krepsininko rezultatyviausia */
        public int ImtiRez() { return rez; }

        //-------------------------------------------------------
        // Spausdinimo metodas
        //-------------------------------------------------------
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -15} {1, -10}  {2,8:d}   {3,8:d}    {4,8:d}    {5,15:d}",
                pava, vard, gim, ugis, poz, rez);
            return eilute;
        }
    }

    //-----------------------------------------------------------
    /** Klase krepsininku duomenis saugoti
     @class Komanda */
    class Komanda
    {
        const int CMaxZd = 20;    // didziausias galimas zaideju skaicius
        const int CMaxRu = 10;    // didziausias galimas rungtyniu skaicius
        private Krepsininkas[] Krepsininkai;   // krepsininkas duomenys
        private int[,] Taskas;    // pelnyti taskai
        public string pav { get; set; }   // komanda klubo pavadinimas
        public string mies { get; set; }  // komanda klubo miestas
        public int n { get; set; }        // krepsininko skaicius
        public int m { get; set; }        // rungtyniu skaicius
        public Komanda()
        {
            pav = "";
            mies = "";
            n = 0;
            m = 0;
            Krepsininkai = new Krepsininkas[CMaxZd];
            Taskas = new int[CMaxRu, CMaxZd];
        }

        /** Grazina nurodyto indesko krepsininko objekta
         @param nr - krepsininko indeksas */
        public Krepsininkas Imti(int nr) { return Krepsininkai[nr]; }

        /** Padeda i krepsininku objektu masyva nauja krepsininka ir masyvo dydi padidina vienetu
         @param ob - krepsininko objektas */
        public void Deti(Krepsininkas ob) { Krepsininkai[n++] = ob;  }

        /** Pakeicia krepsininku objektu masyvo krepsininka, kurio numeris nr
         @param nr - keiciamo krepsininko numeris
         @param kre - krepsininko objekto masyva */
        public void PakeistiMokini(int nr, Krepsininkas kre) { Krepsininkai[nr] = kre; }

        /** Pakeicia imestu tasku matricos elementa
         @param i - rungtyniu numeris
         @param j - krepsininko numeris
         @param r - naujas imesti taskai */
        public void DetiTaskas(int i, int j, int r) { Taskas[i, j] = r; }

        /** Grazina imestu tasku matricos elementa
         @param i - rungtyniu numeris
         @param j - krepsininko numeris */
        public int ImtiTaskas(int i, int j) { return Taskas[i, j]; }

        //-------------------------------------------------------
        /** Objektu masyvo papildymas imestais taskais, is dvimacio masyvo */
        //-------------------------------------------------------
        public void PapildytiKrepsininkuDuomenis()
        {
            int suma;
            Krepsininkas kre;
            for (int i = 0; i < n; i++)
            {
                suma = 0;
                for (int j = 0; j < m; j++)
                    suma = suma + Taskas[j, i];
                kre = Imti(i);
                kre.DetiRez(suma);
                PakeistiMokini(i, kre);
            }
        }
    }
    class Program
    {
        //-----------------------------------------------------------------------
        /** Failo duomenis suraso i konteineri.
         @param fd      - duomenu failo vardas
         @param team    - konteineris */
        //-----------------------------------------------------------------------
        static void Skaityti(string fd, ref Komanda team)
        {
            string pav, mies, pavar, varda;
            int nn, mm, gi, cm, pozc, rezu;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts = line.Split(';');
                pav = parts[0];
                mies = parts[1];
                nn = int.Parse(parts[2]);
                mm = int.Parse(parts[3]);
                team.pav = pav;
                team.mies = mies;
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pavar = parts[0];
                    varda = parts[1];
                    gi = int.Parse(parts[2]);
                    cm = int.Parse(parts[3]);
                    pozc = int.Parse(parts[4]);
                    Krepsininkas kre = new Krepsininkas();
                    kre.Deti(pavar, varda, gi, cm, pozc);
                    team.Deti(kre);
                }
                for (int i = 0; i < mm; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    for (int j = 0; j < nn; j++)
                    {
                        rezu = int.Parse(parts[j]);
                        team.DetiTaskas(i, j, rezu);
                    }
                }
                team.m = mm;
                team.n = nn;
            }
        }
        //---------------------------------------------------------------------------
        /** Spausdina konteinerio duomenis faile.
         @param fv         - rezultatu failo vardas
         @param team       - krepsininko duomenu konteineris
         @param antraste   - uzrasas virs lenteles */
        //---------------------------------------------------------------------------
        static void Spausdinti(string fv, Komanda team, string antraste)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 100);
                fr.WriteLine(antraste);
                fr.WriteLine();
                fr.WriteLine(bruksnys);
                fr.WriteLine(" Nr. Pavarde        Vardas     Gimimo metai    Ugis(cm)    Zaidimo pozicija     Taskas");
                fr.WriteLine(bruksnys);
                for (int i = 0; i < team.n; i++)
                    fr.WriteLine("  {0}. {1}  ", i + 1, team.Imti(i).ToString());
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }
        //---------------------------------------------------------------------------
        /** Spausdina rezultatyviausia krepsininka matrica faile.
         @param fv         - rezultatu failo vardas
         @param team       - krepsininko duomenu konteineris
         @param antraste   - uzrasas virs matricos */
        //---------------------------------------------------------------------------
        static void SpausdintiTas(string fv, Komanda team, string koment)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("{0} per {1} rungtynes.", koment, team.m);
                fr.WriteLine();
                for (int i = 0; i < team.m; i++)
                {
                    fr.Write("{0,4:d}.  ", i + 1);
                    for (int j = 0; j < team.n; j++)
                        fr.Write("{0,3:d} ", team.ImtiTaskas(i, j));
                    fr.WriteLine();
                }
            }
        }
        const string CFd = "..\\..\\Duomenys.txt";
        const string CFr = "..\\..\\Rezultatai.txt";
        static void Main(string[] args)
        {
            Komanda team = new Komanda();        // komandos krepsininku duomenys
            Komanda team1 = new Komanda();
            Skaityti(CFd, ref team);
            if (File.Exists(CFr))
                File.Delete(CFr);
            using (var fr = File.CreateText(CFr))
            {
                fr.WriteLine("       Pradiniai duomenys");
                fr.WriteLine();
                fr.WriteLine(" Krepsinio klubo pavadinimas: {0}", team.pav);
                fr.WriteLine(" Klubo miestas: {0}", team.mies);
                fr.WriteLine(" Zalgirio komandoje yra {0} zaideju.", team.n);
                fr.WriteLine(" Zalgirio komanda zaide {0} rungtynes.", team.m);
                fr.WriteLine();
            }
            Spausdinti(CFr, team, "       Zalgirio komandos sarasas (pelnyti taskai = 0):");
            SpausdintiTas(CFr, team, "Krepsininkai zaide");

            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine();
                fr.WriteLine("       Rezultatai");
                fr.WriteLine();
            }
            team.PapildytiKrepsininkuDuomenis();
            Spausdinti(CFr, team, "       Zalgirio komandos sarasas ir zaideju pelnyti taskai:");

            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine();
                int zaidejas;
                Krepsininkas kre;
                RezultatyviausiaMax(team, out zaidejas);
                kre = team.Imti(zaidejas - 1);
                fr.WriteLine(" Rezultatyviausias komandos krepsininkas yra: {0} {1}   , {2,3:d} pelnyti taskai"
                    , kre.ImtiPav(), kre.ImtiVard(), kre.ImtiRez());
            }

            KiekvienaRezMax(CFr, ref team);

            Formuoti(team, ref team1);
            Spausdinti(CFr, team1, "Pasalinti du zaidejai, maziausiai rezultatyvus:");

            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine();
                fr.WriteLine("Zalgirio klubo komandos visu rezultatyviausiu: {0,4:d} tasku", VisuRezulta(team));
            }

            KiekvienaRez(CFr, ref team);

            Console.WriteLine("Programa baige darba!");
        }

        //------------------------------------------------------------------------------------
        /** Suskaiciuoja, kuria rezultatyviausia komandos krepsininka buvo daugiausiai tasku.
         @param team - konteinerio vardas
         @param eilNr - zaideju numeris */
        //------------------------------------------------------------------------------------
        static void RezultatyviausiaMax(Komanda team, out int eilNr)
        {
            eilNr = -1;
            int max = 0;
            for (int i = 0; i < team.n; i++)
            {
                int x = team.Imti(i).ImtiRez();
                if (x > max)
                {
                    max = x;
                    eilNr = i + 1;
                }
            }
        }

        //----------------------------------------------------------------------------------------
        /** Suskaiciuoja ir isspausdina, kiek rezultatyviausias krepsininkai kiekviena pozicija.
         @param fv - rezultatu failo vardas
         @param team - konteinerio vardas */
        //----------------------------------------------------------------------------------------
        static void KiekvienaRezMax(string fv, ref Komanda team)
        {
            int[] Poz = { 1, 2, 3, 4, 5 };
            int eilNr = -1;
            int taskas = 0;
            Krepsininkas kre;
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine();
                for (int i = 0; i < Poz.Length; i++)
                {
                    int max = 0;
                    for (int j = 0; j < team.n; j++)
                    {
                        int c = team.Imti(j).ImtiPoz();
                        if (c == Poz[i])
                        {
                            int x = team.Imti(j).ImtiRez();
                            if (x > max)
                            {
                                max = x;
                                eilNr = j;
                            }
                            
                            //if (x == max)
                            //    eilNr =j;
                        }
                        
                    }
                    taskas = taskas + max;
                    kre = team.Imti(eilNr);
                    fr.WriteLine("{0:d} pozicijos rezultatyviausias krepsininkas: {1} {2}  , {3,3:d} taskai",
                    i + 1, kre.ImtiPav(), kre.ImtiVard(), kre.ImtiRez());
                    
                }
                fr.WriteLine();
                fr.WriteLine("1-5 pozicijo rezultatyviausias krepsininkai is viso: {0,4:d}", taskas);
                fr.WriteLine();
            }
        }

        //-------------------------------------------------------------------------
        /** Is pirmojo konteinerio atrenka i antraji konteineri studentus, 
        // kuriu pasalinti is komandos du maziausiai tasku pelniusius krepsininkus
         @param team - primasis krepsininku konteineris
         @param team1 - antrasis krepsininku konteineris */
        //-------------------------------------------------------------------------
        static void Formuoti(Komanda team, ref Komanda team1)
        {
            int min1 = 100;
            int min2 = 100;
            for (int i = 0; i < team.n; i++)
            {
                int x = team.Imti(i).ImtiRez();
                if (min1 > x)
                    min1 = x;
                if (min2 > x && x > min1)
                    min2 = x;
            }
            for (int i = 0; i < team.n; i++)
            {
                int x = team.Imti(i).ImtiRez();
                if (x > min1 && x > min2)
                    team1.Deti(team.Imti(i));
            }
        }
        static int VisuRezulta(Komanda team)
        {
            Krepsininkas kre;
            int taskas = 0;
            for (int i = 0; i < team.n; i++)
            {
                kre = team.Imti(i);
                taskas = taskas + kre.ImtiRez();
            }
            return taskas;
        }
        static void KiekvienaRez(string fv, ref Komanda team)
        {
            int[] Poz = { 1, 2, 3, 4, 5 };
            Krepsininkas kre;
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine();
                for (int i = 0; i < Poz.Length; i++)
                {
                    int max = 0;
                    for (int j = 0; j < team.n; j++)
                    {
                        int c = team.Imti(j).ImtiPoz();
                        if (c == Poz[i])
                        {
                            kre = team.Imti(j);
                            fr.WriteLine("{0:d} pozicijos rezultatyviausias krepsininkas: {1} {2}  , {3,3:d} taskai",
                            i + 1, kre.ImtiPav(), kre.ImtiVard(), kre.ImtiRez());
                        }
                    }
                }
                fr.WriteLine();
            }
        }
    }
}
