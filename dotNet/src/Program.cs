using System;
using System.Collections.Generic;
using System.Linq;

class Car
{
    public int Year { get; set; }
    public int Value { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Condition { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var carInventory = new List<Car>
        {
            new Car { Year = 2020, Value = 15000, Make = "Toyota", Model = "Corolla", Condition = "used" },
            new Car { Year = 2021, Value = 20000, Make = "Honda", Model = "Civic", Condition = "new" },
            new Car { Year = 2022, Value = 25000, Make = "Tesla", Model = "Model 3", Condition = "new" },
            new Car { Year = 2019, Value = 12000, Make = "Ford", Model = "Focus", Condition = "used" },
            new Car { Year = 2023, Value = 30000, Make = "BMW", Model = "X3", Condition = "new" },
            new Car { Year = 2018, Value = 8000, Make = "Nissan", Model = "Altima", Condition = "used" }
        };

        // First task

        // Second task

        // Third task

        // Fourth task

        // Fifth task
    }
}

