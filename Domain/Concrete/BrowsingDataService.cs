using DAL.Browsing_Data;
using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
	public class BrowsingDataService
	{
		private readonly IBrowsingDataRepository _browsingDataRepository;

		public BrowsingDataService(IBrowsingDataRepository browsingDataRepository)
		{
			_browsingDataRepository = browsingDataRepository;
		}

		public void LogLoginActivity(int clientId)
		{
			var browsingData = new BrowsingData
			{
				ActionType = "Login",
				Time = DateTime.Now,
				ReservationDetails = "Perdoruesi u logua"
			};

			_browsingDataRepository.AddBrowsingData(browsingData);
		}

	}
}
