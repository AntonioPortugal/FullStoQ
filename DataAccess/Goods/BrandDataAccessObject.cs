﻿using Microsoft.EntityFrameworkCore;
using Recodme.RD.FullStoQ.Data.Goods;
using Recodme.RD.FullStoQ.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.RD.FullStoQ.DataAccess.Goods
{
    public class BrandDataAccessObject
    {
        private Context _context;
        public BrandDataAccessObject()
        {
            _context = new Context();
        }

        #region List
        public List<Brand> List()
        {
            return _context.Set<Brand>().ToList();
        }

        public async Task<List<Brand>> ListAsync()
        {
            return await _context.Set<Brand>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Brand brand)
        {
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Brand Read(Guid id)
        {
            return _context.Brands.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Brand> ReadAsync(Guid id)
        {
            return await Task.Run(() => _context.Set<Brand>().FirstOrDefault(x => x.Id == id));
        }
        #endregion

        #region Update
        public void Update(Brand brand)
        {
            _context.Entry(brand).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Brand brand)
        {
            _context.Entry(brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Brand brand)
        {
            brand.IsDeleted = true;
            Update(brand);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Brand brand)
        {
            brand.IsDeleted = true;
            await UpdateAsync(brand);
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
