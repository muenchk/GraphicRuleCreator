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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicRuleCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
            RenderOptions.ProcessRenderMode = System.Windows.Interop.RenderMode.SoftwareOnly;
        }

        private void Button_AlchemyExpansion_Click(object sender, RoutedEventArgs e)
        {
            AlchemyExpansionMain window = new AlchemyExpansionMain();
            window.Show();
            Close();
        }

        private void Button_NPCsUsePotions_Click(object sender, RoutedEventArgs e)
        {
            NPCsUsePotionsMain window = new NPCsUsePotionsMain();
            window.Show();
            Close();
        }
    }
}
