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
    /// Interaction logic for AlchemyExpansionEffEditor.xaml
    /// </summary>
    public partial class AlchemyExpansionEffEditor : Window
    {
        Effects effect;

        public AlchemyExpansionEffEditor(Effects eff)
        {
            InitializeComponent();

            alchemyOverwrite.Items.Add(Utility.ToString(new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kNone)));
            // first effect range
            for (int i = 0; i <= 63; i++)
            {
                alchemyOverwrite.Items.Add(Utility.ToString(new Alchem(AlchemyBaseEffectFirst.kNone, (AlchemyBaseEffectSecond)((UInt64)1 << i))));
            }
            // second effect range
            for (int i = 0; i <= 63; i++)
            {
                alchemyOverwrite.Items.Add(Utility.ToString(new Alchem((AlchemyBaseEffectFirst)((UInt64)1 << i), AlchemyBaseEffectSecond.kNone)));
            }
            if (eff.Overwrite == true)
            {
                alchemyOverwrite.SelectedIndex = Utility.ToIndex(eff.AlchemyEffect);
                overwrite.IsChecked = true;
            }
            else
            {
                alchemyOverwrite.SelectedIndex = 0;
                overwrite.IsChecked = false;
            }

            for (int i = -1; i <= 163; i++)
            {
                actorValue.Items.Add(((ActorValue)i).ToString());
            }
            actorValue.SelectedIndex = (Int32)eff.ActorValue + 1;
            Name.Text = eff.name;
            FormID.Text = eff.FormID.ToString("X");
            EditorID.Text = eff.EditorID;
            PLuginName.Text = eff.PluginName;
            AlchemyEffectName.Content = Utility.ToString(Utility.ConvertToAlchemyEffect(eff.ActorValue));
            Detrimental.IsChecked = eff.detrimental;
            effect = eff;


            Name.Focus();
            Name.SelectAll();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //actorValue.SelectedItem as string;
            AlchemyEffectName.Content = Utility.ToString(Utility.ConvertToAlchemyEffect((ActorValue)(actorValue.SelectedIndex - 1)));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            error.Text = "";
            UInt32 formid = 0;
            ActorValue av = (ActorValue)(actorValue.SelectedIndex - 1);
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

            effect.name = Name.Text;
            effect.FormID = formid;
            effect.PluginName = PLuginName.Text;
            effect.EditorID = EditorID.Text;
            effect.ActorValueName = Utility.ToString(av);
            effect.AlchemyEffect = Utility.ConvertToAlchemyEffect(av);
            effect.AlchemyEffectName = AlchemyEffectName.Content as string;
            effect.Overwrite = false;
            if (overwrite.IsChecked == true)
            {
                if (alchemyOverwrite.SelectedIndex > 0)
                {
                    if (alchemyOverwrite.SelectedIndex > 64)
                        effect.AlchemyEffect = new Alchem((AlchemyBaseEffectFirst)((UInt64)1 << (alchemyOverwrite.SelectedIndex - 1)), AlchemyBaseEffectSecond.kNone);
                    else
                        effect.AlchemyEffect = new Alchem(AlchemyBaseEffectFirst.kNone, (AlchemyBaseEffectSecond)((UInt64)1 << (alchemyOverwrite.SelectedIndex - 1)));
                }
                else
                    effect.AlchemyEffect = new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kNone);
                effect.AlchemyEffectName = Utility.ToString(effect.AlchemyEffect);
                effect.Overwrite = true;
            }
            if (Detrimental.IsChecked == true)
                effect.detrimental = true;
            else
                effect.detrimental = false;
            effect.ActorValue = av;

            effect.modified = true;

            // calculate references
            Utility.CalcReferences(effect);

            Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            alchemyOverwrite.IsEnabled = true;
        }

        private void overwrite_Unchecked(object sender, RoutedEventArgs e)
        {
            alchemyOverwrite.IsEnabled = false;
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
                PLuginName.Focus();
                PLuginName.SelectAll();
            }
        }

        private void PLuginName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
                actorValue.Focus();
        }

        private void actorValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
                Detrimental.Focus();    
        }

        private void Detrimental_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
                save.Focus();
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
