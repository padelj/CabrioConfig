using System;
using Gtk;
using CabrioConfig;

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


	protected void OnBtnMAMEBrowseClicked (object sender, System.EventArgs e)
	{
		Gtk.FileChooserDialog myFileChooser = new 
			Gtk.FileChooserDialog ("MAME Directory",this
			                       ,FileChooserAction.SelectFolder
			                       ,"Cancel",ResponseType.Cancel
			                       ,"Open",ResponseType.Accept);
		
		if (myFileChooser.Run () == (int)ResponseType.Accept)
		{
			txtMAMEPath.Text = myFileChooser.Filename;
			myFileChooser.Destroy ();
		}
		else
		{
			myFileChooser.Destroy ();	
		}
		
	}

	protected void OnBtnROMSBrowseClicked (object sender, System.EventArgs e)
	{
		throw new System.NotImplementedException ();
	}

	protected void OnOpenActionActivated (object sender, System.EventArgs e)
	{
		throw new System.NotImplementedException ();
	}

	protected void OnOpenAction1Activated (object sender, System.EventArgs e)
	{
		throw new System.NotImplementedException ();
	}

	protected void OnQuitActionActivated (object sender, System.EventArgs e)
	{
		throw new System.NotImplementedException ();
	}

	protected void OnBtnSnapBrowseClicked (object sender, System.EventArgs e)
	{
		throw new System.NotImplementedException ();
	}
}
