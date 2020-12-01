using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Model;
using Microsoft.EntityFrameworkCore;

namespace Business
{
	class CRUDManager
	{
		static void Main(string[] args)
		{
		}

		// Create
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

		public void CreatePatient(Patient gp, string firstName, string lastName, DateTime dob, string address1,
			string address2, string address3, string city, string region, string postcode, string contactnumber)
		{
			using var db = new PatientRecordsContext();
			var newPatient = new Patient
			{
				Gp = gp,
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

		public void CreateConcern(string concern, Concern patient)
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
			db.PatientMedications.Remove(selectedMedication);
			db.SaveChanges();
		}

	}
}
