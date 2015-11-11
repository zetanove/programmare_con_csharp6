using static System.Console;

namespace Using
{
    using System;
    using static Nuovo.Console2;

    class Program
    {
        static void Main(string[] args)
        {
            Title = "Esempio Console I/O";
            BackgroundColor = ConsoleColor.White;
            Clear();
            ForegroundColor = ConsoleColor.Blue;
            Write(" Hello World");
            ReadKey();
        }
    }
}

namespace Nuovo
{
    public class Console2
    {
        public static void WriteLine(string a)
        {

        }
    }
}