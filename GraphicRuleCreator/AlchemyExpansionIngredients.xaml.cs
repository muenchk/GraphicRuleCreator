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
    /// Interaction logic for AlchemyExpansionIngredients.xaml
    /// </summary>
    public partial class AlchemyExpansionIngredients : Window
    {
        AlchemyExpansionMain parentWindow;
        bool filter = false;
        string effect = "";
        public AlchemyExpansionIngredients(AlchemyExpansionMain parentWindow, bool filter, string effect)
        {
            InitializeComponent();
            Update();
            this.parentWindow = parentWindow;
            this.filter = filter;
            this.effect = effect;
            parentWindow.RegisterForUpdate(this);
            Update();
        }
        public AlchemyExpansionIngredients(AlchemyExpansionMain parentWindow)
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
                foreach (Ingredient ing in Ingredient.ingredients)
                {
                    if (ing.Effect1 == effect || ing.Effect2 == effect || ing.Effect3 == effect || ing.Effect4 == effect)
                        IngredienstView.Items.Add(ing);
                }
            }
            else
            {
                foreach (Ingredient ing in Ingredient.ingredients)
                {
                    IngredienstView.Items.Add(ing);
                }
            }
            IngredienstView.Items.Refresh();
        }

        private void Ing_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (IngredienstView.SelectedItem != null)
            {
                AlchemyExpansionIngEditor editor = new AlchemyExpansionIngEditor(IngredienstView.SelectedItem as Ingredient);
                editor.ShowDialog();
                parentWindow.Update();
            }
        }

        private void createing_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ing = new Ingredient();
            AlchemyExpansionIngEditor editor = new AlchemyExpansionIngEditor(ing);
            editor.ShowDialog();
            Ingredient.ingredients.Add(ing);
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

public class SortAdorner : Adorner
{
    private static Geometry ascGeometry =
        Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

    private static Geometry descGeometry =
        Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

    public ListSortDirection Direction { get; private set; }

    public SortAdorner(UIElement element, ListSortDirection dir)
        : base(element)
    {
        this.Direction = dir;
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);

        if (AdornedElement.RenderSize.Width < 20)
            return;

        TranslateTransform transform = new TranslateTransform
            (
                AdornedElement.RenderSize.Width - 15,
                (AdornedElement.RenderSize.Height - 5) / 2
            );
        drawingContext.PushTransform(transform);

        Geometry geometry = ascGeometry;
        if (this.Direction == ListSortDirection.Descending)
            geometry = descGeometry;
        drawingContext.DrawGeometry(Brushes.Black, null, geometry);

        drawingContext.Pop();
    }
}