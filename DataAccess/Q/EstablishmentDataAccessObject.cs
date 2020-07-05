using Data.Queues;
using Recodme.RD.FullStoQ.Data.Users;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Recodme.RD.FullStoQ.DataAccess.Queues
{
    public class EstablishmentDataAccessObject 
    {
        private Account _context;

        public EstablishmentDataAccessObject()
        {
            _context = new Account();
        }

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
