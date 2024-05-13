using System.ComponentModel.DataAnnotations;

namespace Kolos1.Models;

public class FireTruck
{
    [Required]
    public int IdFiretruck { get; set; }
    [Required]
    public string OperationNumber { get; set; }
    [Required]
    public bool SpecialEquipment { get; set; }
}