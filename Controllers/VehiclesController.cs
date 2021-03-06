using System;
using System.Threading.Tasks;
using aspcore_angular.Controllers.Resources;
using aspcore_angular.Models;
using aspcore_angular.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    /// <summary>
    /// Create a new vehicle entry
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody]SaveVehicleResource vehicleResource)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
      vehicle.LastUpdate = DateTime.Now;

      context.Vehicles.Add(vehicle);
      await context.SaveChangesAsync();

      var result = mapper.Map<Vehicle, SaveVehicleResource>(vehicle);

      return Ok(result);
    }

    /// <summary>
    /// Update vehicle entry data
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVehicle(int id, [FromBody]SaveVehicleResource vehicleResource)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

      if (vehicle == null)
        return NotFound();

      mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
      vehicle.LastUpdate = DateTime.Now;

      await context.SaveChangesAsync();

      var result = mapper.Map<Vehicle, SaveVehicleResource>(vehicle);

      return Ok(result);
    }

    /// <summary>
    /// Delete a vehicle Entry
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehicle(int id)
    {
      var vehicle = await context.Vehicles.FindAsync(id);

      if (vehicle == null)
        return NotFound();

      context.Remove(vehicle);
      await context.SaveChangesAsync();
      return Ok(id);
    }

    /// <summary>
    /// get single Vehicle with the ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetVehicle(int id)
    {
      var vehicle = await context
        .Vehicles.Include(v => v.Features).ThenInclude(vf => vf.Feature).Include(v => v.Model).ThenInclude(m => m.Make).SingleOrDefaultAsync(v => v.Id == id);

      if (vehicle == null)
        return NotFound();

      var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

      return Ok(vehicleResource);
    }
  }
}