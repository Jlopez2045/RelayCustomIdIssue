
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType()
    .AddRelayCustomIdIssueTypes()
    .AddGlobalObjectIdentification();

var app = builder.Build();

app.MapGraphQL();
app.Run();
