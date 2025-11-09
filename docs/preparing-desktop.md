# 🖥️ Preparing the Desktop
The first page you'll see in wDIM is the *desktop management* page, which helps you prepare your desktop for icon sets.

<img width="870" height="464" alt="A screenshot of the wDIM Desktop Management page." src="https://github.com/user-attachments/assets/dbd8789c-2e1b-461b-abb2-1da0ea7523d3" />

## Validating the Desktop
This tool checks whether everything on the desktop is a .lnk shortcut file and whether or not they're all on the private desktop (see below). If it detects non-shortcuts on the desktop, it notifies you and offers to help you move the files to different folders (either individually or all at once) and automatically generate shortcuts to their new locations. This is important because the tool only modifies shortcuts; you can leave other files on the desktop if you'd like, but their icons will not be affected by icon sets. The tool similarly offers help moving shortcuts on the public desktop to the private desktop if desired; this may require administrator privileges.

### The Public and Private Desktops
The desktop you see covered in icons technically consists of files in two folders: the private desktop and the public desktop. The private desktop consists of things only available to you, whereas the public desktop holds things (usually shortcuts) that are available for all users to see. *You should not move shortcuts off the public desktop if multiple people use your computer;* doing so will prevent everyone else besides you from seeing them.

If you're the only one who uses the computer, however, moving all the shortcuts to the private desktop can be helpful. Administrator privileges are sometimes required to modify files on the public desktop, but not the private desktop.

You may not see any change when the shortcuts are moved since they'll still show up on the desktop; you can go over to [the settings page](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/settings.md) to quickly check if the public desktop has successfully been cleared.

## Initializing Icon Paths
This modifies all shortcuts on the desktop so that their icon paths point to a custom location. The icon names the shortcuts will search for are based on the target of the file; for instance, a shortcut that opens "firefox.exe" will be set to look for an icon named "firefox.ico". All icon paths will be located in the "Current-Icons" folder, which is stored within the app folder—[you can navigate to it with the *open app folder* button in settings](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/settings.md#viewing-the-app-folder) but I don't recommend you touch any of the files unless you know what you're doing.

By the way, the reason that each icon is named based on the target of the shortcut instead of its name is to keep behavior consistent [even if shortcut names/labels are modified.](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/labels.md)

## Backing Up Shortcuts
This saves all the shortcuts (as well as the contents of the "Current-Icons" folder) to a date-labeled folder that can be viewed in the "Saved-Backups" folder located [within the app folder.](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/settings.md#viewing-the-app-folder) Some operations automatically save such backups; they can be found in that same folder. 

## Refreshing the Desktop
Refreshing the desktop is required for many desktop changes to show. Anything this app does that requires a desktop refresh should do it itself, but you can use this button if it doesn't or if you want to refresh it yourself.

## Restarting Windows Explorer
The only time you should have to do this is when you're [changing the shortcut arrow path.](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/shortcut-arrows.md#applying-custom-arrows) It can be disruptive for a second or two as it unloads and reloads a good portion of Windows (the operating system) at once. You probably won't need to use this button, but if you aren't seeing a change apply that should have applied, restarting Explorer may fix it.

## Reading the Documentation
The link on the bottom takes you to this documentation in your preferred browser—you may have clicked it to find this article in the first place. :)

---
## Documentation Pages
- [Intro](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/intro.md)
- [Preparing the Desktop](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/preparing-desktop.md)
- [Icon Sets](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/icon-sets.md)
- [Labels](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/labels.md)
- [Shortcut Arrows](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/shortcut-arrows.md)
- [Settings](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/settings.md)
