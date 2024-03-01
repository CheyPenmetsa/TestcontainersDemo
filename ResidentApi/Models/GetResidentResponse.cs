namespace ResidentApi.Models
{
    public record GetResidentResponse(Guid Id, string firstName, string lastName, int Age);
}
