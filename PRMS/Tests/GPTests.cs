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
			var selectedGP = db.Gps.Where(x => x.Gpemail == "test@test.com").FirstOrDefault();
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
			var selectedGP = db.Gps.Where(x => x.Gpemail == "test@test.com").FirstOrDefault();
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
			_crudManager.CreateGP("test@test.com", "test123", "test1", "test2");
			int endUserCount = db.Gps.Count();
			Assert.AreEqual(startUserCount + 1, endUserCount);
		}

		[Test]
		public void WhenANewGPIsAdded_TheirNameIsCorrect()
		{
			using var db = new PatientRecordsContext();
			_crudManager.CreateGP("test@test.com", "test123", "test1", "test2");
			var query = db.Gps.Where(x => x.Gpemail == "test@test.com").FirstOrDefault();
			Assert.AreEqual("test1", query.FirstName);
			Assert.AreEqual("test2", query.LastName);
			Assert.AreEqual("test@test.com", query.Gpemail);
			Assert.AreEqual("test123", query.Gppassword);
		}
	}
}
