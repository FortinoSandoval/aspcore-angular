using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using aspcore_angular.Models;

namespace aspcore_angular.Controllers.Resources
{
  public class VehicleResource
  {
    public int Id { get; set; }
    public ModelResource Model { get; set; }
    public MakeResource Make { get; set; }

    public bool IsRegistered { get; set; }
    public ContactResource Contact { get; set; }
    [StringLength(255)]
    public DateTime LastUpdate { get; set; }
    public ICollection<FeatureResource> Features { get; set; }

    public VehicleResource()
    {
      Features = new Collection<FeatureResource>();
    }
  }
}