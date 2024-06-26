﻿using DAL.Contacts;
using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class BrowsingDataRepository : IBrowsingDataRepository
    {
        private readonly HospitalityPRO_DbContext _context;

        public BrowsingDataRepository(HospitalityPRO_DbContext context)
        {
            _context = context;
        }
        public ICollection<BrowsingData> GetAllData()
        {
            return _context.BrowsingData.ToList();
        }

        public BrowsingData GetData(int dataId)
        {

            return _context.BrowsingData.Where(s => s.BrowsingId == dataId).FirstOrDefault();
        }

        public bool DataExists(int dataId)
        {
            if (_context.BrowsingData.Any(p => p.BrowsingId == dataId)) return true;
            else return false;
        }



        public void AddBrowsingData(BrowsingData browsingData)
        {
            _context.BrowsingData.Add(browsingData);
            _context.SaveChanges();
        }

        public bool CreateData(BrowsingData data)
        {
            _context.Add(data);
            return Save();
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool DeleteData(BrowsingData data)
        {
            _context.Remove(data);
            return Save();
        }
    }


}
