using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace U3_1
{
    /** Klase vaismedzio duomenis saugoti
     @class Vaismedis */
    class Vaismedis
    {
        private string pav;       // vaismedzio pavadinimas
        private int amzius;       // vaismedzio amzius
        private double aukstis;   // vaismedzio aukstis
        private double augimoGreitis;  // vaismedzio augimo greitis per metus
        

        //------------------------------------------------------
        /** Vaismedzio duomenys
         @param pav - nauja pavadinimo reiksme
         @param amzius - nauja vaismedzio metai reiksme
         @param aukstis - nauja vaismedzio aukstis reiksme   */
        //-------------------------------------------------------
        public Vaismedis(string pav, double aukstis, int amzius, double augimoGreitis)
        {
            this.pav = pav;           // vaismedzio pavadinimas
            this.aukstis = aukstis;   // vaismedzio aukstis
            this.amzius = amzius;     // vaismedzio metai
            this.augimoGreitis = augimoGreitis;
            
        }

        /** grazina vaismedzio pavadinimas */
        public string ImtiPav() { return pav; }

        /** grazina vaismedzio aukstis */
        public double ImtiAuksti() { return aukstis; }

        /** grazina vaismedzio metai */
        public int ImtiAmziu() { return amzius; }

        /** grazina vaismedzio augimo greitis per metus */
        public double AugimoGreiti() { return augimoGreitis; }
        
        
    }
    class Program
    {
        //-----------------------------------------------------------------------
        /** Skaito duomenis is failo
         @param Fd       - failo vardas
         @param V        - objektu rinkinys vaismedziu duomenims saugoti
         @param var      - sodo savininkas
         @param n        - vaismedzio skaicius  */
        static void Skaityti(string Fd, Vaismedis[] V, out string vard, out int n)
        {
            
            using (StreamReader reader = new StreamReader(Fd))
            {
                string pav; double aukstis; int amzius;
                double augimoGreitis;
                string line;
                line = reader.ReadLine();
                string[] parts;
                vard = line;
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pav = parts[0];
                    aukstis = double.Parse(parts[1]);
                    amzius = int.Parse(parts[2]);
                    augimoGreitis = aukstis / amzius;
                    V[i] = new Vaismedis(pav, aukstis, amzius, augimoGreitis);
                }
            }
        }
        //---------------------------------------------------------------------------
        /** Spausdina duomenis i faila
         @param fv       - rezultatu failo vardas
         @param V        - objektu rinkinys vaismedziu duomenis saugoti
         @param pav      - sodo savininkas
         @param kiek     - vaismedziu skaicius  */
        static void SpausdintiDuomenis(string fv, Vaismedis[] V, string pav, int kiek)
        {
            const string virsus =
                "|-----------------------|---------------|-------------|\r\n"
                + "|    Pavadinimas        |   Aukstis(m)  |    Amzius   |\r\n"
                + "|                       |               |             |\r\n"
                + "|-----------------------|---------------|-------------|";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Sodo savininkas:{0}", pav);
                fr.WriteLine(virsus);
                Vaismedis tarp;
                for (int i = 0; i < kiek; i++)
                {
                    tarp = V[i];
                    fr.WriteLine("| {0,-10}            |   {1,5:f2}       |   {2,2:d}        |", 
                        tarp.ImtiPav(), tarp.ImtiAuksti(), tarp.ImtiAmziu());
                }
                fr.WriteLine("-------------------------------------------------------------------");
            }
        }
        //---------------------------------------------------------------------------
        /** Spausdina sarasas i faila
         @param fv       - rezultatu failo vardas
         @param V        - objektu rinkinys vaismedziu duomenis saugoti
         @param kiek     - vaismedziu skaicius
         @param pav      - vaismedziai auksciausiai pavadinimo sarasas  */
        static void SpausdintiSarasas(string fv, Vaismedis[] V, int kiek, string pav)
        {
            const string virsus =
                "|-----------------------|---------------|\r\n"
                + "|     Pavadinimas       |   Aukstis(m)  |\r\n"
                + "|-----------------------|---------------|";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Vaismedzio sarasas: {0}", pav);
                fr.WriteLine(virsus);
                Vaismedis tarp;
                for (int i = 0; i < kiek; i++)
                {
                    tarp = V[i];
                    fr.WriteLine("| {0,-10}            |   {1,5:f2}       |", tarp.ImtiPav(), tarp.ImtiAuksti());
                }
                fr.WriteLine("-----------------------------------------------------------");
            }
        }
        static void SpausdintiAugimo(string fv, Vaismedis[] V, int kiek, string pav)
        {
            const string virsus =
                "|-----------------------|--------------------------------|\r\n"
                + "|     Pavadinimas       |   Augimo greitis per metus(m)  |\r\n"
                + "|-----------------------|--------------------------------|";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("{0}", pav);
                fr.WriteLine(virsus);
                Vaismedis tarp;
                for (int i = 0; i < kiek; i++)
                {
                    tarp = V[i];
                    fr.WriteLine("| {0,-10}            |              {1,5:f2}             |", tarp.ImtiPav(), tarp.AugimoGreiti());
                }
                fr.WriteLine("-----------------------------------------------------------");
            }
        }
        const string CFd1 = "...\\...\\Duomen.txt";
        const string CFd2 = "...\\...\\Duomen2.txt";
        const string CFrez = "...\\...\\Rezultat.txt";
        static void Main(string[] args)
        {
            Vaismedis[] V1 = new Vaismedis[100];   // sodas duomenys
            int n1;                                // sodo kiekis
            string vard1;                            // sodo savininko

            Vaismedis[] V2 = new Vaismedis[100];
            int n2;
            string vard2;
            Skaityti(CFd1, V1, out vard1, out n1);
            Skaityti(CFd2, V2, out vard2, out n2);

            
                Console.WriteLine("Sodo savininkas: {0}", vard1);      // kontrolinis spausdinimas
            Console.WriteLine("Vaismedziu kiekis: {0}", n1);
            Console.WriteLine("Pavadinimas       Aukstis(m)         Amzius");
            for (int i = 0; i < n1; i++)
                Console.WriteLine("{0,-10}         {1,5:f2}                {2,2:d}",
                   V1[i].ImtiPav(), V1[i].ImtiAuksti(), V1[i].ImtiAmziu());            
            Console.WriteLine();
                        
            Console.WriteLine("Auksciausias vaismedis: {0}  {1,5:f2}m", 
                V1[Auksciausias(V1, n1)].ImtiPav(), V1[Auksciausias(V1, n1)].ImtiAuksti());

            Console.WriteLine("Seniausias vaismedis: {0}  {1,3:d}\n",
                V1[Seniausias(V1, n1)].ImtiPav(), V1[Seniausias(V1, n1)].ImtiAmziu());

            Console.WriteLine("Sodo savininkas: {0}", vard2);
            Console.WriteLine("Vaismedziu kiekis: {0}", n2);
            Console.WriteLine("Pavadinimas       Aukstis(m)         Amzius");
            for (int i = 0; i < n2; i++)
                Console.WriteLine("{0,-10}         {1,5:f2}                {2,2:d}",
                    V2[i].ImtiPav(), V2[i].ImtiAuksti(), V2[i].ImtiAmziu());
            Console.WriteLine();

            Vaismedis[] Vr = new Vaismedis[100];  // Nauja objekto rinkiniai Vr
            int nr;       // nr - objektu skaicius rinkinyje Vr
            nr = 0;            
            
            Vaismedis[] Vf = new Vaismedis[10];
            int nf;   // nf - objektu skaicius rinkinyje Vf
                       
            Formuoti(V1, n1, Vr, ref nr);
            Formuoti(V2, n2, Vr, ref nr);
            string pav = Vr[Auksciausias(Vr, nr)].ImtiPav();
            Console.WriteLine("Atrinktu aismedziu sarasas:");
            Console.WriteLine("Pavadinimas       Aukstis(m)");
            SutampaPav(Vr, Vf, nr, pav, out nf);            

            if (V1[Auksciausias(V1, n1)].ImtiAuksti() < V2[Auksciausias(V2, n2)].ImtiAuksti())
                Console.WriteLine("Visu auksciausias vaismedis {0} sode:  {1}  {2,5:f2}m\n",
                    vard2, V2[Auksciausias(V2, n2)].ImtiPav(), V2[Auksciausias(V2, n2)].ImtiAuksti());
            else Console.WriteLine("Visu auksciausias vaismedis {0} sode:  {1}  {2,5:f2}m\n",
                    vard1, V1[Auksciausias(V1, n1)].ImtiPav(), V1[Auksciausias(V1, n1)].ImtiAuksti());

            if (File.Exists(CFrez))
                File.Delete(CFrez);

            SpausdintiDuomenis(CFrez, V1, vard1, n1);
            using (var fr = File.AppendText(CFrez))
            {
                fr.WriteLine("Auksciausias vaismedis: {0}  {1,5:f2}m",
                V1[Auksciausias(V1, n1)].ImtiPav(), V1[Auksciausias(V1, n1)].ImtiAuksti());

                fr.WriteLine("Seniausias vaismedis: {0}  {1,3:d}\n",
                    V1[Seniausias(V1, n1)].ImtiPav(), V1[Seniausias(V1, n1)].ImtiAmziu());
            }

            SpausdintiDuomenis(CFrez, V2, vard2, n2);
            SpausdintiSarasas(CFrez, Vf, nf, "Atrinktu aismedziu sarasas:");

            using (var fr = File.AppendText(CFrez))
            {
                if (V1[Auksciausias(V1, n1)].ImtiAuksti() < V2[Auksciausias(V2, n2)].ImtiAuksti())
                    fr.WriteLine("Visu auksciausias vaismedis {0} sode:  {1}  {2,5:f2}m\n",
                        vard2, V2[Auksciausias(V2, n2)].ImtiPav(), V2[Auksciausias(V2, n2)].ImtiAuksti());
                else fr.WriteLine("Visu auksciausias vaismedis {0} sode:  {1}  {2,5:f2}m\n",
                        vard1, V1[Auksciausias(V1, n1)].ImtiPav(), V1[Auksciausias(V1, n1)].ImtiAuksti());
            }
            

            SpausdintiAugimo(CFrez, Vr, nr, "k");
        }
        //---------------------------------------------
        /** Grazina vaismedzio, kurio auksciu skaicius yra maziausias, indeksa
         @param V - objektu rinkinys
         @param n - objektu skaicius rinkinyje  */
        //---------------------------------------------
        static int Auksciausias(Vaismedis[] V, int n)
        {
            int k = 0;
            for (int i = 0; i < n; i++)
                if (V[i].ImtiAuksti() > V[k].ImtiAuksti())
                    k = i;
            return k;
        }
        //--------------------------------------------
        /** Grazina vaismedzio, kurio metu skaicius yra maziausias, indeksa
         @param V - objektu rinkinys
         @param n - objektu skaicius rinkinyje  */
        //-------------------------------------------
        static int Seniausias(Vaismedis[] V, int n)
        {
            int k = 0;
            for (int i = 0; i < n; i++)
                if (V[i].ImtiAmziu() > V[k].ImtiAmziu())
                    k = i;
            return k;
        }
        //------------------------------------------------------------------------
        /** Objektu rinkini papildo duomenimis is kito objektu rinkinio
        // Jeigu objektu rinkinio V tokio pat saraso vaismedzio yra objektu rinkinyje Vr,
        // tuomet didinamas kiekis, kitaip - papildomas nauju objektu
         @param V - objektu rinkinys, is kurio pildo
         @param n - objektu skaicius rinkinyje V
         @param Vr - objektu rinkinys, kuri pildo                 
         @param nr - objektu skaicius rinkinyje Vr  */
        static void Formuoti(Vaismedis[] V, int n, Vaismedis[] Vr, ref int nr)
        {
            
            for (int i = 0; i < n; i++)
            {                
                Vr[nr] = V[i];              // papildomas rinkinys
                nr++;
            }
        }
        //----------------------------------------------------------------------------------
        /** Objektu rinkini papildo duomenis is kito objektu rinkinio
         // Jei objektu rinkinio Vr tokio pat sutampa sarasas vaismedzio yr objetktu rinkinyje Vf,
         // tuomet atskira rinkinio visus vaismedzius, kuris sutampa su auksciausio vaismedzio pavadinimu
         @param Vr    - objektu rinkinys, is kurio pildo
         @param Vf    - objektu rininys, kuri pildo
         @param nr    - objektu skaicius rinkinyje Vr
         @param pav   - objektu kas auksciausiai vaismedziai rinkinyje
         @param kiek  - objektu skaicius rinkinyje Vf  */
        static int SutampaPav(Vaismedis[] Vr, Vaismedis [] Vf, int nr, string pav, out int kiek)
        {
            kiek = 0;
            for (int i = 0; i < nr; i++)
            {
                if (Vr[i].ImtiPav() == pav)
                {
      
                    Console.WriteLine("{0,-10}        {1,5:f2}m",
                        Vr[i].ImtiPav(), Vr[i].ImtiAuksti());
                    Vf[kiek] = Vr[i];
                    kiek++;
                }
            }            
            return (int)kiek;
        }
    }
}
    

