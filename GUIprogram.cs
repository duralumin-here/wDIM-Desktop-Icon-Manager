using System;

using System;
using Shell32;
using System.ComponentModel;
using IWshRuntimeLibrary;
using File = System.IO.File;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;

namespace DesktopIconGUIapp

public class ShortcutTools
{
    // This is tweaked from https://stackoverflow.com/a/647286 to let me refresh the desktop once the icons are replaced in order to get rid of the old ones.
    [DllImport("Shell32.dll")] // Import function
    private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);
    private const uint SHCNE_ALLEVENTS = 0x80000000;
    private const uint SHCNF_FLUSH = 0x1000;

    public static void CreateDesktopBackups()
    {
        Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Saved-Backups"));
        // Back up public desktop
        Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Saved-Backups", "Public-Desktop"));
        string newPublicPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager\\Saved-Backups\\Public-Desktop\\" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss"));
        CopyDirectory(@"C:\Users\Public\Desktop", newPublicPath);

        // Back up user desktop
        Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Saved-Backups", "User-Desktop"));
        string newPrivatePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager\\Saved-Backups\\User-Desktop\\" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss"));
        CopyDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), newPrivatePath);

        // Notify user
        System.Windows.Forms.MessageBox.Show("Saved public desktop icons to \"" + newPublicPath + "\"\n" + "Saved private desktop icons to \"" + newPrivatePath + "\".");
    }
}
