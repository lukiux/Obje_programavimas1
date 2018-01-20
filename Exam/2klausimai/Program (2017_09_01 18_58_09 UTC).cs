using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2klausimai
{
    
    class Program
    {
        static void Skaityti(string fv, string zodis, out int enr, out int nr)
        {
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                int n = 0;
                enr = -1;
                nr = -1;
                while (((line = reader.ReadLine()) != null) && enr == -1)
                {
                    n++;
                    nr = line.IndexOf(zodis);
                    if (nr > -1)
                        enr = n;
                }
            }
        }
        static void RastiIlgausFaile(string fv, char[] skyr, out int enr, out int pr, out int ilg)
        {
            enr = -1; pr = -1; ilg = 0;
            int n = 0;
            int ilge = 0; int pre = -1; string zodisilge = "";
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    n++;
                    if (line.Length > 0)
                    {
                        string[] parts = line.Split(skyr, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string zodis in parts)
                            if (zodis.Length > zodisilge.Length)
                                zodisilge = zodis;
                        pre = line.IndexOf(zodisilge);
                        ilge = zodisilge.Length;
                        if (ilge > ilg)
                        {
                            ilg = ilge;
                            pr = pre;
                            enr = n;
                        }
                    }
                }
            }
        }
        static void SkaitytiPasalinti(string fv, int n)
        {
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                for (int i = 0; i < n && ((line = reader.ReadLine()) != null); i++)
                    Console.WriteLine(line);
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                    Console.WriteLine(line);
            }
        }
        static void SkaitytiIterpi(string fv, string eil, int n)
        {
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                for (int i = 0; i <= n && ((line = reader.ReadLine()) != null); i++)
                    Console.WriteLine(line);
                Console.WriteLine(eil);
                while ((line = reader.ReadLine()) != null)
                    Console.WriteLine(line);
            }
        }
        static void SkaitytiKeisti(string fv, int n1, int n2)
        {
            string line2 = "";
            string line1 = "";
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                for (int i = 0; i < n1 && ((line = reader.ReadLine()) != null); i++)
                    line1 = reader.ReadLine();
                for (int i = n1 + 1; i < n2 && ((line = reader.ReadLine()) != null); i++)
                    line2 = reader.ReadLine();
            }
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                for (int i = 0; i < n1 && ((line = reader.ReadLine()) != null); i++)
                    Console.WriteLine(line);
                line = reader.ReadLine();
                Console.WriteLine(line2);
                for (int i = n1 + 1; i < n2 && ((line = reader.ReadLine()) != null); i++)
                    Console.WriteLine(line);
                line = reader.ReadLine();
                Console.WriteLine(line1);
                while ((line = reader.ReadLine()) != null)
                    Console.WriteLine(line);
            }
        }
        static void PasalinimasTek(string fv, string skyrikliai, string zg)
        {
            string line1 = "";
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                
                while ((line = reader.ReadLine()) != null)
                {
                    string[] zodis = line.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    string p;
                    for (int i = 0; i < zodis.Length; i++)
                    {
                        p = zodis[i] + " ";

                        if (p == zg)
                        {
                            //int ind = line.IndexOf(p);
                            //string eil1 = line.Remove(ind, p.Length);
                            //line = eil1.Insert(eil1.Length, " " + p);
                            //line = eil1.Insert(0, p);
                            //Console.WriteLine(line);
                            line1 = line;
                            break;
                        }
                    }
                    //Console.WriteLine(line);
                    break;
                }
                //Console.WriteLine(line1);
            }
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    if (line != line1)
                        Console.WriteLine(line);
                Console.WriteLine(line1);
            }
        }
        static void PasalinimasText(string fv)
        {
            int nr = 0;
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                int ilg = 0;
                int n = -1;

                while ((line = reader.ReadLine()) != null)
                {
                    n++;
                    if (line.Length > ilg)
                    {
                        ilg = line.Length;
                        nr = n;
                    }
                }
            }
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                for (int i = 0; i < nr && ((line = reader.ReadLine()) != null); i++)
                    Console.WriteLine(line);
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                    Console.WriteLine(line);
            }
        }
        static void RastiZodi(ref string e, string skyrikliai, string zg)
        {
            string[] zodis = e.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string p;
            for (int i = 0; i < zodis.Length; i++)
            {
                p = zodis[i] + " ";
                if (p == zg)
                {
                    int ind = e.IndexOf(zg);
                    string eil1 = e.Remove(ind, p.Length);
                    e = eil1.Insert(eil1.Length, " " + p);
                    //e = eil1.Insert(0, p);
                    //break;
                }
            }            
        }
        static void RastiZodi2(ref string e, string skyrikliai, string zg)
        {
            string[] zodis = e.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string p;
            for (int i = 0; i < zodis.Length; i++)
            {
                p = zodis[i];
                //if (p.StartsWith(zg))
                if (p.EndsWith(zg))
                {
                    int ind = e.IndexOf(p);
                    string eil1 = e.Remove(ind, p.Length + 1);
                    e = eil1.Insert(eil1.Length, " " + p);
                    //e = eil1.Insert(0, p + " ");
                    break;
                }
            }
        }
        static void ZodziuPasalinimas(ref string e, string skyrikliai, string zg)
        {
            string[] zodis = e.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string p;
            for (int i = 0; i < zodis.Length; i++)
            {
                p = zodis[i] + " ";
                if (p == zg)
                {
                    int ind = e.IndexOf(p);
                    string eil1 = e.Remove(ind, p.Length);
                    e = eil1;
                    break;
                }
            }
        }
        static void Insert(ref string e, string skyrikliai, string zg, string lg)
        {
            string[] zodis = e.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string p;
            for (int i = 0; i < zodis.Length; i++)
            {
                p = zodis[i] + " ";
                if (p == zg)
                {
                    int ind = e.IndexOf(zg);
                    e = e.Insert(ind + p.Length, lg);
                    break;
                }
            }
        }
        static void Keisti(ref string e, string skyrikliai, string zg, string lg)
        {
            string[] zodis = e.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string p;
            for (int i = 0; i < zodis.Length; i++)
            {
                p = zodis[i] + " ";
                if (p == zg)
                {
                    int ind = e.IndexOf(zg);
                    string eil = e.Remove(ind, p.Length);
                    e = eil.Insert(ind, lg);
                    break;
                }
            }
        }
        static void Keisti2(ref string e, string zg, string lg)
        {
            e = e.Replace(zg, lg);
            
        }
        const string CFd = "..\\..\\Duomenys.txt";
        static void Main(string[] args)
        {
            string eilu = "As noriu ziureti matyt ziureti darzoves.";
            string zg = "ziuretis ";
            string lm = "tis";
            string skyrik = " .,:;?!()";
            char[] skyr = {' ', ',',';', ':','?','!','(', ')'};
            string lg = "Lukas ";
            int nr;
            int enr;
            string zodis = "Kauno ";
            //Skaityti(CFd, zodis, out enr, out nr);
            //Console.WriteLine("{0} {1}", enr, nr);
            //PasalinimasTek(CFd, skyrik, zodis);
            //RastiZodi(ref eilu, skyrik, zg);
            //ZodziuPasalinimas(ref eilu, skyrik, zg);
            //Insert(ref eilu, skyrik, zg, lg);
            //RastiZodi2(ref eilu, skyrik, lm);
            //Keisti(ref eilu, skyrik, zg, lg);
            //Keisti2(ref eilu, zg, lg);
            //Console.WriteLine(eilu);
            //int pr, ilg;
            //RastiIlgausFaile(CFd, skyr, out enr, out pr, out ilg);
            //Console.WriteLine("{0} {1} {2}", enr, pr, ilg);
            PasalinimasText(CFd);
        }
    }
}
