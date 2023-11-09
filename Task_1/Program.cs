using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public abstract class Vehicle
    {
        public int Speed { get; set; }
        public int Capacity { get; set; }

        public abstract void Move();
    }

   
    public class Human
    {
        public int Speed { get; set; }

        public void Move()
        {
            Console.WriteLine("Human is moving.");
        }
    }

    
    public class Car : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Car is moving.");
        }
    }

    public class Bus : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Bus is moving.");
        }
    }

    public class Train : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Train is moving.");
        }
    }

    
    public class Route
    {
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }

        
    }

    // Клас TransportNetwork
    public class TransportNetwork
    {
        private List<Vehicle> vehicles;

        public TransportNetwork()
        {
            vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }


        // Метод для розрахунку оптимального маршруту
        public void CalculateOptimalRoute(Route route, Vehicle vehicle)
        {
            Console.WriteLine($"Calculating optimal route for {vehicle.GetType().Name} from {route.StartPoint} to {route.EndPoint}.");
        }

        // Логіка посадки та висадки пасажирів
        public void BoardPassengers(Vehicle vehicle)
        {
            Console.WriteLine($"Boarding passengers onto {vehicle.GetType().Name}.");
        }

        public void DisembarkPassengers(Vehicle vehicle)
        {
            Console.WriteLine($"Disembarking passengers from {vehicle.GetType().Name}.");
        }
    }

    class Program
    {
        static void Main()
        {
            TransportNetwork transportNetwork = new TransportNetwork();

            Car car = new Car();
            Bus bus = new Bus();
            Train train = new Train();

            transportNetwork.AddVehicle(car);
            transportNetwork.AddVehicle(bus);
            transportNetwork.AddVehicle(train);

            Route route = new Route
            {
                StartPoint = "Point A",
                EndPoint = "Point B"
            };

            transportNetwork.CalculateOptimalRoute(route, car);
            transportNetwork.BoardPassengers(bus);
            transportNetwork.DisembarkPassengers(train);

            Console.ReadLine();
        }
    }

}
