using System.ComponentModel.DataAnnotations;

namespace Kolos1.Models;

public class FirefighterAction
{
    [Required]
    public int IdAction { get; set; }
    [Required]
    public int IdFirefighter { get; set; }
}