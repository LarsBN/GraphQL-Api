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
        public async Task<UpdateBookPayload> UpdateBookAsync(
                    UpdateBookInput input,
                    [ScopedService] AppDbContext context)
        {
            if (input.Name.Length!=0 && input.Name is null)
            {
                return null;
            }

            Book? book = await context.Books.FindAsync(input.id);

            if (book is null)
            {
                return null;
            }
            if (input.Genre.Length == 0)
            {
                return null;
            }

            if (input.Name.Length != 0)
            {
                book.Name = input.Name;
            }

            if (input.Genre.Length !=0)
            {
                book.Genre = input.Genre;
            }

            if (input.authorId == book.AuthorId)
            {
                book.AuthorId = input.authorId;
            }
            context.Books.Update(book);
            await context.SaveChangesAsync();

            return new UpdateBookPayload(book);
        }


        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddAuthorPayload> AddAuthorAsync(
            AddAuthorInput input,
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
        [UseDbContext(typeof(AppDbContext))]
        public async Task<UpdateAuthorPayload> UpdateAuthorAsync(
                    UpdateAuthorInput input,
                    [ScopedService] AppDbContext context)
        {
            if (input.Name.Length != 0 && input.Name is null)
            {
                return null;
            }

            Author? author = await context.Authors.FindAsync(input.id);

            if (author is null)
            {
                return null;
            }
            if (input.Age <= 0)
            {
                return null;
            }

            if (input.Name.Length != 0)
            {
                author.Name = input.Name;
            }

            if (input.id == author.Id)
            {
                author.Id = input.id;
            }
            context.Authors.Update(author);
            await context.SaveChangesAsync();

            return new UpdateAuthorPayload(author);
        }
    }
}
