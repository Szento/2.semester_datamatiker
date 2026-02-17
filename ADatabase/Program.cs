using Microsoft.Extensions.Configuration;

public class CarRepository
{
    private readonly string ConnectionString; 
    private List<Car> cars; 
    public CarRepository() { 
        IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); 
        cars = new List<Car>(); 
        ConnectionString = config.GetConnectionString("MyDBConnection"); 
    } 
    // Relevante CRUD-metoder indsættes her

}