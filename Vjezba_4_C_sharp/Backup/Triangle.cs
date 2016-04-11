using System;
using System.Collections;

namespace Labs
{
	/// <summary>
	/// Summary description for Triangle.
	/// </summary>
	public class Triangle:Shape
	{
		private double oneSide;
		
		public Triangle(double p)
		{
			oneSide=p;
			xPos=DataModel.getNewXPos();
			yPos=DataModel.getNewYPos();		
		}

		
		public override string ToString()
		{			
			return "Triangle - side of triangle="+oneSide+", X pos="+xPos+", Y pos="+yPos;
		}

		public override double getArea()
		{
			return (oneSide*oneSide*Math.Sqrt(3))/4;
		}

		public override double getPerimeter()
		{
			return 3*oneSide;
		}		

		public override void printData()
		{
			Console.WriteLine();
			Console.WriteLine("My type: "+this.GetType());
			Console.WriteLine("Side of triangle = "+oneSide);
			Console.WriteLine("X position = "+xPos);
			Console.WriteLine("Y position = "+yPos);
		}
	}
}
