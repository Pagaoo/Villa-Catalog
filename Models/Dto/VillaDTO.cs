using System.ComponentModel.DataAnnotations;

public class VillaDTO {
    public int Id {get; set;}
    
    [Required]
    [MaxLength(30)]
    public String Name {get; set;}
}