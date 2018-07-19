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

namespace Mission_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMenuLink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (((MenuItem)sender).Name)
                {
                    case "btnForumLink":
                        System.Diagnostics.Process.Start("http://forum.kerbalspaceprogram.com/");
                        break;
                    case "btnRedditLink":
                        System.Diagnostics.Process.Start("https://www.reddit.com/r/KerbalSpaceProgram");
                        break;
                    case "btnWikiLink":
                        System.Diagnostics.Process.Start("http://wiki.kerbalspaceprogram.com/wiki/Main_Page");
                        break;
                    case "btnCurseModsLink":
                        System.Diagnostics.Process.Start("http://mods.curse.com/ksp-mods/kerbal?filter-project-sort=3");
                        break;
                    case "btnCKANLink":
                        System.Diagnostics.Process.Start("https://github.com/KSP-CKAN/CKAN/releases");
                        break;
                    case "btnSourceCodeLink":
                        System.Diagnostics.Process.Start("https://github.com/Obrelix/Interplanetary-Mission-Calculator");
                        break;
                    case "btnIssuesLink":
                        System.Diagnostics.Process.Start("https://github.com/Obrelix/Interplanetary-Mission-Calculator/issues");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
