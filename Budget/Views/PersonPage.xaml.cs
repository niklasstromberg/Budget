using Budget.Models;
using Budget.ViewModels;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Budget.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PersonPage : Page
    {
        private PersonViewModel _viewModel;

        public PersonPage()
        {
            this.InitializeComponent();
            _viewModel = new PersonViewModel();
            FillGUI();
            SetGUI();
        }

        private void SetGUI()
        {
            // kod här
        }

        private void FillGUI()
        {
            LstBxHouseholds.ItemsSource = _viewModel.Households;
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            SetGUI();
        }

        private void LstBxHouseholds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var household = (Household)LstBxHouseholds.SelectedItem;
            var persons = household.PersonsInHousehold;
            LstBxPersons.ItemsSource = persons;
        }
    }
}
