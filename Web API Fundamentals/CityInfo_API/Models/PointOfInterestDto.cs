using System.ComponentModel.DataAnnotations;

namespace CityInfo_API;

public class PointOfInterestDto
{

    [Required(ErrorMessage = "You should provide a name value.")]
    [MaxLength(50)]

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int NumberOfPointsOfInterest
    {
        get
         { return PointsOfInterest.Count; }
    }
    
    public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();

}
