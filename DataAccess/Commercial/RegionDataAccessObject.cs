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
    public class RegionDataAccessObject
    {
        //private Context _context;

        public RegionDataAccessObject()
        {
            //_context = new Context();
        }

        #region List
        public List<Region> List()
        {
            using var _context = new Context();
            return _context.Set<Region>().ToList();
        }
        public async Task<List<Region>> ListAsync()
        {
            using var _context = new Context();
            return await _context.Set<Region>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(Region region)
        {
            using var _context = new Context();
            _context.Regions.Add(region);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Region region)
        {
            using var _context = new Context();
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Region Read(Guid id)
        {
            using var _context = new Context();
            return _context.Regions.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Region> ReadAsync(Guid id)
        {
            using var _context = new Context();
            Func<Region> region = () => _context.Regions.FirstOrDefault(x => x.Id == id);
            return await new Task<Region>(region);
        }
        #endregion

        #region Update
        public void Update(Region region)
        {
            using var _context = new Context();
            _context.Entry(region).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Region region)
        {
            using var _context = new Context();
            _context.Entry(region).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Region region)
        {
            region.IsDeleted = true;
            Update(region);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Region region)
        {
            region.IsDeleted = true;
            await UpdateAsync(region);
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
