using System;
using System.Collections;

namespace Labs
{
	/// <summary>
	/// </summary>
	class Lab1App
	{	

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			DataModel dm = new DataModel();
			Console.WriteLine("Program started");
			Console.WriteLine();
			doMainMenu();
		}

		private static void printMainMenu()
		{
			Console.WriteLine("You are in main menu - choose action:");
			Console.WriteLine("1 - Insert new circle");
			Console.WriteLine("2 - Insert new square");
            Console.WriteLine("3 - Insert new triangle");		
			Console.WriteLine("4 - Print total area of all inserted elements");
			Console.WriteLine("5 - Print total perimeter of all inserted elements");
			Console.WriteLine("6 - Print properties of all inserted elements");
			Console.WriteLine("Q - Exit");
			Console.Write("Action:");

		}
		private static void doMainMenu()
		{
			printMainMenu();			

			string s;
			while (true)
			{
				s=Console.ReadLine().Trim();
				
				if(s=="1")
				{
					doSubMenuCircle();
				}
				else if(s=="2")
				{
					doSubMenuSquare();
				}
                else if (s == "3")
                {
                    doSubMenuTriangle();
                }				
				else if(s=="4")
				{
					printTotalArea();
					Console.Write("Action:");

				}
				else if(s=="5")
				{
					printTotalPerimeter();
					Console.Write("Action:");
				}
				else if(s=="6")
				{
					printAllData();
					Console.Write("Action:");
				}
				else if(s.ToUpper()=="Q")
				{					
					Console.WriteLine ("Exit of application");
					break;
				}
			}			
		}

		private static void doSubMenuCircle()
		{
			Console.WriteLine("You are in sub menu for circle - insert the value of radius:");
			Console.Write("Radius=");
			string input;
			while (true)
			{				
				input = Console.ReadLine();
				if(input.Trim()!="")
				{
					try
					{
						double r=System.Convert.ToDouble(input);
						Circle myCircle=new Circle(r);
						DataModel.getAllElementsList().Add(myCircle);
						Console.WriteLine("New circle inserted!");
						Console.Write("Do you want to insert one more circle? (y/n)");

						string s;						
						while (true)
						{							
							s=Console.ReadLine().Trim();
							if(s=="y")
							{
								Console.Write("Radius=");
								break;								
							}							
							else if(s=="n")
							{
								Console.WriteLine();
								printMainMenu();
								return;								
							}
						}
						
					}
					catch
					{
						Console.WriteLine("Value for radius is not correct!");
						Console.Write("Radius=");
					}
				}
				
				
			}
		}

		private static void doSubMenuSquare()
		{
			Console.WriteLine("You are in sub menu for square - insert the value for the side of square:");
			Console.Write("Side of square=");
			string input;
			while (true)
			{				
				input = Console.ReadLine();
				if(input.Trim()!="")
				{
					try
					{
						double a=System.Convert.ToDouble(input);
						Square mySquare=new Square(a);
						DataModel.getAllElementsList().Add(mySquare);
						Console.WriteLine("New square inserted!");
						Console.Write("Do you want to insert one more square? (y/n)");

						string s;
						while (true)
						{
							s=Console.ReadLine().Trim();				
							if(s=="y")
							{
								Console.Write("Side of square=");
								break;								
							}
							else if(s=="n")
							{
								Console.WriteLine();
								printMainMenu();
								return;								
							}
						}
						
					}
					catch
					{
						Console.WriteLine("Value for the side of square is not correct!");
						Console.Write("Side of square=");
					}
				}
				
				
			}
			
		}

        private static void doSubMenuTriangle()
        {
            Console.WriteLine("You are in sub menu for triangle - insert the value for the side of triangle:");
            Console.Write("Side of triangle=");
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (input.Trim() != "")
                {
                    try
                    {
                        double a = System.Convert.ToDouble(input);
                        Triangle myTriangle = new Triangle(a);
                        DataModel.getAllElementsList().Add(myTriangle);
                        Console.WriteLine("New triangle inserted!");
                        Console.Write("Do you want to insert one more triangle? (y/n)");

                        string s;
                        while (true)
                        {
                            s = Console.ReadLine().Trim();
                            if (s == "y")
                            {
                                Console.Write("Side of triangle=");
                                break;
                            }
                            else if (s == "n")
                            {
                                Console.WriteLine();
                                printMainMenu();
                                return;
                            }
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Value for the side of triangle is not correct!");
                        Console.Write("Side of triangle=");
                    }
                }
            }
        }

				
		private static void printTotalArea()
		{
			Console.WriteLine();			
			Console.WriteLine("Total area of all inserted elements is: "+DataModel.getTotalArea());
		}

		private static void printTotalPerimeter()
		{
			Console.WriteLine();			
			Console.WriteLine("Total perimeter of all inserted elements is: "+DataModel.getTotalPerimeter());
		}

		private static void printAllData()
		{
			Console.WriteLine("DATA OF ALL ELEMENTS IN LIST");			

			foreach(Shape shape in DataModel.getAllElementsList())
			{
				shape.printData();
			}			
			
		}

		
	}
}
