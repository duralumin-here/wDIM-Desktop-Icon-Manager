# ↗️ Shortcut Arrows
You've probably noticed that shortcuts have a little arrow in their corner. The arrow is there to remind you that you aren't looking at the actual file: you're just looking at a shortcut that points to the file. We can use a registry edit to change these arrows to a different image.

## Using the Arrow Editor
wDIM includes a custom arrow editor to let you quickly customize your very own arrow:

<img width="841" height="432" alt="The wDIM arrow editor." src="https://github.com/user-attachments/assets/228cbac1-7d0b-4700-b6a8-5f905ff05e59" />

The *dropdown box* allows you to select from multiple different included arrow styles. You can use the *sliders* (or their associated text boxes) to adjust the hue, saturation, and lightness of the arrow you choose—you should be able to make pretty much any color you can think of, and if you don't like the color you've come up with, you can use the *reset button* to reset it to default.

Once you're done editing your masterpiece, you can use the *save button* to select a folder to save it to. It'll be named "arrow.ico" by default since that's the filename that the program looks for when applying arrows.

## Applying Custom Arrows
To use a custom arrow, wDIM has to make an edit to the Windows registry to tell it to look at a custom file location for the arrow instead of using the default location. Making this change requires administrator access and must be done at your own risk—you should always be careful about changing the registry—but once the path is set, you can swap out the stored arrow and it should update even if the program isn't running with administrator privileges.

Also, note that the arrow change will apply all across the system; for instance, these arrows will be visible when you look at shortcuts in File Explorer.

To set the custom arrow path, which must be done before custom arrows will show, use the *initialize arrow path* button. Make sure the program is running with administrator privileges or this will not work. In order to see the change, you'll have to restart Windows Explorer (which Windows uses to display a lot of its user interface). Things may go black for a few seconds, but they should all come back in a moment or two.

Once the path is set, you can apply the arrow that's currently in the editor using the *apply this arrow* button, or you can load a different icon using the *apply other arrow* button (note that arrows, like other icons, must be a .ico file for them to work).

## Restoring Default Arrows
If you no longer want to use a custom arrow, you can use the *restore default arrows* button to clear the custom path in the registry so Windows will go back to using the default one. Since this is a registry edit, it requires that the program be running with administrator privileges. Like setting a custom arrow path, Windows Explorer must be restarted before you'll be able to see the changes.

---
## Documentation Pages
- [Intro](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/intro.md)
- [Preparing the Desktop](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/preparing-desktop.md)
- [Icon Sets](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/icon-sets.md)
- [Labels](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/labels.md)
- [Shortcut Arrows](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/shortcut-arrows.md)
- [Settings](https://github.com/duralumin-here/wDIM-Desktop-Icon-Manager/blob/master/docs/settings.md)
