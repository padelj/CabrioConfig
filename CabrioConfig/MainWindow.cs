using System;
using System.IO;
using System.Data;
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
			Gtk.FileChooserDialog ("Choose MAME Directory",this
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
		Gtk.FileChooserDialog myFileChooser = new 
			Gtk.FileChooserDialog ("Choose MAME ROM Directory",this
			                       ,FileChooserAction.SelectFolder
			                       ,"Cancel",ResponseType.Cancel
			                       ,"Open",ResponseType.Accept);
		
		if (myFileChooser.Run () == (int)ResponseType.Accept)
		{
			txtROMSPath.Text = myFileChooser.Filename;
			myFileChooser.Destroy ();
		}
		else
		{
			myFileChooser.Destroy ();	
		}
	}

	protected void OnBtnSnapBrowseClicked (object sender, System.EventArgs e)
	{
		Gtk.FileChooserDialog myFileChooser = new 
			Gtk.FileChooserDialog ("Choose MAME Snapshot Directory",this
			                       ,FileChooserAction.SelectFolder
			                       ,"Cancel",ResponseType.Cancel
			                       ,"Open",ResponseType.Accept);
		
		if (myFileChooser.Run () == (int)ResponseType.Accept)
		{
			txtSnapsPath.Text = myFileChooser.Filename;
			myFileChooser.Destroy ();
		}
		else
		{
			myFileChooser.Destroy ();	
		}
	}

	protected void OnOpenActionActivated (object sender, System.EventArgs e)
	{
		statusbar1.Push (1,"Loading existing config file, please wait...");
		string [] configArray = new string[3];
		for (int x=0;x<configArray.Length;x++)
		{
			configArray[x] = "Unassigned";
		}
		config myConfig = new config ();
		myConfig.LoadConfig (ref configArray);
		txtMAMEPath.Text = configArray[0];
		txtROMSPath.Text = configArray[1];
		txtSnapsPath.Text = configArray[2];
		statusbar1.Pop (1);
		myConfig = null;
		statusbar1.Push (1,"Ready");
	}

	protected void OnOpenAction1Activated (object sender, System.EventArgs e)
	{
		OnOpenActionActivated (sender, e);
	}

	protected void OnQuitActionActivated (object sender, System.EventArgs e)
	{
		Application.Quit ();
	}
	
	protected void OnBtnScanClicked (object sender, EventArgs e)
	{
		string [] dirList = Directory.GetFiles (txtROMSPath.Text);
		Console.WriteLine (dirList.Length); //Directory count
	}
}
