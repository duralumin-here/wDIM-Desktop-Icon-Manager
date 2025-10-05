using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wDIMForm
{
    internal class IconSets
    {
        public static void ApplySet(string iconSetPath, bool applyWallpaper, bool applyArrows, bool restartExplorer)
        {
            if (applyWallpaper)
            {
                // string wallpaperPath = Utilities.GetCurrentIconsFolder();
                // Utilities.ChangeWallpaper();
            }

            /* Copy icons into the current set
             *  Every set should include a name and whether or not it has custom labels in the details.txt
             *     , the shortcuts aren't part of the set. Where should the details file go? I guess still the current icons
             *      since that is separate from anything else
             *  If current set has a name, check the folder for a folder with that name
             *      If it exists and there are conflicts, ask to overwrite set "nameVariable" with CurrentIcons or don't apply changes
             *          If it's just an arrow or a wallpaper apply it too
             *      If it doesn't exist, create a folder nameVariable and save it to it
             *  Then clear the current icons and copy the icon set to it
             *  Can set in settings whether wallpapers should apply automatically, and whether arrows should
             *      By default, apply wallpapers but not arrows
             *      I do really wish we could update arrows without resetting explorer
            */

        }
    }
}
