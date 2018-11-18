using System.ComponentModel.DataAnnotations;

namespace aspcore_angular.Models
{
  public class Feature
  {
    public long Id { get; set; }
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
  }
}