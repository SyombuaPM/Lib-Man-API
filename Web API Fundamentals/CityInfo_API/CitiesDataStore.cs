namespace CityInfo_API;

public class CitiesDataStore
{

    public List<CityDto> Cities { get; set; }

    public static CitiesDataStore Current { get; } = new CitiesDataStore();

    public CitiesDataStore()
    {
        // init dummy data
        Cities = new List<CityDto>()
        {
            new CityDto()
            {
                Id = 1,
                Name = "Nairobi",
                Description = "The Green City in the Sun",
                
            },
            new CityDto()
            {
                Id = 2,
                Name = "Antwerp",
                Description = "The one with the cathedral that was never really finished",
                
            },
            new CityDto()
            {
                Id = 3,
                Name = "Paris",
                Description = "The one with that big tower",
                
            }
        };
    }

}
