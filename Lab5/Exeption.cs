public partial class Exception : Gtk.Dialog
{
	public Exception ()
	{
		this.Build ();
	}

	public void SetText (string exce)
	{
		Exe.LabelProp = exce;
	}
}

