using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Metrics;

var telemetryClient = new TelemetryClient();
var metric = telemetryClient.GetMetric("Publish message", "TenantId");

for (var i = 1; i <= 101; i++)
{
    var tenantId = $"tenantId1prod{i:000}dx";
    var accepted = metric.TrackValue(10, tenantId);
    
    Console.WriteLine($"{tenantId}: {accepted}");
}
