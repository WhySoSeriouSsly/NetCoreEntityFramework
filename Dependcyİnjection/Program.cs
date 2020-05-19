using System;

namespace Dependcyİnjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Organizator organizator = new Organizator(new BusDriver(), new BusPassenger());
            organizator.MakeTrip();
            Organizator organizator1 = new Organizator(new CarDriver(), new CarPassenger());
            organizator1.MakeTrip();
            Organizator organizator2 = new Organizator(new MiniBusDriver(), new MiniBusPassenger());
            organizator2.MakeTrip();
            Console.ReadLine();
        }
    }
    class Organizator
    {
        IDriver _driver = null;
        IVehicle _vehicle = null;
        public Organizator(IDriver driver, IVehicle vehicle)
        {
            _driver = driver;
            _vehicle = vehicle;
        }

        public void MakeTrip()
        {
            _vehicle.Passenger();

            _driver.Drive();

        }
    }
    public interface IDriver
    {
        void Drive();

    }
    // ARABA İLE GEZME İSTEĞİ GELDİĞİNDE EKLENDİ

    class MiniBusDriver : IDriver
    {
        public void Drive()
        {
            Console.WriteLine("MiniOtobüs sürülüyor");
        }
    }
    class CarDriver : IDriver
    {
        public void Drive()
        {
            Console.WriteLine("araba sürülüyor");
        }
    }

    class BusDriver : IDriver
    {
        public void Drive()
        {
            Console.WriteLine("Otobüs sürülüyor");
        }
    }

    public interface IVehicle
    {
        void Passenger();

    }


    class MiniBusPassenger : IVehicle
    {
        public void Passenger()
        {
            Console.WriteLine("MiniOtobüsle ile geziliyor");
        }
    }

    class BusPassenger : IVehicle
    {
        public void Passenger()
        {
            Console.WriteLine("Otobüs ile geziliyor");
        }
    }
    // ARABA İLE GEZME İSTEĞİ GELDİĞİNDE EKLENDİ

    class CarPassenger : IVehicle
    {
        public void Passenger()
        {
            Console.WriteLine("Araba ile geziliyor");
        }
    } 
}
