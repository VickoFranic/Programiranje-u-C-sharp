using System;
using System.Collections;

namespace Labs
{
    /**
     * class Triangle extends Shape
     */
    class Triangle : Shape
    {
        /**
         * @param oneSide
         */
        private double oneSide;

        /**
         * Constructor for Triangle class
         * 
         * @param s - side of equilateral triangle
         */
        public Triangle(double s)
        {
            oneSide = s;
            xPos = DataModel.getNewXPos();
            yPos = DataModel.getNewYPos();
        }

        /**
         * Returns area for triangle
         *
         * @return double
         */
        public override double getArea()
        {
            return ((Math.Sqrt(3)/4) * (oneSide * oneSide));
        }

        /**
         * Returns perimeter of triangle
         * 
         * @return double
         */
        public override double getPerimeter()
        {
            return oneSide * 3;
        }

        /**
         * Prints triangle data to the console
         */
        public override void printData()
        {
            Console.WriteLine();
            Console.WriteLine("My type: " + this.GetType());
            Console.WriteLine("Side of triangle = " + oneSide);
            Console.WriteLine("X position = " + xPos);
            Console.WriteLine("Y position = " + yPos);
        }
    }
}
