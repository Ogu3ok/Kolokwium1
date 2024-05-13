using System.ComponentModel.DataAnnotations;

namespace Kolos1.Models;

public class FireAction
{
    [Required]
    public int IdFireAction { get; set; }
    [Required]
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    [Required]
    public bool NeedSpecialEquipment { get; set; }
    public List<Firefighter>? Firefighters { get; set; }
}