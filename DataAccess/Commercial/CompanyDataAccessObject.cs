using Microsoft.EntityFrameworkCore;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.RD.FullStoQ.DataAccess.Commercial
{
    public class CompanyDataAccessObject
    {
        private readonly Context _context;
        public CompanyDataAccessObject()
        {
            _context = new Context();
        }

        #region Create
        public void Create(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Company Read(Guid id)
        {
            return _context.Companies.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Company> ReadAsync(Guid id)
        {
            return await new Task<Company>(() => _context.Companies.FirstOrDefault(x => x.Id == id));
            
        }
        #endregion

        #region Update
        public void Update(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Company company)
        {
            company.IsDeleted = true;
            Update(company);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }
        public async Task DeleteAsync(Company company)
        {
            company.IsDeleted = true;
            await UpdateAsync(company);
        }
        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);
        }
        #endregion

        public List<Company> List()
        {
            return _context.Set<Company>().ToList();
        }

        public async Task<List<Company>> ListAsync()
        {
            return await _context.Set<Company>().ToListAsync();
        }
    }
}
