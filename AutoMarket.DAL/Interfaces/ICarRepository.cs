﻿using AutoMarket.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.DAL.Interfaces
{
    public interface ICarRepository : IBaseRepostory<Car>
    {
       Task<Car> GetByName(string name);
    }
}
