using System;

namespace Labs
{
	/// <summary>
	/// Summary description for 
	/// </summary>
	public class DeletePersonCmd:AbstractCommand
	{
		private Person _personForDel;		

		public DeletePersonCmd(Person p)
		{
			_personForDel=p;			
		}

		public override void doit()
		{
			AppForm.PERSONS_ROOT_NODE.Nodes.Remove(_personForDel);
			AppForm.getAppForm().MyTreeView.SelectedNode=AppForm.PERSONS_ROOT_NODE;			
		}

		public override void undo()
		{
			AppForm.PERSONS_ROOT_NODE.Nodes.Add(_personForDel);
			AppForm.PERSONS_ROOT_NODE.Expand();
			AppForm.getAppForm().MyTreeView.SelectedNode=_personForDel;
			
		}

		public override void redo()
		{
			doit();			
		}
	}
}
