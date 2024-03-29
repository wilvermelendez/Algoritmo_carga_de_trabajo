﻿using System.Collections.Generic;
using ASPNET_Core_2_1.Models;

namespace ASPNET_Core_2_1.Services
{
    public interface IOperatorService
    {
        List<Operator> CreateOperatorsList(int quantity);
        List<Operator> AddOperator(List<Operator> operators);
    }
}