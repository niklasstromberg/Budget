using Budget.Models;
using Budget.ViewModels;
using Microsoft.Data.Sqlite;
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

namespace Budget.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FrontPage : Page
    {
        private FrontViewModel _viewModel;


        public FrontPage()
        {
            this.InitializeComponent();
            _viewModel = new FrontViewModel();
            //DatabaseManager.DatabaseSetup();
            //if(DatabaseManager.databaseExists)
            FillGUI();
            SetGUI();
        }

        private void FillGUI()
        {
            LstBxHouseholds.ItemsSource = _viewModel.Households;
        }

        private void SetGUI()
        {
            if(_viewModel.Households.Count() > 0)
            {
                LstBxHouseholds.Visibility = Visibility.Visible;
                BtnTakeControl.Visibility = Visibility.Visible;
                TxtblInstruction.Text = "Choose a household from the list and click the button to take control, or click 'Households' from the menu to create additional households.";
            }
            else
            {
                LstBxHouseholds.Visibility = Visibility.Collapsed;
                BtnTakeControl.Visibility = Visibility.Collapsed;
                TxtblInstruction.Text = "To start taking control, please click 'Households' in the menu to create your first household.";
            }
        }

    }
}
