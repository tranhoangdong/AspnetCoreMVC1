using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Web.Models;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace eShopSolution.Web.Controllers
{
    public class AdminOrderController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IConverter _converter;
        public AdminOrderController(IOrderDetailService orderDetailService, IConverter converter)
        {
            _orderDetailService = orderDetailService;
            _converter = converter;
        }
        public IActionResult LoadOrder(int idban, int idOrder, string statusOrder, DateTime? startDate, DateTime? endDate)
        {
            var getOrderDTO = new OrderRequestDto
            {
                BanId = idban,
                OrderId = idOrder,
                OrderStatus = statusOrder,
                StartDate = startDate,
                EndDate = endDate
            };
            var orders = _orderDetailService.GetAllOrders(getOrderDTO);
            var orderViewModels = orders.Select(o => new OrderIndexViewModel
            {
                Id = o.Id,
                RoomAndTableId = o.RoomAndTableId,
                TotalAmount = o.TotalAmount,
                OrderTime = o.OrderTime, 
                IsPaid = o.IsPaid
            }).ToList();
            return PartialView("_IndexPartial", orderViewModels);
        }
        public IActionResult Index(int idban, int idOrder)
        {
            return View();
        }

        [HttpPost]
        public IActionResult PayOrder(int id)
        {
            _orderDetailService.PayOrder(id); 
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult OrderDetails(int orderId)
        {
            var orderDetails = _orderDetailService.OrderDetails(orderId);
            var getorderDetailViewModels = orderDetails.Select(od => new GetOrderDetailsViewmodel
            {
                Id = od.Id,
                ProductId = od.ProductId,
                Quantity = od.Quantity,
                Price = od.Price,
                Total = od.Total
            }).ToList();

            return PartialView("_OrderDetailsPartial", getorderDetailViewModels);
        }
        public IActionResult ExportOrderDetailsToWord(int orderId)
        {
            var orderDetails = _orderDetailService.GetOrderDetailsByOrderId(orderId);

            using (var memoryStream = new MemoryStream())
            {
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(
                    memoryStream,
                    DocumentFormat.OpenXml.WordprocessingDocumentType.Document,
                    true))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    // Tiêu đề đẹp
                    Run headingRun = new Run(new Text("CHI TIẾT HÓA ĐƠN"));
                    headingRun.RunProperties = new RunProperties(
                        new Bold(),
                        new FontSize() { Val = "28" } // Font 14pt
                    );
                    Paragraph heading = new Paragraph(headingRun)
                    {
                        ParagraphProperties = new ParagraphProperties(
                            new Justification() { Val = JustificationValues.Center }
                        )
                    };
                    body.AppendChild(heading);

                    body.AppendChild(new Paragraph(new Run(new Text("")))); // dòng trống

                    // Tạo bảng
                    Table table = new Table();

                    // Thêm viền cho bảng
                    TableProperties tableProperties = new TableProperties(
                        new TableBorders(
                            new TopBorder { Val = BorderValues.Single, Size = 4 },
                            new BottomBorder { Val = BorderValues.Single, Size = 4 },
                            new LeftBorder { Val = BorderValues.Single, Size = 4 },
                            new RightBorder { Val = BorderValues.Single, Size = 4 },
                            new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4 },
                            new InsideVerticalBorder { Val = BorderValues.Single, Size = 4 }
                        )
                    );
                    table.AppendChild(tableProperties);

                    // Hàng tiêu đề
                    TableRow headerRow = new TableRow();
                    headerRow.Append(
                        CreateCell("Mã sản phẩm", true),
                        CreateCell("Số lượng", true),
                        CreateCell("Giá", true),
                        CreateCell("Tổng", true),
                        CreateCell("Bàn", true),
                        CreateCell("Tổng tiền", true),
                        CreateCell("Thời gian đặt", true)
                    );
                    table.AppendChild(headerRow);

                    // Dữ liệu
                    foreach (var detail in orderDetails)
                    {
                        TableRow row = new TableRow();
                        row.Append(
                            CreateCell(detail.ProductId.ToString()),
                            CreateCell(detail.Quantity.ToString()),
                            CreateCell(detail.Price.ToString("#,##0") + " ₫"),
                            CreateCell(detail.Total.ToString("#,##0") + " ₫"),
                            CreateCell(detail.RoomAndTableID.ToString()),
                            CreateCell(detail.TotalAmount.ToString("#,##0") + " ₫"),
                            CreateCell(detail.OrderTime.ToString("dd/MM/yyyy HH:mm"))
                        );
                        table.AppendChild(row);
                    }

                    body.AppendChild(table);
                    mainPart.Document.Save();
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
                return File(memoryStream.ToArray(),
                    "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    "ChiTietHoaDon.docx");
            }
        }


        private TableCell CreateCell(string text, bool isBold = false)
        {
            Run run = new Run(new Text(text ?? ""));
            if (isBold)
            {
                run.RunProperties = new RunProperties(new Bold());
            }

            Paragraph paragraph = new Paragraph(run)
            {
                ParagraphProperties = new ParagraphProperties(
                    new Justification() { Val = JustificationValues.Center }
                )
            };

            return new TableCell(paragraph);
        }

        public IActionResult ExportOrderDetailsToPdf(int orderId)
        {
            var orderDetails = _orderDetailService.GetOrderDetailsByOrderId(orderId);
            var htmlContent = $@"
            <html>
                <head><title>Chi tiết đơn hàng</title></head>
                <body>
                    <h2>Chi tiết đơn hàng #{orderId}</h2>
                    <table>
                        <tr>
                            <th>Sản phẩm</th>
                            <th>Số lượng</th>
                            <th>Giá</th>
                            <th>Tổng</th>
                        </tr>
                        {string.Join("", orderDetails.Select(d => $@"
                            <tr>
                                <td>{d.ProductId}</td>
                                <td>{d.Quantity}</td>
                                <td>{d.Price}</td>
                                <td>{d.Total}</td>
                            </tr>"))}
                    </table>
                </body>
            </html>";

            var pdfDoc = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,
                },
                Objects = {
                new ObjectSettings
                {
                    HtmlContent = htmlContent,
                    WebSettings = { DefaultEncoding = "utf-8" }
                }
            }
            };

            var pdf = _converter.Convert(pdfDoc);
            return File(pdf, "application/pdf", $"ChiTietDonHang_{orderId}.pdf");
        }
    }
}
