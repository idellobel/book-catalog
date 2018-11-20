using AutoMapper;
using BookService.Models;

namespace BookService.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<Book, BookDetailDTO>();
                cfg.CreateMap<Author, AuthorDTO>();
                //cfg.CreateMap<Author, BookDetailDTO>();
                cfg.CreateMap<BookDetailDTO, Book>();
                cfg.CreateMap<AuthorDTO, Author>();
            });
        }
    }
}