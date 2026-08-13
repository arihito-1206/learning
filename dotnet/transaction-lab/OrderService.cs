namespace TransactionLab;

using Microsoft.Data.Sqlite;

public class OrderService(SqliteConnection connection)
{
    public void CreateOrder(SqliteTransaction transaction)
    {
        var orderCommand = connection.CreateCommand();
        orderCommand.Transaction = transaction;
        orderCommand.CommandText = """
                                   INSERT INTO Orders (Name) VALUES ('Keyboard');
                                   """;

        orderCommand.ExecuteNonQuery();

        Console.WriteLine("Order Inserted successfully.");
    }
}