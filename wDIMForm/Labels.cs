using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using File = System.IO.File;

namespace wDIMForm
{
    public class Labels
    {
        public static void ChangeLabels(List<string> desktopEntries, string font, string startString, string endString)
        {
            StringBuilder myList = new StringBuilder();
            if (Properties.Settings.Default.areLabelsApplied)
            {
                ResetLabels(desktopEntries);
                ChangeLabels(Utilities.CreateLinkArray(), font, startString, endString);
                return;
            }

            string[] oldAlphabet = GetFontArray(Properties.Settings.Default.labelFont);
            string[] newAlphabet = GetFontArray(font);

            foreach (string entry in desktopEntries)
            {
                // Get just the file name
                string original = entry.Substring((entry.LastIndexOf("\\") + 1));
                string oldNoExtension = original.Substring(0, original.LastIndexOf('.')); // List only has lnk so we can trim it

                // Convert file name to new font
                string newNoExtension = ApplyFontToEntry(oldNoExtension, oldAlphabet, newAlphabet);

                try
                {
                    CopyShortcutWithLabel(entry.Contains("C:\\Users\\Public"), oldNoExtension, newNoExtension, startString, endString);
                    UpdateLabelLog(myList, oldNoExtension, startString + newNoExtension + endString);
                }
                catch (Exception e)
                {
                    DialogResult result = MessageBox.Show("An error occurred processing " + entry + ":\n\n" + e.Message + "\n\nThis item will be skipped. Press OK to continue or press Cancel to end.", "Error", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.Cancel)
                    {
                        UpdateLabelSettings(myList, font, startString, endString);
                        return;
                    }
                }
            }
            UpdateLabelSettings(myList, font, startString, endString);
            Utilities.RefreshDesktop();
        }

        public static void ResetLabels(List<string> desktopEntries)
        {
            // TODO: error handling for if something is missed?
            if (Properties.Settings.Default.areLabelsApplied)
            {
                foreach (string entry in desktopEntries)
                {
                    string original = entry.Substring((entry.LastIndexOf("\\") + 1));
                    string oldNoExtension = original.Substring(0, original.LastIndexOf('.'));

                    int startIndex = Properties.Settings.Default.labelMap.IndexOf(oldNoExtension);
                    int endIndex = startIndex - 2;
                    int lineStartIndex = Properties.Settings.Default.labelMap.LastIndexOf('\n', endIndex) + 1;
                    try
                    {
                        string newNoExtension = Properties.Settings.Default.labelMap.Substring(lineStartIndex, endIndex - lineStartIndex + 1).Trim();
                        CopyShortcutWithLabel(entry.Contains("C:\\Users\\Public"), oldNoExtension, newNoExtension, "", "");
                    }
                    catch
                    {
                        break;
                    }
                }
            }

            Utilities.RefreshDesktop();

            Properties.Settings.Default.labelMap = null;
            Properties.Settings.Default.labelFont = "default";
            Properties.Settings.Default.areLabelsApplied = false;
            Properties.Settings.Default.prependedText = null;
            Properties.Settings.Default.appendedText = null;
            Properties.Settings.Default.Save();
        }

        private static void UpdateLabelLog(StringBuilder myList, string oldName, string newName)
        {
            myList.Append(oldName + "|" + newName).Append('\n');
        }

        private static void UpdateLabelSettings(StringBuilder myList, string font, string startString, string endString)
        {
            Properties.Settings.Default.labelMap = myList.ToString().TrimEnd('\n');
            Properties.Settings.Default.areLabelsApplied = true;
            Properties.Settings.Default.labelFont = font;
            Properties.Settings.Default.prependedText = startString;
            Properties.Settings.Default.appendedText = endString;
            Properties.Settings.Default.Save();
            Utilities.RefreshDesktop();
        }

        public static void CopyShortcutWithLabel(bool isPublic, string oldNameNoExtension, string newNameNoExtension, string startString, string endString)
        {
            // TODO: Add option in settings to move all shortcuts to private desktop (with lots of warnings)? Might be helpful

            // Select proper desktop
            string desktop;
            if (isPublic) desktop = @"C:\Users\Public\Desktop";
            else desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string oldLnk = Path.Combine(desktop, oldNameNoExtension + ".lnk");
            string newLnk = Path.Combine(desktop, startString + newNameNoExtension + endString + ".lnk");

            // Icons getting mixed up is a system limitation unless I can figure out how to manually store the shortcut locations
            File.Move(oldLnk, newLnk);
        }

        public static string ApplyFontToEntry(string entry, string[] oldAlphabet, string[] newAlphabet)
        {
            // TODO: get it to work to convert between fonts
            string[] entryArr = StringToArray(entry);

            for (int i = 0; i < entryArr.Length; ++i) // iterate through letters of entry
            {
                for (int j = 0; j < oldAlphabet.Length; ++j) // try to match them with a font letter
                {
                    if (entryArr[i] == oldAlphabet[j])
                    {
                        entryArr[i] = newAlphabet[j];
                        break;
                    }
                }
            }

            return ArrayToString(entryArr);
        }

        public static string ArrayToString(string[] entryArr)
        {
            string newText = "";
            for (int i = 0; i < entryArr.Length; ++i)
            {
                newText += entryArr[i];
            }
            return newText;
        }

        public static string[] StringToArray(string entry)
        {
            string[] entryArr = new string[entry.Length];

            for (int i = 0; i < entry.Length; ++i)
            {
                entryArr[i] = entry[i].ToString();
            }

            return entryArr;
        }

        // Returns an array of the characters of a given font
        // Yes, I know it's clunky. I tried just having them as strings and spliting them with StringToArray.
        // But each of these letters seem to actually count as multiple characters
        // and I think this is the easiest way to get the result I want.
        public static string[] GetFontArray(string fontName)
        {
            switch (fontName)
            {
                case "cursive":
                    string[] cursiveLetters = new string[] {"𝒶","𝒷","𝒸","𝒹","𝑒","𝒻","𝑔","𝒽","𝒾","𝒿","𝓀","𝓁","𝓂","𝓃","𝑜","𝓅","𝓆","𝓇","𝓈","𝓉","𝓊","𝓋","𝓌","𝓍","𝓎","𝓏",
                        "𝒜","𝐵","𝒞","𝒟","𝐸","𝐹","𝒢","𝐻","𝐼","𝒥","𝒦","𝐿","𝑀","𝒩","𝒪","𝒫","𝒬","𝑅","𝒮","𝒯","𝒰","𝒱","𝒲","𝒳","𝒴","𝒵",
                        "𝟶","𝟷","𝟸","𝟹","𝟺","𝟻","𝟼","𝟽","𝟾","𝟿"};
                    return cursiveLetters;
                case "cursive-bold":
                    string[] cursiveBoldLetters = new string[] {"𝓪","𝓫","𝓬","𝓭","𝓮","𝓯","𝓰","𝓱","𝓲","𝓳","𝓴","𝓵","𝓶","𝓷","𝓸","𝓹","𝓺","𝓻","𝓼","𝓽","𝓾","𝓿","𝔀","𝔁","𝔂","𝔃",
                        "𝓐","𝓑","𝓒","𝓓","𝓔","𝓕","𝓖","𝓗","𝓘","𝓙","𝓚","𝓛","𝓜","𝓝","𝓞","𝓟","𝓠","𝓡","𝓢","𝓣","𝓤","𝓥","𝓦","𝓧","𝓨","𝓩",
                        "𝟎","𝟏","𝟐","𝟑","𝟒","𝟓","𝟔","𝟕","𝟖","𝟗"};
                    return cursiveBoldLetters;
                case "italic":
                    string[] italicLetters = new string[] {"𝘢","𝘣","𝘤","𝘥","𝘦","𝘧","𝘨","𝘩","𝘪","𝘫","𝘬","𝘭","𝘮","𝘯","𝘰","𝘱","𝘲","𝘳","𝘴","𝘵","𝘶","𝘷","𝘸","𝘹","𝘺","𝘻",
                        "𝘈","𝘉","𝘊","𝘋","𝘌","𝘍","𝘎","𝘏","𝘐","𝘑","𝘒","𝘓","𝘔","𝘕","𝘖","𝘗","𝘘","𝘙","𝘚","𝘛","𝘜","𝘝","𝘞","𝘟","𝘠","𝘡",
                        "0","1","2","3","4","5","6","7","8","9"};
                    return italicLetters;
                case "italic-bold":
                    string[] boldItalicLetters = new string[] {"𝙖","𝙗","𝙘","𝙙","𝙚","𝙛","𝙜","𝙝","𝙞","𝙟","𝙠","𝙡","𝙢","𝙣","𝙤","𝙥","𝙦","𝙧","𝙨","𝙩","𝙪","𝙫","𝙬","𝙭","𝙮","𝙯",
                        "𝘼","𝘽","𝘾","𝘿","𝙀","𝙁","𝙂","𝙃","𝙄","𝙅","𝙆","𝙇","𝙈","𝙉","𝙊","𝙋","𝙌","𝙍","𝙎","𝙏","𝙐","𝙑","𝙒","𝙓","𝙔","𝙕",
                        "𝟎","𝟏","𝟐","𝟑","𝟒","𝟓","𝟖","𝟕","𝟖","𝟗"};
                    return boldItalicLetters;
                case "serif":
                    string[] serifLetters = new string[] {"𝚊","𝚋","𝚌","𝚍","𝚎","𝚏","𝚐","𝚑","𝚒","𝚓","𝚔","𝚕","𝚖","𝚗","𝚘","𝚙","𝚚","𝚛","𝚜","𝚝","𝚞","𝚟","𝚠","𝚡","𝚢","𝚣",
                        "𝙰","𝙱","𝙲","𝙳","𝙴","𝙵","𝙶","𝙷","𝙸","𝙹","𝙺","𝙻","𝙼","𝙽","𝙾","𝙿","𝚀","𝚁","𝚂","𝚃","𝚄","𝚅","𝚆","𝚇","𝚈","𝚉",
                        "𝟶","𝟷","𝟸","𝟹","𝟺","𝟻","𝟼","𝟽","𝟾","𝟿"};
                    return serifLetters;
                case "serif-bold":
                    string[] boldSerifLetters = new string[] {"𝐚","𝐛","𝐜","𝐝","𝐞","𝐟","𝐠","𝐡","𝐢","𝐣","𝐤","𝐥","𝐦","𝐧","𝐨","𝐩","𝐪","𝐫","𝐬","𝐭","𝐮","𝐯","𝐰","𝐱","𝐲","𝐳",
                        "𝐀","𝐁","𝐂","𝐃","𝐄","𝐅","𝐆","𝐇","𝐈","𝐉","𝐊","𝐋","𝐌","𝐍","𝐎","𝐏","𝐐","𝐑","𝐒","𝐓","𝐔","𝐕","𝐖","𝐗","𝐘","𝐙",
                        "𝟎","𝟏","𝟐","𝟑","𝟒","𝟓","𝟖","𝟕","𝟖","𝟗"};
                    return boldSerifLetters;
                case "lined":
                    string[] linedLetters = new string[] {"𝕒","𝕓","𝕔","𝕕","𝕖","𝕗","𝕘","𝕙","𝕚","𝕛","𝕜","𝕝","𝕞","𝕟","𝕠","𝕡","𝕢","𝕣","𝕤","𝕥","𝕦","𝕧","𝕨","𝕩","𝕪","𝕫",
                        "𝔸","𝔹","ℂ","𝔻","𝔼","𝔽","𝔾","ℍ","𝕀","𝕁","𝕂","𝕃","𝕄","ℕ","𝕆","𝕃","𝕀","𝕀","𝕊","𝕋","𝕌","𝕍","𝕎","𝕏","𝕐","ℤ",
                        "𝟘","𝟙","𝟚","𝟛","𝟜","𝟝","𝟞","𝟟","𝟠","𝟡"};
                    return linedLetters;
                case "thin":
                    string[] thinLetters = new string[] {"ａ","ｂ","ｃ","ｄ","ｅ","ｆ","ｇ","ｈ","ｉ","ｊ","ｋ","ｌ","ｍ","ｎ","ｏ","ｐ","ｑ","ｒ","ｓ","ｔ","ｕ","ｖ","ｗ","ｘ","ｙ","ｚ",
                        "Ａ","Ｂ","Ｃ","Ｄ","Ｅ","Ｆ","Ｇ","Ｈ","Ｉ","Ｊ","Ｋ","Ｌ","Ｍ","Ｎ","Ｏ","Ｐ","Ｑ","Ｒ","Ｓ","Ｔ","Ｕ","Ｖ","Ｗ","Ｘ","Ｙ","Ｚ",
                        "０","１","２","３","４","５","６","７","８","９"};
                    return thinLetters;
                case "medieval":
                    string[] medievalLetters = new string[] {"𝖆","𝖇","𝖈","𝖉","𝖊","𝖋","𝖌","𝖍","𝖎","𝖏","𝖐","𝖑","𝖒","𝖓","𝖔","𝖕","𝖖","𝖗","𝖘","𝖙","𝖚","𝖛","𝖜","𝖝","𝖞","𝖟",
                        "𝕬","𝕭","𝕮","𝕯","𝕰","𝕱","𝕲","𝕳","𝕴","𝕵","𝕶","𝕷","𝕸","𝕹","𝕺","𝕻","𝕼","𝕽","𝕾","𝕿","𝖀","𝖁","𝖂","𝖃","𝖄","𝖅",
                        "𝟶","𝟷","𝟸","𝟹","𝟺","𝟻","𝟼","𝟽","𝟾","𝟿"};
                    return medievalLetters;
                case "circle":
                    string[] circleLetters = new string[] {"ⓐ","ⓑ","ⓒ","ⓓ","ⓔ","ⓕ","ⓖ","ⓗ","ⓘ","ⓙ","ⓚ","ⓛ","ⓜ","ⓝ","ⓞ","ⓟ","ⓠ","ⓡ","ⓢ","ⓣ","ⓤ","ⓥ","ⓦ","ⓧ","ⓨ","ⓩ",
                        "Ⓐ","Ⓑ","Ⓒ","Ⓓ","Ⓔ","Ⓕ","Ⓖ","Ⓗ","Ⓘ","Ⓙ","Ⓚ","Ⓛ","Ⓜ","Ⓝ","Ⓞ","Ⓟ","Ⓠ","Ⓡ","Ⓢ","Ⓣ","Ⓤ","Ⓥ","Ⓦ","Ⓧ","Ⓨ","Ⓩ",
                        "⓪","①","②","③","④","⑤","⑥","⑦","⑧","⑨"};
                    return circleLetters;
                default:
                    string[] defaultLetters = new string[] {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
                        "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                        "0","1","2","3","4","5","6","7","8","9"};
                    return defaultLetters;
            }
        }
    }
}
