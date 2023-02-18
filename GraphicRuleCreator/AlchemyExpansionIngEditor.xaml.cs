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
            ingredient = ing;
            FormID.Text = ing.FormID.ToString("X");
            EditorID.Text = ing.EditorID;
            PluginName.Text = ing.PluginName;
            Name.Text = ing.name;
            Weight.Text = ing.Weight.ToString();
            Value.Text = ing.value.ToString();
            Duration1.Text = ing.Duration1.ToString();
            Magnitude1.Text = ing.Magnitude1.ToString();
            Duration2.Text = ing.Duration2.ToString();
            Magnitude2.Text = ing.Magnitude2.ToString();
            Duration3.Text = ing.Duration3.ToString();
            Magnitude3.Text = ing.Magnitude3.ToString();
            Duration4.Text = ing.Duration4.ToString();
            Magnitude4.Text = ing.Magnitude4.ToString();

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
            try
            {
                dur1 = Int32.Parse(Duration1.Text);
            }
            catch { error.Text = "Duration1: Wrong Format"; return; }
            try
            {
                dur2 = Int32.Parse(Duration2.Text);
            }
            catch { error.Text = "Duration2: Wrong Format"; return; }
            try
            {
                dur3 = Int32.Parse(Duration3.Text);
            }
            catch { error.Text = "Duration3: Wrong Format"; return; }
            try
            {
                dur4 = Int32.Parse(Duration4.Text);
            }
            catch { error.Text = "Duration4: Wrong Format"; return; }
            try
            {
                mag1 = Math.Round(Double.Parse(Magnitude1.Text, System.Globalization.NumberStyles.Float), 2);
            }
            catch { error.Text = "Magnitude1: Wrong Format"; return; }
            try
            {
                mag2 = Math.Round(Double.Parse(Magnitude2.Text, System.Globalization.NumberStyles.Float), 2);
            }
            catch { error.Text = "Magnitude2: Wrong Format"; return; }
            try
            {
                mag3 = Math.Round(Double.Parse(Magnitude3.Text, System.Globalization.NumberStyles.Float), 2);
            }
            catch { error.Text = "Magnitude3: Wrong Format"; return; }
            try
            {
                mag4 = Math.Round(Double.Parse(Magnitude4.Text, System.Globalization.NumberStyles.Float), 2);
            }
            catch { error.Text = "Magnitude4: Wrong Format"; return; }


            ingredient.FormID = formid;
            ingredient.EditorID = EditorID.Text;
            ingredient.PluginName = PluginName.Text;
            ingredient.name = Name.Text;
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
            ingredient.Magnitude2 = mag1;
            ingredient.Magnitude3 = mag1;
            ingredient.Magnitude4 = mag1;

            ingredient.modified = true;

            Utility.CalcAllReferences();

            Close();
        }
    }
}
