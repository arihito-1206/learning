namespace LambdaExtensionMethod;

internal class Options
{
    internal int Value { get; set; }
}

internal class Builder(Options options)
{
    internal void Configure(Action<Options> configure)
    {
        configure(options);
    }
}