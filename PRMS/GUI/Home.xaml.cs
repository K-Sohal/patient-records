using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business;
using Model;

namespace GUI
{
	/// <summary>
	/// Interaction logic for Home.xaml
	/// </summary>
	public partial class Home : Page
	{
		public Home()
		{
			InitializeComponent();
			PopulateListBox();
		}

		private CRUDManager _crudManager = new CRUDManager();

		private void PopulateListBox()
		{
			ListBoxGPs.ItemsSource = _crudManager.RetrieveAllGPs();
		}

		private void ButtonCreate_Click(object sender, RoutedEventArgs e)
		{
			_crudManager.CreateGP(TextForename.Text, TextSurname.Text);
			ListBoxGPs.ItemsSource = null;
			PopulateListBox();
			ListBoxGPs.SelectedItem = _crudManager.selectedGP;
			PopulateGPFields();
		}

		private void ButtonDelete_Click(object sender, RoutedEventArgs e)
		{
			if (_crudManager.selectedGP == null)
			{
				MessageBox.Show("Please select a GP first!");
			}
			else
			{
				_crudManager.DeleteGP(_crudManager.selectedGP.Gpid);
				ListBoxGPs.ItemsSource = null;
				PopulateListBox();
				_crudManager.selectedGP = null;
				PopulateGPFields();
			}
		}

		private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
		{
			if (_crudManager.selectedGP == null)
			{
				MessageBox.Show("Please select a GP first!");
			}
			else
			{
				_crudManager.UpdateGP(_crudManager.selectedGP.Gpid, TextForename.Text, TextSurname.Text);
				ListBoxGPs.ItemsSource = null;
				PopulateListBox();
				_crudManager.selectedGP = null;
				PopulateGPFields();
			}
		}


		private void PopulateGPFields()
		{
			if (_crudManager.selectedGP != null)
			{
				TextID.Text = _crudManager.selectedGP.Gpid.ToString();
				TextForename.Text = _crudManager.selectedGP.FirstName;
				TextSurname.Text = _crudManager.selectedGP.LastName;
			}
			else
			{
				TextID.Text = "";
				TextForename.Text = "";
				TextSurname.Text = "";
			}
		}

		private void ListBoxPost_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (ListBoxGPs.SelectedItem != null)
			{
				_crudManager.SetSelectedGP(ListBoxGPs.SelectedItem);
				PopulateGPFields();
			}
		}
	}
}
