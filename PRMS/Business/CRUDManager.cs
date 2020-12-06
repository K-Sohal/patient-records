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
		static void Main(string[] args)
		{

		}

		//Register logic

		public bool CheckPassword(string password, string confirmedPassword)
		{
			return password == confirmedPassword;
		}

		public bool EmailExists(string email)
		{
			using var db = new PatientRecordsContext();
			var Email = db.Gps.Where(e => e.Gpemail.ToLower() == email.ToLower()).FirstOrDefault();
			if (Email != null)
			{
				return true;
			}
			return false;
		}

		//Login logic

		public bool CheckLoginDetails(string email, string password)
		{
			using var db = new PatientRecordsContext();
			var selectedGP = db.Gps.Where(e => e.Gpemail == email).FirstOrDefault();
			if (selectedGP != null)
			{
				if (selectedGP.Gppassword == password)
				{
					return true;
				}
			}
			return false;
		}

		public void SetGP(string email)
		{
			using var db = new PatientRecordsContext();
			selectedGP = db.Gps.Where(e => e.Gpemail == email).FirstOrDefault();
		}

		//Gp logic
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
			var PatientAllergies = db.Allergies.Where(p => p.PatientId == selectedPatient.PatientId);
			return PatientAllergies.ToList();
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
			var PatientVaccines = db.Vaccines.Where(p => p.PatientId == selectedPatient.PatientId);
			return PatientVaccines.ToList();
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
			var PatientMedications = db.Medications.Where(p => p.PatientId == selectedPatient.PatientId);
			return PatientMedications.ToList();
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
		public void CreateGP(string email, string password, string firstName, string lastName)
		{
			using var db = new PatientRecordsContext();
			var newGP = new Gp
			{
				Gpemail = email,
				Gppassword = password,
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
				PatientId = patient.PatientId
			};
			db.Concerns.Add(newConcern);
			db.SaveChanges();
		}
		public void CreateVaccine(Patient patient, string name, DateTime vaccineDate)
		{
			using var db = new PatientRecordsContext();
			var newVaccine = new Vaccine
			{
				PatientId = patient.PatientId,
				Vaccine1 = name,
				VaccineDate = vaccineDate
			};
			db.Vaccines.Add(newVaccine);
			db.SaveChanges();
		}


		public void CreateAllergy(Patient patient, string allergen, string reaction)
		{
			using var db = new PatientRecordsContext();
			var newAllergy = new Allergy
			{
				PatientId = patient.PatientId,
				Allergen = allergen,
				ReactionType = reaction
			};
			db.Allergies.Add(newAllergy);
			db.SaveChanges();
		}

		public void CreateMedication(Patient patient, string name, string frequency, string dosage, DateTime startdate, DateTime stopdate)
		{
			using var db = new PatientRecordsContext();
			var newMedication = new Medication
			{
				PatientId = patient.PatientId,
				MedicationName = name,
				Frequency = frequency,
				Dosage = dosage,
				StartDate = startdate,
				StopDate = stopdate
			};
			db.Medications.Add(newMedication);
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

		public void DeleteAllergy(int allergyid)
		{
			using var db = new PatientRecordsContext();
			var selectedAllergy = db.Allergies.Where(x => x.AllergyId == allergyid).FirstOrDefault();
			db.Allergies.Remove(selectedAllergy);
			db.SaveChanges();
		}

		public void DeleteMedication(int medicationid)
		{
			using var db = new PatientRecordsContext();
			var selectedMedication = db.Medications.Where(x => x.MedicationId == medicationid).FirstOrDefault();
			db.Medications.Remove(selectedMedication);
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
		public void UpdateVaccine(int vaccineid, string name, DateTime vaccineDate)
		{
			using var db = new PatientRecordsContext();
			var selectedVaccine = db.Vaccines.Where(x => x.VaccineId == vaccineid).FirstOrDefault();
			selectedVaccine.Vaccine1 = name;
			selectedVaccine.VaccineDate = vaccineDate;
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

		public void UpdateMedication(int medicationid, string name, string frequency, string dosage, DateTime startdate, DateTime stopdate)
		{
			using var db = new PatientRecordsContext();
			var selectedMedication = db.Medications.Where(x => x.MedicationId == medicationid).FirstOrDefault();
			selectedMedication.MedicationName = name;
			selectedMedication.Frequency = frequency;
			selectedMedication.Dosage = dosage;
			selectedMedication.StartDate = startdate;
			selectedMedication.StopDate = stopdate;
			db.SaveChanges();
		}

	}
}
