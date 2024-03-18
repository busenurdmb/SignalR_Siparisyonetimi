using Application.Repositories;
using Domain.Entities;
using Persistence.Context;
using Persistence.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
	public class MessageRepository : EfEntityRepository<Message, SignalRContext>, IMessageRepository
	{
		public MessageRepository(SignalRContext context) : base(context)
		{
		}
	}
}
