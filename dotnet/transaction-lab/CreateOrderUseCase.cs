namespace TransactionLab;

using Microsoft.Data.Sqlite;

public class CreateOrderUseCase(SqliteConnection connection, OrderService orderService, PaymentService paymentService)
{
    public void Execute()
    {
        using var transaction = connection.BeginTransaction();

        try
        {
            orderService.CreateOrder(transaction);
            paymentService.CreatePayment(transaction);

            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw;
        }
    }
}