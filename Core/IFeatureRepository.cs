using System.Collections.Generic;
using System.Threading.Tasks;
using vega.Core.Models;

namespace vega.Core
{
    public interface IFeatureRepository
    {
        Task<Feature> GetFeature(int id); 
        Task<List<Feature>> GetFeatures();
        void Add(Feature feature);
        void Remove(Feature feature);
    }
}