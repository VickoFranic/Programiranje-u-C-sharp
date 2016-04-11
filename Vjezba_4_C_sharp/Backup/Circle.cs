using System;
using System.Collections;

namespace Labs
{
	/// <summary>
	/// Summary description for Circle.
	/// </summary>
	public class Circle:Shape
	{
		private double radius;		
		private static double PI=3.14159;

		public Circle(double r)
		{
			radius=r;
			xPos=DataModel.getNewXPos();
			yPos=DataModel.getNewYPos();
		}

		
		public override string ToString()
		{			
			return "Circle - radius="+radius+", X pos="+xPos+", Y pos="+yPos;
		}


		public override double getArea()
		{
			return radius*radius*PI;

		}

		public override double getPerimeter()
		{
			return 2*radius*PI;
		}		

		public override void printData()
		{			
			Console.WriteLine();
			Console.WriteLine("My type: "+this.GetType());
			Console.WriteLine("Radius = "+radius);
			Console.WriteLine("X position = "+xPos);
			Console.WriteLine("Y position = "+yPos);
		}
	}
}
