using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspcore_angular.Controllers.Resources;
using aspcore_angular.Models;
using aspcore_angular.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspcore_angular.Controllers
{
  public class FeaturesController : Controller
  {
    private readonly AppDbContext context;
    private readonly IMapper mapper;
    public FeaturesController(AppDbContext context, IMapper mapper)
    {
      this.mapper = mapper;
      this.context = context;
    }

    [HttpGet("/api/features")]
    public async Task<IEnumerable<FeatureResource>> GetFeatures()
    {
      var features = await context.Features.ToListAsync();

      return mapper.Map<List<Feature>, List<FeatureResource>>(features);
    }
  }
}