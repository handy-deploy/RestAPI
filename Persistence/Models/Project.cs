using System.ComponentModel.DataAnnotations;

namespace Persistence.Models;

public class Project
{
    [Key]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    
    public string VCSUrl { get; set; }
}