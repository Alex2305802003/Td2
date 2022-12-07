using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace affichenombrepremier
{
    class TD1
    {
        public static int NombreFacteur(int N)
        {
            int Count = 2, I;
            double Racine = Math.Sqrt(N);
            for (I = 2; I <= Racine; I++)
                if (N % I == 0)
                    Count++;
            return Count;
        }

        public static bool Premier(int N)
        {
            return (NombreFacteur(N) == 2);
        }

        public static int Erathostene(int N)
        {
            Console.WriteLine("Liste des nombres premier avant " + N + " : ");

            for (int I = 2; I < N; I++)
                if (Premier(I))
                    Console.Write((int)I + " ");
            Console.WriteLine();
            return 0;
        }

        public static int PGCD(int a, int b)
        {
            int temp = a % b;
            if (temp == 0)
                return b;
            return PGCD(b, temp);
        }

        public static int PremierEntreEux(int a, int b)
        {
            if (PGCD(a, b) == 1)
            {
                Console.WriteLine(a + " et " + b + " son premier entre eux.");
            }
            else
            {
                Console.WriteLine(a + " et " + b + " ne sont pas premier entre eux.");
            }
            return 0;
        }

        public static int DFP(int N)
        {
            int div = 2;
            Console.Write("La décomposition en facteur premier de " + N + " = ");
            while (N != 1)
            {
                while (N % div == 0)
                {
                    N /= div;
                    if (N != 1)
                        Console.Write(div + " * ");
                    else
                        Console.Write(div + "\n");
                }
                if (div > 2)
                    div += 2;
                else
                    ++div;
            }
            return 0;
        }

        static int Phi(int n)
        {
            int result = 1;
            for (int i = 2; i < n; i++)
                if (PGCD(i, n) == 1)
                    result++;
            return result;
        }

        /*static string ConversionEntierBinaire (int n)
        {
            string resultat;
            resultat = Convert.ToString(n, 2);
            return resultat;
        } */

        static int ExponentationModulaireLente(int a, int b, int n)
        {
            int res = a % n;    // b = puissance et n = modulo 

            for (int i = 2; i <= b; i++)
            {
                res = (res * a) % n;
            }
            Console.Write("L'exponation modulaire de " + a + " puissance " + b + " modulo " + n + " vaut ");
            return res;
        }

        /* static int ExponentationModualaireRapide (int a, int b, int n)
        {
            int res = 1;
            List<string> binaire = new List<string>();
            binaire.Add(ConversionEntierBinaire(b));
            return res;
        } */

        static int RSA()
        {
            int n, z, p, q, e, d;

            p = 47;
            q = 71;
            e = 79;

            n = p * q;
            z = (p - 1) * (q - 1);

            d = e ^ Phi(z);  //faire algo euclide etendu 

            Console.WriteLine(n + " , " + z + " , " + d);
            return 0;
        }

        static void Main(string[] args)
        {
            int N, a, b, x, d, y, z, p;    //Initialisation des variables

            Console.WriteLine("Saisir un entier N : "); //Demande la saisie d'un nombre entier
            N = Convert.ToInt32(Console.ReadLine());    //Saisie N

            Console.WriteLine("Saisir un entier a : "); //Demande la saisie d'un nombre entier
            a = Convert.ToInt32(Console.ReadLine());    //Saisie a

            Console.WriteLine("Saisir un entier b : "); //Demande la saisie d'un nombre entier
            b = Convert.ToInt32(Console.ReadLine());    //Saisie b  

            Console.WriteLine("Saisir un entier x : "); //Demande la saisie d'un nombre entier
            x = Convert.ToInt32(Console.ReadLine());    //Saisie x

            Console.WriteLine("Saisir un entier d : ");
            d = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Saisir un entier y : ");
            y = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Saisir un entier z : ");
            z = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Saisir un entier p : ");
            p = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Erathostene(N));          //Affiche le resultat de la fonction erathostene

            Console.WriteLine(DFP(N));                  //Affiche le resultat de la fonction DFP

            Console.WriteLine(PremierEntreEux(a, b));   //Determine si 2 nombre sont premiers entre eux

            Console.WriteLine("phi(" + x + ") = " + Phi(x));

            //Console.WriteLine(ConversionEntierBinaire(d));

            Console.WriteLine(ExponentationModulaireLente(y, z, p));

            Console.WriteLine(RSA());
        }
    }
}