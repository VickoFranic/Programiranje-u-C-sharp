using System;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace Labs
{
	/// <summary>
	/// Summary description for Person.
	/// </summary>
	
	
	[Serializable]
	public class Person:TreeNode,ISerializable
	{
		public string _name;
		public string _lastName;
		public int _age;
		public string _city;

		public Person(string name,string lastName,int age,string city)
		{
			_name=name;
			_lastName=lastName;
			_age=age;
			_city=city;		

			updateTreeText();
		}

		
		private Person(SerializationInfo si, StreamingContext ctx)
		{
            _name=si.GetString("Name");
			_lastName=si.GetString("LastName");
			_age=si.GetInt32("Age");
			_city=si.GetString("City");

			updateTreeText();
		}
			
	
		public void GetObjectData(SerializationInfo si, StreamingContext ctx)
		{
			si.AddValue("Name",_name);
			si.AddValue("LastName",_lastName);
			si.AddValue("Age",_age);
			si.AddValue("City",_city);
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
