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
	/// Interaction logic for GPPatientView.xaml
	/// </summary>
	public partial class GPPatientView : Page
	{
		CRUDManager _crudManager;
		public GPPatientView(CRUDManager cRUDManager)
		{
			InitializeComponent();
			_crudManager = cRUDManager;
			PopulateListBox();
			TextDOB.SelectedDate = null;
		}

		private bool FieldValidation()
		{
			return string.IsNullOrWhiteSpace(TextForename.Text) || string.IsNullOrWhiteSpace(TextSurname.Text)
		|| string.IsNullOrWhiteSpace(TextAddress1.Text) || string.IsNullOrWhiteSpace(TextCity.Text) || string.IsNullOrWhiteSpace(TextRegion.Text) || string.IsNullOrWhiteSpace(TextCity.Text)
		|| string.IsNullOrWhiteSpace(TextRegion.Text) || string.IsNullOrWhiteSpace(TextPostcode.Text) || TextDOB.SelectedDate == null;
		}
		private void PopulateListBox()
		{
			ListBoxPatients.ItemsSource = _crudManager.RetrieveAllPatients();
		}

		private void ButtonCreate_Click(object sender, RoutedEventArgs e)
		{
			if (FieldValidation())
			{
				MessageBox.Show("Please enter all required fields");
			}
			else
			{
				_crudManager.CreatePatient(_crudManager.selectedGP, TextForename.Text, TextSurname.Text, TextDOB.SelectedDate.Value,
				TextAddress1.Text, TextAddress2.Text, TextAddress3.Text, TextCity.Text, TextRegion.Text, TextPostcode.Text, TextNumber.Text);
				ListBoxPatients.ItemsSource = null;
				PopulateListBox();
				ListBoxPatients.SelectedItem = _crudManager.selectedPatient;
				PopulatePatientFields();
			}
		}

		private void ButtonDelete_Click(object sender, RoutedEventArgs e)
		{
			if (_crudManager.selectedPatient == null)
			{
				MessageBox.Show("Please select a Patient first!");
			}
			else
			{
				_crudManager.DeletePatient(_crudManager.selectedPatient.PatientId);
				ListBoxPatients.ItemsSource = null;
				PopulateListBox();
				_crudManager.selectedPatient = null;
				PopulatePatientFields();
				MessageBox.Show("Successfully deleted!");
			}
		}

		private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
		{
			if (_crudManager.selectedPatient == null)
			{
				MessageBox.Show("Please select a Patient first!");
			}
			else
			{
				if (FieldValidation())
				{
					MessageBox.Show("Please enter all required fields");
				}
				else
				{
					_crudManager.UpdatePatient(_crudManager.selectedPatient.PatientId, _crudManager.selectedGP, TextForename.Text, TextSurname.Text, TextDOB.SelectedDate.Value,
					TextAddress1.Text, TextAddress2.Text, TextAddress3.Text, TextCity.Text, TextRegion.Text, TextPostcode.Text, TextNumber.Text);
					ListBoxPatients.ItemsSource = null;
					PopulateListBox();
					_crudManager.selectedPatient = null;
					PopulatePatientFields();
					MessageBox.Show("Successfully updated!");
				}

			}
		}

		private void PopulatePatientFields()
		{
			if (_crudManager.selectedPatient != null)
			{
				TextID.Text = _crudManager.selectedPatient.PatientId.ToString();
				TextForename.Text = _crudManager.selectedPatient.FirstName;
				TextSurname.Text = _crudManager.selectedPatient.LastName;
				TextDOB.SelectedDate = _crudManager.selectedPatient.DateOfBirth;
				TextAddress1.Text = _crudManager.selectedPatient.Address1;
				TextAddress2.Text = _crudManager.selectedPatient.Address2;
				TextAddress3.Text = _crudManager.selectedPatient.Address3;
				TextCity.Text = _crudManager.selectedPatient.City;
				TextRegion.Text = _crudManager.selectedPatient.Region;
				TextPostcode.Text = _crudManager.selectedPatient.PostalCode;
				TextNumber.Text = _crudManager.selectedPatient.ContactNumber;
			}
			else
			{
				TextID.Text = "";
				TextForename.Text = "";
				TextSurname.Text = "";
				TextDOB.SelectedDate = null;
				TextAddress1.Text = "";
				TextAddress2.Text = "";
				TextAddress3.Text = "";
				TextCity.Text = "";
				TextRegion.Text = "";
				TextPostcode.Text = "";
				TextNumber.Text = "";
			}

		}

		private void ListBoxPost_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (ListBoxPatients.SelectedItem != null)
			{
				_crudManager.SetSelectedPatient(ListBoxPatients.SelectedItem);
				PopulatePatientFields();
			}
		}

		private void ButtonView_Click(object sender, RoutedEventArgs e)
		{
			if (_crudManager.selectedPatient == null)
			{
				MessageBox.Show("Please select a Patient first!");
			}
			else
			{
				_crudManager.SetSelectedPatient(ListBoxPatients.SelectedItem);
				PatientRecordView patientRecordView = new PatientRecordView(_crudManager);
				this.NavigationService.Navigate(patientRecordView);
			}
		}
	}
}
