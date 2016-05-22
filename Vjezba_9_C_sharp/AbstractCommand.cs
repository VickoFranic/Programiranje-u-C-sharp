using System;

namespace Labs
{
	/// <summary>
	/// Summary description for AbstractCommand.
	/// </summary>
	public abstract class AbstractCommand
	{
		public abstract void doit();
		public abstract void undo();
		public abstract void redo();
	}
}
