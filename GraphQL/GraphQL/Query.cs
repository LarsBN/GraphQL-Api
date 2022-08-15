using GraphQL.Data;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace GraphQL.GraphQL
{

    [GraphQLDescription("Represents the queries available.")]
    public class Query
    {

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable platform.")]
        public IQueryable<Book> GetBook([ScopedService] AppDbContext context)
        {
            return context.Books;
        }


        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable author.")]
        public IQueryable<Author> GetAuthor([ScopedService] AppDbContext context)
        {
            return context.Authors;
        }


        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable author.")]
        public Author GetAuthor(int Id, AppDbContext context)
        {
            return context.Authors.FirstOrDefault(x => x.Id == Id);
        }
    }
}
