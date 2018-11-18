using System;
using System.Threading.Tasks;
using aspcore_angular.Controllers.Resources;
using aspcore_angular.Models;
using aspcore_angular.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace aspcore_angular.Controllers
{
  [Route("/api/vehicles")]
  public class VehiclesController : Controller
  {
    public IMapper mapper;
    private readonly AppDbContext context;
    public VehiclesController(IMapper mapper, AppDbContext context)
    {
      this.context = context;
      this.mapper = mapper;

    }
    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody]VehicleResource vehicleResource)
    {
      var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
      vehicle.LastUpdate = DateTime.Now;
      context.Vehicles.Add(vehicle);
      await context.SaveChangesAsync();
      var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
      return Ok(result);
    }
  }
}