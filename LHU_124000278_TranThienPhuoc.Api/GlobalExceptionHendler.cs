using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace LHU_124000278_TranThienPhuoc.Api
{
    public class GlobalExceptionHendler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHendler> _logger;
        public GlobalExceptionHendler(ILogger<GlobalExceptionHendler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpcontext, Exception exception, CancellationToken ct)
        {
            _logger.LogError(exception, "Ngoại lệ: {Msg}", exception.Message);
            var problemDetails = new ProblemDetails
            {
                Instance = httpcontext.Request.Path,
                Status = exception switch
                {
                    KeyNotFoundException => StatusCodes.Status404NotFound,
                    ArgumentException or ArgumentNullException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError
                },
                Title = exception switch
                {
                    KeyNotFoundException => "Không tìm thấy tài nguyên",
                    ArgumentException or ArgumentNullException 
                     => "Yêu cầu không hợp lệ",
                    _ => "Lỗi máy chủ nội bộ"
                },
                Detail = exception.Message
            };
            httpcontext.Response.StatusCode = problemDetails.Status.Value;
            await httpcontext.Response.WriteAsJsonAsync(problemDetails, cancellationToken: ct);
            return true;
        }
    }
}
