using API.Models;
using Bogus;

namespace API.Features.Books;

public static class BookOperations
{
    private static Faker faker = new Faker();

    [Query]
    public static Book GetRandomBook()
    {
        return new Book(string.Join(' ', faker.Lorem.Words()));
    }
}
