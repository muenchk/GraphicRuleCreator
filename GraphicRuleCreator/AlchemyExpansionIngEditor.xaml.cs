using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace GraphicRuleCreator
{
    /// <summary>
    /// Interaction logic for AlchemyExpansionIngEditor.xaml
    /// </summary>
    public partial class AlchemyExpansionIngEditor : Window
    {

        public int GetIndex(string x)
        {
            for (int i = 0; i < effList.Length; i++)
            {
                if (effList[i] == x)
                    return i;
            }
            return effList.Length -1;
        }

        Ingredient ingredient;
        string[] effList;

        public AlchemyExpansionIngEditor(Ingredient ing)
        {
            InitializeComponent();
            Settings.Effects.Identifier ident = Settings.Effects.Identifier._None;
            ingredient = ing;
            FormID.Text = ing.FormID.ToString("X");
            EditorID.Text = ing.EditorID;
            PluginName.Text = ing.PluginName;
            Name.Text = ing.name;
            Weight.Text = ing.Weight.ToString();
            Value.Text = ing.value.ToString();

            if ((ident = Settings.Effects.GetType(ing.Duration1)) != Settings.Effects.Identifier._None)
                Duration1.Text = Settings.Effects.ToString(ident);
            else
                Duration1.Text = ing.Duration1.ToString();

            if ((ident = Settings.Effects.GetType((int)ing.Magnitude1)) != Settings.Effects.Identifier._None)
                Magnitude1.Text = Settings.Effects.ToString(ident);
            else
                Magnitude1.Text = ing.Duration1.ToString();

            if ((ident = Settings.Effects.GetType(ing.Duration2)) != Settings.Effects.Identifier._None)
                Duration2.Text = Settings.Effects.ToString(ident);
            else
                Duration2.Text = ing.Duration1.ToString();

            if ((ident = Settings.Effects.GetType((int)ing.Magnitude2)) != Settings.Effects.Identifier._None)
                Magnitude2.Text = Settings.Effects.ToString(ident);
            else
                Magnitude2.Text = ing.Duration1.ToString();

            if ((ident = Settings.Effects.GetType(ing.Duration3)) != Settings.Effects.Identifier._None)
                Duration3.Text = Settings.Effects.ToString(ident);
            else
                Duration3.Text = ing.Duration1.ToString();

            if ((ident = Settings.Effects.GetType((int)ing.Magnitude3)) != Settings.Effects.Identifier._None)
                Magnitude3.Text = Settings.Effects.ToString(ident);
            else
                Magnitude3.Text = ing.Duration1.ToString();

            if ((ident = Settings.Effects.GetType(ing.Duration4)) != Settings.Effects.Identifier._None)
                Duration4.Text = Settings.Effects.ToString(ident);
            else
                Duration4.Text = ing.Duration1.ToString();

            if ((ident = Settings.Effects.GetType((int)ing.Magnitude4)) != Settings.Effects.Identifier._None)
                Magnitude4.Text = Settings.Effects.ToString(ident);
            else
                Magnitude4.Text = ing.Duration1.ToString();

            HashSet<string> effects = new HashSet<string>();


            foreach (var pair in Effects.effects)
            {
                effects.Add(pair.Key);
            }
            Queue<string> queue = new Queue<string>(effects.ToArray());
            queue.Enqueue("");
            effList = queue.ToArray();
            for (int i = 0; i < effList.Length; i++)
            {
                Effect1.Items.Add(effList[i]);
                Effect2.Items.Add(effList[i]);
                Effect3.Items.Add(effList[i]);
                Effect4.Items.Add(effList[i]);
            }
            Effect1.SelectedIndex = GetIndex(ing.Effect1);
            Effect2.SelectedIndex = GetIndex(ing.Effect2);
            Effect3.SelectedIndex = GetIndex(ing.Effect3);
            Effect4.SelectedIndex = GetIndex(ing.Effect4);


            Name.Focus();
            Name.SelectAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            error.Text = "";
            UInt32 formid = 0;
            double weight = 0;
            int val = 0;
            int dur1 = 0;
            int dur2 = 0;
            int dur3 = 0;
            int dur4 = 0;
            double mag1 = 0;
            double mag2 = 0;
            double mag3 = 0;
            double mag4 = 0;

            Settings.Effects.Identifier ident = Settings.Effects.Identifier._None;

            try
            {
                formid = UInt32.Parse(FormID.Text, System.Globalization.NumberStyles.HexNumber);
            } catch { error.Text = "FormID: Wrong Format"; return; }
            if (formid == 0)
            {
                error.Text = "FormID: Wrong format or zero";
                return;
            }    
            if (Name.Text == "")
            {
                error.Text = "Name: cannot be empty";
                return;
            }
            try
            {
                weight = Math.Round(Double.Parse(Weight.Text, System.Globalization.NumberStyles.Float), 2);
            }
            catch { error.Text = "Weight: Wrong Format"; return; }
            try
            {
                val = Int32.Parse(Value.Text);
            }
            catch { error.Text = "Value: Wrong Format"; return; }
            // Durations
            if ((ident = Settings.Effects.FromString(Duration1.Text)) != Settings.Effects.Identifier._None)
            {
                dur1 = (int)Settings.Effects.GetValue(ident);
            }
            else
            {
                try
                {
                    dur1 = Int32.Parse(Duration1.Text);
                }
                catch { error.Text = "Duration1: Wrong Format"; return; }
            }
            if ((ident = Settings.Effects.FromString(Duration2.Text)) != Settings.Effects.Identifier._None)
            {
                dur2 = (int)Settings.Effects.GetValue(ident);
            }
            else
            {
                try
                {
                    dur2 = Int32.Parse(Duration2.Text);
                }
                catch { error.Text = "Duration2: Wrong Format"; return; }
            }
            if ((ident = Settings.Effects.FromString(Duration3.Text)) != Settings.Effects.Identifier._None)
            {
                dur3 = (int)Settings.Effects.GetValue(ident);
            }
            else
            {
                try
                {
                    dur3 = Int32.Parse(Duration3.Text);
                }
                catch { error.Text = "Duration3: Wrong Format"; return; }
            }
            if ((ident = Settings.Effects.FromString(Duration4.Text)) != Settings.Effects.Identifier._None)
            {
                dur4 = (int)Settings.Effects.GetValue(ident);
            }
            else
            {
                try
                {
                    dur4 = Int32.Parse(Duration4.Text);
                }
                catch { error.Text = "Duration4: Wrong Format"; return; }
            }
            // Magnitudes
            if ((ident = Settings.Effects.FromString(Magnitude1.Text)) != Settings.Effects.Identifier._None)
            {
                mag1 = (int)Settings.Effects.GetValue(ident);
            }
            else
            {
                try
                {
                    mag1 = Math.Round(Double.Parse(Magnitude1.Text, System.Globalization.NumberStyles.Float), 2);
                }
                catch { error.Text = "Magnitude1: Wrong Format"; return; }
            }
            if ((ident = Settings.Effects.FromString(Magnitude2.Text)) != Settings.Effects.Identifier._None)
            {
                mag2 = (int)Settings.Effects.GetValue(ident);
            }
            else
            {
                try
                {
                    mag2 = Math.Round(Double.Parse(Magnitude2.Text, System.Globalization.NumberStyles.Float), 2);
                }
                catch { error.Text = "Magnitude2: Wrong Format"; return; }
            }
            if ((ident = Settings.Effects.FromString(Magnitude3.Text)) != Settings.Effects.Identifier._None)
            {
                mag3 = (int)Settings.Effects.GetValue(ident);
            }
            else
            {
                try
                {
                    mag3 = Math.Round(Double.Parse(Magnitude3.Text, System.Globalization.NumberStyles.Float), 2);
                }
                catch { error.Text = "Magnitude3: Wrong Format"; return; }
            }
            if ((ident = Settings.Effects.FromString(Magnitude4.Text)) != Settings.Effects.Identifier._None)
            {
                mag4 = (int)Settings.Effects.GetValue(ident);
            }
            else
            {
                try
                {
                    mag4 = Math.Round(Double.Parse(Magnitude4.Text, System.Globalization.NumberStyles.Float), 2);
                }
                catch { error.Text = "Magnitude4: Wrong Format"; return; }
            }


            ingredient.FormID = formid;
            ingredient.EditorID = EditorID.Text;
            ingredient.PluginName = PluginName.Text;
            ingredient.name.Content = Name.Text;
            ingredient.value = val;
            ingredient.Weight = weight;
            ingredient.Effect1 = Effect1.SelectedItem as string;
            ingredient.Effect2 = Effect2.SelectedItem as string;
            ingredient.Effect3 = Effect3.SelectedItem as string;
            ingredient.Effect4 = Effect4.SelectedItem as string;
            ingredient.Duration1 = dur1;
            ingredient.Duration2 = dur2;
            ingredient.Duration3 = dur3;
            ingredient.Duration4 = dur4;
            ingredient.Magnitude1 = mag1;
            ingredient.Magnitude2 = mag2;
            ingredient.Magnitude3 = mag3;
            ingredient.Magnitude4 = mag4;

            ingredient.modified = true;

            Utility.CalcAllReferences();

            Close();
        }

        private void Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                FormID.Focus();
                FormID.SelectAll();
            }
        }

        private void FormID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                EditorID.Focus();
                EditorID.SelectAll();
            }
        }

        private void EditorID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                PluginName.Focus();
                PluginName.SelectAll();
            }
        }

        private void PluginName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Weight.Focus();
                Weight.SelectAll();
            }
        }

        private void Weight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Value.Focus();
                Value.SelectAll();
            }
        }

        private void Value_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Effect1.Focus();
            }
        }

        private void Effect1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Duration1.Focus();
                Duration1.SelectAll();
            }
        }

        private void Duration1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Magnitude1.Focus();
                Magnitude1.SelectAll();
            }
        }

        private void Magnitude1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Effect2.Focus();
            }
        }

        private void Effect2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Duration2.Focus();
                Duration2.SelectAll();
            }
        }

        private void Duration2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Magnitude2.Focus();
                Magnitude2.SelectAll();
            }
        }

        private void Magnitude2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Effect3.Focus();
            }
        }

        private void Effect3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Duration3.Focus();
                Duration3.SelectAll();
            }
        }

        private void Duration3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Magnitude3.Focus();
                Magnitude3.SelectAll();
            }
        }

        private void Magnitude3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Effect4.Focus();
            }
        }

        private void Effect4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Duration4.Focus();
                Duration4.SelectAll();
            }
        }

        private void Duration4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Magnitude4.Focus();
                Magnitude4.SelectAll();
            }
        }

        private void Magnitude4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                save.Focus();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                Button_Click(sender, new RoutedEventArgs());
            }
        }
    }
}
