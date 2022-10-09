using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Entity;
using AutoMarket.Service.Intrefaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMarket.Domain.Response;
using AutoMarket.Domain.Enum;
using AutoMarket.Domain.ViewModel.Car;

namespace AutoMarket.Service.Implementations
{
	public class CarService : ICarService
	{
		private readonly ICarRepository _carRepository;
		public CarService(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}

		public async Task<IBaseResponse<IEnumerable<Car>>> GetCars()
		{
			var baseResponse = new BaseResponse<IEnumerable<Car>>();
			try
			{
				var cars = await _carRepository.Select();
				if(cars.Count == 0)
				{
					baseResponse.Description = "Найдено 0 элементов";
					baseResponse.StatusCode = StatusCode.OK;
					return baseResponse;
				}
				baseResponse.Data = cars;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;	
			}
			catch(Exception ex)
			{
				return new BaseResponse<IEnumerable<Car>>()
				{
					Description = $"[GetCars] : {ex.Message}",
					StatusCode = StatusCode.CarNotFound
					
				};
			}
		}

		public async Task<IBaseResponse<Car>> GetCar(int id)
		{
			var baseResponse = new BaseResponse<Car>();
			try
			{
				var car = await _carRepository.Get(id);
				if(car == null)
				{
					baseResponse.Description = "Car was not found";
					baseResponse.StatusCode = StatusCode.CarNotFound;
					return baseResponse;
				}
				baseResponse.Data = car;
				return baseResponse;
			}
			catch(Exception ex)
			{
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCars] : {ex.Message}",
					StatusCode = StatusCode.CarNotFound
                };
            }
		}
		public async Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel)
		{
			try
			{
			var baseResponse = new BaseResponse<CarViewModel>();
				var car = new Car()
				{
					Name = carViewModel.Name,
					Price = carViewModel.Price,
					Description = carViewModel.Description,
					DateCreate = carViewModel.DateCreate,
					TypeCar = (TypeCar)Convert.ToInt32(carViewModel.TypeCar),
					Model = carViewModel.Model,
					Speed = carViewModel.Speed
				};
				await _carRepository.Create(car);
				return baseResponse;
			}
			catch(Exception ex)
			{
				return new BaseResponse<CarViewModel>()
				{
					Description = $"[CreateCar] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
                };
			}
		}
		public async Task<IBaseResponse<bool>> DeleteCar(int id)
		{
			var baseResponse = new BaseResponse<bool>()
			{
				Data = true
			};
			try
			{
                var car = await _carRepository.Get(id);
                if (car == null)
				{
                    baseResponse.Description = "Car was not found";
                    baseResponse.StatusCode = StatusCode.CarNotFound;
					baseResponse.Data = false;
					return baseResponse;
				}
                   
               await _carRepository.Delete(car);
				return baseResponse;
            }
			catch(Exception ex)
			{
				return new BaseResponse<bool>()
				{
					Description = $"[DeleteCar] : {ex.Message}",
					StatusCode = StatusCode.CarNotFound
					
				};
			}
			
		} 
        public async Task<IBaseResponse<Car>> GetCarByName(string name)
        {
            var baseResponse = new BaseResponse<Car>();
            try
            {
                var car = await _carRepository.GetByName(name);
                if (car == null)
                {
                    baseResponse.Description = "Car was not found";
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    return baseResponse;
                }
                baseResponse.Data = car;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCar] : {ex.Message}",
                    StatusCode = StatusCode.CarNotFound
                };
            }
        }
    }
}
