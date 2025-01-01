using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Services;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Collections.Specialized;


[Route("api/[controller]")]
[ApiController]
public class OrdersReportController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IPaymentService _paymentService;

    public OrdersReportController(IOrderService orderService, IPaymentService paymentService)
    {
        _orderService = orderService;
        _paymentService = paymentService;
    }

    [HttpGet("download-sales-report")]
    public IActionResult DownloadSalesReport([FromQuery] DateOnly startDate, [FromQuery] DateOnly endDate)
    {
        var orders = _orderService.GetByDateRange(startDate, endDate).ToList();
        decimal totalRevenue = 0;
        foreach (var order in orders)
        {
            var paymentAmount = _paymentService.GetByOrderId(order.Id).Amount;
            totalRevenue += paymentAmount;
        }


        byte[] pdf = GenerateSalesReport(startDate, endDate, orders, totalRevenue);

        return File(pdf, "application/pdf", "SalesReport.pdf");
    }


    private byte[] GenerateSalesReport(DateOnly startDate, DateOnly endDate, List<Order> orders, decimal totalRevenue)
    {
        using MemoryStream stream = new MemoryStream();
        // Initialize PDF writer
        PdfWriter writer = new PdfWriter(stream);
        PdfDocument pdf = new PdfDocument(writer);
        Document document = new Document(pdf);

        // Add title
        document.Add(new Paragraph("Sales Report")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(18)
            );

        document.Add(new Paragraph($"From: {startDate:yyyy-MM-dd} To: {endDate:yyyy-MM-dd}")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(12));

        // Add total revenue and orders
        document.Add(new Paragraph($"Total Revenue: ${totalRevenue:F2}")
            .SetTextAlignment(TextAlignment.LEFT)
            .SetFontSize(12));
        document.Add(new Paragraph($"Total Orders: {orders.Count}")
            .SetTextAlignment(TextAlignment.LEFT)
            .SetFontSize(12));

        // Add a table for orders
        Table table = new Table(new float[] { 1, 3, 3, 2, 2 });
        table.SetWidth(UnitValue.CreatePercentValue(100));

        table.AddHeaderCell("Order ID");
        table.AddHeaderCell("Client Name");
        table.AddHeaderCell("Date");
        table.AddHeaderCell("Total Amount");
        table.AddHeaderCell("Payment ID");

        foreach (var order in orders)
        {
            var orderPayment = _paymentService.GetByOrderId(order.Id);
            var orderPaymentAmount = orderPayment.Amount;
            table.AddCell(order.Id.ToString());
            // table.AddCell(order.Client?.Name ?? "N/A");
            table.AddCell(order.CreatedAt.ToString("yyyy-MM-dd"));
            table.AddCell($"${orderPaymentAmount:F2}");
            table.AddCell(orderPayment.Id.ToString());
        }

        document.Add(table);

        // Close document
        document.Close();

        return stream.ToArray();
    }
}