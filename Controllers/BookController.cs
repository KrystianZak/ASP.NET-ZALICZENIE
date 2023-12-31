using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace LibrarySystem.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> _books = new List<Book>();

        public ActionResult List()
        {
            return View(_books);
        }

        public ActionResult Add()
        {
            return View(new Book());
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                // Dodaj nową książkę do bazy danych (symulacja)
                book.Id = _books.Count + 1;
                _books.Add(book);
                return RedirectToAction("List");
            }

            // Jeśli ModelState nie jest prawidłowy, zwróć formularz z błędami
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            // Pobierz książkę do edycji
            var book = _books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                // Obsłuż sytuację, gdy książka nie istnieje
                ViewBag.ErrorMessage = "Książka nie została znaleziona.";
                return View("Error");
            }

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                // Znajdź indeks książki w liście i zaktualizuj dane
                var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);

                if (existingBook != null)
                {
                    existingBook.Title = book.Title;
                    existingBook.Author = book.Author;
                    existingBook.PublicationYear = book.PublicationYear;
                    existingBook.Description = book.Description;
                    existingBook.Categories = book.Categories;

                    return RedirectToAction("List");
                }
            }

            // Jeśli ModelState nie jest prawidłowy, zwróć formularz z błędami
            return View(book);
        }

        public ActionResult Delete(int id)
        {
            // Pobierz książkę do usunięcia
            var book = _books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                // Obsłuż sytuację, gdy książka nie istnieje
                ViewBag.ErrorMessage = "Książka nie została znaleziona.";
                return View("Error");
            }

            return View(book);
        }

        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult ConfirmDelete(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                _books.Remove(book);
            }

            return RedirectToAction("List");
        }

    }
}
