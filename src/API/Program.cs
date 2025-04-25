var builder = WebApplication.CreateBuilder(args);

builder.AddGraphQL().AddAPITypes();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.MapGraphQL();

app.Run();