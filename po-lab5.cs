using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_5
{
    //class Board : IEnumerable<char>
    //{
    //    private char[,] _board = {
    //        {'_', 'X', '_'},
    //        {'O' ,'X', '_'},
    //        {'_', 'X', '_'}
    //        };

    //    public char this[int x, int y]
    //    {
    //        get
    //        {
    //            //test poprawności x i y
    //            return _board[y - 1, x - 1];
    //        }
    //        set
    //        {
    //            // test poprawności x i y
    //            _board[y - 1, x - 1] = value;
    //        }
    //    }

    //    public void Print()
    //    {
    //        for (int row = 0; row < _board.GetLength(1); row++)
    //        {
    //            for (int col = 0; col < _board.GetLength(0); col++)
    //            {
    //                Console.Write(_board[row, col] + "" + ' ');
    //            }
    //            Console.WriteLine();
    //        }
    //    }

    //    public IEnumerator<char> GetEnumerator()
    //    {
    //        for (int col = 0; col < _board.GetLength(0); col++)
    //        {
    //            for (int row = 0; row < _board.GetLength(1); row++)
    //            {
    //                yield return _board[row, col];
    //            }
    //        }
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }
    //}
    //class Team : IEnumerable<string>
    //{
    //    public string Leader { get; init; }
    //    public string ViceLeader { get; init; }
    //    public string Admin { get; init; }
    //    public string Developer { get; init; }

    //    public IEnumerator<string> GetEnumerator()
    //    {
    //        //return new TeamEnumerator(this);
    //        yield return Leader;
    //        yield return ViceLeader;
    //        yield return Admin;
    //        yield return Developer;
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }
    //}

    //class TeamEnumerator : IEnumerator<string>
    //{

    //    private readonly Team _Team;
    //    private int _counter = 0;

    //    public TeamEnumerator(Team team)
    //    {
    //        _Team = team;
    //    }
    //    public string Current
    //    {

    //        get
    //        {

    //            switch (_counter)
    //            {
    //                case 0:
    //                    return _Team.Leader;
    //                case 1:
    //                    return _Team.ViceLeader;
    //                case 2:
    //                    return _Team.Admin;
    //                case 3:
    //                    return _Team.Developer;
    //                default:
    //                    return null;
    //            }
    //        }
    //    }

    //    object IEnumerator.Current => Current;

    //    public void Dispose()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool MoveNext()
    //    {
    //        return _counter++ < 4;
    //    }

    //    public void Reset()
    //    {
    //        _counter = 0;
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Team team = new Team()
    //        {
    //            Leader = "Kowalski",
    //            ViceLeader = "Nowak",
    //            Admin = "Karolak",
    //            Developer = "Stasiak",
    //        };
    //        foreach (string member in team)
    //        {
    //            Console.WriteLine(member);
    //        }

    //        Board board = new Board();

    //        foreach (var znak in board)
    //        {
    //            Console.WriteLine(znak);
    //        }
    //        board[1, 2] = 'O';
    //        board.Print();
    //    }
    //}

    class App
    {
        public static void Main(string[] args)
        {
            Exercise1<string> team = new Exercise1<string>()
            {
                Manager = "Adam",
                MemberA = "Ola",
                MemberB = "Ewa"
            };

            foreach (string member in team)
            {
                Console.WriteLine(member);
            }

            CurrencyRates rates = new CurrencyRates();
            CurrencyRates rates1 = new CurrencyRates();
            rates[Currency.USD] = 4.27m;
            Console.WriteLine(rates[Currency.USD]);
            rates1[Currency.EUR] = 4.65m;
            Console.WriteLine(rates1[Currency.EUR]);


            var hex = new Exercise3();
            var limitedHex = hex.GetLimitedHex(4);
            while (limitedHex.MoveNext())
            {
                Console.WriteLine(limitedHex.Current);
            }
        }
    }
    //Cwiczenie 1 (2 punkty)
    //Zmodyfikuj klasę Exercise1 aby implementowała interfesj IEnumerable<T>
    //Zdefiniuj metodę GetEnumerator, aby zwracał kolejno pola Manager, MemberA, MemberB
    //Przykład
    //Exercise1<string> team = new Exercise1(){ Manager: "Adam", MemberA: "Ola", MemberB: "Ewa"};
    //foreach(var member in team){
    //    Console.WriteLine(member);
    //}
    //otrzymamy na ekranie
    //Adam
    //Ola
    //Ewa
    public class Exercise1<T> : IEnumerable<T>
    {
        public T Manager { get; init; }
        public T MemberA { get; init; }
        public T MemberB { get; init; }

        public IEnumerator<T> GetEnumerator()
        {
            yield return Manager;
            yield return MemberA;
            yield return MemberB;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    //Cwiczenie 2 (2 punkty)
    //Zdefiniuj indekser dla klasy CurrencyRates, aby umożliwiał przypisania i pobierania notowania dla danej waluty.
    //Zainicjuj tablice _rates, aby jej rozmiar byl równy liczbie stałych wyliczeniowych w klasie Currency i nie wymagał zmiany
    //gdy zostaną dodane następne stałe.
    //Przykład
    //CurrencyRates rates = new CurrencyRates();
    //rates[Currency.EUR] = 4.6m;
    //Console.WriteLine(rates[Currency.EUR]);

    enum Currency
    {
        PLN,
        USD,
        EUR,
        CHF
    }

    class CurrencyRates
    {
        //utwórz tablicę o rozmiarze równym liczbie stalych wyliczeniowych Currency
        private decimal[] _rates = new decimal[Enum.GetValues<Currency>().Length];

        public decimal this[Currency currency]
        {
            get
            {
                return _rates[(int)currency];
            }
            set
            {
                _rates[(int)currency] = value;
            }
        }
    }
    //Cwiczenie 3
    //Zdefiniuj enumerator zwracający kolejne liczby szesnastowe zapisane w łańcuchu o długości 8 znaków plus znaki 0x jako prefiks
    //Przykład 
    //0x00000000 0x00000001 0x00000002 0x00000003 ... 0x0000000A ... 0x000000010 ... 0xFFFFFFFF 
    //Zdefiniuj metodę GetLimitedHex(int digitCount), która zwraca enumerator z liczbami o podanej liczbie cyfr.
    //Przykład wykorzystania metody
    // var limitedHex = hex.GetLimitedHex(4);
    // while (limitedHex.MoveNext())
    // {
    //     Console.WriteLine(limitedHex.Current);
    // }
    //Wyjście:
    //0x0000
    //0x0001
    //...
    //0x2c7b
    //0x2c7c
    //0x2c7d
    //...
    //0xffff

    class Exercise3 : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < 0xFFFFFFFF; i++)
            {
                yield return string.Format("0x{0:X8}", i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<string> GetLimitedHex(int digitCount)
        {
            for (long i = 0; i < 0xFFFFFFFF; i++)
            {
                string hex = string.Format("0x{0:X" + digitCount + "}", i);
                if(hex.Length <= digitCount + 2)
                {
                    yield return hex;
                }
            }
        }
    }

    enum ChessPiece
    {
        Empty,
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }

    enum ChessColor
    {
        Black,
        White
    }
    //Cwiczenie 4 (4 punkty)
    //Zdefiniuj klasę opisująca szachownicę z indekserem umożliwiającym dostęp do pola
    //na podstawie indeksu w postaci łańcucha np.: "A5" oznacza pierwszą kolumnę i 5 wiersz (od dołu).
    //W podanych współrzędnych należy umieścić krotkę z dwoma stałymi wyliczeniowymi (ChessPiece, ChessColor)
    //Przykład
    //Exercise4 board = new Exerceise4();
    //board["A5"] = (ChessPiece.King, ChessColor.White);
    //Console.WriteLine(board["A8"]); // pole bez figury w kolorze białym (ChessPiece.Empty, ChessColor.White)
    //Console.WriteLine(board["A1"]); // pole bez figury w kolorze czarnym (ChessPiece.Empty, ChessColor.Black)
    //Klasa powinna zachować zasadę, że nie można umieścić więcej niż dozwolona liczba figur danego typu:
    //1 królowa i król, 2 wieże, gońce, skoczki, 8 pionów
    //W sytuacji, gdy zostanie dodana nadmiarowa figura np. 3 skoczek w kolorze białym, klasa powinna zgłosić wyjątek InvalidChessPieceCount
    //W sytuacji podania niepoprawnych współrzednych np. K9 lub AA44, klasa powinna zgłosić wyjątek InvalidChessBoardCoordinates 
    class Exercise4
    {
        private (ChessPiece, ChessColor)[,] _board = new (ChessPiece, ChessColor)[8, 8];
    }

    class InvalidChessPieceCount : Exception
    {

    }

    class InvalidChessBoardCoordinates : Exception
    {

    }

}
