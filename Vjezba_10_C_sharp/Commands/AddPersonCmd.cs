using System;

namespace Labs
{
	/// <summary>
	/// 
	/// </summary>
	public class AddPersonCmd:AbstractCommand
	{		
		private Person _newPerson;
		
	
		public AddPersonCmd(Person newPerson)
		{			
			_newPerson = newPerson;
		}

		public override void doit()
		{
			AppForm.PERSONS_ROOT_NODE.Nodes.Add(_newPerson);
			AppForm.PERSONS_ROOT_NODE.Expand();
			AppForm.getAppForm().MyTreeView.SelectedNode=_newPerson;
		}

		public override void undo()
		{
			AppForm.PERSONS_ROOT_NODE.Nodes.Remove(_newPerson);
			AppForm.getAppForm().MyTreeView.SelectedNode=AppForm.PERSONS_ROOT_NODE;
			
			
		}

		public override void redo()
		{
			doit();			
		}


	}
}
