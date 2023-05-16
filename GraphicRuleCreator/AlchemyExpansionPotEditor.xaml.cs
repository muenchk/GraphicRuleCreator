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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GraphicRuleCreator
{
    /// <summary>
    /// Interaction logic for AlchemyExpansionPotEditor.xaml
    /// </summary>
    public partial class AlchemyExpansionPotEditor : Window
    {
        public int GetIndex(string x)
        {
            for (int i = 0; i < effList.Length; i++)
            {
                if (effList[i] == x)
                    return i;
            }
            return effList.Length - 1;
        }

        Potion potion;
        string[] effList;

        public AlchemyExpansionPotEditor(Potion pot)
        {
            InitializeComponent();
            potion = pot;
            FormID.Text = pot.FormID.ToString("X");
            EditorID.Text = pot.EditorID;
            PluginName.Text = pot.PluginName;
            Name.Text = pot.name;
            Weight.Text = pot.Weight.ToString();
            Value.Text = pot.value.ToString();
            Duration1.Text = pot.Duration1.ToString();
            Magnitude1.Text = pot.Magnitude1.ToString();
            Duration2.Text = pot.Duration2.ToString();
            Magnitude2.Text = pot.Magnitude2.ToString();
            Duration3.Text = pot.Duration3.ToString();
            Magnitude3.Text = pot.Magnitude3.ToString();
            Duration4.Text = pot.Duration4.ToString();
            Magnitude4.Text = pot.Magnitude4.ToString();
            Duration5.Text = pot.Duration5.ToString();
            Magnitude5.Text = pot.Magnitude5.ToString();
            Duration6.Text = pot.Duration6.ToString();
            Magnitude6.Text = pot.Magnitude6.ToString();

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
                Effect5.Items.Add(effList[i]);
                Effect6.Items.Add(effList[i]);
            }
            Effect1.SelectedIndex = GetIndex(pot.Effect1);
            Effect2.SelectedIndex = GetIndex(pot.Effect2);
            Effect3.SelectedIndex = GetIndex(pot.Effect3);
            Effect4.SelectedIndex = GetIndex(pot.Effect4);
            Effect5.SelectedIndex = GetIndex(pot.Effect5);
            Effect6.SelectedIndex = GetIndex(pot.Effect6);


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
            int dur5 = 0;
            int dur6 = 0;
            double mag1 = 0;
            double mag2 = 0;
            double mag3 = 0;
            double mag4 = 0;
            double mag5 = 0;
            double mag6 = 0;

            Settings.Effects.Identifier ident = Settings.Effects.Identifier._None;

            try
            {
                formid = UInt32.Parse(FormID.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch { error.Text = "FormID: Wrong Format"; return; }
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
            if ((ident = Settings.Effects.FromString(Duration5.Text)) != Settings.Effects.Identifier._None)
            {
                dur5 = (int)Settings.Effects.GetValue(ident);
            }
            else
            {
                try
                {
                    dur5 = Int32.Parse(Duration5.Text);
                }
                catch { error.Text = "Duration5: Wrong Format"; return; }
            }
            if ((ident = Settings.Effects.FromString(Duration6.Text)) != Settings.Effects.Identifier._None)
            {
                dur6 = (int)Settings.Effects.GetValue(ident);
            }
            else
            {
                try
                {
                    dur6 = Int32.Parse(Duration6.Text);
                }
                catch { error.Text = "Duration6: Wrong Format"; return; }
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
            if ((ident = Settings.Effects.FromString(Magnitude5.Text)) != Settings.Effects.Identifier._None)
            {
                mag5 = (int)Settings.Effects.GetValue(ident);
            }
            else
            {
                try
                {
                    mag5 = Math.Round(Double.Parse(Magnitude5.Text, System.Globalization.NumberStyles.Float), 2);
                }
                catch { error.Text = "Magnitude5: Wrong Format"; return; }
            }
            if ((ident = Settings.Effects.FromString(Magnitude6.Text)) != Settings.Effects.Identifier._None)
            {
                mag6 = (int)Settings.Effects.GetValue(ident);
            }
            else
            {
                try
                {
                    mag6 = Math.Round(Double.Parse(Magnitude6.Text, System.Globalization.NumberStyles.Float), 2);
                }
                catch { error.Text = "Magnitude6: Wrong Format"; return; }
            }


            potion.FormID = formid;
            potion.EditorID = EditorID.Text;
            potion.PluginName = PluginName.Text;
            potion.name.Content = Name.Text;
            potion.value = val;
            potion.Weight = weight;
            potion.Effect1 = Effect1.SelectedItem as string;
            potion.Effect2 = Effect2.SelectedItem as string;
            potion.Effect3 = Effect3.SelectedItem as string;
            potion.Effect4 = Effect4.SelectedItem as string;
            potion.Effect5 = Effect5.SelectedItem as string;
            potion.Effect6 = Effect6.SelectedItem as string;
            potion.Duration1 = dur1;
            potion.Duration2 = dur2;
            potion.Duration3 = dur3;
            potion.Duration4 = dur4;
            potion.Duration5 = dur5;
            potion.Duration6 = dur6;
            potion.Magnitude1 = mag1;
            potion.Magnitude2 = mag2;
            potion.Magnitude3 = mag3;
            potion.Magnitude4 = mag4;
            potion.Magnitude5 = mag5;
            potion.Magnitude6 = mag6;

            potion.modified = true;

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
                Effect5.Focus();
            }
        }

        private void Effect5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Duration5.Focus();
                Duration5.SelectAll();
            }
        }

        private void Duration5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Magnitude5.Focus();
                Magnitude5.SelectAll();
            }
        }

        private void Magnitude5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Effect6.Focus();
            }
        }

        private void Effect6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Duration6.Focus();
                Duration6.SelectAll();
            }
        }

        private void Duration6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                Magnitude6.Focus();
                Magnitude6.SelectAll();
            }
        }

        private void Magnitude6_KeyDown(object sender, KeyEventArgs e)
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
