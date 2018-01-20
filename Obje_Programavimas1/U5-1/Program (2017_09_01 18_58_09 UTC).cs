using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace U5_1
{
    class Program
    {
        //----------------------------------------------------------
        /** Iesko ilgiausio zodzio eiluteje ir grazina rezultata per varda.
         @param eilute       - duomenu eilute
         @param skyrikliai   - zodziu skyrikliai  */
        //-----------------------------------------------------------
        static string Ilgiausias(string eilute, char[] skyrikliai)
        {
            string[] parts = eilute.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
            string ilgiaus = "";
            
            foreach (string zodis in parts)
                if (zodis.Length > ilgiaus.Length)
                    ilgiaus = zodis;
            return ilgiaus;
        }

        //------------------------------------------------------------------
        /** Is zodzio pasalina ilgiausius žodžius ir grazina rezultata per naują eilutę.
         @param line      - duomenu eilute
         @param ilgiaus   - kiekvienos eilutes ilgiausia zodi
         @param skyrikliai - zodziu skyrikliai */
        //------------------------------------------------------------------
        static StringBuilder Pasalinti(string line, string ilgiaus, char[] skyrikliai)
        {
            StringBuilder nauja = new StringBuilder();
            string papild = " " + line + " ";
            int ind = papild.IndexOf(ilgiaus);
            string skyrstring = new string(skyrikliai);

            int prad = 1;
            while (ind != -1)
            {
                
                nauja.Append(papild.Substring(prad, ind - prad));
                prad = ind + ilgiaus.Length;
                ind = papild.IndexOf(ilgiaus, ind + 1);
            }
            nauja.Append(line.Substring(prad - 1));
            return nauja;
                
        }

        //--------------------------------------------------------------
        /** Skaito faila, analizuoja eilutes, kuria rezultatu failus.
         @param fd        - duomenu failo vardas
         @param fr        - rezultatu failo vardas
         @param fa        - analizes failo vardas
         @param skyrikliai - zodziu skyrikliai  */
        //--------------------------------------------------------------
        static void Apdoroti(string fd, string fr, string fa, char[] skyrikliai)
        {
            string[] lines = File.ReadAllLines(fd, Encoding.GetEncoding(1257));
            string eilute = new string('-', 38);
            using (var far = File.CreateText(fr))
            {
                using (var faa = File.CreateText(fa))
                {
                    faa.WriteLine(eilute);
                    faa.WriteLine("| Ilgiausias zodis | Pradzia | Ilgis |");
                    faa.WriteLine(eilute);
                    foreach (string line in lines)
                        if (line.Length > 0)
                        {
                            StringBuilder nauja = new StringBuilder();
                            string ilgiaus = Ilgiausias(line, skyrikliai);
                            string pasalinti = Pasalinti(line, ilgiaus, skyrikliai).ToString();
                            faa.WriteLine("| {0, -16} | {1, 7:d} | {2, 5:d} |", 
                                ilgiaus, line.IndexOf(ilgiaus), ilgiaus.Length);
                            nauja.Append(pasalinti);
                            far.WriteLine(nauja);
                        }
                        else
                            far.WriteLine(line);
                    faa.WriteLine(eilute);
                }
            }
        }
        const string CFd = "..\\..\\Duomenys.txt";
        const string CFr = "..\\..\\Rezultatai.txt";
        const string CFa = "..\\..\\Analize.txt";
        static void Main(string[] args)
        {
            char[] skyrikliai = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            Apdoroti(CFd, CFr, CFa, skyrikliai);

            Console.WriteLine("Programa baige darba!");
        }
    }
}
