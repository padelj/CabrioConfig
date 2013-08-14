using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.IO;

namespace CabrioConfig
{
	public partial class frmMain : Form
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
		private const string LinCrLf = "\n";
		private const string WinCrLf = "\r\n";
		private string CrLf;
		private const string LinDirSeparator = "/";
		private const string WinDirSeparator = "\\";
		private string DirSeparator;
		XmlDocument appConfigDocument = new XmlDocument ();
		XmlDocument configDocument = new XmlDocument ();
		XmlDocument mameDocument = new XmlDocument ();

		public static bool IsLinux {
			get {
				int p = (int)Environment.OSVersion.Platform;
				return (p == 4) || (p == 6) || (p == 128);
			}
		}

		string filePath;
		int ChildIndexConfig;
		int ChildIndexGameList;
		int ChildIndexGames;
		string statusText = "";
		string[] dirList;
		string shortROMName;
		string ROMDescription;
		DataSet gameList = new DataSet ();

		public frmMain ()
		{
			InitializeComponent ();
		}

		protected void ReadConfig ()
		{
			if (IsLinux)
			{
				CrLf = LinCrLf;
			}
				else
			{
				CrLf = WinCrLf;
			}

			if (filePath == null) {
				if (IsLinux) {
					filePath = Environment.GetEnvironmentVariable ("HOME") + "/.cabrio/config.xml";
				} else {
					filePath = Environment.ExpandEnvironmentVariables ("%HOMEDRIVE%%HOMEPATH%") + "\\.cabrio\\config.xml";
				}
			}
			if (File.Exists (filePath)) {
				configDocument.Load (filePath);
				Console.WriteLine ("config XML Loaded");
				int x = 0;
				bool found = false;
				foreach (XmlNode tempNode in configDocument.ChildNodes) {
					if (tempNode.Name == tag_root) {
						ChildIndexConfig = x;
						found = true;
						Console.WriteLine ("cabrio-config index: " + x);
					}
					x++;
				}

				x = 0;
				found = false;
				foreach (XmlNode tempNode in configDocument.ChildNodes[ChildIndexConfig].ChildNodes) {
					if (tempNode.Name == tag_game_list) {
						ChildIndexGameList = x;
						found = true;
						Console.WriteLine ("game-list index: " + x);
					}
					x++;
				}

				if (!found)
				{
					XmlNode newNode = configDocument.CreateElement("game-list");
					Console.WriteLine (configDocument.ChildNodes[ChildIndexConfig].Name);
					configDocument.ChildNodes[ChildIndexConfig].AppendChild ( newNode);

					x = 0;
					foreach (XmlNode tempNode in configDocument.ChildNodes[ChildIndexConfig].ChildNodes) {
						if (tempNode.Name == tag_game_list) {
							ChildIndexGameList = x;
							found = true;
							Console.WriteLine ("game-list index: " + x);
						}
						x++;
					}
				}

				x = 0;
				found = false;
				foreach (XmlNode tempNode in configDocument.ChildNodes[ChildIndexConfig].ChildNodes[ChildIndexGameList].ChildNodes) {
					if (tempNode.Name == tag_games) {
						found = true;
						Console.WriteLine ("games index: " + x);
					}
					x++;
				}
				if (!found)
				{
					XmlNode newNode = configDocument.CreateElement("games");
					Console.WriteLine (configDocument.ChildNodes[ChildIndexConfig].ChildNodes[ChildIndexGameList].Name);
					configDocument.ChildNodes[ChildIndexConfig].ChildNodes[ChildIndexGameList].AppendChild (newNode);
					
					x = 0;
					foreach (XmlNode tempNode in configDocument.ChildNodes[ChildIndexConfig].ChildNodes[ChildIndexGameList].ChildNodes) {
						if (tempNode.Name == tag_games) {
							ChildIndexGames = x;
							found = true;
							Console.WriteLine ("games index: " + x);
						}
						x++;
					}
				}

			} else {
				Console.WriteLine ("Cabrio config file does not exist.");
				this.toolStripStatusLabel1.Text = "Cabrio config file does not exist.";
			}

		}

		public void LoadConfig ()
		{
			string appConfig;
			Console.WriteLine (Directory.GetCurrentDirectory ());

			if (IsLinux) {
				appConfig = Directory.GetCurrentDirectory () + "/appconfig.xml";
			} else {
				appConfig = Directory.GetCurrentDirectory () + "\\appconfig.xml";
			}

			if (File.Exists (appConfig)) {
				appConfigDocument.Load (appConfig);
				txtMAMEPath.Text = appConfigDocument.SelectSingleNode ("/config/mamedirectory").InnerText;
				txtROMSPath.Text = appConfigDocument.SelectSingleNode ("/config/romsdirectory").InnerText;
				txtSnapsPath.Text = appConfigDocument.SelectSingleNode ("/config/snapdirectory").InnerText;
				this.btnScan.Enabled = true;
			} else {
				Console.WriteLine ("appconfig.xml does not exist.");
			}

			if (IsLinux) {
				filePath = Environment.GetEnvironmentVariable ("HOME") + "/.cabrio/config.xml";
			} else {
				filePath = Environment.ExpandEnvironmentVariables ("%HOMEDRIVE%%HOMEPATH%") + "\\.cabrio\\config.xml";
			}
			Console.WriteLine ("Cabrio filename: " + filePath);

			if (File.Exists (filePath)) {
				Console.WriteLine ("Loading...");
				this.ReadConfig ();
			} else {
				Console.WriteLine ("Cabrio config file does not exist.");
				this.toolStripStatusLabel1.Text = "Cabrio config file does not exist.";
			}

		}

		private void openToolStripMenuItem_Click (object sender, EventArgs e)
		{
			this.LoadConfig ();
		}

		private void saveToolStripMenuItem_Click (object sender, EventArgs e)
		{
			this.SaveConfig ();
		}

		private void exitToolStripMenuItem_Click (object sender, EventArgs e)
		{
			Application.Exit ();
		}

		private void toolStripButtonOpen_Click (object sender, EventArgs e)
		{
			this.LoadConfig ();
		}

		private void toolStripButtonSave_Click (object sender, EventArgs e)
		{
			this.SaveConfig ();
		}

		private void btnMAMEBrowse_Click (object sender, EventArgs e)
		{
			if (this.txtMAMEPath.Text != "") {
				this.folderBrowserDialog1.SelectedPath = this.txtMAMEPath.Text;
			}

			this.folderBrowserDialog1.Description = "Choose MAME folder";

			if (this.folderBrowserDialog1.ShowDialog () == DialogResult.OK) {
				this.txtMAMEPath.Text = this.folderBrowserDialog1.SelectedPath;
			}
		}

		private void btnROMSBrowse_Click (object sender, EventArgs e)
		{
			if (this.txtROMSPath.Text != "") {
				this.folderBrowserDialog1.SelectedPath = this.txtROMSPath.Text;
			}

			this.folderBrowserDialog1.Description = "Choose ROMS folder";

			if (this.folderBrowserDialog1.ShowDialog () == DialogResult.OK) {
				this.txtROMSPath.Text = this.folderBrowserDialog1.SelectedPath;
				this.btnScan.Enabled = true;
			}
		}

		private void btnSnapBrowse_Click (object sender, EventArgs e)
		{
			if (this.txtSnapsPath.Text != "") {
				this.folderBrowserDialog1.SelectedPath = this.txtSnapsPath.Text;
			}

			this.folderBrowserDialog1.Description = "Choose Snapshot folder";

			if (this.folderBrowserDialog1.ShowDialog () == DialogResult.OK) {
				this.txtSnapsPath.Text = this.folderBrowserDialog1.SelectedPath;
			}

		}

		private void btnScan_Click (object sender, EventArgs e)
		{
			this.scanDirectory ();
			this.populateListFromDirectory ();
		}

		private void btnLookup_Click (object sender, EventArgs e)
		{
			this.MAMEThreader ();
		}

		private void btnDelete_Click (object sender, EventArgs e)
		{
			DataGridViewRow DeleteRow = dataGridView1.CurrentRow;

			string ROMName = DeleteRow.Cells ["ROM Name"].Value.ToString ();
			Console.WriteLine ("Deleting row: " + ROMName);
			this.DeleteLine (ROMName);
		}

		protected void startMameLoad ()
		{
			this.LoadMame ();
		}

		protected void LoadMame ()
		{
			if (IsLinux) {
				if (File.Exists (txtMAMEPath.Text + "/mameinfo.xml")) {
					mameDocument.Load (txtMAMEPath.Text + "/mameinfo.xml");
				} else {
					this.toolStripStatusLabel1.Text = "File does not exist.  Please check.";
				}
			} else {
				if (File.Exists (txtMAMEPath.Text + "\\mameinfo.xml")) {
					mameDocument.Load (txtMAMEPath.Text + "\\mameinfo.xml");
				} else {
					this.toolStripStatusLabel1.Text = "File does not exist.  Please check.";
				}
			}
		}

		protected void SaveConfig ()
		{
			string appConfig;

			if (IsLinux) {
				appConfig = Directory.GetCurrentDirectory () + "/appconfig.xml";
			} else {
				appConfig = Directory.GetCurrentDirectory () + "\\appconfig.xml";
			}

			if (appConfigDocument.ChildNodes.Count == 0) {
				appConfigDocument.Load (appConfig);
			}

			appConfigDocument.SelectSingleNode ("/config/mamedirectory").InnerText = txtMAMEPath.Text;
			appConfigDocument.SelectSingleNode ("/config/romsdirectory").InnerText = txtROMSPath.Text;
			appConfigDocument.SelectSingleNode ("/config/snapdirectory").InnerText = txtSnapsPath.Text;

			appConfigDocument.Save (appConfig);

			if (gameList.Tables.Count > 0) {
				if (gameList.Tables ["GameList"].Rows.Count > 0) {
					configDocument.Save (filePath);
				}
			}
		}

		protected void statusBarUpdateThread ()
		{
			this.toolStripStatusLabel1.Text = statusText;
		}

		protected void statusMAMEDone ()
		{
			this.toolStripStatusLabel1.Text = "Done";
		}

		protected void populateListFromXML ()
		{
			if (gameList == null) {
				Console.WriteLine ("Creating dataset");
				gameList = new DataSet ();
			}

			if (gameList.Tables.Count == 0) {
				Console.WriteLine ("Creating table");
				DataTable myTable = new DataTable ("GameList");
				DataColumn ROM = new DataColumn ("ROM Name", typeof(string));
				ROM.Caption = "ROM";
				DataColumn Desc = new DataColumn ("Description", typeof(string));
				Desc.Caption = "Description";
				myTable.Columns.Add (ROM);
				myTable.Columns.Add (Desc);
				gameList.Tables.Add (myTable);
			}

			XmlNodeList xmlGameList = configDocument.SelectNodes ("/" + tag_root + "/" + tag_game_list + "/"
			                                                       + tag_games + "/" + tag_game);
			Console.WriteLine (configDocument.ChildNodes.Count);
			if (configDocument.ChildNodes.Count == 0) {
				this.ReadConfig ();
			}
			Console.WriteLine ("Count of games in XML: " + configDocument.ChildNodes [1].ChildNodes [3].ChildNodes [1].ChildNodes.Count);
			Console.WriteLine ("Count from XMLNode: " + xmlGameList.Count);
			if (xmlGameList.Count > 0) {
				foreach (XmlNode tempNode in xmlGameList) {
					DataRow tempRow = gameList.Tables ["GameList"].NewRow ();

					tempRow ["ROM Name"] = tempNode.SelectSingleNode ("rom-image").InnerText;
					tempRow ["Description"] = tempNode.SelectSingleNode ("name").InnerText;

					gameList.Tables ["GameList"].Rows.Add (tempRow);
				}
			}

			this.dataGridView1.DataSource = gameList.Tables ["GameList"];
			Console.WriteLine ("Datatable count: " + this.gameList.Tables ["GameList"].Rows.Count);
			this.dataGridView1.Columns [0].Width = Convert.ToInt16 (this.dataGridView1.Width * .55) - 22;
			this.dataGridView1.Columns [1].Width = Convert.ToInt16 (this.dataGridView1.Width * .45) - 22;
			this.dataGridView1.Update ();

		}

		protected void MAMEThreader ()
		{
			if (configDocument.ChildNodes.Count == 0) {
				ReadConfig ();
			}
			string snapFileName = "";
			string stringXML = "";
			XmlDocumentFragment newXMLDocFrag;
			if (IsLinux) {
				CrLf = LinCrLf;
				DirSeparator = LinDirSeparator;
			} else {
				CrLf = WinCrLf;
				DirSeparator = WinDirSeparator;
			}

			Thread mameThread = new Thread (new ThreadStart (this.startMameLoad));

			this.toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
			Console.WriteLine ("Loading MAME XML.  Please Wait.");
			statusText = "Loading MAME XML.  Please Wait.";
			this.statusBarUpdateThread ();
			mameThread.Start ();

			while (mameThread.IsAlive) {
				Application.DoEvents ();
			}

			Console.WriteLine ("Looking up MAME ROM matches.");
			statusText = "Looking up MAME ROM matches.";
			this.statusBarUpdateThread ();

			Console.WriteLine ("Number of ROMS in list: " + gameList.Tables ["GameList"].Rows.Count);
			XmlNode tempNode;

			int statusCount = 0;
			this.toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
			this.toolStripProgressBar1.Maximum = 100;
			string romName;
			DataRow[] tempListItem;
			foreach (DataRow listItem in gameList.Tables["GameList"].Rows) {
				romName = listItem ["ROM Name"].ToString ();
				tempListItem = gameList.Tables ["GameList"].Select ("[ROM Name] = '" + romName + "'");
				Console.WriteLine (tempListItem [0] [0].ToString ());
				statusCount++;
				this.toolStripProgressBar1.Value = Convert.ToInt16( 100 * (Convert.ToDouble (statusCount) 
				                                                           / Convert.ToDouble (gameList.Tables["GameList"].Rows.Count)));
				Application.DoEvents ();
				Console.WriteLine ("ROM :" + romName);
				tempNode = configDocument.SelectSingleNode ("/" + tag_root + "/" + 
				                                            tag_game_list + "/" + tag_games + 
				                                            "/"  + tag_game + "[" + 
				                                            tag_game_rom_image + "='" + romName + "']");
				if (tempNode == null) { //Then create new entry
					shortROMName = System.IO.Path.GetFileNameWithoutExtension (romName);
					Console.WriteLine ("ROM Short Name: " + shortROMName);
					ROMDescription = mameDocument.SelectSingleNode ("/mame/game[@name='" + shortROMName +
						"']/description").InnerText;
					if (ROMDescription.IndexOf ("&") > 0) { //Filtering out bad XML character.
						ROMDescription = ROMDescription.Substring (0, ROMDescription.IndexOf ("&") - 1) +
							ROMDescription.Substring (ROMDescription.IndexOf ("&") + 1);
					}

					Console.WriteLine ("Desc: " + ROMDescription);
					snapFileName = "";
					if (Directory.Exists (txtSnapsPath.Text + DirSeparator + shortROMName)) {
						string[] SnapDir = Directory.GetFiles (txtSnapsPath.Text + DirSeparator + shortROMName);
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
						"<name>Emulator</name>" + CrLf +
						"<value>MAME</value>" + CrLf +
						"</category>" + CrLf +
						"</categories>" + CrLf +
						"</game>" + CrLf;
					Console.WriteLine (stringXML);

					newXMLDocFrag = configDocument.CreateDocumentFragment ();
					newXMLDocFrag.InnerXml = stringXML;
					configDocument.ChildNodes [ChildIndexConfig].ChildNodes [ChildIndexGameList]
                    .ChildNodes [ChildIndexGames].AppendChild (newXMLDocFrag);
				} else {
					shortROMName = System.IO.Path.GetFileNameWithoutExtension (romName);
					Console.WriteLine ("ROM Short Name: " + shortROMName);
					ROMDescription = mameDocument.SelectSingleNode ("/mame/game[@name='" + shortROMName +
						"']/description").InnerText;
					if (ROMDescription.IndexOf ("&") > 0) { //Filtering out bad XML character.
						ROMDescription = ROMDescription.Substring (0, ROMDescription.IndexOf ("&") - 1) +
							ROMDescription.Substring (ROMDescription.IndexOf ("&") + 1);
					}
					
					Console.WriteLine ("Desc: " + ROMDescription);

				}
				tempListItem [0] ["Description"] = ROMDescription;
				gameList.Tables ["GameList"].AcceptChanges ();
				this.btnDelete.Enabled = true;
			}


			this.dataGridView1.Update ();
			statusText = "Done";
			this.statusBarUpdateThread ();
			this.toolStripProgressBar1.Value = 0;
		}

		protected void scanDirectory ()
		{
			if (Directory.Exists (txtROMSPath.Text)) {
				dirList = Directory.GetFiles (txtROMSPath.Text);
				Console.WriteLine ("Count of ROM files in directory: " + dirList.Length); //Directory count
			} else {
				this.toolStripStatusLabel1.Text = "Directory does not exist. Please check.";
			}
		}

		protected void populateListFromDirectory ()
		{
			Console.WriteLine (txtROMSPath.Text);
			this.scanDirectory ();

			if (gameList == null) {
				Console.WriteLine ("Creating dataset");
				gameList = new DataSet ();
			}
			
			if (gameList.Tables.Count == 0) {
				Console.WriteLine ("Creating table");
				DataTable myTable = new DataTable ("GameList");
				DataColumn ROM = new DataColumn ("ROM Name", typeof(string));
				ROM.Caption = "ROM";
				DataColumn Desc = new DataColumn ("Description", typeof(string));
				Desc.Caption = "Description";
				myTable.Columns.Add (ROM);
				myTable.Columns.Add (Desc);
				gameList.Tables.Add (myTable);
			}
			
			if (dirList.Length > 0) {
				foreach (string romName in dirList) {
					DataRow tempRow = gameList.Tables ["GameList"].NewRow ();
					
					tempRow ["ROM Name"] = romName;
					tempRow ["Description"] = "";
					
					gameList.Tables ["GameList"].Rows.Add (tempRow);
				}
				this.btnLookup.Enabled = true;
			}
			
			this.dataGridView1.DataSource = gameList.Tables ["GameList"];
			Console.WriteLine ("Datatable count: " + this.gameList.Tables ["GameList"].Rows.Count);
			this.dataGridView1.Columns [0].Width = Convert.ToInt16 (this.dataGridView1.Width * .55) - 22;
			this.dataGridView1.Columns [1].Width = Convert.ToInt16 (this.dataGridView1.Width * .45) - 22;
			this.dataGridView1.Update ();

		}

		protected void DeleteLine (string ROMName)
		{
			if (configDocument.ChildNodes [ChildIndexConfig].ChildNodes [ChildIndexGameList]
			    .ChildNodes [ChildIndexGames].ChildNodes.Count > 0) {
				XmlNode DeleteNode = configDocument.SelectSingleNode ("/" + tag_root + "/"
				                                                      + tag_game_list + "/" + tag_games
				                                                       + "/"  + tag_game + "[" + tag_game_rom_image
				                                                       + "='" + ROMName + "']");
				Console.WriteLine (DeleteNode.Name);
				if (DeleteNode != null) {
					DeleteNode.ParentNode.RemoveChild (DeleteNode);
				}
			}

			gameList.Tables ["GameList"].Rows [dataGridView1.Rows.IndexOf (dataGridView1.CurrentRow)].Delete ();
			gameList.AcceptChanges ();
			dataGridView1.Update ();
		}
	}
}
