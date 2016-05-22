using System;
using System.Windows.Forms;

namespace Labs
{
	/// <summary>
	/// Summary description for Person.
	/// </summary>
	
	public class Person:TreeNode
	{
		private string _name;
		private string _lastName;
		private int _age;
		private string _city;		

		public Person(string name,string lastName,int age,string city)
		{
			_name=name;
			_lastName=lastName;
			_age=age;
			_city=city;		

			updateTreeText();
		}

		public string Name
		{
			get			
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}

		public string LastName
		{
			get			
			{
				return _lastName;
			}
			set
			{
				_lastName=value;
			}
		}

		public int Age
		{
			get			
			{
				return _age;
			}
			set
			{
				_age=value;
			}
		}

		public string City
		{
			get			
			{
				return _city;
			}
			set
			{
				_city=value;
			}
		}
		
		public void updateTreeText()
		{
			this.Text=_lastName+" "+_name+", "+System.Convert.ToString(_age)+", "+_city;

		}
	}
}
