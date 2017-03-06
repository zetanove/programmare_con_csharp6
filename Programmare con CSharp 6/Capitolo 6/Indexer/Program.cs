﻿/*
 * Programmare con C# 6 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: indicizzatori
 */

namespace Indexer
{
    public class Smartphone
    {
        public class TelephoneNumber
        {
            public string Nome {get;set;}
            public int Number { get; set; }
        }

        //contiene una rubrica di 10 numeri!
        private TelephoneNumber[] numeri = new TelephoneNumber[10];

        public TelephoneNumber this[int index]
        {
            get
            {
                return numeri[index];
            }
            set
            {
                numeri[index] = value;
            }
        }

        public TelephoneNumber this[string nome]
        {
            get
            {
                foreach (TelephoneNumber number in numeri)
                {
                    if (number.Nome == nome)
                        return number;
                }
                return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Smartphone sp = new Smartphone();
            //crea il primo numero
            sp[0] = new Smartphone.TelephoneNumber() { Nome="Antonio", Number=1234 };
            //legge il primo numero
            Smartphone.TelephoneNumber primo = sp[0];
        }
    }
}
