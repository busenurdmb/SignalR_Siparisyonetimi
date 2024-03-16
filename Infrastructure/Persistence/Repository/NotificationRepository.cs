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
	public class NotificationRepository : EfEntityRepository<Notification, SignalRContext>, INotificationRepository
	{
		public NotificationRepository(SignalRContext context) : base(context)
		{
		}

		public List<Notification> GetAllNotificationByFalse()
		{
			var value = _context.Notifications.Where(x => x.Status == false).ToList();
			return value;
		}

		public int NotificationCountByStatusFalse()
		{
			var value=_context.Notifications.Where(x=>x.Status==false).Count();
			return value;
		}

        public async Task NotificationStatusChangeToFalse(int id)
        {
			var değer =await _context.Notifications.FindAsync(id);
			değer.Status = false;
			await _context.SaveChangesAsync();
        }

        public async Task NotificationStatusChangeToTrue(int id)
        {
            var değer = await _context.Notifications.FindAsync(id);
            değer.Status = true;
            await _context.SaveChangesAsync();
        }
    }
}
