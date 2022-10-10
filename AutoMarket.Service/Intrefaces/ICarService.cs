﻿using AutoMarket.Domain.Entity;
using AutoMarket.Domain.Response;
using AutoMarket.Domain.ViewModel.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutoMarket.Service.Intrefaces
{
	public interface ICarService
	{
		Task<IBaseResponse<IEnumerable<Car>>> GetCars();
		Task<IBaseResponse<Car>> GetCar(int id);

		Task<IBaseResponse<bool>> DeleteCar(int id);

		Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel);
		
		Task<IBaseResponse<Car>> GetCarByName(string name);

		Task<IBaseResponse<Car>> Edit(int id, CarViewModel model);
	}
}
