﻿using EduBook.DataAccess.Data;
using EduBook.DataAccess.Repository.IRepository;
using EduBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBook.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            var objFromDb = _db.Companies.FirstOrDefault(s => s.Id == company.Id);
            if (objFromDb != null) 
            {
                objFromDb.Name = company.Name;
            }
        }
    }
}