using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ssibir.DAL.Models.Enums
{
	public enum TripStatus
	{
		ManagerMeditation,
		ClientMeditation,
		ManagerWaiting,
		ClientWaiting,
		AgreementOnly,
		DocsWaiting,
		TripWaiting,
		InTrip,
		Final_WithGoodResponce,
		Final_WithBadResponce,
		Final,
	}
}
