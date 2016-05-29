using System;

namespace Labs
{
	/// <summary>
	/// 
	/// </summary>
	public class ChangePersonDataCmd:AbstractCommand
	{
		Person	_person;

		string _oldName;
		string _oldLastName;
		int _oldAge;
		string _oldCity;

		string _newName;
		string _newLastName;
		int _newAge;
		string _newCity;

		public ChangePersonDataCmd(Person person,string newName,string newLastName,int newAge, string newCity)
		{
			_person=person;

			_oldName=_person.Name;
			_oldLastName=_person.LastName;
			_oldAge=_person.Age;
			_oldCity=_person.City;

			_newName=newName;
			_newLastName=newLastName;
			_newAge=newAge;
			_newCity=newCity;
		}

		public override void doit()
		{			
			_person.Name=_newName;
			_person.LastName=_newLastName;
			_person.Age=_newAge;
			_person.City=_newCity;

			_person.updateTreeText();

			AppForm.getAppForm().MyTreeView.SelectedNode=_person;

		}

		public override void undo()
		{
			_person.Name=_oldName;
			_person.LastName=_oldLastName;
			_person.Age=_oldAge;
			_person.City=_oldCity;

			_person.updateTreeText();
			AppForm.getAppForm().MyTreeView.SelectedNode=_person;
			
		}

		public override void redo()
		{
			doit();
		}

		
	}
}
