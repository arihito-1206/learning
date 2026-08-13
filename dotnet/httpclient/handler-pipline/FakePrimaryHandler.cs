using System.Net;

namespace HandlerPipelineExperiment;

public class FakePrimaryHandler : HttpMessageHandler
{
    private int _counter = 0;

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (_counter == 0)
        {
            _counter++;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.TooManyRequests));
        }

        return Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
    }
}