using GraphQL.Data;
using GraphQL.GraphQL.Authors;
using GraphQL.GraphQL.Books;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using System.Threading.Tasks;

namespace GraphQL.GraphQL
{
    [GraphQLDescription("Represents the mutations available.")]
    public class Mutation
    {

        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Adds a book.")]
        public async Task<AddBookPayload> AddBookAsync(
            AddBookInput input,
            [ScopedService] AppDbContext context)
        {
            var book = new Book
            {
                Name = input.Name,
                Genre = input.Genre,
                AuthorId = input.authorId
            };

            context.Books.Add(book);
            await context.SaveChangesAsync();


            return new AddBookPayload(book);
        }


        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Adds a author.")]
        public async Task<AddAuthorPayload> AddAuthorAsync(AddAuthorInput input,
            [ScopedService] AppDbContext context)
        {
            var author = new Author
            {
                Name = input.Name,
                Age = input.Age
                //BookId = input.BookId
            };

            context.Authors.Add(author);
            await context.SaveChangesAsync();

            return new AddAuthorPayload(author);
        }
    }
}
