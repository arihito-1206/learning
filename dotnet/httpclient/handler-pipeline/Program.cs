using HandlerPipelineExperiment;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddHttpClient("TrustApi")
    .AddHttpMessageHandler(_ => new ThrottlingHandler())
    .ConfigurePrimaryHttpMessageHandler(_ => new FakePrimaryHandler());

var serviceProvider = services.BuildServiceProvider();

var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
var client = httpClientFactory.CreateClient("TrustApi");


// Factory を使わず自分で Handler をセットする場合
// var client = new HttpClient(new ThrottlingHandler
// {
//     InnerHandler = new FakePrimaryHandler()
// });

const string dummyUrl = "http://localhost:5000/test";
var res1 = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, dummyUrl));
Console.WriteLine(res1.StatusCode);

var res2 = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, dummyUrl));
Console.WriteLine(res2.StatusCode);

var res3 = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, dummyUrl));
Console.WriteLine(res3.StatusCode);