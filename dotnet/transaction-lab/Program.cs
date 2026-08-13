using Microsoft.Data.Sqlite;

var connection = new SqliteConnection("Data Source=transaction.db");
connection.Open();

var createCommand = connection.CreateCommand();
createCommand.CommandText = """
                            CREATE TABLE IF NOT EXISTS Orders (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Name TEXT NOT NULL
                            );

                            CREATE TABLE IF NOT EXISTS Payments (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                OrderId INTEGER NOT NULL,
                                Amount INTEGER NOT NULL
                            );
                            """;

createCommand.ExecuteNonQuery();

Console.WriteLine("Tables created successfully.");

var transaction = connection.BeginTransaction();
try
{
    var orderCommand = connection.CreateCommand();
    orderCommand.Transaction = transaction;
    orderCommand.CommandText = """
                               INSERT INTO Orders (Name) VALUES ('Keyboard');
                               """;

    orderCommand.ExecuteNonQuery();

    Console.WriteLine("Order Inserted successfully.");

    throw new Exception("Something went Wrong");

    // 未到達
    var paymentCommand = connection.CreateCommand();
    paymentCommand.Transaction = transaction;
    paymentCommand.CommandText = """
                                 INSERT INTO PAayments (OrderId, Amount)
                                 VALUES (1, 20000);
                                 """;
    paymentCommand.ExecuteNonQuery();
    transaction.Commit();
    
}
catch (Exception e)
{ 
    Console.WriteLine("例外発生");
    Console.WriteLine(e);
    transaction.Rollback();
    throw;
}

