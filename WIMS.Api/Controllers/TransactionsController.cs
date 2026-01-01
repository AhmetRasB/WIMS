using Microsoft.AspNetCore.Mvc;
using WIMS.Application.Transactions.Commands.CreateTransaction;
using WIMS.Application.Transactions.Commands.DeleteTransaction;

namespace WIMS.Api.Controllers;
[ApiController]
[Route("api/transactions")]
public sealed class TransactionsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromServices] CreateTransactionHandler handler,
        [FromBody] CreateTransactionCommand command, CancellationToken ct)
    {
        var id = await handler.Handle(command, ct);
        return CreatedAtAction(nameof(Create), new { id }, new { id });
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        [FromServices] DeleteTransactionHandler handler,
        Guid id,
        CancellationToken ct)
    {
        var ok = await handler.Handle(new DeleteTransactionCommand(id), ct);
        return ok ? NoContent() : NotFound();
    }
}