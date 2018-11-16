using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace aspcore_angular.Models
{
  public class Make
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Model> Models { get; set; }

    public Make()
    {
      Models = new Collection<Model>();
    }
  }
}