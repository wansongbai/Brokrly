﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dobany.MultiTenancy.HostDashboard.Dto;

namespace Dobany.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}