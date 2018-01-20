using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_1
{
    class Medis
    {
        private int amzius;
        private double aukstis,
            lajos;
        public Medis(int amzius, double lajos, double aukstis)
        {
            this.amzius = amzius;
            this.lajos = lajos;
            this.aukstis = aukstis;
        }
        public int ImtiAmziu() { return amzius; }
        public double ImtiLajos() { return lajos; }
        public double ImtiAuksti() { return aukstis; }
    }
    class Parkas
    {
        private int ilgis,
            plotis;
        public Parkas(int ilgis, int plotis)
        {
            this.ilgis = ilgis;
            this.plotis = plotis;
        }
        public int ImtiIlgi() { return ilgis; }
        public int ImtiPloti() { return plotis; }
    }
    class Sodas
    {
        private int ilgis,
            plotis;
        public Sodas()
        {
        }
        public void DetiIlgi(int ilgis)
        {
            this.ilgis = ilgis;
        }
        public void DetiPloti(int plotis)
        {
            this.plotis = plotis;
        }
        public int ImtiIlgi() { return ilgis; }
        public int ImtiPloti() { return plotis; }
        public int RastiIlgi(double skaicius, double lajos)
        {
            double suma;
            suma = ilgis * skaicius / lajos;
            return (int)suma;
        }
        public int RastiPloti(double skaicius, double lajos)
        {
            double suma;
            suma = plotis * skaicius / lajos;
            return (int)suma;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Medis m1, m2, m3;
            m1 = new Medis(90, 45.8, 65.7);
            m2 = new Medis(62, 25.0, 60.6);
            m3 = new Medis(86, 34.8, 68.0);

            Parkas p;
            p = new Parkas(200, 100);

            Sodas s;
            s = new Sodas();

            s.DetiIlgi(500);
            s.DetiPloti(400);


            Console.WriteLine("(Liepos medis:\t      amzius,\t       aukstis,\t        lajos dydis)");
            Console.WriteLine("1 liepos medis:\t\t {0} \t\t{1:f}m \t\t{2:f}m", m1.ImtiAmziu(), m1.ImtiAuksti(), m1.ImtiLajos());
            Console.WriteLine("2 liepos medis:\t\t {0} \t\t{1:f}m \t\t{2:f}m", m2.ImtiAmziu(), m2.ImtiAuksti(), m2.ImtiLajos());
            Console.WriteLine("3 liepos medis:\t\t {0} \t\t{1:f}m \t\t{2:f}m\n", m3.ImtiAmziu(), m3.ImtiAuksti(), m3.ImtiLajos());

            double maxAukstis = m1.ImtiAuksti();
            int maxAmzius = m1.ImtiAmziu();
            if (m2.ImtiAuksti() > maxAukstis)
            {
                maxAukstis = m2.ImtiAuksti();
            }
            if (m3.ImtiAuksti() > maxAukstis)
            {
                maxAukstis = m3.ImtiAuksti();
            }
            if (m2.ImtiAmziu() > maxAmzius)
            {
                maxAmzius = m2.ImtiAmziu();
            }
            if (m3.ImtiAmziu() > maxAmzius)
            {
                maxAmzius = m3.ImtiAmziu();
            }
            Console.WriteLine("Auksciausias liepos medis: {0:f}m \nSeniausias liepos medis: {1,5}metu\n", maxAukstis, maxAmzius);

            Console.WriteLine("1-o tipo parke gali augti: {0}", MedziuKiekParke(p, m1));
            Console.WriteLine("2-o tipo parke gali augti: {0}", MedziuKiekParke(p, m2));
            Console.WriteLine("3-o tipo parke gali augti: {0}\n", MedziuKiekParke(p, m3));





            double maxLajos = m1.ImtiLajos();
            if (m2.ImtiLajos() > maxLajos)
            {
                maxLajos = m2.ImtiLajos();
            }
            if (m3.ImtiLajos() > maxLajos)
            {
                maxLajos = m3.ImtiLajos();
            }
            double minLajos = m2.ImtiLajos();
            if (m1.ImtiLajos() < minLajos)
            {
                minLajos = m1.ImtiLajos();
            }
            if (m3.ImtiLajos() < minLajos)
            {
                minLajos = m3.ImtiLajos();
            }

            Console.WriteLine("Didziausios lajos liepos medis: {0:f} \nMaziausios lajos liepos medis: {1,3:f}\n", maxLajos, minLajos);
            Console.WriteLine("Sode gali augti maziausiu liepu: {0:d}\n", s.RastiIlgi(Math.Sqrt(1), minLajos) * s.RastiPloti(Math.Sqrt(1), minLajos));
            Console.WriteLine("2 kart didesniame sode gali augti didziausiu liepu: {0:d}\n", s.RastiIlgi(Math.Sqrt(2), maxLajos) * s.RastiPloti(Math.Sqrt(2), maxLajos));



            Console.WriteLine("Programa baige darba!");

        }
        static int MedziuKiekParke(Parkas p, Medis m)
        {
            int suma;
            suma = (int)(p.ImtiIlgi() / m.ImtiLajos()) * (int)(p.ImtiPloti() / m.ImtiLajos());
            return suma;

        }
    }
}
