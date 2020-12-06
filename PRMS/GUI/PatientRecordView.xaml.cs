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
	/// Interaction logic for PatientRecordView.xaml
	/// </summary>
	public partial class PatientRecordView : Page
	{
		public PatientRecordView(CRUDManager cRUDManager)
		{
			_crudManager = cRUDManager;
			InitializeComponent();
			PopulateAllergyListBox();
			PopulateVaccineListBox();
			PopulateMedicineListBox();
			PopulateConcernListBox();
		}

		CRUDManager _crudManager;

		// Allergy

		private void PopulateAllergyListBox()
		{
			ListBoxAllergy.ItemsSource = _crudManager.RetrieveAllAllergies();
		}

		private bool AllergyFieldValidation()
		{
			return string.IsNullOrWhiteSpace(TextAllergen.Text) || string.IsNullOrWhiteSpace(TextReaction.Text);
		}


		private void ButtonCreate_Click(object sender, RoutedEventArgs e)
		{
			if (AllergyFieldValidation())
			{
				MessageBox.Show("Please enter all allergy fields");
			}
			else
			{
				_crudManager.CreateAllergy(_crudManager.selectedPatient, TextAllergen.Text, TextReaction.Text);
				ListBoxAllergy.ItemsSource = null;
				PopulateAllergyListBox();
				ListBoxAllergy.SelectedItem = _crudManager.selectedAllergy;
				PopulateAllergyFields();
			}
		}

		private void ButtonDelete_Click(object sender, RoutedEventArgs e)
		{
			if (_crudManager.selectedAllergy == null)
			{
				MessageBox.Show("Please select an Allergy first!");
			}
			else
			{
				_crudManager.DeleteAllergy(_crudManager.selectedAllergy.AllergyId);
				ListBoxAllergy.ItemsSource = null;
				PopulateAllergyListBox();
				_crudManager.selectedAllergy = null;
				PopulateAllergyFields();
				MessageBox.Show("Successfully deleted!");
			}
		}

		private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
		{
			if (_crudManager.selectedAllergy == null)
			{
				MessageBox.Show("Please select an Allergy first!");
			}
			else
			{
				if (AllergyFieldValidation())
				{
					MessageBox.Show("Please enter all allergy fields");
				}
				else
				{
					_crudManager.UpdateAllergy(_crudManager.selectedAllergy.AllergyId, TextAllergen.Text, TextReaction.Text);
					ListBoxAllergy.ItemsSource = null;
					PopulateAllergyListBox();
					_crudManager.selectedAllergy = null;
					PopulateAllergyFields();
					MessageBox.Show("Successfully updated!");
				}
			}
		}



		private void PopulateAllergyFields()
		{
			if (_crudManager.selectedAllergy != null)
			{
				TextAllergyID.Text = _crudManager.selectedAllergy.AllergyId.ToString();
				TextAllergen.Text = _crudManager.selectedAllergy.Allergen;
				TextReaction.Text = _crudManager.selectedAllergy.ReactionType;
			}
			else
			{
				TextAllergyID.Text = "";
				TextAllergen.Text = "";
				TextReaction.Text = "";
			}
		}

		private void AllergyListBoxPost_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (ListBoxAllergy.SelectedItem != null)
			{
				_crudManager.SetSelectedAllergy(ListBoxAllergy.SelectedItem);
				PopulateAllergyFields();
			}
		}


		// Vaccine

		private void PopulateVaccineListBox()
		{
			ListBoxVaccine.ItemsSource = _crudManager.RetrieveAllVaccines();
		}

		private bool VaccineFieldValidation()
		{
			return string.IsNullOrWhiteSpace(TextVaccine.Text) || TextVaccineDate.SelectedDate == null;
		}

		private void ButtonCreateVaccine_Click(object sender, RoutedEventArgs e)
		{
			if (VaccineFieldValidation())
			{
				MessageBox.Show("Please enter all vaccine fields");
			}
			else
			{
				_crudManager.CreateVaccine(_crudManager.selectedPatient, TextVaccine.Text, TextVaccineDate.SelectedDate.Value);
				ListBoxVaccine.ItemsSource = null;
				PopulateVaccineListBox();
				ListBoxVaccine.SelectedItem = _crudManager.selectedVaccine;
				PopulateVaccineFields();
			}
		}

		private void ButtonDeleteVaccine_Click(object sender, RoutedEventArgs e)
		{
			if (_crudManager.selectedVaccine == null)
			{
				MessageBox.Show("Please select a vaccine first!");
			}
			else
			{
				_crudManager.DeleteVaccine(_crudManager.selectedVaccine.VaccineId);
				ListBoxVaccine.ItemsSource = null;
				PopulateVaccineListBox();
				_crudManager.selectedVaccine = null;
				PopulateVaccineFields();
				MessageBox.Show("Successfully deleted!");
			}
		}

		private void ButtonUpdateVaccine_Click(object sender, RoutedEventArgs e)
		{
			if (_crudManager.selectedVaccine == null)
			{
				MessageBox.Show("Please select a vaccine first!");
			}
			else
			{
				if (VaccineFieldValidation())
				{
					MessageBox.Show("Please enter all vaccine fields");
				}
				else
				{
					_crudManager.UpdateVaccine(_crudManager.selectedVaccine.VaccineId, TextVaccine.Text, TextVaccineDate.SelectedDate.Value);
					ListBoxVaccine.ItemsSource = null;
					PopulateVaccineListBox();
					_crudManager.selectedVaccine = null;
					PopulateVaccineFields();
					MessageBox.Show("Successfully updated!");
				}
			}
		}

		private void PopulateVaccineFields()
		{
			if (_crudManager.selectedVaccine != null)
			{
				TextVaccineID.Text = _crudManager.selectedVaccine.VaccineId.ToString();
				TextVaccine.Text = _crudManager.selectedVaccine.Vaccine1;
				TextVaccineDate.SelectedDate = _crudManager.selectedVaccine.VaccineDate;
			}
			else
			{
				TextVaccineID.Text = "";
				TextVaccine.Text = "";
				TextVaccineDate.SelectedDate = null;
			}

		}

		private void VaccineListBoxPost_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (ListBoxVaccine.SelectedItem != null)
			{
				_crudManager.SetSelectedVaccine(ListBoxVaccine.SelectedItem);
				PopulateVaccineFields();
			}
		}

		// Medication

		private void PopulateMedicineListBox()
		{
			ListBoxMedication.ItemsSource = _crudManager.RetrieveAllMedications();
		}

		private bool MedicineFieldValidation()
		{
			return string.IsNullOrWhiteSpace(TextName.Text) || string.IsNullOrWhiteSpace(TextFrequency.Text) || string.IsNullOrWhiteSpace(TextDosage.Text)
				|| TextStart.SelectedDate == null || TextStop.SelectedDate == null;
		}

		private void ButtonCreateMedication_Click(object sender, RoutedEventArgs e)
		{
			if (MedicineFieldValidation())
			{
				MessageBox.Show("Please enter all medicine fields");
			}
			else
			{
				_crudManager.CreateMedication(_crudManager.selectedPatient, TextName.Text, TextFrequency.Text, TextDosage.Text, TextStart.SelectedDate.Value, TextStop.SelectedDate.Value);
				ListBoxMedication.ItemsSource = null;
				PopulateMedicineListBox();
				ListBoxMedication.SelectedItem = _crudManager.selectedMedication;
				PopulateMedicationFields();
			}
		}

		private void ButtonDeleteMedication_Click(object sender, RoutedEventArgs e)
		{
			if (_crudManager.selectedMedication == null)
			{
				MessageBox.Show("Please select a Medication first!");
			}
			else
			{
				_crudManager.DeleteMedication(_crudManager.selectedMedication.MedicationId);
				ListBoxMedication.ItemsSource = null;
				PopulateMedicineListBox();
				_crudManager.selectedMedication = null;
				PopulateMedicationFields();
				MessageBox.Show("Successfully deleted!");
			}
		}

		private void ButtonUpdateMedication_Click(object sender, RoutedEventArgs e)
		{
			if (_crudManager.selectedMedication == null)
			{
				MessageBox.Show("Please select a Medication first!");
			}
			else
			{
				if (MedicineFieldValidation())
				{
					MessageBox.Show("Please enter all medicine fields");
				}
				else
				{
					_crudManager.UpdateMedication(_crudManager.selectedMedication.MedicationId, TextName.Text, TextFrequency.Text, TextDosage.Text, TextStart.SelectedDate.Value, TextStop.SelectedDate.Value);
					ListBoxMedication.ItemsSource = null;
					PopulateMedicineListBox();
					_crudManager.selectedMedication = null;
					PopulateMedicationFields();
					MessageBox.Show("Successfully updated!");
				}
			}
		}

		private void PopulateMedicationFields()
		{
			if (_crudManager.selectedMedication != null)
			{
				TextMedicationID.Text = _crudManager.selectedMedication.MedicationId.ToString();
				TextName.Text = _crudManager.selectedMedication.MedicationName;
				TextFrequency.Text = _crudManager.selectedMedication.Frequency;
				TextDosage.Text = _crudManager.selectedMedication.Dosage;
				TextStart.SelectedDate = _crudManager.selectedMedication.StartDate;
				TextStop.SelectedDate = _crudManager.selectedMedication.StopDate;
			}
			else
			{
				TextMedicationID.Text = "";
				TextName.Text = "";
				TextFrequency.Text = "";
				TextDosage.Text = "";
				TextStart.SelectedDate = null;
				TextStop.SelectedDate = null;
			}
		}

		private void MedicationListBoxPost_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (ListBoxMedication.SelectedItem != null)
			{
				_crudManager.SetSelectedMedication(ListBoxMedication.SelectedItem);
				PopulateMedicationFields();
			}
		}

		// Concerns

		private void PopulateConcernListBox()
		{
			ListBoxConcern.ItemsSource = _crudManager.RetrieveAllConcerns();
		}

		private bool ConcernFieldValidation()
		{
			return string.IsNullOrWhiteSpace(TextConcern.Text);
		}

		private void ButtonCreateConcern_Click(object sender, RoutedEventArgs e)
		{
			if (ConcernFieldValidation())
			{
				MessageBox.Show("Please enter a concern");
			}
			else
			{
				_crudManager.CreateConcern(TextConcern.Text, _crudManager.selectedPatient);
				ListBoxConcern.ItemsSource = null;
				PopulateConcernListBox();
				ListBoxConcern.SelectedItem = _crudManager.selectedConcern;
				PopulateConcernFields();
			}
		}

		private void ButtonDeleteConcern_Click(object sender, RoutedEventArgs e)
		{
			if (_crudManager.selectedConcern == null)
			{
				MessageBox.Show("Please select a concern first!");
			}
			else
			{
				_crudManager.DeleteConcern(_crudManager.selectedConcern.ConcernId);
				ListBoxConcern.ItemsSource = null;
				PopulateConcernListBox();
				_crudManager.selectedConcern = null;
				PopulateConcernFields();
				MessageBox.Show("Successfully deleted!");
			}
		}

		private void ButtonUpdateConcern_Click(object sender, RoutedEventArgs e)
		{
			if (_crudManager.selectedConcern == null)
			{
				MessageBox.Show("Please select a Concern first!");
			}
			else
			{
				if (ConcernFieldValidation())
				{
					MessageBox.Show("Please enter a concern");
				}
				else
				{
					_crudManager.UpdateConcern(_crudManager.selectedConcern.ConcernId, TextConcern.Text);
					ListBoxConcern.ItemsSource = null;
					PopulateConcernListBox();
					_crudManager.selectedConcern = null;
					PopulateConcernFields();
					MessageBox.Show("Successfully updated!");
				}
			}
		}

		private void PopulateConcernFields()
		{
			if (_crudManager.selectedConcern != null)
			{
				TextConcern.Text = _crudManager.selectedConcern.Concern1;
			}
			else
			{
				TextConcern.Text = "";
			}

		}

		private void ConcernListBoxPost_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (ListBoxConcern.SelectedItem != null)
			{
				_crudManager.SetSelectedConcern(ListBoxConcern.SelectedItem);
				PopulateConcernFields();
			}
		}

	}
}
