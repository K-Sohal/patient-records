using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	public partial class Patient
	{
		public override string ToString()
		{
			return $"{FirstName} {LastName}";
		}
	}
}
