using System;
using System.Collections;


namespace Labs
{
	/// <summary>
	/// Summary description for Square.
	/// </summary>
	public class Square:Shape
	{
		private double oneSide;		

		public Square(double p)
		{
			oneSide=p;
			xPos=DataModel.getNewXPos();
			yPos=DataModel.getNewYPos();			
		}

		
		public override string ToString()
		{			
			return "Square - side of square="+oneSide+", X pos="+xPos+", Y pos="+yPos;
		}

		public override double getArea()
		{
			return oneSide*oneSide;
		}

		public override double getPerimeter()
		{
			return 4*oneSide;
		}
		

		public double getSide()
		{
			return oneSide;
		}

		public override void printData()
		{
			Console.WriteLine();
			Console.WriteLine("My type: "+this.GetType());
			Console.WriteLine("Side of square = "+oneSide);
			Console.WriteLine("X position = "+xPos);
			Console.WriteLine("Y position = "+yPos);
		}
	}
}
