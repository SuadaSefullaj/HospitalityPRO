using DAL.Contacts;
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

		
		//LogLoginActivity(userName, password);

	}
}
