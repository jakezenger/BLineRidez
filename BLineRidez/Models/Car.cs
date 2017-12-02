using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class Car
    {
        //public int CarID { get; set; }
        public string Make { get; }
        public string Model { get; }
        public string Color { get; }
        public int Year { get; }
        public string LicensePlate { get; }

        public Car()
        {

        }

        public Car(string make, string model, string color, int year, string licensePlate)
        {
            Make = make;
            Model = model;
            Color = color;
            Year = year;
            LicensePlate = licensePlate;
        }
    }
}