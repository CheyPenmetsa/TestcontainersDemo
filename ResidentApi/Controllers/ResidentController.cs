using Microsoft.AspNetCore.Mvc;
using ResidentApi.Logic.Domain;
using ResidentApi.Logic.Repositories;
using ResidentApi.Models;

namespace ResidentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentController : ControllerBase
    {
        private readonly IResidentRepository _residentRepository;

        public ResidentController(IResidentRepository residentRepository)
        {
            _residentRepository = residentRepository;
        }

        [HttpPost("CreateResident")]
        public async Task<ActionResult<GetResidentResponse>> CreateResidentAsync(CreateResidentRequest request)
        {
            var resident = new Resident(request.firstName, request.lastName, request.age);

            await _residentRepository.CreateResidentAsync(resident);

            var residentResponse = new GetResidentResponse(
                resident.Id,
                resident.FirstName,
                resident.LastName,
                resident.Age);

                return CreatedAtAction(
                    "GetResident",
                    new { id = residentResponse.Id },
                    residentResponse);
        }

        [HttpDelete("DeleteResident/{id}")]
        public async Task<ActionResult> DeleteCatAsync(Guid id)
        {
            await _residentRepository.DeleteResidentAsync(id);
            return Ok();
        }

        [HttpGet("GetResident/{id}")]
        public async Task<ActionResult<GetResidentResponse>> GetResidentAsync(Guid id)
        {
            var resident = await _residentRepository.GetResidentByIdAsync(id);

            if (resident is null)
            {
                return NotFound();
            }

            var residentResponse = new GetResidentResponse(
                resident.Id,
                resident.FirstName,
                resident.LastName,
                resident.Age);

            return Ok(residentResponse);
        }

        [HttpGet("GetAllResidents")]
        public async Task<ActionResult<GetAllResidentsResponse>> GetAllCatsAsync()
        {
            var residents = await _residentRepository.GetAllResidentsAsync();
            var residentResps = new List<GetResidentResponse>();

            foreach (var resident in residents)
            {
                residentResps.Add(
                    new GetResidentResponse(
                        resident.Id,
                        resident.FirstName,
                        resident.LastName,
                        resident.Age));
            }

            var allResResponse = new GetAllResidentsResponse(residentResps);

            return Ok(allResResponse);
        }

        [HttpPut("UpdateResident")]
        public async Task<ActionResult<GetResidentResponse>> UpdateResidentAsync(UpdateResidentRequest request)
        {
            var resident = new Resident(request.firstName, request.lastName, request.age);

            await _residentRepository.UpdateResidentAsync(resident);

            var residentResponse = new GetResidentResponse(
                resident.Id,
                resident.FirstName,
                resident.LastName,
                resident.Age);

            return Ok(residentResponse);
        }
    }
}
