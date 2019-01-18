using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace GeneticAlgoritmListApp
{
    public class Genetic
    {
        public int jenerasyonSayisi = 0;
        public int bitSayisi = 1000000;
        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public Tuple<double, double> Baslangic()
        {
            double xn, r;
            Random random = new Random();
            //xn değerimizi random aldık
            xn = random.NextDouble();
            //r değerimizi random aldık
            r = GetRandomNumber(3.5, 4.0);



            return Tuple.Create(xn, r);
        }




        public string[] Populasyon()
        {
           
            string[] pop = new string[20];
            double xnn;
            var tuple = Baslangic();
            double xn;
            double r;
            StringBuilder kromozom = new StringBuilder("");

           

            for (int i = 0; i < 20; i++)
            {
                tuple = Baslangic();
                xn = tuple.Item1;
                r = tuple.Item2;
                kromozom.Clear();
                Console.WriteLine(i);
                foreach (int j in Enumerable.Range(0, bitSayisi))
                {
                    xnn = xn * r * (1 - xn);
                    if (xnn <0.5)
                    {
                        kromozom.Append('0');
                    }
                    else
                    {
                        kromozom.Append('1');
                    }

                    xn = xnn;

                }


                pop[i] = kromozom.ToString();

                Console.WriteLine(r);
                Console.WriteLine(xn);
             
            }


            //for (int i = 0; i < 20; i++)
            //{
            //    Console.WriteLine(pop[i]);

            //}





            return pop;
        }


        public Tuple<int[], string[], string> FitnessDegeriBulma()
        {

            string[] deger = Populasyon();
            int[] birlerinSayisi = new int[20];
            int[] fitnessdegeri = new int[20];
            string minimumFitnessDegerliDizi = deger[0];
            int minFitnessDegeri = bitSayisi;
            for (int i = 0; i < deger.Length; i++)
            {
                birlerinSayisi[i] = deger[i].Count(x => x == '1');
                fitnessdegeri[i] = Math.Abs(birlerinSayisi[i] - (bitSayisi - birlerinSayisi[i]));

                Console.WriteLine(i + ". populasyonda bir= " + birlerinSayisi[i] + " sıfır= " + (bitSayisi - birlerinSayisi[i]) + " fitness degeri=" + fitnessdegeri[i]);
                if (fitnessdegeri[i] < minFitnessDegeri)
                {
                    minimumFitnessDegerliDizi = deger[i];
                    minFitnessDegeri = fitnessdegeri[i];
                }

            }


            return Tuple.Create(fitnessdegeri, deger, minimumFitnessDegerliDizi);

        }

        //Fitness degerine göre kromozom sececez. Birtane en iyi deger birtane sanslı deger
        public Tuple<string, string, string[]> KromozomSecme()
        {
            Random random = new Random();
            var tuple = FitnessDegeriBulma();
            int[] degerlerFitness = tuple.Item1;
            int sansliRandom = random.Next(0, 20);
            int minimumFitnessDegeri = degerlerFitness.Min();
            int sansliFitnessDegeri = degerlerFitness[sansliRandom];

            string sansliDizi = tuple.Item2[sansliRandom];
            string minimumDegerliDizi = tuple.Item3;

            Console.WriteLine("en iyi deger=" + minimumFitnessDegeri + " sansli deger=" + sansliFitnessDegeri);

            return Tuple.Create(minimumDegerliDizi, sansliDizi, tuple.Item2);
        }


        public void Caprazlama()
        {
            Random esikRandom = new Random();
            StringBuilder kromozom = new StringBuilder("");
            string[] pop = new string[20];
            var baslangicTuple = Baslangic();
            double xn, r, xnn;
            var tuple = KromozomSecme();
            string[] populasyon = tuple.Item3;
            string enMukemmelKromozom = tuple.Item1;
            string sansliKromozom = tuple.Item2;
           

            for (int i = 0; i < 20; i++)
            {
                baslangicTuple = Baslangic();
                xn = baslangicTuple.Item1;
                r = baslangicTuple.Item2;
                Console.WriteLine(i);
                for (int j = 0; j < bitSayisi; j++)
                {
                    xnn = xn * r * (1 - xn);
                    if (xnn < 0.5)
                    {
                        kromozom.Append(sansliKromozom[j]);
                    }
                    else
                    {
                        kromozom.Append(enMukemmelKromozom[j]);
                    }

                    xn = xnn;
                }

                pop[i] = kromozom.ToString();
                kromozom.Clear();
                Console.WriteLine(r);
                Console.WriteLine(xn);
                
            }

            int[] birlerinSayisi = new int[20];
            int[] fitnessdegeri = new int[20];
            string minimumFitnessDegerliDizi = pop[0];
            int minFitnessDegeri = bitSayisi;

            for (int i = 0; i < pop.Length; i++)
            {
                birlerinSayisi[i] = pop[i].Count(x => x == '1');
                fitnessdegeri[i] = Math.Abs(birlerinSayisi[i] - (bitSayisi - birlerinSayisi[i]));

                Console.WriteLine(i + ". populasyonda bir= " + birlerinSayisi[i] + " sıfır= " + (bitSayisi - birlerinSayisi[i]) + " fitness degeri=" + fitnessdegeri[i]);
                if (fitnessdegeri[i] < minFitnessDegeri)
                {
                    minimumFitnessDegerliDizi = pop[i];
                    minFitnessDegeri = fitnessdegeri[i];
                }

            }

            Random random = new Random();

            int[] degerlerFitness = fitnessdegeri;
            int sansliRandom = random.Next(0, 20);
            int minimumFitnessDegeri = degerlerFitness.Min();
            int sansliFitnessDegeri = degerlerFitness[sansliRandom];

            string sansliDizi = pop[sansliRandom];
            string minimumDegerliDizi = minimumFitnessDegerliDizi;

            Console.WriteLine("en iyi deger=" + minimumFitnessDegeri + " sansli deger=" + sansliFitnessDegeri);


            PopulasyonuSurdur(minimumFitnessDegerliDizi, sansliDizi, minimumFitnessDegeri);

            Console.ReadKey();


        }

        public string[] PopulasyonuSurdur(string minYeniDizi, string sansliYeniDizi, int minFitDegeri)
        {

            string[] pop = new string[20];
            if (Math.Abs(minFitDegeri) > 10)
            {
                Random esikRandom=new Random();
                StringBuilder kromozom = new StringBuilder("");
                

                double xn, r, xnn;
                for (int i = 0; i < 20; i++)
                {
                    var baslangicTuple = Baslangic();
                    xn = baslangicTuple.Item1;
                    r = baslangicTuple.Item2;
                    Console.WriteLine(i);
                    for (int j = 0; j < bitSayisi; j++)
                    {
                        xnn = xn * r * (1 - xn);
                        if (xnn <0.5)
                        {
                            kromozom.Append(sansliYeniDizi[j]);
                        }
                        else
                        {
                            kromozom.Append(minYeniDizi[j]);
                        }

                        xn = xnn;
                    }

                    pop[i] = kromozom.ToString();
                    kromozom.Clear();
                    Console.WriteLine(r);
                    Console.WriteLine(xn);
                    
                }
                int[] birlerinSayisi = new int[20];
                int[] fitnessdegeri = new int[20];
                string minimumFitnessDegerliDizi = pop[0];
                int minFitnessDegeri = bitSayisi;

                for (int i = 0; i < pop.Length; i++)
                {
                    birlerinSayisi[i] = pop[i].Count(x => x == '1');
                    fitnessdegeri[i] = Math.Abs(birlerinSayisi[i] - (bitSayisi - birlerinSayisi[i]));

                    Console.WriteLine(i + ". populasyonda bir= " + birlerinSayisi[i] + " sıfır= " + (bitSayisi - birlerinSayisi[i]) + " fitness degeri=" + fitnessdegeri[i]);
                    if (fitnessdegeri[i] < minFitnessDegeri)
                    {
                        minimumFitnessDegerliDizi = pop[i];
                        minFitnessDegeri = fitnessdegeri[i];
                    }

                }

                Random random = new Random();

                int[] degerlerFitness = fitnessdegeri;
                int sansliRandom = random.Next(0, 20);
                int minimumFitnessDegeri = degerlerFitness.Min();
                int sansliFitnessDegeri = degerlerFitness[sansliRandom];

                string sansliDizi = pop[sansliRandom];
                string minimumDegerliDizi = minimumFitnessDegerliDizi;

                Console.WriteLine("en iyi deger=" + minimumFitnessDegeri + " sansli deger=" + sansliFitnessDegeri);


                if (minFitDegeri == minimumFitnessDegeri)
                {
                    sansliDizi = Mutasyon(sansliDizi);
                }

                jenerasyonSayisi++;
                Console.WriteLine("Jenerasyon Sayısı=" + jenerasyonSayisi);
               

                return PopulasyonuSurdur(minimumDegerliDizi, sansliDizi, minimumFitnessDegeri);
            }


            Console.WriteLine(minYeniDizi);
            return pop;

        }


        public string Mutasyon(string sansliDizi)
        {
            Console.WriteLine("Mutasyona Girdi");
            Random random = new Random();
            int sayac = 0;
            StringBuilder tmp = new StringBuilder("");

            for (int t = 0; t < sansliDizi.Length; t++)
            {
                int r = random.Next(t, sansliDizi.Length);
                tmp.Append(sansliDizi[r]);
            }

            ////fitness Degeri Degisiyormu diye kontrol etmek için yazdım.
            //for (int i = 0; i < tmp.Length; i++)
            //{
            //    if (tmp[i].ToString().Equals("1"))
            //    {
            //        sayac++;
            //    }
            //}
            //Console.WriteLine(Math.Abs(sayac - (bitSayisi - sayac)));


            return tmp.ToString();

        }
    }
}
