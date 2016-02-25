using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExample
{
    class Car
    {
        protected string vin;
        protected int fuelCapacity;

        public int FuelCapacity
        {
            get
            {
                return fuelCapacity;
            }
        }

        public string VIN
        {
            get
            {
                return vin;
            }
        }

        public virtual string Horn()
        {
            return String.Format("Машина {0} посигналила", VIN);
        }

        public virtual string Horn(Car whom)
        {
            return String.Format("{0} машине {1}", this.Horn(), whom.VIN);
        }

        public Car(string vin, int fuelCapacity)
        {
            this.vin = vin;
            this.fuelCapacity = fuelCapacity;
        }
    }


    class PassengerCar : Car
    {
        private int humanCapacity;

        public int HumanCapacity
        {
            get
            {
                return humanCapacity;
            }
        }

        public PassengerCar(string vin, int fuelCapacity, int humanCapacity)
            : base(vin, fuelCapacity)
        {
            this.humanCapacity = humanCapacity;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PassengerCar devyatos = new PassengerCar("A001AA", 40, 9);
            PassengerCar chetirka = new PassengerCar("A002AA", 45, 5);

            Console.WriteLine(devyatos.Horn(chetirka));
            Console.WriteLine(chetirka.Horn());
        }
    }
}
