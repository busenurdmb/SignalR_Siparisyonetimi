using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
	public interface INotificationRepository:IEntityRepository<Notification>
	{
		int NotificationCountByStatusFalse();
		List<Notification> GetAllNotificationByFalse();
        Task NotificationStatusChangeToTrue(int id);
        Task NotificationStatusChangeToFalse(int id);
    }
}
