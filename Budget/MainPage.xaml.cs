using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Budget.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Budget
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            FrontPage frontpage = new FrontPage();
            MainFrame.Content = frontpage;
        }

        // override this.loaded, kolla om household else if persons i db = null, skriv instruktioner i FrontPage

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SVMenu.IsPaneOpen = !SVMenu.IsPaneOpen;
        }

        private void HouseholdButton_Click(object sender, RoutedEventArgs e)
        {
            var Household01 = new Household01();
            MainFrame.Content = Household01;
        }

        private void PersonButton_Click(object sender, RoutedEventArgs e)
        {
            var PersonPage = new PersonPage();
            MainFrame.Content = PersonPage;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            FrontPage frontpage = new FrontPage();
            MainFrame.Content = frontpage;
        }
    }
}
