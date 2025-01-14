namespace PizzaStore.Services;

public class SalesReportService
{
    private readonly string _salesDirectory;

    public SalesReportService(IConfiguration configuration)
    {
        _salesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data", "sales_data");
        Directory.CreateDirectory(_salesDirectory);
    }

    public async Task GenerateReport(string outputPath)
    {
        // Implementación del reporte de ventas aquí
        // Puedes usar el código del SalesReportGenerator que proporcioné anteriormente
    }
}