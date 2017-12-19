using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.Core;
using vega.Core.Models;

namespace vega.Persistence
{
    public class FeatureRepository : IFeatureRepository
    {
    private readonly VegaDbContext context;

    public FeatureRepository(VegaDbContext context)
    {
        this.context = context;
    }
     public void Add(Feature feature)
        {
            context.Features.Add(feature);
        }

        public async Task<Feature> GetFeature(int id)
        {
          return await context.Features.FindAsync(id);
        }

        public void Remove(Feature feature)
        {          
            context.Remove(feature);
        }
        public async Task<List<Feature>> GetFeatures()
        {
            return await context.Features.ToListAsync();
        }
    }
}