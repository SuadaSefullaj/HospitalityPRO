using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Browsing_Data
{
	public  interface IBrowsingDataRepository
	{
		ICollection<BrowsingData> GetAllData();
		BrowsingData GetData(int dataId);
		void AddBrowsingData(BrowsingData browsingData);
		bool DataExists(int dataId);
	}
}
