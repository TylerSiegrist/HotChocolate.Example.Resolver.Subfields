using API.Models;
using Bogus;

namespace API.Features.Books;

[ObjectType<Book>]
public static partial class BookType
{
    private static Faker faker = new Faker();
    static partial void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Field(b => b.Author.Name).Resolve(ctx => faker.Person.FullName);
        descriptor.Field(b => b.Author.Age).Resolve(ctx => faker.Random.Int(13, 100));
    }
}
