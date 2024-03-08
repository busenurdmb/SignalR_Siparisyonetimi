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
    public class SocialMediaRepository : EfEntityRepository<SocialMedia, SignalRContext>, ISocialMediaRepository
    {
        public SocialMediaRepository(SignalRContext context) : base(context)
        {
        }
    }
}
