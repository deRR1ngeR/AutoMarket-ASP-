using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Entity;
using AutoMarket.Domain.ViewModel.Car;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AutoMarket.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDBContext db;
        public CarRepository(ApplicationDBContext db)
        {
            this.db = db;
        }

        public async Task<bool> Create(Car entity)
        {
            await db.Car.AddAsync(entity);
            db.SaveChanges();

            return true;
        }

        public async Task<bool> Delete(Car entity)
        {
            db.Car.Remove(entity);
          await  db.SaveChangesAsync();
            return true;

        }

        public async Task<Car> Get(int id)
        {
            return await db.Car.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Car> GetByName(string name)
        {
            return await db.Car.FirstOrDefaultAsync(x => x.Name == name);

        }

        public async Task<List<Car>> Select()
        {
            return await db.Car.ToListAsync();
        }

        public async Task<Car> Update(Car entity)
        {
            db.Update(entity);
            await db.SaveChangesAsync();
            return entity;

        }
    }
}
