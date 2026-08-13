using Microsoft.Data.Sqlite;
using TransactionLab;

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

var orderService = new OrderService(connection);
var paymentService = new PaymentService(connection);

var useCase = new CreateOrderUseCase(connection, orderService, paymentService);
useCase.Execute();