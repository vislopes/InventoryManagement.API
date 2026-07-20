using InventoryManagement.API.Exceptions;
using System.Text.Json;

namespace InventoryManagement.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";

            switch (ex)
            {
                case NotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;

                case ConflictException:
                    context.Response.StatusCode = StatusCodes.Status409Conflict; ;
                    break;

                case BusinessRuleException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;

                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }

}
