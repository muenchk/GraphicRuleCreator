using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AlchemyExpansionEffects.xaml
    /// </summary>
    public partial class AlchemyExpansionEffects : Window
    {
        AlchemyExpansionMain parentWindow;
        public AlchemyExpansionEffects(AlchemyExpansionMain parentWindow)
        {
            InitializeComponent();
            Update();
            this.parentWindow = parentWindow;

            ContextMenu menu = new ContextMenu();
            EffectView.ContextMenu = menu;
            MenuItem m = new MenuItem();
            m.Header = "References Ingredients";
            m.Click += M_Click;
            menu.Items.Add(m);
            MenuItem m2 = new MenuItem();
            m2.Header = "References Potions";
            m2.Click += M2_Click;
            menu.Items.Add(m2);
        }

        private void M2_Click(object sender, RoutedEventArgs e)
        {
            if (EffectView.SelectedItem != null)
            {
                Effects eff = EffectView.SelectedItem as Effects;

                AlchemyExpansionPotions editor = new AlchemyExpansionPotions(parentWindow, true, eff.name);
                editor.Title = "AlchemyExpansion - Potions - Filter - " + eff.name;
                editor.Show();
            }
        }

        private void M_Click(object sender, RoutedEventArgs e)
        {

            if (EffectView.SelectedItem != null)
            {
                Effects eff = EffectView.SelectedItem as Effects;

                AlchemyExpansionIngredients editor = new AlchemyExpansionIngredients(parentWindow, true, eff.name);
                editor.Title = "AlchemyExpansion - Ingredients - Filter - " + eff.name;
                editor.Show();
            }
        }

        public void Update()
        {
            EffectView.Items.Clear();
            foreach (KeyValuePair<string, Effects> eff in GraphicRuleCreator.Effects.effects)
            {
                EffectView.Items.Add(eff.Value);
            }
        }


        private GridViewColumnHeader? listViewSortCol = null;
        private SortAdorner? listViewSortAdorner;

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            
            if (sender != null)
            {
                GridViewColumnHeader column = sender as GridViewColumnHeader;
                string sortBy = column.Tag.ToString();
                if (listViewSortCol != null)
                {
                    AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                    EffectView.Items.SortDescriptions.Clear();
                }

                ListSortDirection newDir = ListSortDirection.Ascending;
                if (listViewSortCol == column && listViewSortAdorner != null && listViewSortAdorner.Direction == newDir)
                    newDir = ListSortDirection.Descending;

                listViewSortCol = column;
                listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
                AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
                EffectView.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
            }

        }

        private void Eff_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (EffectView.SelectedItem != null)
            {
                Effects eff = EffectView.SelectedItem as Effects;
                string oldname = eff.name;
                AlchemyExpansionEffEditor editor = new AlchemyExpansionEffEditor(eff);
                editor.ShowDialog();
                if (oldname != eff.name)
                {
                    Effects.effects.Remove(oldname);
                    Effects.effects.Add(eff.name, eff);
                }

                Update();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Effects eff = new Effects();
            AlchemyExpansionEffEditor editor = new AlchemyExpansionEffEditor(eff);
            editor.ShowDialog();
            Effects.effects.Add(eff.name, eff);
            Update();
        }

        private void EffectView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
