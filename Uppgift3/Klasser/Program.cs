using System;
using System.Collections.Generic;

namespace Klasser
{
    class Program
    {
        /// <summary>
        /// Se instruktionenr i Uppgift.txt
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<Person> person_list = new List<Person>();
            string name, modell, reggnummer, input, avsluta;
            int vikt = 0, age = 0;
            bool elBil = false;
            bool loop = true, villAvsluta;

            while (loop)
            {
                Console.WriteLine("\nVälkommen!");
                Console.WriteLine("Skriv in ditt namn så kan vi börja!");
                name = Console.ReadLine();

            age:
                Console.WriteLine("\nHur gammal är du?");
                try
                {
                    age = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Felaktig inmatning, försök igen.");
                    goto age;
                }

                Console.WriteLine("\nAnge modell: ");
                modell = Console.ReadLine();
                Console.WriteLine("\nAnge registreringsnummer: ");
                reggnummer = Console.ReadLine();

            vikt:
                Console.WriteLine("\nAnge vikt: ");
                try
                {
                    vikt = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Felaktig inmatning, försök igen.");
                    goto vikt;
                }

            elbil:
                Console.WriteLine("\nÄr det en elbil?: Svara ja / nej: ");
                input = Console.ReadLine();
                if (input == "ja")
                {
                    elBil = true;
                }
                else if (input == "nej")
                {
                    elBil = false;
                }
                else
                {
                    Console.WriteLine("\nDu skrev inte in ja eller nej.");
                    goto elbil;
                }

                DateTime dateTime = DateTime.Now;

                Bil bil = new Bil(modell, reggnummer, elBil, dateTime, vikt);
                Person person = new Person(name, age, bil);
                person_list.Add(person);
                Console.WriteLine("\nTryck på en tangent för att skriva ut informationen på skärmen...");
                Console.ReadKey(true);
                Console.Clear();

                foreach (var personer in person_list)
                {
                    Console.WriteLine($"\nNamn: {personer.Name}");
                    Console.WriteLine($"\nÅlder: {personer.Age}");
                    Console.WriteLine($"\nModell: {personer.Bil.Modell}");
                    Console.WriteLine($"\nReggnummer: {personer.Bil.Reggnummer}");
                    Console.WriteLine($"\n{personer.Bil.Tostring()}");
                    Console.WriteLine($"\nVikt: {personer.Bil.Vikt}");
                    Console.WriteLine($"\nDatum: {personer.Bil.Datum}");
                    Console.WriteLine("-------------------------------------------------");
                }
                Console.WriteLine("\nTryck på en tangent...");
                Console.ReadKey(true);
                Console.Clear();

                Console.WriteLine("\nVill du avsluta? ja / nej");
                avsluta = Console.ReadLine();
                villAvsluta = avsluta == "ja";

                if (villAvsluta)
                {
                    loop = false;
                    Console.WriteLine("\nTryck på en tangent för att avsluta...");
                    Console.ReadKey(true);
                }
            }
        }
    }

    public class Bil
    {
        public string Reggnummer { get; set; }
        public string Modell { get; set; }
        public DateTime Datum { get; set; }
        public bool ElBil { get; set; }
        public int Vikt { get; set; }

        public Bil(string modell, string reggnummer, bool elBil, DateTime dateTime, int vikt)
        {
            Modell = modell;
            Reggnummer = reggnummer;
            ElBil = elBil;
            Datum = dateTime;
            Vikt = vikt;
        }

        public string Tostring()
        {
            if (ElBil == true)
            {
                return string.Format($"Detta är en elbil!");
            }
            else
            {
                return string.Format($"Detta är inte en elbil!");
            }
        }
    }

    public class Person
    {
        public Bil Bil { get; set; }
        private string name { get; set; }
        private int age { get; set; }

        public Person(string name, int age, Bil bil)
        {
            this.name = name;
            this.age = age;
            Bil = bil;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
