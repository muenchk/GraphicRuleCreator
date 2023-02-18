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
        public void ProcessRule(string rule)
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
                                        eff.AlchemyEffect = (AlchemyEffect)UInt64.Parse(splits[index], System.Globalization.NumberStyles.HexNumber);
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

                                    if (contains(ing))
                                        Ingredient.ingredients.RemoveAll((x) => { if (x.FormID == ing.FormID || x.EditorID == ing.EditorID) return true; else return false; });
                                    Ingredient.ingredients.Add(ing);
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
            rule += "|" + ((UInt64)eff.AlchemyEffect).ToString("X");
            // detrimental
            if (eff.detrimental == true)
                rule += "|1";
            else
                rule += "|0";

            return rule;
        }

        AlchemyExpansionEffects WinEff;
        AlchemyExpansionIngredients WinIng;

        HashSet<AlchemyExpansionIngredients> updatesIng = new HashSet<AlchemyExpansionIngredients>();

        public AlchemyExpansionMain()
        {
            InitializeComponent();
            // load all available rules

            updatesIng.Clear();

            WinIng = new AlchemyExpansionIngredients(this);
            WinIng.Show();
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
        }

        public void RegisterForUpdate(AlchemyExpansionIngredients window)
        {
            updatesIng.Add(window);
        }

        public void UnregisterForUpdate(AlchemyExpansionIngredients window)
        {
            updatesIng.Remove(window);
        }

        int lc = 0;
        private void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            lc++;
            WriteConsole("Loading files");
            GraphicRuleCreator.Effects.effects.Clear();
            Ingredient.ingredients.Clear();
            // get current dir
            string? path = System.IO.Path.GetDirectoryName(typeof(AlchemyExpansionMain).Assembly.Location);
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
                        }
                        catch { }
                    }
                }

                for (int i = 0; i < lines.Count; i++)
                {
                    ProcessRule(lines[i]);
                }
            }

            Utility.CalcAllReferences();
            Update();

            WriteConsole("Loading finished " + lc.ToString());
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            WriteConsole("Saving Data");
            // get current dir
            string? path = System.IO.Path.GetDirectoryName(typeof(AlchemyExpansionMain).Assembly.Location);
            if (path != null)
            {
                SaveFileDialog diag = new SaveFileDialog();
                diag.AddExtension = true;
                diag.DefaultExt = "_ALCH_DIST.ini";
                diag.InitialDirectory = path;
                if (diag.ShowDialog() == true)
                {
                    string file = diag.FileName;

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
                                if (list[i].modified == false)
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
                                if (list[i].modified == false)
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
            }
            WriteConsole("Saving Failed");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
