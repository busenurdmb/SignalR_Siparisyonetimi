﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IBookingRepository : IEntityRepository<Booking>
    {
        Task BookingStatusApproved(int id);
        Task BookingStatusCancelled(int id);
    }
}
