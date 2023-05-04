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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GraphicRuleCreator
{
    /// <summary>
    /// Interaction logic for AlchemyExpansionPotions.xaml
    /// </summary>
    public partial class AlchemyExpansionPotions : Window
    {
        AlchemyExpansionMain parentWindow;
        bool filter = false;
        string effect = "";
        public AlchemyExpansionPotions(AlchemyExpansionMain parentWindow, bool filter, string effect)
        {
            InitializeComponent();
            Update();
            this.parentWindow = parentWindow;
            this.filter = filter;
            this.effect = effect;
            parentWindow.RegisterForUpdate(this);
            Update();
        }
        public AlchemyExpansionPotions(AlchemyExpansionMain parentWindow)
        {
            InitializeComponent();
            Update();
            this.parentWindow = parentWindow;
        }
        public void Update()
        {
            IngredienstView.Items.Clear();
            IngredienstView.Items.Refresh();
            if (filter)
            {
                foreach (Potion pot in Potion.potions)
                {
                    if (pot.Effect1 == effect || pot.Effect2 == effect || pot.Effect3 == effect || pot.Effect4 == effect)
                        IngredienstView.Items.Add(pot);
                }
            }
            else
            {
                foreach (Potion pot in Potion.potions)
                {
                    IngredienstView.Items.Add(pot);
                }
            }
            IngredienstView.Items.Refresh();
        }

        private void Ing_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (IngredienstView.SelectedItem != null)
            {
                AlchemyExpansionPotEditor editor = new AlchemyExpansionPotEditor(IngredienstView.SelectedItem as Potion);
                editor.ShowDialog();
                parentWindow.Update();
            }
        }

        private void createing_Click(object sender, RoutedEventArgs e)
        {
            Potion pot = new Potion();
            AlchemyExpansionPotEditor editor = new AlchemyExpansionPotEditor(pot);
            editor.ShowDialog();
            Potion.potions.Add(pot);
            parentWindow.Update();
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
                    IngredienstView.Items.SortDescriptions.Clear();
                }

                ListSortDirection newDir = ListSortDirection.Ascending;
                if (listViewSortCol == column && listViewSortAdorner != null && listViewSortAdorner.Direction == newDir)
                    newDir = ListSortDirection.Descending;

                listViewSortCol = column;
                listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
                AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
                IngredienstView.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
            }

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (filter)
                parentWindow.UnregisterForUpdate(this);
        }
    }


}
