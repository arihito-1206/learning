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

    internal Result BuildWith(Func<Builder, Result> factory) => factory(this);

    internal Result CreateResult() => new() { Value = options.Value };
}

internal class Result
{
    internal int Value { get; set; }
}