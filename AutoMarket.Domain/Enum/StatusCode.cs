using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.Domain.Enum
{
	public enum StatusCode
	{
		CarNotFound = 0,
		OK = 200,
		InternalServerError = 500
	};
}
