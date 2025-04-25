using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace API.Tests.Tests.Foos;

public class BookOperationTests : IAsyncLifetime
{
    private IRequestExecutor requestExecutor;
    private const string bookQuery =
    """
    query {
        randomBook {
          name
          author {
            name
            age
          }
        }
    }
    """;

    public async Task InitializeAsync()
    {
        requestExecutor = await new ServiceCollection().AddGraphQL().AddAPITypes().BuildRequestExecutorAsync();
    }

    [Fact]
    public async Task GetBook_AuthorPropertiesSet()
    {
        // ACT
        var result = await requestExecutor.ExecuteAsync(bookQuery);
        var json = JsonNode.Parse(result.ToJson());

        // ASSERT
        Assert.NotNull(json!["data"]!["randomBook"]!["name"]); // Book has a name!
        Assert.NotNull(json!["data"]!["randomBook"]!["author"]!["name"]); // Author name is null :(
        Assert.NotNull(json!["data"]!["randomBook"]!["author"]!["age"]); // Author age is null :(
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}
