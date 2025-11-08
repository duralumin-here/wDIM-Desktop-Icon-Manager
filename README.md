# wDIM: A Simple Way to Manage Desktop Icons

wDIM is an easy-to-use, yet powerful system for quickly setting up and swapping between different sets of icons to use on the Windows desktop. You don't need any advanced technical skills to use this tool, nor do you need to learn commandline commands: most of it should be intuitive and/or includes instructions to guide you through. It's made with Windows Forms (and C#), so it looks familiar and it's easy to navigate.

![A gif showing the interface of wDIM.](https://github.com/user-attachments/assets/b4c44d4c-c340-4ba5-b16d-ee45dfa3853d)

The basic workflow is pretty simple:
1. Run the "Validate Desktop" tool to make sure all the items on your desktop are shortcuts. If they aren't, the application can walk you through moving the files off the desktop step-by-step (or you can remove them yourself and run the tool again to check your work).
2. Let the application change the icon paths of your desktop shortcuts to all point to the wDIM data folder, just with one push of a button.
3. Load an icon set and watch your icons magically change!

This is an open-source project made by a solo developer. I did my best to make this a safe and helpful tool, but I claim no liability for any harm caused to you or your device by using this program. Use at your own risk.

## Features
- **Custom icon sets:** Create, import, copy, and edit your own sets, which can also include their own backgrounds and shortcut arrows.
- **Smart icon application:** Icon sets can define specific icons for specific apps, as well a set of generic icons to apply to any apps that don't have an associated icon within the set.
- **Shortcut arrows:** Customize your very own shortcut arrow and apply it systemwide, or save custom arrows to different icon sets.
- **Desktop shortcut labels:** Change all desktop shortcut labels at once by applying "fonts" (custom alphabet characters) and adding custom characters (including emojis!) to the start and/or end, and easily revert the changes if you have a change of heart.
- **Shortcut backups:** Easily save and load the shortcuts on your desktop.
- **Desktop refreshing:** Happens automatically, allowing you to see most changes to the desktop instantly.
- **Persistent settings:** The app remembers your preferences for applying icon sets, but you can easily change them back to their defaults.
- **Ease of use:** An intuitive UI and detailed documentation makes it easy for anyone to start using wDIM.

## FAQ
- ***What does wDIM stand for?*** The "DIM" stands for "Desktop Icon Manager," and the "w" just stands for all the applicable words that start with "w", including "Windows"[^1], "workflow", "wonderful", "wacky"...
- ***I'm not very good with computers. Can I still use wDIM?*** Yes! wDIM is designed to be used by anyone! The application itself features plenty of descriptive explanations throughout (including warnings for things that could go wrong, and errors for things that do), and I'm working on writing out some documentation to explain it all in more detail. Keep an eye out!
- ***Does the app nag you, or hold back experienced users?*** No! wDIM is instantly up and running, so you can jump right into using it without being held back by annoying prompts and tutorials. Also, icon sets follow a simple structure that you can easily replicate and edit yourself.
- ***Why did you make this?*** Over a year ago, I was looking for an app like this to use myself since I always love customizing my devices so they really feel like my own. I was pretty surprised that I couldn't find one (though perhaps I just didn't look hard enough), so I decided to make it myself. Plus, it was a great way for me to get comfortable developing using C# and Windows Forms and taught me a lot about coding in general.
- ***Where can I find assets to use?*** wDIM offers an in-app tool for customizing your own shortcut arrows. You can find wallpapers all over the internet; I really like [Unsplash](https://unsplash.com/)[^2] because the images there are copyright free and, in my experience, pretty much always look really pretty and professional. Icons have to be in .ico format; [Photopea](https://www.photopea.com/)[^2] is a nice, free photo editor that can run right in your browser and lets you make images into .ico files, though the interface may be a bit intimidating if you've never used any editor like it before.
- ***Can you add \[insert cool feature here\]?*** Maybe! Put in an issue and ask me, and I'll see what I can do.

[^1]: I am not affiliated with Microsoft.
[^2]: As of writing this, I like these services quite a lot. However, I'm not affiliated with them and take no responsibility for anything they have done, are doing, or will do. Use at your own discretion.
