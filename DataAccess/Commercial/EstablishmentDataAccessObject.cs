﻿using Microsoft.EntityFrameworkCore;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.FullStoQ.DataAccess.Commercial
{
    public class EstablishmentDataAccessObject 
    {
        //private Context _context;

        public EstablishmentDataAccessObject()
        {
            //_context = new Context();
        }

        #region List
        public List<Establishment> List()
        {
            using var _context = new Context();
            return _context.Set<Establishment>().ToList();
        }
        public async Task<List<Establishment>> ListAsync()
        {
            using var _context = new Context();
            return await _context.Set<Establishment>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(Establishment establishment)
        {
            using var _context = new Context();
            _context.Establishments.Add(establishment);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Establishment establishment)
        {
            using var _context = new Context();
            await _context.Establishments.AddAsync(establishment);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Establishment Read(Guid id)
        {
            using var _context = new Context();
            return _context.Establishments.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Establishment> ReadAsync(Guid id)
        {
            using var _context = new Context();
            Func<Establishment> establishment = () => _context.Establishments.FirstOrDefault(x => x.Id == id);
            return await new Task<Establishment>(establishment);
        }
        #endregion

        #region Update
        public void Update(Establishment establishment)
        {
            using var _context = new Context();
            _context.Entry(establishment).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Establishment establishment)
        {
            using var _context = new Context();
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
