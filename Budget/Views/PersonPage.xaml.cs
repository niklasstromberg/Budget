using Budget.Managers;
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
            BtnDelete.Visibility = Visibility.Collapsed;
            BtnAddToHousehold.Visibility = Visibility.Collapsed;
            BtnRemoveFromHousehold.Visibility = Visibility.Collapsed;
            if (LstBxPersons.SelectedItem != null)
            {
                BtnDelete.Visibility = Visibility.Visible;
            }
        }

        private void IsBothSelected()
        {
            if (_viewModel.ChosenPerson != null && _viewModel.ChosenHousehold != null)
            {
                BtnAddToHousehold.Visibility = Visibility.Visible;
                BtnRemoveFromHousehold.Visibility = Visibility.Visible;
            }
            else
            {
                BtnAddToHousehold.Visibility = Visibility.Collapsed;
                BtnRemoveFromHousehold.Visibility = Visibility.Collapsed;
            }
        }

        private void FillGUI()
        {
            _viewModel.GetData();
            LstBxHouseholds.ItemsSource = _viewModel.Households;
            LstBxPersons.ItemsSource = _viewModel.Persons;
            if (_viewModel.ChosenHousehold != null)
                LstBxPersonsInHousehold.ItemsSource = _viewModel.ChosenHousehold.PersonsInHousehold;
            LstBxPersonsInHousehold.DisplayMemberPath = "Name";
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            SetGUI();
            //FillGUI();
        }

        private void LstBxHouseholds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstBxHouseholds.SelectedItem != null)
                _viewModel.ChosenHousehold = (Household)LstBxHouseholds.SelectedItem;
            if (_viewModel.ChosenHousehold != null)
            {
                LstBxPersonsInHousehold.ItemsSource = _viewModel.ChosenHousehold.PersonsInHousehold;
                LstBxHouseholds.SelectedItem = _viewModel.ChosenHousehold;
            }
            LstBxPersonsInHousehold.DisplayMemberPath = "Name";
            IsBothSelected();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            bool success = DatabaseManager.SavePerson(TxtbxName.Text);
            if (success)
                FillGUI();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var person = (Person)LstBxPersons.SelectedItem;
            bool success = DatabaseManager.DeletePerson(person.PersonId);
            if (success)
                FillGUI();
        }

        private void LstBxPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.ChosenPerson = (Person)LstBxPersons.SelectedItem;
            IsBothSelected();
            if (_viewModel.ChosenPerson != null)
            {
                TxtbxName.Text = _viewModel.ChosenPerson.Name;
                BtnDelete.Visibility = Visibility.Visible;
            }
        }

        private void BtnAddToHousehold_Click(object sender, RoutedEventArgs e)
        {
            bool success = DatabaseManager.AttachPerson(_viewModel.ChosenPerson, _viewModel.ChosenHousehold);
            if (success)
                FillGUI();
        }

        private void BtnRemoveFromHousehold_Click(object sender, RoutedEventArgs e)
        {
            bool success = DatabaseManager.DetachPerson(_viewModel.ChosenPerson, _viewModel.ChosenHousehold);
            if (success)
                FillGUI();
        }
    }
}
