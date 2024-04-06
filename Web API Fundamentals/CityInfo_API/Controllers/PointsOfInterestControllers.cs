using CityInfo_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.JsonPatch;
using CityInfo_API.Sercices;

namespace CityInfo_API.Controllers;

[Route("api/cities/{cityId}/pointsofinterest")]
[ApiController]
public class PointsOfInterestControllers : ControllerBase
{

    private readonly ILogger<PointsOfInterestControllers> _logger;

    public PointsOfInterestControllers(ILogger<PointsOfInterestControllers> logger, LocalMailService localMailService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //_loggerMailService = localMailService ?? throw new ArgumentNullException(nameof(localMailService));
    }

    [HttpGet]
    public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
    {
        try
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                _logger.LogInformation($"City with id {cityId} wasn't found when accessing points of interest.");
                return NotFound();
            }

            return Ok(city.PointsOfInterest);
        }
        catch (Exception ex)
        {
            _logger.LogCritical($"Exception while getting points of interest for city with id {cityId}.", ex);
            return StatusCode(500, "A problem happened while handling your request.");
        }
    }

    [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]

    [HttpPost]

    public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, PointOfInterestForCreationDto pointOfInterest)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
        if (city == null)
        {
            return NotFound();
        }

        var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

        var finalPointOfInterest = new PointOfInterestDto()
        {
            Id = ++maxPointOfInterestId,
            Name = pointOfInterest.Name,
            Description = pointOfInterest.Description
        };
        city.PointsOfInterest.Add(finalPointOfInterest);

        return CreatedAtRoute("GetPointOfInterest",

            new
            {
                cityId = cityId,
                pointOfInterestId = finalPointOfInterest.Id
            },
            finalPointOfInterest);

    }

    [HttpPutAttribute("{pointOfInterestId}")]

    public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterest, PointOfInterestForUpdateDto pointOfInterest)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
        if (city == null)
        {
            return NotFound();
        }

        var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterest);
        if (pointOfInterestFromStore == null)
        {
            return NotFound();
        }

        pointOfInterestFromStore.Name = pointOfInterest.Name;
        pointOfInterestFromStore.Description = pointOfInterest.Description;

        return NoContent();
    }


    pointOfInterestFromStore.Name = pointOfInterest.Name;
    pointOfInterestFromStore.Description = pointOfInterest.Description;

    return NoContent();


    [HttpPatch("{pointOfInterestId}")]

    public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId,
    JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
        if (city == null)
        {
            return NotFound();
        }
        var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);

        if (pointOfInterestFromStore == null)
        {
            return NotFound();
        }

        var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
        {
            Name = pointOfInterestFromStore.Name,
            Description = pointOfInterestFromStore.Description
        };

        using Microsoft.AspNetCore.Mvc; // Add this using directive

        patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!TryValidateModel(pointOfInterestToPatch))
        {
            return BadRequest(ModelState);
        }

        pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
        pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

        return NoContent();

    }
}