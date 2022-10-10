﻿using AutoMarket.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.Domain.Response
{
	public class BaseResponse<T>: IBaseResponse<T>
	{
		public string Description { get; set; }

		public StatusCode StatusCode { get; set; }

		public T Data { get; set; }
	}
	public interface IBaseResponse<T>
	{
		T Data { get; }
        StatusCode StatusCode { get; }
    }
}
