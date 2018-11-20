using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookService.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace BookService.Controllers
{
    public class BooksController : ApiController
    {
        private BookServiceContext db = new BookServiceContext();

        // GET: api/Books
        public IQueryable<BookDTO> GetBooks()
        {  
            var books = db.Books.ProjectTo<BookDTO>();
            return books;
        }

        // GET: api/Books/5
        [ResponseType(typeof(BookDetailDTO))]
        public async Task<IHttpActionResult> GetBook(int id)
        {  
            var book = await db.Books
                .ProjectTo<BookDetailDTO>().SingleOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }


        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBook(int id, BookDetailDTO bookDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Book book = Mapper.Map<Book>(bookDetailDTO);
            db.Set<Book>().Attach(book); // voor update
            db.Entry(book).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return Ok(bookDetailDTO);

        }


        // POST: api/Books
        [ResponseType(typeof(BookDetailDTO))]
        public async Task<IHttpActionResult> PostBook(BookDetailDTO bookDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Book book = Mapper.Map<Book>(bookDetailDTO);
            db.Books.Add(book);
            await db.SaveChangesAsync();

            // Id naar DTO wegschrijven
            bookDetailDTO.Id = book.Id;

            return Ok(bookDetailDTO);
        }



        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }
    }
}