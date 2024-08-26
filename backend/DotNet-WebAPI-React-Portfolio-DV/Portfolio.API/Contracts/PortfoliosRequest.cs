namespace Portfolio.API.Contracts
{
    public record PortfoliosRequest(
       int Id,
       string Name,
       string Surname,
       string Description);
}
