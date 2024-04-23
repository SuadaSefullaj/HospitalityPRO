using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contacts
{
    public interface IBrowsingDataRepository
    {
        ICollection<BrowsingData> GetAllData();
        BrowsingData GetData(int dataId);
        bool CreateData(BrowsingData data);
        bool DeleteData(BrowsingData data);

        bool Save();
        bool DataExists(int dataId);
    }
}
