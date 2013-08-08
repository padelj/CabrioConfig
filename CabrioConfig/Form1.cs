using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CabrioConfig
{
    public partial class Form1 : Form
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
		String filePath = Environment.GetEnvironmentVariable ("HOME") + "/.cabrio/config.xml";
		int ChildIndexConfig;
		int ChildIndexGameList;
		int ChildIndexGames;


        public Form1()
        {
            InitializeComponent();
        }

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

		public void LoadConfig ()
		{
			Console.WriteLine ("Loading...");
			this.ReadConfig ();
			txtMAMEPath.Text = "/home/jim/.mame";			//Temporary for debug
			txtROMSPath.Text = "/home/jim/.mame/roms";	//Temporary for debug
			
			txtSnapsPath.Text = configDocument.SelectSingleNode ("/cabrio-config/locations/location/directory").InnerText;
		}


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
			this.LoadConfig ();
			this.ReadConfig ();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {

        }

        private void btnMAMEBrowse_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.Description = "Choose MAME folder";
            if (this.folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtMAMEPath.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnROMSBrowse_Click(object sender, EventArgs e)
        {

        }

        private void btnSnapBrowse_Click(object sender, EventArgs e)
        {

        }

        private void btnScan_Click(object sender, EventArgs e)
        {

        }

        private void btnLookup_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {

        }

    }
}
