using System.Security.Claims;
using Fina.Api.Common.Api;
using Fina.Core;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Api.Endpoints.Transactions;

public class GetTransactionsByPeriodEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Transactions: Get All")
            .WithSummary("Recupera todas as transações")
            .WithDescription("Recupera todas as transações")
            .WithOrder(5)
            .Produces<PagedResponse<List<Transaction>?>>();

    private static async Task<IResult> HandleAsync(
        ITransactionHandler handler,
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetTransactionsByPeriodRequest
        {
            UserId = ApiConfiguration.UserId,
            PageNumber = pageNumber,
            PageSize = pageSize,
            StartDate = startDate,
            EndDate = endDate
        };

        var result = await handler.GetByPeriodAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}