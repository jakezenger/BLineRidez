using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class Car
    {
        public int CarID { get; }
        public string Make { get; }
        public string Model { get; }
        public string Color { get; }
        public int Year { get; }

        public Car(int carID, string make, string model, string color, int year)
        {
            CarID = carID;
            Make = make;
            Model = model;
            Color = color;
            Year = year;
        }
    }
}