using System;
using System.Collections;
using System.Windows.Forms;

namespace Labs
{
	/// <summary>
	/// Summary description for CommandProcessor.
	/// </summary>
	public class CommandProcessor
	{		
		private Stack _doneStack, _undoneStack;
		private int _maxStackSize;
		
		public CommandProcessor()
		{
			_doneStack = new Stack();
			_undoneStack = new Stack();
			_maxStackSize = 51; //desired size + 1
			
		}

		public void doCmd(AbstractCommand cmd) 
		{			
			cmd.doit();
			_doneStack.Push(cmd);
			_undoneStack.Clear();

			if (_doneStack.Count== _maxStackSize) 
			{
				_doneStack=this.reduceStackSize(_doneStack);
			}

			setUnReButtonState();
					
		}

		public void undoLastCmd() 
		{
			if (_doneStack.Count!=0) 
			{
				AbstractCommand lastcmd = (AbstractCommand) _doneStack.Pop();
				lastcmd.undo();
				_undoneStack.Push(lastcmd);
				
				if (_undoneStack.Count== _maxStackSize) 
				{
					_undoneStack=this.reduceStackSize(_undoneStack);
				}
				
				setUnReButtonState();
			}
		}

		public void redoLastUndone() 
		{
			if (_undoneStack.Count!=0) 
			{				
				AbstractCommand last_undone_cmd = (AbstractCommand) _undoneStack.Pop();
				last_undone_cmd.redo();
				_doneStack.Push(last_undone_cmd);

				if (_doneStack.Count== _maxStackSize) 
				{
					_doneStack=this.reduceStackSize(_doneStack);
				}
			
				setUnReButtonState();
			}
		}

				
		public void setUnReButtonState()
		{
			if(_doneStack.Count>0)
			{
				AppForm.getAppForm().getUndoToolBarButton().Enabled=true;

			}
			else
			{
				AppForm.getAppForm().getUndoToolBarButton().Enabled=false;

			}

			if(_undoneStack.Count>0)
			{
				AppForm.getAppForm().getRedoToolBarButton().Enabled=true;

			}
			else
			{
				AppForm.getAppForm().getRedoToolBarButton().Enabled=false;

			}

		}

		
		private Stack reduceStackSize(Stack oldStack)
		{			
			Stack newStack = new Stack();
			int stackCount=oldStack.Count;

			for(int n=1;n<stackCount;n++)
			{				
				AbstractCommand ac=(AbstractCommand)oldStack.Pop();
				newStack.Push(ac);				
			}

			return newStack;

		}

		public void clearStacks()
		{
			_doneStack.Clear();
			_undoneStack.Clear();
		}

	}
}
