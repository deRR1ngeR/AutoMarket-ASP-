using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.Domain.Enum
{
    public enum TypeCar
    {
        [Display(Name = "Легковой автомобиль")]
        PassengerCar = 0,
        [Display(Name = "Седан")]
        Sedan = 1,
        [Display(Name = "Хэтчбек")]
        HatchBaack = 2,
        [Display(Name = "Минивэн")]
        Minivan = 3,
        [Display(Name = "Спортировный автомобиль")]
        SportCar = 4,
        [Display(Name = "Внедорожник")]
        Suv = 5

    }
}
