using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	public partial class Medication
	{
		public override string ToString()
		{
			return $"{MedicationName}";
		}
	}
}
