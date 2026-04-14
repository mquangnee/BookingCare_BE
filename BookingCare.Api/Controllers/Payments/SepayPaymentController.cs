using BookingCare.Application.Services;
using BookingCare.Domain.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Api.Controllers.Payments
{
    [ApiController]
    [Route("api/payments/sepay")]
    public class SepayPaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISepayService _sepayService;

        public SepayPaymentController(IUnitOfWork unitOfWork, ISepayService sepayService)
        {
            _unitOfWork = unitOfWork;
            _sepayService = sepayService;
        }

        [HttpGet("checkout/{paymentId:guid}")]
        public async Task<IActionResult> CreateCheckout(Guid paymentId, CancellationToken cancellationToken)
        {
            var payment = await _unitOfWork.Payments.QueryableAsync()
                .Include(p => p.Appointment)
                .FirstOrDefaultAsync(p => p.Id == paymentId, cancellationToken);

            if (payment == null || payment.Appointment == null)
            {
                return NotFound(new { success = false, message = "Payment not found" });
            }

            var result = await _sepayService.CreateCheckoutAsync(payment, payment.Appointment);

            return Ok(new
            {
                success = true,
                message = "Create checkout successfully",
                data = result
            });
        }

        [HttpGet("success")]
        [AllowAnonymous]
        public async Task<IActionResult> Success([FromQuery(Name = "order_id")] string? orderId, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(orderId))
            {
                await _sepayService.VerifyPaidOrderAndUpdateAsync(orderId, cancellationToken);
            }

            return Redirect("http://localhost:5173/payment-result?status=success");
        }

        [HttpGet("error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            return Redirect("http://localhost:5173/payment/error");
        }

        [HttpGet("cancel")]
        [AllowAnonymous]
        public IActionResult Cancel()
        {
            return Redirect("http://localhost:5173/payment/cancel");
        }

        [HttpGet("verify/{orderId}")]
        public async Task<IActionResult> VerifyOrder(string orderId, CancellationToken cancellationToken)
        {
            var result = await _sepayService.GetOrderDetailAsync(orderId, cancellationToken);

            return Ok(new
            {
                success = true,
                data = result
            });
        }
    }
}
