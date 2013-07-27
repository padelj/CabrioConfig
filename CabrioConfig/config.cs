using System;

namespace CabrioConfig
{
	public class config
	{
		/* Specific XML tags */

		private const char tag_root							= "cabrio-config";
		private const char tag_emulators					= "emulators";
		private const char tag_emulator_executable			= 		"executable";
		private const char tag_game_list					= "game-list";
		private const char tag_games						=   "games";
		private const char tag_game							=     "game";
		private const char tag_game_rom_image				=       "rom-image";
		private const char tag_game_categories				=       "categories";
		private const char tag_game_images					=     "images";
		private const char tag_game_images_image			=       "image";
		private const char tag_game_video					=     "video";
		private const char tag_iface						= "interface";
		private const char tag_iface_full_screen			= 	"full-screen";
		private const char tag_iface_screen					=   "screen";
		private const char tag_iface_screen_hflip			=     "flip-horizontal";
		private const char tag_iface_screen_vflip			=     "flip-vertical";
		private const char tag_iface_controls				=   "controls";
		private const char tag_iface_frame_rate				=   "frame-rate";
		private const char tag_iface_gfx					=   "graphics";
		private const char tag_iface_gfx_quality			=     "quality";
		private const char tag_iface_gfx_max_width			=     "max-image-width";
		private const char tag_iface_gfx_max_height			=     "max-image-height";
		private const char tag_iface_theme					=     "theme";
		private const char tag_iface_labels					=   "labels";
		private const char tag_iface_labels_label			=     "label";
		private const char tag_iface_prune_menus			=   "prune-menus";
		private const char tag_iface_lookups				=   "lookups";
		private const char tag_iface_lookups_category		=     "category-lookup";
		private const char tag_iface_lookups_lookup			=       "lookup";
		private const char tag_themes						=   "themes";
		private const char tag_themes_theme					=     "theme";
		private const char tag_theme_menu					=   "menu";
		private const char tag_theme_menu_item_width		=     "item-width";
		private const char tag_theme_menu_item_height		=     "item-height";
		private const char tag_theme_menu_items_visible		=     "items-visible";
		private const char tag_theme_menu_border			=     "border";
		private const char tag_theme_submenu				=   "submenu";
		private const char tag_theme_submenu_item_width		=     "item-width";
		private const char tag_theme_submenu_item_height	=     "item-height";
		private const char tag_theme_background				=   "background";
		private const char tag_theme_font					=   "font";
		private const char tag_theme_font_file				=     "font-file";
		private const char tag_theme_sounds					=	"sounds";
		private const char tag_theme_sounds_sound			=	  "sound";
		private const char tag_theme_sounds_sound_file		=	  "sound-file";
		private const char tag_theme_snap					=	"snap";
		private const char tag_theme_snap_fix_ar			=	  "fix-aspect-ratio";
		private const char tag_theme_snap_platform_icons	=	  "platform-icons";
		private const char tag_theme_hints					=	"hints";
		private const char tag_theme_hints_pulse			=     "pulse";
		private const char tag_theme_hints_image_back		=     "back-image";
		private const char tag_theme_hints_image_select		=     "select-image";
		private const char tag_theme_hints_image_arrow		=     "arrow-image";
		private const char tag_theme_game_sel				=   "game-selector";
		private const char tag_theme_game_sel_selected		=     "selected";
		private const char tag_theme_game_sel_tile_size		=     "tile-size";
		private const char tag_theme_game_sel_tiles			=     "tiles";
		private const char tag_theme_game_sel_tiles_tile	=       "tile";
		private const char tag_locations					= "locations";
		private const char tag_locations_location			=   "location";
		
		/* General (reused) XML tags */
		private const char tag_name					= "name";
		private const char tag_value				= "value";
		private const char tag_id					= "id";
		private const char tag_display_name			= "display-name";
		private const char tag_platform				= "platform";
		private const char tag_params				= "params";
		private const char tag_param				= "param";
		private const char tag_control				= "control";
		private const char tag_event				= "event";
		private const char tag_device				= "device";
		private const char tag_type					= "type";
		private const char tag_width				= "width";
		private const char tag_height				= "height";
		private const char tag_transparency			= "transparency";
		private const char tag_zoom					= "zoom";
		private const char tag_rotation				= "rotation";
		private const char tag_image_file			= "image-file";
		private const char tag_size					= "size";
		private const char tag_x_size				= "x-size";
		private const char tag_y_size				= "y-size";
		private const char tag_font_scale			= "font-scale";
		private const char tag_orientation			= "orientation";
		private const char tag_offset1				= "primary-offset";
		private const char tag_offset2				= "secondary-offset";
		private const char tag_auto_hide			= "auto-hide";
		private const char tag_angle_x				= "x-angle";
		private const char tag_angle_y				= "y-angle";
		private const char tag_angle_z				= "z-angle";
		private const char tag_position_x			= "x-position";
		private const char tag_position_y			= "y-position";
		private const char tag_position_z			= "z-position";
		private const char tag_order				= "order";
		private const char tag_directory			= "directory";
		private const char tag_color				= "color";
		private const char tag_match				= "match";
		private const char tag_category				= "category";
		private const char tag_emulator				= "emulator";
		private const char tag_default				= "default";
		private const char tag_spacing				= "spacing";
		
		/* Common values */
		private const char config_empty				= "";
		private const char config_true				= "true";
		private const char config_false				= "false";
		private const char config_yes				= "yes";
		private const char config_no				= "no";
		private const char config_low				= "low";
		private const char config_medium			= "medium";
		private const char config_high				= "high";
		private const char config_portrait			= "portrait";
		private const char config_landscape			= "landscape";
		private const char config_auto				= "auto";
		
		/* Labels */
		private const char config_label_all				= "all";
		private const char config_label_platform		= "platform";
		private const char config_label_back			= "back";
		private const char config_label_select			= "select";
		private const char config_label_lists			= "lists";
		
		public config ()
		{
		
		}
	}
}

