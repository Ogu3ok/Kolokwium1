using System.ComponentModel.DataAnnotations;

namespace Kolos1.Models;

public class Firefighter
{
    [Required] 
    public int IdFirefighter { get; set; }
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string LastName { get; set; }
    
}