using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}	

	protected void OnButton1Clicked (object sender, EventArgs e)
	{
		string term = entry2.Text;
		Taschenrechner1.Taschenrechner myCalc = new Taschenrechner1.Taschenrechner ();
		myCalc.Initialize ();

		string[] result = myCalc.Analyze (term);
		label2.Text = result[0];
		label3.Text = result[1];
		if (myCalc.warning == true) {
			Warning();
		}
	}	
	protected void OnEntry2KeyReleaseEvent (object o, KeyReleaseEventArgs args)
	{
		if (Convert.ToString (args.Event.Key) == "Return") {
			button1.Activate();
		}
	}
	public void Warning() {
		label3.LabelProp = "<b>"+label3.LabelProp+"</b>";
		label3.UseMarkup = true;
	}




}
