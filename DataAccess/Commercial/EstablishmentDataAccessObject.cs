﻿using Microsoft.EntityFrameworkCore;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Users;
using Recodme.RD.FullStoQ.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.FullStoQ.DataAccess.Commercial
{
    public class EstablishmentDataAccessObject 
    {
        private Context _context;

        public EstablishmentDataAccessObject()
        {
            _context = new Context();
        }

        #region List
        public List<Establishment> List()
        {
            return _context.Set<Establishment>().ToList();
        }
        public async Task<List<Establishment>> ListAsync()
        {
            return await _context.Set<Establishment>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(Establishment establishment)
        {
            _context.Establishment.Add(establishment);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Establishment establishment)
        {
            await _context.Establishment.AddAsync(establishment);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Establishment Read(Guid id)
        {
            return _context.Establishment.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Establishment> ReadAsync(Guid id)
        {
            Func<Establishment> establishment = () => _context.Establishment.FirstOrDefault(x => x.Id == id);
            return await new Task<Establishment>(establishment);
        }
        #endregion

        #region Update
        public void Update(Establishment establishment)
        {
            _context.Entry(establishment).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Establishment establishment)
        {
            _context.Entry(establishment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Establishment establishment)
        {
            establishment.IsDeleted = true;
            Update(establishment);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Establishment establishment)
        {
            establishment.IsDeleted = true;
            await UpdateAsync(establishment);
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);
        }
        #endregion
    }
}