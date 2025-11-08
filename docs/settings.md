# ⚙️ Settings
The *settings page* is rather simple—it just lets you set a few preferences for how applying icon sets works.

<img width="916" height="509" alt="A screenshot of the settings page in wDIM." src="https://github.com/user-attachments/assets/cdfa5e91-e3f7-4001-b153-4d0417bb2527" />

## Automatically Applying Wallpapers
By default, wallpapers included in an icon set will automatically be applied. The wallpaper will be the first file found named "wallpaper;" if multiple "wallpaper" files are found, the order of precedence is "wallpaper.png" > "wallpaper.jpeg" > "wallpaper.jpg" > "wallpaper.bmp" > "wallpaper.gif", with "wallpaper.png" taking highest precedence and "wallpaper.gif" taking lowest precedence. If you uncheck this box, the wallpaper included in a set won't be used when you apply the set.

## Setting a Default Wallpaper
You can set a wallpaper that wDIM will apply if it looks for a "wallpaper" file in an icon set and doesn't find it. To use this setting, check off the *apply default wallpaper* checkbox and choose the location of your default wallpaper with the *select default wallpaper* button. Note that if the wallpaper is later deleted or moved and cannot be found, it will not be applied. The default wallpaper path won't do anything if the *apply default wallpaper* checkbox is deselected.

## Restarting Windows Explorer Automatically
This isn't a setting you should need, but I'm leaving it just in case. It used to appear that updating the shortcut arrows on the desktop required restarting Windows Explorer, but now it seems that you only need to do so if you update the arrow *path,* not the arrow itself. Restarting Explorer over and over is not recommended, and restarting it at all can be disruptive, so I only recommend using this setting if changes aren't applying automatically. [(See my page about shortcut arrows for more information about arrows and restarting Windows Explorer.)](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/shortcut-arrows.md)

## Restoring Default Settings
The *restore defaults* button sets the above settings back to their default values. Be careful: when you do this, your old settings cannot be restored!

## Viewing the App Folder
The *view app folder* button launches File Explorer opened up the folder that wDIM uses. This will let you look at, save, and manually edit the files there—the app takes back-ups of things frequently and this is where they'll be located unless it prompted you to set a different path. **I highly advise against touching the Current-Icons folder and the Shortcut-Arrows folder as editing these files can cause unexpected behavior.** I also advise against deleting, renaming, or editing *any* files in *any* of these folders unless you understand what they do or are willing to risk data loss or program instability.

## Moving Public Shortcuts to Private Desktop
The *move public shortcuts* button (which only activates if public shortcuts are found) attempts to move all shortcuts on the public desktop to the private desktop. [See here for more information about why you may (or may not) want to do this.](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/preparing-desktop.md#the-public-and-private-desktops)
