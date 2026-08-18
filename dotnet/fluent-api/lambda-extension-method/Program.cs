// Func 型を使った場合
// Func<int, int> doubleFunc = x => 2 * x;
// Console.WriteLine($"{doubleFunc(5)}");

// Action 型を使った場合

using LambdaExtensionMethod;

Action<int> doubleAction = x => Console.WriteLine($"{2 * x}");
doubleAction(5);

// 拡張メソッドの練習
Console.WriteLine("5.Double() の結果: {0}", 5.Double());
Console.WriteLine("5.Apply(x => x * x) の結果: {0}", 5.Apply(x => x * x));
Console.WriteLine("5.Double().Apply(x => x * x) の結果: {0}", 5.Double().Apply(x => x * x));

var options = new Options();
var builder = new Builder(options);
builder.Configure(opt => opt.Value = 500);
var result = builder.BuildWith(b => b.CreateResult());

Console.WriteLine("option.Value = " + options.Value);
Console.WriteLine("result.Value = " + result.Value);

internal static class IntExtensions
{
    public static int Double(this int i) => i * 2;

    public static int Apply(this int i, Func<int, int> func) => func(i);
}