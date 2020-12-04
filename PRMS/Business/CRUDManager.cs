using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Model;
using Microsoft.EntityFrameworkCore;

namespace Business
{
	public class CRUDManager

	{
		//private static CRUDManager _CRUDManager = new CRUDManager();
		static void Main(string[] args)
		{
			//var newgp = new Gp();
			//_CRUDManager.CreatePatient(newgp, "testc", "testc", DateTime.Now, "a", "a", "a", "a", "a", "a", "a");
		}

		//Home logic
		public Gp selectedGP { get; set; }

		public List<Gp> RetrieveAllGPs()
		{
			using var db = new PatientRecordsContext();
			return db.Gps.ToList();
		}

		public void SetSelectedGP(object selectedItem)
		{
			selectedGP = (Gp)selectedItem;
		}

		//GPPatient view logic

		public Patient selectedPatient { get; set; }

		public List<Patient> RetrieveAllPatients()
		{
			using var db = new PatientRecordsContext();
			var GPPatients = db.Patients.Where(p => p.Gpid == selectedGP.Gpid);
			return GPPatients.ToList();
		}

		public void SetSelectedPatient(object selectedItem)
		{
			selectedPatient = (Patient)selectedItem;
		}

		//Allergies logic

		public Allergy selectedAllergy { get; set; }

		public List<Allergy> RetrieveAllAllergies()
		{
			using var db = new PatientRecordsContext();
			return db.Allergies.ToList();
		}

		public void SetSelectedAllergy(object selectedItem)
		{
			selectedAllergy = (Allergy)selectedItem;
		}

		//Vaccine logic

		public Vaccine selectedVaccine { get; set; }

		public List<Vaccine> RetrieveAllVaccines()
		{
			using var db = new PatientRecordsContext();
			return db.Vaccines.ToList();
		}

		public void SetSelectedVaccine(object selectedItem)
		{
			selectedVaccine = (Vaccine)selectedItem;
		}

		//Medication logic

		public Medication selectedMedication { get; set; }

		public List<Medication> RetrieveAllMedications()
		{
			using var db = new PatientRecordsContext();
			return db.Medications.ToList();
		}

		public void SetSelectedMedication(object selectedItem)
		{
			selectedMedication = (Medication)selectedItem;
		}

		//Concerns logic
		public Concern selectedConcern { get; set; }

		public List<Concern> RetrieveAllConcerns()
		{
			using var db = new PatientRecordsContext();
			var PatientConcerns = db.Concerns.Where(p => p.PatientId == selectedPatient.PatientId);
			return PatientConcerns.ToList();
		}

		public void SetSelectedConcern(object selectedItem)
		{
			selectedConcern = (Concern)selectedItem;
		}

		//Create
		public void CreateGP(string firstName, string lastName)
		{
			using var db = new PatientRecordsContext();
			var newGP = new Gp
			{
				FirstName = firstName,
				LastName = lastName
			};
			db.Gps.Add(newGP);
			db.SaveChanges();
		}

		public void CreatePatient(Gp gp, string firstName, string lastName, DateTime dob, string address1,
			string address2, string address3, string city, string region, string postcode, string contactnumber)
		{
			using var db = new PatientRecordsContext();
			var newPatient = new Patient
			{
				Gpid = gp.Gpid,
				FirstName = firstName,
				LastName = lastName,
				DateOfBirth = dob,
				Address1 = address1,
				Address2 = address2,
				Address3 = address3,
				City = city,
				Region = region,
				PostalCode = postcode,
				ContactNumber = contactnumber
			};
			db.Patients.Add(newPatient);
			db.SaveChanges();
		}

		public void CreateConcern(string concern, Patient patient)
		{
			using var db = new PatientRecordsContext();
			var newConcern = new Concern
			{
				Concern1 = concern,
				ConcernDate = DateTime.Now,
				Patient = patient
			};
			db.Concerns.Add(newConcern);
			db.SaveChanges();
		}
		public void CreateVaccine(string name)
		{
			using var db = new PatientRecordsContext();
			var newVaccine = new Vaccine
			{
				Vaccine1 = name
			};
			db.Vaccines.Add(newVaccine);
			db.SaveChanges();
		}

		public void CreatePatientImmunisation(Patient patient, Vaccine vaccine, DateTime vaccineDate)
		{
			using var db = new PatientRecordsContext();
			var newPatientImmunisation = new PatientImmunisation
			{
				Patient = patient,
				Vaccine = vaccine,
				VaccineDate = vaccineDate
			};
			db.PatientImmunisations.Add(newPatientImmunisation);
			db.SaveChanges();
		}

		public void CreateAllergy(string allergen, string reaction)
		{
			using var db = new PatientRecordsContext();
			var newAllergy = new Allergy
			{
				Allergen = allergen,
				ReactionType = reaction
			};
			db.Allergies.Add(newAllergy);
			db.SaveChanges();
		}

		public void CreatePatientAllergy(Patient patient, Allergy allergy)
		{
			using var db = new PatientRecordsContext();
			var newPatientAllergy = new PatientAllergy
			{
				Patient = patient,
				Allergy = allergy
			};
			db.PatientAllergies.Add(newPatientAllergy);
			db.SaveChanges();
		}

		public void CreateMedication(string name)
		{
			using var db = new PatientRecordsContext();
			var newMedication = new Medication
			{
				MedicationName = name
			};
			db.Medications.Add(newMedication);
			db.SaveChanges();
		}

		public void CreatePatientMedication(Medication medication, Patient patient, string frequency, string dosage, DateTime startdate, DateTime stopdate)
		{
			using var db = new PatientRecordsContext();
			var newPatientMedication = new PatientMedication
			{
				Medication = medication,
				Patient = patient,
				Frequency = frequency,
				Dosage = dosage,
				StartDate = startdate,
				StopDate = stopdate
			};
			db.PatientMedications.Add(newPatientMedication);
			db.SaveChanges();
		}

		//Delete

		public void DeleteGP(int gpid)
		{
			using var db = new PatientRecordsContext();
			var selectedGP = db.Gps.Where(x => x.Gpid == gpid).FirstOrDefault();
			db.Gps.Remove(selectedGP);
			db.SaveChanges();
		}

		public void DeletePatient(int patientid)
		{
			using var db = new PatientRecordsContext();
			var selectedPatient = db.Patients.Where(x => x.PatientId == patientid).FirstOrDefault();
			db.Patients.Remove(selectedPatient);
			db.SaveChanges();
		}
		public void DeleteConcern(int concernid)
		{
			using var db = new PatientRecordsContext();
			var selectedConcern = db.Concerns.Where(x => x.ConcernId == concernid).FirstOrDefault();
			db.Concerns.Remove(selectedConcern);
			db.SaveChanges();
		}
		public void DeleteVaccine(int vaccineid)
		{
			using var db = new PatientRecordsContext();
			var selectedVaccine = db.Vaccines.Where(x => x.VaccineId == vaccineid).FirstOrDefault();
			db.Vaccines.Remove(selectedVaccine);
			db.SaveChanges();
		}

		public void DeletePatientImmunisation(int patientid)
		{
			using var db = new PatientRecordsContext();
			var selectedPatient = db.PatientImmunisations.Where(x => x.PatientId == patientid).FirstOrDefault();
			db.PatientImmunisations.Remove(selectedPatient);
			db.SaveChanges();
		}

		public void DeleteAllergy(int allergyid)
		{
			using var db = new PatientRecordsContext();
			var selectedAllergy = db.Allergies.Where(x => x.AllergyId == allergyid).FirstOrDefault();
			db.Allergies.Remove(selectedAllergy);
			db.SaveChanges();
		}

		public void DeletePatientAllergy(int patientid)
		{
			using var db = new PatientRecordsContext();
			var selectedPatient = db.PatientAllergies.Where(x => x.PatientId == patientid).FirstOrDefault();
			db.PatientAllergies.Remove(selectedPatient);
			db.SaveChanges();
		}

		public void DeleteMedication(int medicationid)
		{
			using var db = new PatientRecordsContext();
			var selectedMedication = db.Medications.Where(x => x.MedicationId == medicationid).FirstOrDefault();
			db.Medications.Remove(selectedMedication);
			db.SaveChanges();
		}

		public void DeletePatientMedication(int patientMedicationid)
		{
			using var db = new PatientRecordsContext();
			var selectedPatientMedication = db.PatientMedications.Where(x => x.PatientMedicationId == patientMedicationid).FirstOrDefault();
			db.PatientMedications.Remove(selectedPatientMedication);
			db.SaveChanges();
		}

		//Update

		public void UpdateGP(int gpid, string firstName, string lastName)
		{
			using var db = new PatientRecordsContext();
			var selectedGP = db.Gps.Where(x => x.Gpid == gpid).FirstOrDefault();
			selectedGP.FirstName = firstName;
			selectedGP.LastName = lastName;
			db.SaveChanges();
		}

		public void UpdatePatient(int patientid, Gp gp, string firstName, string lastName, DateTime dob, string address1,
			string address2, string address3, string city, string region, string postcode, string contactnumber)
		{
			using var db = new PatientRecordsContext();
			var selectedPatient = db.Patients.Where(x => x.PatientId == patientid).FirstOrDefault();
			selectedPatient.Gp = gp;
			selectedPatient.FirstName = firstName;
			selectedPatient.LastName = lastName;
			selectedPatient.DateOfBirth = dob;
			selectedPatient.Address1 = address1;
			selectedPatient.Address2 = address2;
			selectedPatient.Address3 = address3;
			selectedPatient.City = city;
			selectedPatient.Region = region;
			selectedPatient.PostalCode = postcode;
			selectedPatient.ContactNumber = contactnumber;
			db.SaveChanges();
		}

		public void UpdateConcern(int concernid, string concern)
		{
			using var db = new PatientRecordsContext();
			var selectedConcern = db.Concerns.Where(x => x.ConcernId == concernid).FirstOrDefault();
			selectedConcern.Concern1 = concern;
			db.SaveChanges();
		}
		public void UpdateVaccine(int vaccineid, string name)
		{
			using var db = new PatientRecordsContext();
			var selectedVaccine = db.Vaccines.Where(x => x.VaccineId == vaccineid).FirstOrDefault();
			selectedVaccine.Vaccine1 = name;
			db.SaveChanges();
		}

		public void UpdatePatientImmunisation(int patientid, DateTime vaccinedate)
		{
			using var db = new PatientRecordsContext();
			var selectedPatient = db.PatientImmunisations.Where(x => x.PatientId == patientid).FirstOrDefault();
			selectedPatient.VaccineDate = vaccinedate;
			db.SaveChanges();
		}

		public void UpdateAllergy(int allergyid, string allergen, string reaction)
		{
			using var db = new PatientRecordsContext();
			var selectedAllergy = db.Allergies.Where(x => x.AllergyId == allergyid).FirstOrDefault();
			selectedAllergy.Allergen = allergen;
			selectedAllergy.ReactionType = reaction;
			db.SaveChanges();
		}

		public void UpdateMedication(int medicationid, string name)
		{
			using var db = new PatientRecordsContext();
			var selectedMedication = db.Medications.Where(x => x.MedicationId == medicationid).FirstOrDefault();
			selectedMedication.MedicationName = name;
			db.SaveChanges();
		}

		public void UpdatePatientMedication(int patientMedicationid, Medication medication, string frequency, string dosage, DateTime startdate, DateTime stopdate)
		{
			using var db = new PatientRecordsContext();
			var selectedPatientMedication = db.PatientMedications.Where(x => x.PatientMedicationId == patientMedicationid).FirstOrDefault();
			selectedPatientMedication.Medication = medication;
			selectedPatientMedication.Frequency = frequency;
			selectedPatientMedication.Dosage = dosage;
			selectedPatientMedication.StartDate = startdate;
			selectedPatientMedication.StopDate = stopdate;
			db.SaveChanges();
		}
	}
}
