using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Labs
{
    class ChangePersonDataCmd:AbstractCommand
    {
        private Person _tmpPerson;
        private Person _personForChange;
        private int pos;

        public ChangePersonDataCmd(Person p)
        {
            _personForChange = p;
        }

        public override void doit()
        {
          _tmpPerson = new Person(_personForChange.Name, _personForChange.LastName, _personForChange.Age, _personForChange.City);
          pos = AppForm.getAppForm().MyTreeView.SelectedNode.Index;
        }

        public override void undo()
        {
            AppForm.PERSONS_ROOT_NODE.Nodes.Insert(pos, _tmpPerson);
            AppForm.PERSONS_ROOT_NODE.Nodes.Remove(_personForChange);
            AppForm.getAppForm().MyTreeView.SelectedNode = _tmpPerson;
        }

        public override void redo()
        {
            AppForm.PERSONS_ROOT_NODE.Nodes[pos].Remove();
            AppForm.PERSONS_ROOT_NODE.Nodes.Insert(pos, _personForChange);
            AppForm.getAppForm().MyTreeView.SelectedNode = _personForChange;
        }
    }
}
