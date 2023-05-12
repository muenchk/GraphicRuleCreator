using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicRuleCreator
{
    /// <summary>
    /// Interaction logic for AlchemyExpansionMain.xaml
    /// </summary>
    public partial class AlchemyExpansionMain : Window
    {
        public void ProcessRule(string rule, string file)
        {
            if (rule.Length <= 0) // empty
                return;
            else if (rule[0] == ';') // comment
                return;

            // get splits
            string[] splits = rule.Split('|');
            if (splits.Length >= 3)
            {
                try
                {
                    int index = 0;
                    int version = Convert.ToInt32(splits[index]);
                    index++;
                    int type = Convert.ToInt32(splits[index]);
                    index++;
                    switch(type)
                    {
                        case 1001: // Effects
                            switch (version)
                            {
                                case 1:
                                    if (splits.Length != 9)
                                    {
                                        return;
                                    }
                                    Effects eff = new Effects();

                                    string ident = splits[index];
                                    index++;
                                    if (ident.Length > 3)
                                    {
                                        // remove brackets
                                        ident = ident.Substring(1);
                                        ident = ident.Substring(0, ident.Length - 1);
                                    }
                                    string[] spl = ident.Split(',');
                                    if (spl.Length != 2)
                                        return;
                                    try
                                    {
                                        eff.FormID = UInt32.Parse(spl[0], System.Globalization.NumberStyles.HexNumber);
                                    }
                                    catch
                                    {
                                        eff.EditorID = spl[0];
                                    }
                                    eff.PluginName = spl[1];
                                    eff.name = splits[index];
                                    index++;
                                    eff.EditorID = splits[index];
                                    index++;
                                    eff.ActorValue = (ActorValue)Convert.ToInt64(splits[index]);
                                    eff.ActorValueName = Utility.ToString(eff.ActorValue);
                                    index++;
                                    if (splits[index] == "1")
                                        eff.Overwrite = true;
                                    else
                                        eff.Overwrite = false;
                                    index++;
                                    if (eff.Overwrite == true)
                                    {
                                        if (splits[index].Length > 16)
                                        {
                                            eff.AlchemyEffect = new Alchem((AlchemyBaseEffectFirst)UInt64.Parse(splits[index].Substring(0, splits[index].Length - 16), System.Globalization.NumberStyles.HexNumber), AlchemyBaseEffectSecond.kNone);
                                        }
                                        else
                                            eff.AlchemyEffect = new Alchem(AlchemyBaseEffectFirst.kNone, (AlchemyBaseEffectSecond)UInt64.Parse(splits[index], System.Globalization.NumberStyles.HexNumber));
                                    }
                                    else
                                        eff.AlchemyEffect = Utility.ConvertToAlchemyEffect(eff.ActorValue);
                                    eff.AlchemyEffectName = Utility.ToString(eff.AlchemyEffect);
                                    index++;
                                    if (splits[index] == "1")
                                        eff.detrimental = true;
                                    else
                                        eff.detrimental = false;

                                    Func<Effects, bool> contains = (Effects x) =>
                                    {
                                        foreach (KeyValuePair<string, Effects> i in GraphicRuleCreator.Effects.effects)
                                        {
                                            if (x.name == i.Key)
                                                return true;
                                        }
                                        return false;
                                    };

                                    eff.file = file;

                                    if (contains(eff))
                                        GraphicRuleCreator.Effects.effects.Remove(eff.name);
                                    GraphicRuleCreator.Effects.effects.Add(eff.name, eff);

                                    break;
                            }
                            break;
                        case 1002: // Ingredient
                            switch (version)
                            {
                                case 1:
                                    // we have 19 fields
                                    if (splits.Length != 19)
                                    {
                                        return;
                                    }
                                    Ingredient ing = new Ingredient();

                                    string ident = splits[index];
                                    index++;
                                    if (ident.Length > 3)
                                    {
                                        // remove brackets
                                        ident = ident.Substring(1);
                                        ident = ident.Substring(0, ident.Length - 1);
                                    }
                                    string[] spl = ident.Split(',');
                                    if (spl.Length != 2)
                                        return;
                                    try
                                    {
                                        ing.FormID = UInt32.Parse(spl[0], System.Globalization.NumberStyles.HexNumber);
                                    }
                                    catch
                                    {
                                        ing.EditorID = spl[0];
                                    }
                                    ing.PluginName = spl[1];
                                    ing.name = splits[index];
                                    index++;
                                    ing.EditorID = splits[index];
                                    index++;
                                    ing.Weight = Convert.ToDouble(splits[index]);
                                    index++;
                                    ing.value = Convert.ToInt32(splits[index]);
                                    index++;
                                    ing.Effect1 = splits[index];
                                    index++;
                                    ing.Duration1 = Convert.ToInt32(splits[index]);
                                    index++;
                                    ing.Magnitude1 = Convert.ToDouble(splits[index]);
                                    index++;
                                    ing.Effect2 = splits[index];
                                    index++;
                                    ing.Duration2 = Convert.ToInt32(splits[index]);
                                    index++;
                                    ing.Magnitude2 = Convert.ToDouble(splits[index]);
                                    index++;
                                    ing.Effect3 = splits[index];
                                    index++;
                                    ing.Duration3 = Convert.ToInt32(splits[index]);
                                    index++;
                                    ing.Magnitude3 = Convert.ToDouble(splits[index]);
                                    index++;
                                    ing.Effect4 = splits[index];
                                    index++;
                                    ing.Duration4 = Convert.ToInt32(splits[index]);
                                    index++;
                                    ing.Magnitude4 = Convert.ToDouble(splits[index]);

                                    Func<Ingredient, bool> contains = (Ingredient x) =>
                                    {
                                        foreach(Ingredient i in Ingredient.ingredients)
                                        {
                                            if (x.FormID == i.FormID || x.EditorID == i.EditorID)
                                                return true;
                                        }
                                        return false;
                                    };

                                    ing.file = file;

                                    if (contains(ing))
                                        Ingredient.ingredients.RemoveAll((x) => { if (x.FormID == ing.FormID || x.EditorID == ing.EditorID) return true; else return false; });
                                    Ingredient.ingredients.Add(ing);
                                    break;
                            }
                            break;
                        case 1003: // Potion
                            switch (version)
                            {
                                case 1:
                                    // we have 19 fields
                                    if (splits.Length != 8)
                                    {
                                        return;
                                    }
                                    Potion pot = new Potion();

                                    string ident = splits[index];
                                    index++;
                                    if (ident.Length > 3)
                                    {
                                        // remove brackets
                                        ident = ident.Substring(1);
                                        ident = ident.Substring(0, ident.Length - 1);
                                    }
                                    string[] spl = ident.Split(',');
                                    if (spl.Length != 2)
                                        return;
                                    try
                                    {
                                        pot.FormID = UInt32.Parse(spl[0], System.Globalization.NumberStyles.HexNumber);
                                    }
                                    catch
                                    {
                                        pot.EditorID = spl[0];
                                    }
                                    pot.PluginName = spl[1];
                                    pot.name = splits[index];
                                    index++;
                                    pot.EditorID = splits[index];
                                    index++;
                                    pot.Weight = Convert.ToDouble(splits[index]);
                                    index++;
                                    pot.value = Convert.ToInt32(splits[index]);
                                    index++;

                                    string[] effectssplit = splits[index].Split(';');
                                    index++;
                                    if (effectssplit.Length > 0)
                                    {
                                        string[] sp = effectssplit[0].Split(',');
                                        pot.Effect1 = sp[0];
                                        pot.Duration1 = Convert.ToInt32(sp[1]);
                                        pot.Magnitude1 = Convert.ToDouble(sp[2]);
                                    }
                                    if (effectssplit.Length > 1)
                                    {
                                        string[] sp = effectssplit[1].Split(',');
                                        pot.Effect2 = sp[0];
                                        pot.Duration2 = Convert.ToInt32(sp[1]);
                                        pot.Magnitude2 = Convert.ToDouble(sp[2]);
                                    }
                                    if (effectssplit.Length > 2)
                                    {
                                        string[] sp = effectssplit[2].Split(',');
                                        pot.Effect3 = sp[0];
                                        pot.Duration3 = Convert.ToInt32(sp[1]);
                                        pot.Magnitude3 = Convert.ToDouble(sp[2]);
                                    }
                                    if (effectssplit.Length > 3)
                                    {
                                        string[] sp = effectssplit[3].Split(',');
                                        pot.Effect4 = sp[0];
                                        pot.Duration4 = Convert.ToInt32(sp[1]);
                                        pot.Magnitude4 = Convert.ToDouble(sp[2]);
                                    }
                                    if (effectssplit.Length > 4)
                                    {
                                        string[] sp = effectssplit[4].Split(',');
                                        pot.Effect5 = sp[0];
                                        pot.Duration5 = Convert.ToInt32(sp[1]);
                                        pot.Magnitude5 = Convert.ToDouble(sp[2]);
                                    }
                                    if (effectssplit.Length > 5)
                                    {
                                        string[] sp = effectssplit[5].Split(',');
                                        pot.Effect6 = sp[0];
                                        pot.Duration6 = Convert.ToInt32(sp[1]);
                                        pot.Magnitude6 = Convert.ToDouble(sp[2]);
                                    }

                                    Func<Potion, bool> contains = (Potion x) =>
                                    {
                                        foreach (Potion i in Potion.potions)
                                        {
                                            if (x.FormID == i.FormID || x.EditorID == i.EditorID)
                                                return true;
                                        }
                                        return false;
                                    };

                                    pot.file = file;

                                    if (contains(pot))
                                        Potion.potions.RemoveAll((x) => { if (x.FormID == pot.FormID || x.EditorID == pot.EditorID) return true; else return false; });
                                    Potion.potions.Add(pot);
                                    break;
                            }
                            break;
                    }
                }
                catch
                {

                }
            } 
            else // invalid number of fields
            {
                return;
            }
        }

        public string CreateRule_Ingredient(Ingredient ing)
        {
            string rule = "";
            // version
            rule += "1";
            // type
            rule += "|1002";
            // ident
            string ident = "<";
            {
                if (ing.FormID != 0)
                    ident += ing.FormID.ToString("X");
                else
                    ident += ing.EditorID;
                ident += ",";
                ident += ing.PluginName;
                ident += ">";
            }
            rule += "|" + ident;
            // name
            rule += "|" + ing.name;
            rule += "|" + ing.EditorID;
            rule += "|" + ing.Weight.ToString();
            rule += "|" + ing.value.ToString();
            rule += "|" + ing.Effect1;
            rule += "|" + ing.Duration1;
            rule += "|" + ing.Magnitude1;
            rule += "|" + ing.Effect2;
            rule += "|" + ing.Duration2;
            rule += "|" + ing.Magnitude2;
            rule += "|" + ing.Effect3;
            rule += "|" + ing.Duration3;
            rule += "|" + ing.Magnitude3;
            rule += "|" + ing.Effect4;
            rule += "|" + ing.Duration4;
            rule += "|" + ing.Magnitude4;

            return rule;
        }

        public string CreateRule_Potion(Potion pot)
        {
            string rule = "";
            // version
            rule += "1";
            // type
            rule += "|1003";
            // ident
            string ident = "<";
            {
                if (pot.FormID != 0)
                    ident += pot.FormID.ToString("X");
                else
                    ident += pot.EditorID;
                ident += ",";
                ident += pot.PluginName;
                ident += ">";
            }
            rule += "|" + ident;
            // name
            rule += "|" + pot.name;
            rule += "|" + pot.EditorID;
            rule += "|" + pot.Weight.ToString();
            rule += "|" + pot.value.ToString();
            rule += "|";
            if (pot.Effect1 != "")
            {
                rule += pot.Effect1 + "," + pot.Duration1 + "," + pot.Magnitude1;
            }
            if (pot.Effect2 != "")
            {
                rule += ";" + pot.Effect2 + "," + pot.Duration2 + "," + pot.Magnitude2;
            }
            if (pot.Effect3 != "")
            {
                rule += ";" + pot.Effect3 + "," + pot.Duration3 + "," + pot.Magnitude3;
            }
            if (pot.Effect4 != "")
            {
                rule += ";" + pot.Effect4 + "," + pot.Duration4 + "," + pot.Magnitude4;
            }
            if (pot.Effect5 != "")
            {
                rule += ";" + pot.Effect5 + "," + pot.Duration5 + "," + pot.Magnitude5;
            }
            if (pot.Effect6 != "")
            {
                rule += ";" + pot.Effect6 + "," + pot.Duration6 + "," + pot.Magnitude6;
            }

            return rule;
        }

        public string CreateRule_Effect(Effects eff)
        {
            string rule = "";

            // version
            rule += "1";
            // type
            rule += "|1001";
            // ident
            string ident = "<";
            {
                if (eff.FormID != 0)
                    ident += eff.FormID.ToString("X");
                else
                    ident += eff.EditorID;
                ident += ",";
                ident += eff.PluginName;
                ident += ">";
            }
            rule += "|" + ident;
            // name
            rule += "|" + eff.name;
            // editorid
            rule += "|" + eff.EditorID;
            // actorvalue
            rule += "|" + ((Int32)eff.ActorValue).ToString();
            // overwrite
            if (eff.Overwrite == true)
                rule += "|1";
            else
                rule += "|0";
            // AlchemyEffect (Overwrite)
            rule += "|" + eff.AlchemyEffect.ToString();
            // detrimental
            if (eff.detrimental == true)
                rule += "|1";
            else
                rule += "|0";

            return rule;
        }

        AlchemyExpansionEffects WinEff;
        AlchemyExpansionIngredients WinIng;
        AlchemyExpansionPotions WinPot;

        HashSet<AlchemyExpansionIngredients> updatesIng = new HashSet<AlchemyExpansionIngredients>();
        HashSet<AlchemyExpansionPotions> updatesPot = new HashSet<AlchemyExpansionPotions>();

        public AlchemyExpansionMain()
        {
            InitializeComponent();
            // load all available rules

            updatesIng.Clear();
            updatesPot.Clear();

            WinIng = new AlchemyExpansionIngredients(this);
            WinIng.Show();
            WinPot = new AlchemyExpansionPotions(this);
            WinPot.Show();
            WinEff = new AlchemyExpansionEffects(this);
            WinEff.Show();
        }

        public void WriteConsole(string message)
        {
            //console.Items.Add(message);
            //console.ScrollIntoView(message);
            //console.UpdateLayout();
            console.Text = message;
        }

        public void Update()
        {
            WinIng.Update();
            WinEff.Update();
            foreach(var window in updatesIng)
                window.Update();
            WinPot.Update();
            foreach (var window in updatesPot)
                window.Update();
        }

        public void RegisterForUpdate(AlchemyExpansionIngredients window)
        {
            updatesIng.Add(window);
        }

        public void UnregisterForUpdate(AlchemyExpansionIngredients window)
        {
            updatesIng.Remove(window);
        }

        public void RegisterForUpdate(AlchemyExpansionPotions window)
        {
            updatesPot.Add(window);
        }

        public void UnregisterForUpdate(AlchemyExpansionPotions window)
        {
            updatesPot.Remove(window);
        }


        int lc = 0;
        private void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            activeFile.Items.Clear();
            activeFile.Items.Add("");
            lc++;
            WriteConsole("Loading files");
            GraphicRuleCreator.Effects.effects.Clear();
            Ingredient.ingredients.Clear();
            // get current dir
            string path = Environment.CurrentDirectory;
            if (path != null)
            {
                // search for all valid rule files in the current directory
                string[] files = System.IO.Directory.GetFiles(path);
                List<string> lfiles = new List<string>(files);
                lfiles.Sort();
                files = lfiles.ToArray();
                List<string> lines = new List<string>();

                foreach (string file in files)
                {
                    if (file.Substring(file.Length - "_ALCH_DIST.ini".Length) == "_ALCH_DIST.ini")
                    {
                        WriteConsole("Loading file " + file);
                        try
                        {
                            string[] tmp = System.IO.File.ReadAllLines(file);
                            lines.AddRange(tmp);
                            for (int i = 0; i < tmp.Length; i++)
                            {
                                ProcessRule(tmp[i], System.IO.Path.GetFileName(file));
                            }
                            activeFile.Items.Add(System.IO.Path.GetFileName(file));
                        }
                        catch { }
                    }
                }

                /*for (int i = 0; i < lines.Count; i++)
                {
                    ProcessRule(lines[i]);
                }*/
            }

            Utility.CalcAllReferences();
            Update();

            WriteConsole("Loading finished " + lc.ToString());
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory;
            if (activeFile.SelectedIndex > 0 && path != null)
                PerformSave(false, path + System.IO.Path.DirectorySeparatorChar + (activeFile.SelectedItem as String), (activeFile.SelectedItem as String));
            else
                Save(false);
        }

        public void Save(bool overwrite = false)
        {
            WriteConsole("Saving Data");
            // get current dir
            string path = Environment.CurrentDirectory;
            if (path != null)
            {
                SaveFileDialog diag = new SaveFileDialog();
                diag.AddExtension = true;
                diag.DefaultExt = "ini";
                diag.InitialDirectory = path;
                if (diag.ShowDialog() == true)
                {
                    string file = diag.FileName;
                    string custext = "_ALCH_DIST.ini";
                    if (!file.Contains(custext))
                    {
                        file = file.Substring(0, file.Length - 4);
                        file += "_ALCH_DIST.ini";
                    }

                    PerformSave(overwrite, file);
                }
            }
            WriteConsole("Saving Failed");
        }

        public void PerformSave(bool overwrite, string file, string filename = "")
        {
            if (file != null)
            {
                List<string> rules = new List<string>();

                rules.Add("; Configuration of the mod AlchemyExpansion");
                rules.Add("");
                rules.Add("");
                rules.Add(";;;;;;;;;; Effects ;;;;;;;;;;");

                Dictionary<string, List<Effects>> plugins = new Dictionary<string, List<Effects>>();

                foreach (KeyValuePair<string, Effects> eff in GraphicRuleCreator.Effects.effects)
                {
                    List<Effects>? res;
                    plugins.TryGetValue(eff.Value.PluginName, out res);
                    if (res != null)
                    {
                        res.Add(eff.Value);
                    }
                    else
                        plugins.Add(eff.Value.PluginName, new List<Effects>() { eff.Value });
                }

                foreach (KeyValuePair<string, List<Effects>> pair in plugins)
                {
                    List<string> strings = new List<string>();

                    var list = pair.Value;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].modified == false && !overwrite && list[i].file != filename)
                            continue;
                        if (list[i].EditorID != "")
                            strings.Add("; " + list[i].EditorID);
                        strings.Add(CreateRule_Effect(list[i]));
                        strings.Add("");
                    }

                    if (strings.Count > 0)
                    {
                        rules.Add(";;;;; " + pair.Key + " ;;;;;");
                        rules.Add("");

                        rules.AddRange(strings);

                        rules.Add("");
                        rules.Add("");
                    }
                }

                rules.Add("");
                rules.Add("");
                rules.Add(";;;;;;;;;; Ingredients ;;;;;;;;;;");

                plugins.Clear();
                Dictionary<string, List<Ingredient>> pluginsI = new Dictionary<string, List<Ingredient>>();

                foreach (Ingredient ing in Ingredient.ingredients)
                {
                    List<Ingredient>? res;
                    pluginsI.TryGetValue(ing.PluginName, out res);
                    if (res != null)
                    {
                        res.Add(ing);
                    }
                    else
                        pluginsI.Add(ing.PluginName, new List<Ingredient>() { ing });
                }

                foreach (KeyValuePair<string, List<Ingredient>> pair in pluginsI)
                {
                    List<string> strings = new List<string>();

                    var list = pair.Value;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].modified == false && !overwrite && list[i].file != filename)
                            continue;
                        if (list[i].EditorID != "")
                            strings.Add("; " + list[i].EditorID);
                        strings.Add(CreateRule_Ingredient(list[i]));
                        strings.Add("");
                    }

                    if (strings.Count > 0)
                    {
                        rules.Add(";;;;; " + pair.Key + " ;;;;;");
                        rules.Add("");

                        rules.AddRange(strings);

                        rules.Add("");
                        rules.Add("");
                    }

                }

                rules.Add("");
                rules.Add("");
                rules.Add(";;;;;;;;;; Potions ;;;;;;;;;;");

                plugins.Clear();
                Dictionary<string, List<Potion>> pluginsP = new Dictionary<string, List<Potion>>();

                foreach (Potion pot in Potion.potions)
                {
                    List<Potion>? res;
                    pluginsP.TryGetValue(pot.PluginName, out res);
                    if (res != null)
                    {
                        res.Add(pot);
                    }
                    else
                        pluginsP.Add(pot.PluginName, new List<Potion>() { pot });
                }

                foreach (KeyValuePair<string, List<Potion>> pair in pluginsP)
                {
                    List<string> strings = new List<string>();

                    var list = pair.Value;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].modified == false && !overwrite && list[i].file != filename)
                            continue;
                        if (list[i].EditorID != "")
                            strings.Add("; " + list[i].EditorID);
                        strings.Add(CreateRule_Potion(list[i]));
                        strings.Add("");
                    }

                    if (strings.Count > 0)
                    {
                        rules.Add(";;;;; " + pair.Key + " ;;;;;");
                        rules.Add("");

                        rules.AddRange(strings);

                        rules.Add("");
                        rules.Add("");
                    }

                }

                try
                {
                    System.IO.File.WriteAllLinesAsync(file, rules.ToArray());
                }
                catch
                {

                }

                WriteConsole("Saving Finished");
                return;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Save_Overwrite_Click(object sender, RoutedEventArgs e)
        {
            Save(true);
        }

        private void SelectActiveFile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
