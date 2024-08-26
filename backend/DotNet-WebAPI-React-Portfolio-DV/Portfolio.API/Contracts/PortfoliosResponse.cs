namespace Portfolio.API.Contracts
{
    public record PortfoliosResponse(
        int Id,
        string Name,
        string Surname,
        string Description);
}