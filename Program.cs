using System;
using System.Collections.Generic;

namespace po_lab3
{
    class App
    {
        public static void Main(string[] args)
        {
            //UWAGA!!! Nie usuwaj poniższego wiersza!!!
            //Console.WriteLine("Otrzymałeś punktów: " + (Test.Exercises_1() + Test.Excersise_2() + Test.Excersise_3()));

            int[] arr = { 2, 3, 4, 6 };
            var tuple = Exercise2.GetTuple2<int>(arr);
            Console.WriteLine(string.Join(", ", tuple.firstAndLast));
            Console.WriteLine(tuple.isSame);

            string[] arr1 = { "adam", "ola", "adam", "ewa", "karol", "ala", "adam", "ola" };
            var t = Exercise3.countElements(arr1, "adam", "ewa", "ola");
            Console.WriteLine(string.Join(", ", t));
        }
    }

    interface IPlay
    {
        string Play();
    }

    class Musician<T> : IPlay
    {
        public T? Instrument { get; init; }

        public string? Play()
        {
            return (Instrument as Instrument)?.Play();
        }

        public override string ToString()
        {
            return $"MUSICIAN with {(Instrument as Instrument)?.Play()}";
        }
    }

    abstract class Instrument : IPlay
    {
        public abstract string Play();
    }

  

    class Guitar : Instrument
    {
        public override string Play()
        {
            return "GUITAR";
        }
    }
    class Keyboard : Instrument
    {
        public override string Play()
        {
            return "KEYBOARD";
        }
    }

    class Drum : Instrument
    {
        public override string Play()
        {
            return "DRUM";
        }
    }

    public class Exercise2
    {
        public static object getTuple1()
        {
            return new Tuple<string, int, bool>("Karol", 12, true);
        }

        public static (T[] firstAndLast, bool isSame) GetTuple2<T>(T[] arr)
        {
            if (arr.Length == 0)
                return (new T[0], false);

            return (new T[] { arr[0], arr[1] }, arr[0].Equals(arr[1]));
        }
    }

    public class Exercise3
    {
        public static (T, int)[] countElements<T>(T[] arr, params T[] elements)
        {
            var result = new List<(T, int)>();
            foreach (var element in elements)
            {
                int count = 0;
                foreach (var item in arr)
                    if (item.Equals(element))
                        count++;
                result.Add((element, count));

            }
            return result.ToArray();
        }
    }
}
