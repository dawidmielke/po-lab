using System;

namespace lab2
{
    public abstract class Vehicle
    {
        public double Weight { get; init; }
        public int MaxSpeed { get; init; }
        protected int _mileage;
        public int Mealeage
        {
            get { return _mileage; }
        }
        public abstract decimal Drive(int distance);
        public override string ToString()
        {
            return $"Vehicle{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage} }}";
        }
    }
    public class HorseCart : Vehicle
    {
        public bool IsHorse { get; set; }
        public bool IsHorseRiding { get; set; }
        public override decimal Drive(int distance)
        {
            if (IsHorse && IsHorseRiding)
            {
                _mileage += distance;
                return (decimal)(distance / (double)MaxSpeed);
            }
            return -1;
        }
    }
    public class Car : Vehicle
    {
        public bool isFuel { get; set; }
        public bool isEngineWorking { get; set; }
        public override decimal Drive(int distance)
        {
            if (isFuel && isEngineWorking)
            {
                _mileage += distance;
                return (decimal)(distance / (double)MaxSpeed);
            }
            return -1;
        }
        public override string ToString()
        {
            return $"Car{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}";
        }
    }
    public class Bicycle : Vehicle
    {
        public bool isDriver { get; set; }
        public override decimal Drive(int distance)
        {
            if (isDriver)
            {
                _mileage += distance;
                return (decimal)(distance / (double)MaxSpeed);
            }
            return -1;
        }
        public override string ToString()
        {
            return $"Bicycle{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}"; ;
        }
    }
    public class Truck : Vehicle, IDriveable
    {
        public override decimal Drive(int distance)
        {
            return 0;
        }
    }
    

    public interface IDriveable
    {
        decimal Drive(int distance);
    }
    public interface ISwimmingable
    {
        decimal Swim(int distance);
    }
    public interface IFlyable
    {
        bool TakeOff();
        decimal Fly(int disntance);
        bool Land();
    }

    class Duck : ISwimmingable, IFlyable
    {
        public decimal Fly(int distance)
        {
            Console.WriteLine("Duck is Flying");
            return -1;
        }
        public decimal Swim(int distance)
        {
            Console.WriteLine("Duck is swimming");
            return 0;
        }
        public bool Land()
        {
            Console.WriteLine("Duck is landing");
            return true;
        }
        public bool TakeOff()
        {
            Console.WriteLine("Duck is taking off");
            return true;
        }
    }
    class Wasp : IFlyable
    {
        public decimal Fly(int distance)
        {
            Console.WriteLine("Wasp is flying");
            return 0;
        }

        public bool TakeOff()
        {
            Console.WriteLine("Wasp is taking off");
            return true;
        }

        public bool Land()
        {
            Console.WriteLine("Wasp is landing");
            return true;
        }
    }

    class Hydroplane : Vehicle, ISwimmingable, IFlyable
    {
        public override decimal Drive(int distance)
        {
            throw new NotImplementedException();
        }

        public decimal Swim(int distance)
        {
            Console.WriteLine("Hydroplane is swimming");
            return 0;
        }

        public decimal Fly(int distance)
        {
            Console.WriteLine("Hydroplane is flying");
            return 0;
        }

        public bool TakeOff()
        {
            Console.WriteLine("Hydroplane is flying");
            return true;
        }

        public bool Land()
        {
            Console.WriteLine("Hydroplane");
            return true;
        }
    }
    
    public abstract class Scooter : Vehicle 
    {
        interface Fly
        {
            void Fly(int distance);

        }
        public class Electricscooter : Scooter
        {
            
            protected int _batteriesLevel;
            public int MaxRange { get; init; }
            public int BatteriesLevel
            {
                get { return _batteriesLevel; }
            }
            

            public void ChargeBatteries()
            {
                _batteriesLevel = 100;
            }

            public override decimal Drive(int distance)
            {
                if(_batteriesLevel > 0)
                {
                    _mileage += distance;
                    _batteriesLevel -= distance / MaxRange;
                    return (decimal)(distance / (double)MaxSpeed);
                }
                return -1;
            }


            public void Fly(int distance)
            {

            }

        }
        public class KickScooter
        {

        }
    }

    public interface IIterator
    {
        bool HasNext();
        int GetNext();
    }
    public abstract class Aggregate
    {
        public abstract IIterator CreateIterator();
    }
    public sealed class ArrayIntIterator : IIterator
    {
        private int _index = 0;
        private ArrayIntAggregate _aggregate;
        public ArrayIntIterator(ArrayIntAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        public int GetNext()
        {
            return _aggregate.array[_index++];
        }
        public bool HasNext()
        {
            return _index < _aggregate.array.Length;
        }

    }
    public class ArrayIntAggregate : Aggregate
    {
        internal int[] array = { 1, 2, 3, 4, 5 };

        public override IIterator CreateIterator()
        {
            return new ArrayIntIterator(this);
        }
    }

    public sealed class ArrayIntReverse : IIterator
    {
        private int _index = 0;
        private ArrayIntAggregate _aggregate;
        public ArrayIntReverse(ArrayIntAggregate aggregate)
        {
            _aggregate = aggregate;
            _index = _aggregate.array.Length - 1;
        }
        public int GetNext()
        {
            return _aggregate.array[_index--];
        }

        public bool HasNext()
        {
            return _index >= 0;
        }
    }
    public class Amphibian : Vehicle, IDriveable, ISwimmingable, IFlyable
    {
        public override decimal Drive(int distance)
        {
            Console.WriteLine("Amphibian is driving");
            return 0;
        }
        public decimal Swim(int distance)
        {
            Console.WriteLine("Amphibian is swimming");
            return 0;
        }
        public bool TakeOff()
        {
            Console.WriteLine("Amphibian is taking off");
            return true;
        }
        public decimal Fly(int distance)
        {
            Console.WriteLine("Amphibian is flying");
            return 0;
        }
        public bool Land()
        {
            Console.WriteLine("Amphibian is landing");
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Vehicle horseCart = new HorseCart() { MaxSpeed = 20, IsHorse = true, Weight = 200 };
            Vehicle[] vehicles = new Vehicle[5];
            vehicles[0] = new Car() { MaxSpeed = 120, Weight = 900 };
            vehicles[1] = new Bicycle() { MaxSpeed = 40, Weight = 15 };
            vehicles[2] = horseCart;
            vehicles[3] = new Bicycle() { MaxSpeed = 40, Weight = 30 };

            int bicycleCounter = 0;
            foreach (var n in vehicles)
            {
                Console.WriteLine(n);
            }

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] is Bicycle)
                {
                    Bicycle bicycle = (Bicycle)vehicles[i];
                    Console.WriteLine($"Czy rower ma kierowcę: {bicycle.isDriver}");
                    bicycleCounter++;
                }
            }
           
            Console.WriteLine($"Liczba rowerów: {bicycleCounter}");

            Aggregate tab = new ArrayIntAggregate();
            IIterator iterator = tab.CreateIterator();
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.GetNext());
            }
            IFlyable flyingObject = new Duck();

            ISwimmingable swimDuck = new Duck();

            Vehicle[] army =
            {
                new Amphibian(){MaxSpeed = 20},
                new Hydroplane(){MaxSpeed = 800},
                new Truck() {MaxSpeed = 100}
            };
            foreach (var vehicle in army)
            {
                if(vehicle is Hydroplane)
                {
                    Console.WriteLine("Hydroplane");
                    Hydroplane hydroplane = (Hydroplane)vehicle;

                    hydroplane.TakeOff();
                    hydroplane.Fly(100);
                    hydroplane.Land();

                }
            }
            IFlyable[] flyables =
            {
                new Wasp(),
                new Hydroplane(),
                new Duck(),
            };
            int flySwimCounter = 0;
            foreach (var flyable in flyables)
            {
                if (flyable is IFlyable && flyable is ISwimmingable)
                    flySwimCounter++;
            }
            Console.WriteLine($"Liczba latających i pływających: {flySwimCounter}");
        }
    }
}
