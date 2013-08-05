using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Xml;
using Gtk;
using CabrioConfig;

public partial class MainWindow: Gtk.Window
{	
	/* Specific XML tags */
	private const string tag_root = "cabrio-config";
	private const string tag_emulators = "emulators";
	private const string tag_emulator_executable = "executable";
	private const string tag_game_list = "game-list";
	private const string tag_games = "games";
	private const string tag_game = "game";
	private const string tag_game_rom_image = "rom-image";
	private const string tag_game_categories = "categories";
	private const string tag_game_images = "images";
	private const string tag_game_images_image = "image";
	private const string tag_game_video = "video";
	private const string tag_iface = "interface";
	private const string tag_iface_full_screen = "full-screen";
	private const string tag_iface_screen = "screen";
	private const string tag_iface_screen_hflip = "flip-horizontal";
	private const string tag_iface_screen_vflip = "flip-vertical";
	private const string tag_iface_controls = "controls";
	private const string tag_iface_frame_rate = "frame-rate";
	private const string tag_iface_gfx = "graphics";
	private const string tag_iface_gfx_quality = "quality";
	private const string tag_iface_gfx_max_width = "max-image-width";
	private const string tag_iface_gfx_max_height = "max-image-height";
	private const string tag_iface_theme = "theme";
	private const string tag_iface_labels = "labels";
	private const string tag_iface_labels_label = "label";
	private const string tag_iface_prune_menus = "prune-menus";
	private const string tag_iface_lookups = "lookups";
	private const string tag_iface_lookups_category = "category-lookup";
	private const string tag_iface_lookups_lookup = "lookup";
	private const string tag_themes = "themes";
	private const string tag_themes_theme = "theme";
	private const string tag_theme_menu = "menu";
	private const string tag_theme_menu_item_width = "item-width";
	private const string tag_theme_menu_item_height = "item-height";
	private const string tag_theme_menu_items_visible = "items-visible";
	private const string tag_theme_menu_border = "border";
	private const string tag_theme_submenu = "submenu";
	private const string tag_theme_submenu_item_width = "item-width";
	private const string tag_theme_submenu_item_height = "item-height";
	private const string tag_theme_background = "background";
	private const string tag_theme_font = "font";
	private const string tag_theme_font_file = "font-file";
	private const string tag_theme_sounds = "sounds";
	private const string tag_theme_sounds_sound = "sound";
	private const string tag_theme_sounds_sound_file = "sound-file";
	private const string tag_theme_snap = "snap";
	private const string tag_theme_snap_fix_ar = "fix-aspect-ratio";
	private const string tag_theme_snap_platform_icons = "platform-icons";
	private const string tag_theme_hints = "hints";
	private const string tag_theme_hints_pulse = "pulse";
	private const string tag_theme_hints_image_back = "back-image";
	private const string tag_theme_hints_image_select = "select-image";
	private const string tag_theme_hints_image_arrow = "arrow-image";
	private const string tag_theme_game_sel = "game-selector";
	private const string tag_theme_game_sel_selected = "selected";
	private const string tag_theme_game_sel_tile_size = "tile-size";
	private const string tag_theme_game_sel_tiles = "tiles";
	private const string tag_theme_game_sel_tiles_tile = "tile";
	private const string tag_locations = "locations";
	private const string tag_locations_location = "location";
	
	/* General (reused) XML tags */
	private const string tag_name = "name";
	private const string tag_value = "value";
	private const string tag_id = "id";
	private const string tag_display_name = "display-name";
	private const string tag_platform = "platform";
	private const string tag_params = "params";
	private const string tag_param = "param";
	private const string tag_control = "control";
	private const string tag_event = "event";
	private const string tag_device = "device";
	private const string tag_type = "type";
	private const string tag_width = "width";
	private const string tag_height = "height";
	private const string tag_transparency = "transparency";
	private const string tag_zoom = "zoom";
	private const string tag_rotation = "rotation";
	private const string tag_image_file = "image-file";
	private const string tag_size = "size";
	private const string tag_x_size = "x-size";
	private const string tag_y_size = "y-size";
	private const string tag_font_scale = "font-scale";
	private const string tag_orientation = "orientation";
	private const string tag_offset1 = "primary-offset";
	private const string tag_offset2 = "secondary-offset";
	private const string tag_auto_hide = "auto-hide";
	private const string tag_angle_x = "x-angle";
	private const string tag_angle_y = "y-angle";
	private const string tag_angle_z = "z-angle";
	private const string tag_position_x = "x-position";
	private const string tag_position_y = "y-position";
	private const string tag_position_z = "z-position";
	private const string tag_order = "order";
	private const string tag_directory = "directory";
	private const string tag_color = "color";
	private const string tag_match = "match";
	private const string tag_category = "category";
	private const string tag_emulator = "emulator";
	private const string tag_default = "default";
	private const string tag_spacing = "spacing";
	
	/* Common values */
	private const string config_empty = "";
	private const string config_true = "true";
	private const string config_false = "false";
	private const string config_yes = "yes";
	private const string config_no = "no";
	private const string config_low = "low";
	private const string config_medium = "medium";
	private const string config_high = "high";
	private const string config_portrait = "portrait";
	private const string config_landscape = "landscape";
	private const string config_auto = "auto";
	
	/* Labels */
	private const string config_label_all = "all";
	private const string config_label_platform = "platform";
	private const string config_label_back = "back";
	private const string config_label_select = "select";
	private const string config_label_lists = "lists";
	private const string CrLf = "\n";


	XmlDocument configDocument = new XmlDocument ();
	XmlDocument mameDocument = new XmlDocument ();
	string[] dirList;
	//string regROMName;
	string shortROMName;
	string ROMDescription;
	string statusText = "Ready";
	int ChildIndexConfig;
	int ChildIndexGameList;
	int ChildIndexGames;
	String filePath = Environment.GetEnvironmentVariable ("HOME") + "/.cabrio/config.xml";
	TreeViewColumn RomName = new TreeViewColumn ();
	TreeViewColumn RomDesc = new TreeViewColumn ();

	private int ReadConfig ()
	{
		configDocument.Load (filePath);
		Console.WriteLine ("config XML Loaded");
		int x = 0;
		foreach (XmlNode tempNode in configDocument.ChildNodes)
		{
			if (tempNode.Name == "cabrio-config") {ChildIndexConfig = x; Console.WriteLine ("cabrio-config index: " + x);}
			x++;
		}

		x = 0;
		foreach (XmlNode tempNode in configDocument.ChildNodes[ChildIndexConfig].ChildNodes)
		{
			if (tempNode.Name == "game-list") {ChildIndexGameList = x; Console.WriteLine ("game-list index: " + x);}
			x++;
		}

		x = 0;
		foreach (XmlNode tempNode in configDocument.ChildNodes[ChildIndexConfig].ChildNodes[ChildIndexGameList].ChildNodes)
		{
			if (tempNode.Name == "games") {ChildIndexGames = x; Console.WriteLine ("games index: " + x);}
			x++;
		}

		return 1;
	}

	private int ReadMAME ()
	{
		
		/* Dataset version
			dsMAMEXML.ReadXml (MAMEPath);
			
			Console.WriteLine (dsMAMEXML.Tables.Count);
			Console.WriteLine (dsMAMEXML.Tables["game"].Rows.Count);
			Console.WriteLine (dsMAMEXML.Tables["game"].Rows[1].ItemArray); 
			*/
		
		/* Start of XPath working sample.
			XmlDocument myXMLDoc = new XmlDocument();
			myXMLDoc.Load (MAMEPath);
			
			String gameDesc = myXMLDoc.SelectSingleNode ("/mame/game[@name='" + txtGameName + "']/description").InnerText;
			Console.WriteLine (gameDesc);  
			
			end of sample */
		
		/* Sample directory
			
			string [] dirList = Directory.GetFiles ("/home/jim/.mame/roms/");
			
			foreach (string myList in dirList)
			{
				Console.WriteLine (Path.GetFileNameWithoutExtension (myList));
			}
			*/
		
		return 1;
	}
	
	public int WriteConfig ()
	{
		/* write config test
			int indexCount = 0;
			foreach (DataRow paramLoop in dsConfig.Tables["game"].Rows)
			{
				Console.WriteLine (paramLoop["name"].ToString ());
				Console.WriteLine (paramLoop["rom-image"].ToString ());
			}

			dsConfig.WriteXml ("/tmp/testfile.xml");
			dsConfig.WriteXmlSchema ("/tmp/schema.xsd");
			*/
		
		return 1;
	}
	
	public void LoadConfig ()
	{
		Console.WriteLine ("Loading...");
		this.ReadConfig ();
		txtMAMEPath.Text = "/home/jim/.mame";			//Temporary for debug
		txtROMSPath.Text = "/home/jim/.mame/roms";	//Temporary for debug
		
		txtSnapsPath.Text = configDocument.SelectSingleNode ("/cabrio-config/locations/location/directory").InnerText;
	}
	
	public void LoadMame ()
	{
		Thread.Sleep (500);
		mameDocument.Load (txtMAMEPath.Text + "/mameinfo.xml");
	}
	
	public int AddGame ()
	{
		return 1;
	}
	
	public int DelGame ()
	{
		return 1;
	}

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
			Gtk.FileChooserDialog ("Choose MAME Directory", this
			                       , FileChooserAction.SelectFolder
			                       , "Cancel", ResponseType.Cancel
			                       , "Open", ResponseType.Accept);
		
		if (myFileChooser.Run () == (int)ResponseType.Accept) {
			txtMAMEPath.Text = myFileChooser.Filename;
			myFileChooser.Destroy ();
		} else {
			myFileChooser.Destroy ();	
		}
	}

	protected void OnBtnROMSBrowseClicked (object sender, System.EventArgs e)
	{
		Gtk.FileChooserDialog myFileChooser = new 
			Gtk.FileChooserDialog ("Choose MAME ROM Directory", this
			                       , FileChooserAction.SelectFolder
			                       , "Cancel", ResponseType.Cancel
			                       , "Open", ResponseType.Accept);
		
		if (myFileChooser.Run () == (int)ResponseType.Accept) {
			txtROMSPath.Text = myFileChooser.Filename;
			myFileChooser.Destroy ();
		} else {
			myFileChooser.Destroy ();	
		}
	}

	protected void OnBtnSnapBrowseClicked (object sender, System.EventArgs e)
	{
		Gtk.FileChooserDialog myFileChooser = new 
			Gtk.FileChooserDialog ("Choose MAME Snapshot Directory", this
			                       , FileChooserAction.SelectFolder
			                       , "Cancel", ResponseType.Cancel
			                       , "Open", ResponseType.Accept);
		
		if (myFileChooser.Run () == (int)ResponseType.Accept) {
			txtSnapsPath.Text = myFileChooser.Filename;
			myFileChooser.Destroy ();
		} else {
			myFileChooser.Destroy ();	
		}
	}

	protected void OnOpenActionActivated (object sender, System.EventArgs e)
	{
		//statusbar1.Push (1,"Done");
		statusText = "Loading Cabrio Config";
		this.statusBarUpdateThread ();
		this.LoadConfig ();
		statusText = "Ready";
		this.statusBarUpdateThread ();
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
		Thread mameThread = new Thread (new ThreadStart (this.startMameLoad));
		Thread statusThread = new Thread (new ThreadStart (this.statusBarUpdateThread));
		Thread statusDoneThread = new Thread (new ThreadStart (this.statusMAMEDone));
		string snapFileName = "";
		string stringXML = "";
		XmlDocumentFragment newXMLDocFrag;
		//XmlNode searchXMLNode;

		Console.WriteLine ("Loading MAME XML.  Please Wait.");
		statusText = "Loading MAME XML.  Please Wait.";
		statusThread.Start ();
		Thread.Sleep (500);
		mameThread.Start ();

		while (mameThread.IsAlive) {
			Thread.Sleep (500);
		}

		dirList = Directory.GetFiles (txtROMSPath.Text);
		Console.WriteLine ("Count of ROM files: " + dirList.Length); //Directory count

		this.ReadConfig ();

		Console.WriteLine ("Looking up MAME ROM matches.");
		statusThread = null;
		statusText = "Looking up MAME ROM matches.";
		statusThread = new Thread (new ThreadStart (this.statusBarUpdateThread));

		Console.WriteLine ("Number of ROMS in directory: " + dirList.Length);
		XmlNode tempNode;
		foreach (string romName in dirList) {
			Console.WriteLine ("ROM :" + romName);
			tempNode = configDocument.SelectSingleNode ("/cabrio-config/game-list/games/game[rom-image='" + 
			                                            romName + "']");
			if (tempNode == null) //Then create new entry
			{
				shortROMName = System.IO.Path.GetFileNameWithoutExtension (romName);
				Console.WriteLine ("ROM Short Name: " + shortROMName);
				ROMDescription = mameDocument.SelectSingleNode ("/mame/game[@name='" + shortROMName + 
				                                                "']/description").InnerText;
				if (ROMDescription.IndexOf ("&") > 0) //Filtering out bad XML character.
				{  
					ROMDescription = ROMDescription.Substring (0, ROMDescription.IndexOf ("&") - 1) +
						ROMDescription.Substring (ROMDescription.IndexOf ("&") + 1);

				}
		
				Console.WriteLine ("Desc: " + ROMDescription);
				snapFileName = "";
				if (Directory.Exists (txtSnapsPath.Text + "/" + shortROMName)) {
					string [] SnapDir = Directory.GetFiles (txtSnapsPath.Text + "/" + shortROMName);
					if (SnapDir.Length > 0) {
						snapFileName = SnapDir [0];
						Console.WriteLine ("Snap Name: " + snapFileName);
					}
				}
				stringXML = "<game>" + CrLf + 
					"<name>" + ROMDescription + "</name>" + CrLf + 
					"<platform>Arcade</platform>" + CrLf + 
					"<rom-image>" + romName + "</rom-image>" + CrLf +
					"<images>" + CrLf;

				if (snapFileName.Length > 0) {
					stringXML = stringXML + "<image>" + CrLf +
						"<type>screenshot</type>" + CrLf +
						"<image-file>" + snapFileName + "</image-file>" + CrLf +
						"</image>" + CrLf;
				}

				stringXML = stringXML + "</images>" + CrLf +
					"<categories>" + CrLf +
					"<category>" + CrLf +
					"<name>Genre</name>" + CrLf +
					"<value>Maze</value>" + CrLf +
					"</category>" + CrLf +
					"</categories>" + CrLf +
					"</game>" + CrLf;
				Console.WriteLine (stringXML);
			
				newXMLDocFrag = configDocument.CreateDocumentFragment ();
				newXMLDocFrag.InnerXml = stringXML;
				configDocument.ChildNodes [ChildIndexConfig].ChildNodes [ChildIndexGameList]
									.ChildNodes [ChildIndexGames].AppendChild (newXMLDocFrag);
			}

		}
		statusDoneThread.Start ();
	}

	protected void startMameLoad ()
	{
		this.LoadMame ();
	}

	protected void statusMAMELoading ()
	{
		Gtk.Application.Invoke (delegate {
			statusbar1.Push (1, "Loading MAME file.  This will take some time.");
		});
		Thread.Sleep (500);

	}

	protected void statusMAMEDone ()
	{
		Gtk.Application.Invoke (delegate {
			statusbar1.Push (1, "Done");
		});
		Thread.Sleep (500);
	}

	protected void statusBarUpdateThread ()
	{
		Gtk.Application.Invoke (delegate {
			statusbar1.Push (1, statusText);
		});
		Thread.Sleep (500);
	}

	protected void OnSaveActionActivated (object sender, EventArgs e)
	{
		configDocument.Save (filePath);
	}

	protected void OnNewActionActivated (object sender, EventArgs e)
	{
		//RomName.Title ("ROM Name");
		//RomDesc.Title ("Description");
		Console.WriteLine ("Updating view...");
		nvGamesList.InsertColumn (RomName,0);
		nvGamesList.InsertColumn (RomDesc,1);
		nvGamesList.EnableGridLines ();
		nvGamesList.ShowNow ();

	}
}
