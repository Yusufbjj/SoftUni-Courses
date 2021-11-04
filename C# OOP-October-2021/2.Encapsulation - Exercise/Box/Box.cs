using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation
{

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;


            set
            {
                if (value > 0)
                {
                    this.length = value;
                }
                else
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                    throw new ArgumentException();
                }
            }
        }

        public double Width
        {
            get => this.width;

            set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                    throw new ArgumentException();
                }
            }
        }

        public double Height
        {
            get => this.height;

            set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                    throw new ArgumentException();
                }
            }
        }

        public double SurfaceArea()
        {
            double surface = 2 * this.length * this.width +
                2 * this.length * this.height +
                2 * this.width * this.height;
            return surface;
        }

        public double LateralSurfaceArea()
        {
            double surface = 2 * this.length * this.height +
                2 * this.width * this.height;
            return surface;
        }

        public double Volume()
        {
            double volume = this.length * this.height * this.width;
            return volume;
        }
    }
}
