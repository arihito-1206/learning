namespace TransactionLab;

using Microsoft.Data.Sqlite;

public class PaymentService(SqliteConnection connection)
{
    public void CreatePayment(SqliteTransaction transaction)
    {
        var command = connection.CreateCommand();
        command.Transaction = transaction;
        command.CommandText = """
                                     INSERT INTO Payments (OrderId, Amount)
                                     VALUES (1, 20000);
                                     """;
        // わざと Exception
        throw new Exception("Payment failed!");
        command.ExecuteNonQuery();
        
        Console.WriteLine("Payment Inserted successfully");
        
    }
}