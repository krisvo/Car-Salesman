using System;
using System.Collections.Generic;
using System.Linq;

public class Car
{
    public string model;
    public Engine engine;
    public int weight;
    public string color;

    public Car(string model, Engine engine, int weight, string color)
    {
        this.model = model;
        this.engine = engine;
        this.weight = weight;
        this.color = color;
    }

    public Car(string model, Engine engine) : this(model, engine, -1, @"n/a")
    {

    }

    public Car(string model, Engine engine, int weight) : this(model, engine, weight, @"n/a")
    {

    }

    public Car(string model, Engine engine, string color) : this(model, engine, -1, color)
    {

    }
} 
public class Engine
{
    public string model;
    public int power;
    public int displacement;
    public string efficiency;
    public Engine(string model, int power,  int displacement, string efficiency)
    {
        this.model = model;
        this.power = power;
        this.displacement = displacement;
        this.efficiency = efficiency;

    }
    public Engine(string model, int power) : this(model, power, -1, @"n/a")
    {

    }

    public Engine(string model, int power, int displacement) : this(model, power, displacement, @"n/a")
    {

    }

    public Engine(string model, int power, string efficiency) : this(model, power, -1, efficiency)
    {

    }
    
}

public class CarSalesman
{
    public static void Main()
    {

        var engines = new List<Engine>();
        var cars = new List<Car>();

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var typeOfEngine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var model = typeOfEngine[0];
            var power = int.Parse(typeOfEngine[1]);

            var displacement = 0;

            Engine eachEngine = null;

            if (typeOfEngine.Length == 2)
            {
                eachEngine = new Engine(model, power);
            }
            if (typeOfEngine.Length > 2 && int.TryParse(typeOfEngine[2], out displacement))
            {
                if (typeOfEngine.Length == 3)
                {
                    eachEngine = new Engine(model, power, displacement);
                }
                else
                {
                    eachEngine = new Engine(model, power, displacement, typeOfEngine[3]);
                }
            }

            if (typeOfEngine.Length > 2 && !int.TryParse(typeOfEngine[2], out displacement))
            {
                eachEngine = new Engine(model, power, typeOfEngine[2]); ;
            }

            engines.Add(eachEngine);
        }




        var m = int.Parse(Console.ReadLine());

        for (int i = 0; i < m; i++)
        {

            var car = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();          

            Engine engine = engines.First(e => e.model == car[1]);

            var weight = 0;
            Car eachCar = null;

            if (car.Length == 2)
            {
                eachCar = new Car(car[0], engine);
            }

            if (car.Length > 2 && int.TryParse(car[2], out weight))
            {
                if (car.Length > 3)
                {
                    eachCar = new Car(car[0], engine, weight, car[3]);
                }
                else
                {
                    eachCar = new Car(car[0], engine, weight);
                }
            }

            if (car.Length > 2 && !int.TryParse(car[2], out weight))
            {
                eachCar = new Car(car[0], engine, car[2]);
            }

            cars.Add(eachCar);
            
        }

        foreach (var c in cars)
        {
            Console.WriteLine($"{c.model}:");
            Console.WriteLine($"  {c.engine.model}:");
            Console.WriteLine($"    Power: {c.engine.power}");
            Console.WriteLine("    Displacement: {0}", c.engine.displacement == -1 ? "n/a" : c.engine.displacement.ToString());
            Console.WriteLine($"    Efficiency: {c.engine.efficiency}");
            Console.WriteLine("  Weight: {0}", c.weight == -1 ? "n/a" : c.weight.ToString());
            Console.WriteLine($"  Color: {c.color}");
        }
    }
}