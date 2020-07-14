using Microsoft.EntityFrameworkCore;
using Recodme.RD.FullStoQ.Data.Goods;
using Recodme.RD.FullStoQ.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.RD.FullStoQ.DataAccess.Goods
{
    public class EssentialGoodDataAccessObject
    {
        private Context _context;

        public EssentialGoodDataAccessObject()
        {
            _context = new Context();
        }

        #region List
        public List<EssentialGood> List()
        {
            return _context.Set<EssentialGood>().ToList();
        }
        public async Task<List<EssentialGood>> ListAsync()
        {
            return await _context.Set<EssentialGood>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(EssentialGood region)
        {
            _context.EssentialGoods.Add(region);
            _context.SaveChanges();
        }

        public async Task CreateAsync(EssentialGood region)
        {
            await _context.EssentialGoods.AddAsync(region);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public EssentialGood Read(Guid id)
        {
            return _context.EssentialGoods.FirstOrDefault(x => x.Id == id);
        }

        public async Task<EssentialGood> ReadAsync(Guid id)
        {
            return await _context.EssentialGoods.FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Update
        public void Update(EssentialGood region)
        {
            _context.Entry(region).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(EssentialGood region)
        {
            _context.Entry(region).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(EssentialGood region)
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

        public async Task DeleteAsync(EssentialGood region)
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
