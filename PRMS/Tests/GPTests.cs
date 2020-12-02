using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;
using Business;
using NUnit.Framework;

namespace Tests
{
	public class GPTests
	{
		CRUDManager _crudManager = new CRUDManager();

		[SetUp]
		public void Setup()
		{
			using var db = new PatientRecordsContext();
			var selectedGP = db.Gps.Where(x => x.FirstName == "Bob").FirstOrDefault();
			if (selectedGP != null)
			{
				db.Remove(selectedGP);
				db.SaveChanges();
			}
		}

		[TearDown]

		public void TearDown()
		{
			using var db = new PatientRecordsContext();
			var selectedGP = db.Gps.Where(x => x.FirstName == "Bob").FirstOrDefault();
			if (selectedGP != null)
			{
				db.Remove(selectedGP);
				db.SaveChanges();
			}
		}

		[Test]
		public void WhenANewGPIsAdded_TheNumberOfGPsIncreasesBy1()
		{
			using var db = new PatientRecordsContext();
			int startUserCount = db.Gps.Count();
			_crudManager.CreateGP("Bob", "Sam");
			int endUserCount = db.Gps.Count();
			Assert.AreEqual(startUserCount + 1, endUserCount);
		}

		[Test]
		public void WhenANewGPIsAdded_TheirNameIsCorrect()
		{
			using var db = new PatientRecordsContext();
			_crudManager.CreateGP("Bob", "Sam");
			var query = db.Gps.Where(u => u.FirstName == "Bob").FirstOrDefault();
			Assert.AreEqual("Bob", query.FirstName);
			Assert.AreEqual("Sam", query.LastName);
		}
	}
}
