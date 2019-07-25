using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Abstract_Factory
{
    public interface ICarFactory
    {
        ISedan ManufactureSedan(string segment);
        ISuv ManufactureSuv(string segment);
    }

    //abstract product A
    public interface ISedan
    {
        string Name();
    }

    //abstract product B
    public interface ISuv
    {
        string Name();
    }

    public class HondaFactory : ICarFactory
    {
        public ISedan ManufactureSedan(string segment)
        {
            switch (segment)
            {
                case "compact":
                    return new HondaCompactSedan();
                case "full":
                    return new HondaFullSedan();
                default:
                    throw new Exception();
            }
        }

        public ISuv ManufactureSuv(string segment)
        {
            switch (segment)
            {
                case "compact":
                    return new HondaCompactSuv();
                case "full":
                    return new HondaFullSuv();
                default:
                    throw new Exception();
            }
        }
    }

    public class ToyotaFactory : ICarFactory
    {
        public ISedan ManufactureSedan(string segment)
        {
            switch (segment)
            {
                case "compact":
                    return new ToyotaCompactSedan();
                case "full":
                    return new ToyotaFullSedan();
                default:
                    throw new Exception();
            }
        }

        public ISuv ManufactureSuv(string segment)
        {
            switch (segment)
            {
                case "compact":
                    return new ToyotaCompactSuv();
                case "full":
                    return new ToyotaFullSuv();
                default:
                    throw new Exception();
            }
        }
    }

    //concrete product X1
    public class HondaCompactSedan : ISedan
    {
        public string Name()
        {
            return "Honda Amaze";
        }
    }

    //concrete product X2
    public class HondaFullSedan : ISedan
    {
        public string Name()
        {
            return "Honda Accord";
        }
    }

    //concrete product Y1
    public class HondaCompactSuv : ISuv
    {
        public string Name()
        {
            return "Honda CR-V";
        }
    }

    //concrete product Y2
    public class HondaFullSuv : ISuv
    {
        public string Name()
        {
            return "Honda Pilot";
        }
    }

    //concrete product X11
    public class ToyotaCompactSedan : ISedan
    {
        public string Name()
        {
            return "Toyota Yaris";
        }
    }

    //concrete product X12
    public class ToyotaFullSedan : ISedan
    {
        public string Name()
        {
            return "Toyota Camry";
        }
    }

    //concrete product Y11
    public class ToyotaCompactSuv : ISuv
    {
        public string Name()
        {
            return "Toyota Rav-4";
        }
    }

    //concrete product Y12
    public class ToyotaFullSuv : ISuv
    {
        public string Name()
        {
            return "Toyota Highlander";
        }
    }

    public class CarClient
    {
        private ISedan sedan;
        private ISuv suv;

        public CarClient(ICarFactory factory, string segment)
        {
            sedan = factory.ManufactureSedan(segment);
            suv = factory.ManufactureSuv(segment);
        }

        public string GetManufacturedSedanName()
        {
            return sedan.Name();
        }

        public string GetManufacturedSuvName()
        {
            return suv.Name();
        }
    }

    /// <summary> 
    /// Abstract Factory Pattern Demo 
    /// </summary> 
    class Program
    {
        static void Main1(string[] args)
        {
            CarClient hondaClient;
            CarClient toyotaClient;
            Console.WriteLine("\r\n------------This is HONDA Car Factory----------------");
            hondaClient = new CarClient(new HondaFactory(), "compact");
            Console.WriteLine("\r\n Manufactureing " + hondaClient.GetManufacturedSedanName() + " as compact Sedan");
            Console.WriteLine("\r\n Manufactureing " + hondaClient.GetManufacturedSuvName() + " as compact SUV");

            hondaClient = new CarClient(new HondaFactory(), "full");
            Console.WriteLine("\r\n Manufactureing " + hondaClient.GetManufacturedSedanName() + " as full Sedan");
            Console.WriteLine("\r\n Manufactureing " + hondaClient.GetManufacturedSuvName() + " as full SUV");

            Console.WriteLine("\r\n\r\n------------This is TOYOTA Car Factory----------------");
            toyotaClient = new CarClient(new ToyotaFactory(), "compact");
            Console.WriteLine("\r\n Manufactureing " + toyotaClient.GetManufacturedSedanName() + " as compact Sedan");
            Console.WriteLine("\r\n Manufactureing " + toyotaClient.GetManufacturedSuvName() + " as compact SUV");

            toyotaClient = new CarClient(new ToyotaFactory(), "full");
            Console.WriteLine("\r\n Manufactureing " + toyotaClient.GetManufacturedSedanName() + " as full Sedan");
            Console.WriteLine("\r\n Manufactureing " + toyotaClient.GetManufacturedSuvName() + " as full SUV");
            Console.ReadLine();
        }
    }



    /*
    interface IVehicleFactory
    {
        ICarEngine GetCarEngine();
        ICarLight GetCarLight();
    }


    class MarutiFactory : IVehicleFactory
    {
        public ICarEngine GetCarEngine()
        {
            return new DDiS();
        }

        public ICarLight GetCarLight()
        {
            return new LED();
        }
    }

    class TataFactory : IVehicleFactory
    {
        public ICarEngine GetCarEngine()
        {
            return new Revtron();
        }

        public ICarLight GetCarLight()
        {
            return new Helogen();
        }
    }

    class LED : ICarLight
    {
        public string GetLightInfo()
        {
            return "Led lights";
        }
    }

    class DDiS : ICarEngine
    {
        public string GetEngineInfo()
        {
            return "DDis engine for their diesal cars...";
        }
    }



    internal class Helogen : ICarLight
    {
        public string GetLightInfo()
        {
            return "Helogan Light...";
        }
    }

    internal class Revtron : ICarEngine
    {
        public string GetEngineInfo()
        {
            return "Revtron engine for their diesal/petrol cars...";
        }
    }

    internal interface ICarLight
    {
        string GetLightInfo();
    }

    internal interface ICarEngine
    {
        string GetEngineInfo();
    }


    class Client
    {
        private IVehicleFactory vehicleFactory = null;
        public void CreateCarWithLight(string carName)
        {
            if (carName.ToLower() == "maruti")
            {
                vehicleFactory = new MarutiFactory();
                Console.Write(
                    $"{carName} uses {vehicleFactory.GetCarEngine().GetEngineInfo()} with {vehicleFactory.GetCarLight().GetLightInfo()} as headlight");
            }
            else if (carName.ToLower() == "tata")
            {
                vehicleFactory = new TataFactory();
                Console.Write(
                    $"{carName} uses {vehicleFactory.GetCarEngine().GetEngineInfo()} with {vehicleFactory.GetCarLight().GetLightInfo()} as headlight");
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("**** Welcome to Abstract Factory pattern By DotnetPiper.com *******\n Kinldy enter your car name...");
            Client client = new Client();
            string carName = Console.ReadLine();
            client.CreateCarWithLight(carName);
            Console.ReadLine();
        }
    }
}

*/

    /*
    using System;

    namespace DesignPatterns.Abstract_Factory
    {
        interface VehicleFactory
        {
            Bike GetBike(string Bike);

            Scooter GetScooter(string Scooter);
        }



        /// <summary> 
        /// The 'ConcreteFactory1' class. 
        /// </summary> 
        class HondaFactory : VehicleFactory

        {
            public Bike GetBike(string Bike)
            {
                switch (Bike)
                {
                    case "Sports":
                        return new SportsBike();
                    case "Regular":
                        return new RegularBike();
                    default:
                        throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Bike));
                }
            }

            public Scooter GetScooter(string Scooter)
            {
                switch (Scooter)
                {
                    case "Sports":
                        return new Scooty();
                    case "Regular":
                        return new RegularScooter();
                    default:
                        throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Scooter));
                }
            }
        }



        /// <summary> 
        /// The 'ConcreteFactory2' class. 
        /// </summary> 
        class HeroFactory : VehicleFactory
        {
            public Bike GetBike(string Bike)
            {
                switch (Bike)
                {
                    case "Sports":
                        return new SportsBike();
                    case "Regular":
                        return new RegularBike();
                    default:
                        throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Bike));
                }
            }

            public Scooter GetScooter(string Scooter)
            {
                switch (Scooter)
                {
                    case "Sports":
                        return new Scooty();
                    case "Regular":
                        return new RegularScooter();
                    default:
                        throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Scooter));
                }
            }
        }


        /// <summary> 
        /// The 'AbstractProductA' interface 
        /// </summary> 
        interface Bike
        {
            string Name();
        }


        /// <summary> 
        /// The 'AbstractProductB' interface 
        /// </summary> 
        interface Scooter
        {
            string Name();
        }


        /// <summary> 
        /// The 'ProductA1' class 
        /// </summary> 
        class RegularBike : Bike
        {
            public string Name()
            {
                return "Regular Bike- Name";
            }
        }



        /// <summary> 
        /// The 'ProductA2' class 
        /// </summary> 
        class SportsBike : Bike
        {
            public string Name()
            {
                return "Sports Bike- Name";
            }
        }



        /// <summary> 
        /// The 'ProductB1' class 
        /// </summary> 
        class RegularScooter : Scooter
        {
            public string Name()
            {
                return "Regular Scooter- Name";
            }
        }


        /// <summary> 
        /// The 'ProductB2' class 
        /// </summary> 
        class Scooty : Scooter
        {
            public string Name()
            {
                return "Scooty- Name";
            }
        }


        /// <summary> 
        /// The 'Client' class  
        /// </summary> 
        class VehicleClient
        {
            Bike bike;
            Scooter scooter;

            public VehicleClient(VehicleFactory factory, string type)
            {
                bike = factory.GetBike(type);
                scooter = factory.GetScooter(type);
            }


            public string GetBikeName()
            {
                return bike.Name();
            }


            public string GetScooterName()
            {
                return scooter.Name();
            }
        }


        /// <summary> 
        /// Abstract Factory Pattern Demo 
        /// </summary> 
        class Program
        {
            static void Main(string[] args)
            {
                VehicleFactory honda = new HondaFactory();
                VehicleClient hondaclient = new VehicleClient(honda, "Regular");
                Console.WriteLine("******* Honda **********");
                Console.WriteLine(hondaclient.GetBikeName());
                Console.WriteLine(hondaclient.GetScooterName());

                hondaclient = new VehicleClient(honda, "Sports");
                Console.WriteLine(hondaclient.GetBikeName());
                Console.WriteLine(hondaclient.GetScooterName());


                VehicleFactory hero = new HeroFactory();
                VehicleClient heroclient = new VehicleClient(hero, "Regular");
                Console.WriteLine("******* Hero **********");
                Console.WriteLine(heroclient.GetBikeName());
                Console.WriteLine(heroclient.GetScooterName());
                heroclient = new VehicleClient(hero, "Sports");
                Console.WriteLine(heroclient.GetBikeName());
                Console.WriteLine(heroclient.GetScooterName());
                Console.ReadKey();
            }
        }
    }
    */

}
