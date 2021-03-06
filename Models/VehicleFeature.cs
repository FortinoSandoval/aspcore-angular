using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore_angular.Models
{
  [Table("VehicleFeatures")]
  public class VehicleFeature
  {
    public int VehicleId { get; set; }
    public int FeatureId { get; set; }
    public Vehicle MyProperty { get; set; }
    public Feature Feature { get; set; }
  }
}