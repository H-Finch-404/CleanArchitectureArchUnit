using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureArchUnit.Web.Endpoints.ProjectEndpoints;

public class CreateProjectRequest
{
  public const string Route = "/Projects";

  [Required]
  public string? Name { get; set; }
}
