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
    public class SliderRepository : EfEntityRepository<Slider, SignalRContext>, ISliderRepository
    {
        public SliderRepository(SignalRContext context) : base(context)
        {
        }
    }
}
