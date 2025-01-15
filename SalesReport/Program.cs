// SalesReport/Program.cs
using System.Text;

public class SalesReportGenerator
{
    public static async Task GenerateSalesSummaryReport(string[] salesFiles, string outputPath)
    {
        var report = new StringBuilder();
        decimal totalSales = 0m;
        
        // Add header
        report.AppendLine("Sales Summary");
        report.AppendLine("----------------------------");
        
        // Process each sales file
        foreach (var file in salesFiles)
        {
            if (File.Exists(file))
            {
                var fileContent = await File.ReadAllTextAsync(file);
                if (decimal.TryParse(fileContent, out decimal saleAmount))
                {
                    totalSales += saleAmount;
                    report.AppendLine($"  {Path.GetFileName(file)}: {saleAmount:C}");
                }
            }
        }
        
        // Insert total sales after header
        report.Insert(report.ToString().IndexOf("----------------------------") + 29,
            $" Total Sales: {totalSales:C}\n\n Details:\n");
        
        // Write report to file
        await File.WriteAllTextAsync(outputPath, report.ToString());
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        // Create sample sales files
        Directory.CreateDirectory("sales");
        await File.WriteAllTextAsync("sales/day1.txt", "5434.56");
        await File.WriteAllTextAsync("sales/day2.txt", "3345.74");
        await File.WriteAllTextAsync("sales/day3.txt", "8456.25");

        // Generate report
        string[] salesFiles = Directory.GetFiles("sales", "*.txt");
        await SalesReportGenerator.GenerateSalesSummaryReport(salesFiles, "sales_summary.txt");
        
        Console.WriteLine("Report generated successfully!");
        Console.WriteLine("\nReport contents:");
        Console.WriteLine(await File.ReadAllTextAsync("sales_summary.txt"));
    }
}