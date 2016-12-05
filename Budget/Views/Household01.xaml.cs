using Budget.Models;
using Budget.ViewModels;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public sealed partial class Household01 : Page
    {
        private HouseholdViewModel _viewModel;


        public Household01()
        {
            this.InitializeComponent();
            _viewModel = new HouseholdViewModel();
            GetData();
            SetGUI();
        }

        private void GetData()
        {
            LstBxHouseholds.ItemsSource = _viewModel.Households;
        }

        private void SetGUI()
        {
            //FillGUI();
            LstBxHouseholds.SelectedItem = null;
            TxtBxName.Text = "";
            if (_viewModel.Households.Count < 1)
            {
                LstBxHouseholds.Visibility = Visibility.Collapsed;
                BtnDelete.Visibility = Visibility.Collapsed;
                TxtblInformation.Text = "Enter a name for your first household.";
            }
            else
            {
                LstBxHouseholds.SelectedItem = null;
                LstBxHouseholds.Visibility = Visibility.Visible;
                BtnDelete.Visibility = Visibility.Collapsed;
                TxtblInformation.Text = "Choose a household from the list to edit or permanently delete it.";

                //if (LstBxHouseholds.SelectedItem != null)
                //{
                //    
                //    BtnDelete.Visibility = Visibility.Visible;
                //}
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            SetGUI();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;

            if (LstBxHouseholds.SelectedItem != null)
            {
                var household = (Household)LstBxHouseholds.SelectedItem;
                success = DatabaseManager.UpdateHousehold(household.HouseholdId, TxtBxName.Text);
            }
            else
            {
                success = DatabaseManager.SaveHousehold(TxtBxName.Text);
            }

            if (success) { }
                //_viewModel.RaiseOnPropertyChanged();
            //SetGUI();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Household household = (Household)LstBxHouseholds.SelectedItem;
            int id = household.HouseholdId;
            bool success = DatabaseManager.DeleteHousehold(id);
            if (success)
            {
                //_viewModel.RaiseOnPropertyChanged();
            }
            //SetGUI();
        }

        private void LstBxHouseholds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstBxHouseholds.SelectedItem != null)
            {
                TxtblInformation.Text = "Edit the name of your household and click 'save'. Click 'Delete' to permanently remove it.";
                BtnDelete.Visibility = Visibility.Visible;
                var household = (Household)LstBxHouseholds.SelectedItem;
                TxtBxName.Text = household.HouseholdName;
            }
            else
            {
                BtnDelete.Visibility = Visibility.Collapsed;
                TxtblInformation.Text = "Choose a household from the list to edit or permanently delete it.";
            }
        }

    }
}
