using System.Collections.Generic;
using System.Threading.Tasks;
using aspcore_angular.Controllers.Resources;
using aspcore_angular.Models;
using aspcore_angular.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspcore_angular.Controllers
{
  public class MakesController : Controller
  {
    private readonly IMapper mapper;

    private readonly AppDbContext context;
    public MakesController(AppDbContext context, IMapper mapper)
    {
      this.mapper = mapper;
      this.context = context;
    }
    [HttpGet("/api/makes")]
    public async Task<IEnumerable<MakeResource>> GetMakes()
    {
      var makes = await context.Makes.Include(m => m.Models).ToListAsync();
      return mapper.Map<List<Make>, List<MakeResource>>(makes);
    }
  }
}