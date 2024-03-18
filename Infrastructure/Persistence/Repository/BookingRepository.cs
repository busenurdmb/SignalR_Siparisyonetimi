using Application.Repositories;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class BookingRepository : EfEntityRepository<Booking, SignalRContext>, IBookingRepository
    {
        public BookingRepository(SignalRContext context) : base(context)
        {
        }

        public async Task BookingStatusApproved(int id)
        {
            var value = await _context.Bookings.FindAsync(id);
            value.Description = "Rezervasyon Onaylandı";
            await _context.SaveChangesAsync();
        }

        public async Task BookingStatusCancelled(int id)
        {
            var value = await _context.Bookings.FindAsync(id);
            value.Description = "Rezervasyon İptal Edildi";
            await _context.SaveChangesAsync();
        }
    }
}
