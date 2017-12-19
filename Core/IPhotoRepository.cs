using System.Collections.Generic;
using System.Threading.Tasks;
using vega.Core.Models;

namespace vega.Core
{
    public interface IPhotoRepository
    {
        void Remove(IEnumerable<Photo> photo);
        Task<IEnumerable<Photo>> GetPhotos(int vehicleId);

         
    }
}