DelegateFunc doubleFunc = x => 2 * x;

Console.WriteLine($"{doubleFunc(5)}");

internal delegate int DelegateFunc(int x);