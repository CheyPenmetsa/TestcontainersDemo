namespace ResidentApi.Models
{
    public record GetAllResidentsResponse(IEnumerable<GetResidentResponse> residents);
}
