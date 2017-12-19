using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Core;
using vega.Core.Models;
using vega.Persistence;

namespace vega.Controllers
{
   [Route("/api/features")]
   public class FeaturesController : Controller
  {
    private readonly VegaDbContext context;
    private readonly IMapper mapper;
    private readonly IFeatureRepository repository;
    private readonly IUnitOfWork unitOfWork;

    public FeaturesController(VegaDbContext context, IMapper mapper,IFeatureRepository repository,IUnitOfWork unitOfWork)
    {
      this.mapper = mapper;
      this.context = context;
      this.repository = repository;
      this.unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    //[Authorize]
    public async Task<IEnumerable<KeyValuePairResource>> GetFeatures()
    {
      List<Feature> features = await repository.GetFeatures();
      
      return mapper.Map<List<Feature>, List<KeyValuePairResource>>(features); 
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetFeature(int id)
    {
      var feature = await repository.GetFeature(id);

      if (feature == null)
        return NotFound();

      var featureResource = mapper.Map<Feature, KeyValuePairResource>(feature);

      return Ok(featureResource);
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteFeature(int id)
    {
      var feature = await repository.GetFeature(id);

      if (feature == null)
        return NotFound();
      repository.Remove(feature);
      await unitOfWork.CompleteAsync();

      return Ok(id);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateFeatures(int id, [FromBody] KeyValuePairResource featureResource)
    {
     var feature = await repository.GetFeature(id);

      if (feature == null)
        return NotFound();

      mapper.Map<KeyValuePairResource, Feature>(featureResource, feature);
      await unitOfWork.CompleteAsync();

      feature = await repository.GetFeature(feature.Id);
      var result = mapper.Map<Feature, KeyValuePairResource>(feature);

      return Ok(result);
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateFeature([FromBody] KeyValuePairResource featureResource)
    {
      var feature = mapper.Map<KeyValuePairResource, Feature>(featureResource);

      repository.Add(feature);
      await unitOfWork.CompleteAsync();

      feature = await repository.GetFeature(feature.Id);

      var result = mapper.Map<Feature,KeyValuePairResource>(feature);

      return Ok(result);
    }
  }
}