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
    public class FeatureRepository : EfEntityRepository<Feature, SignalRContext>, IFeatureRepository
    {
        public FeatureRepository(SignalRContext context) : base(context)
        {
        }
    }
}
