// Func 型を使った場合
// Func<int, int> doubleFunc = x => 2 * x;
// Console.WriteLine($"{doubleFunc(5)}");

// Action 型を使った場合
Action<int> doubleAction = x => Console.WriteLine($"{2 * x}");
doubleAction(5);