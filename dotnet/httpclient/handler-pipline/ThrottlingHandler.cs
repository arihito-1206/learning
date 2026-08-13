namespace HandlerPipelineExperiment;

public class ThrottlingHandler : DelegatingHandler
{
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        await _semaphore.WaitAsync(cancellationToken);
        Console.WriteLine("ロックを取得");
        try
        {
            return await base.SendAsync(request, cancellationToken);
        }
        finally
        {
            Console.WriteLine("ロックを解放");
            _semaphore.Release();
        }
    }
}