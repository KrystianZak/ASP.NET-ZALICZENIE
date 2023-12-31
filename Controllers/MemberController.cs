using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Models;

namespace LibrarySystem.Controllers
{
    public class MemberController : Controller
    {
        private List<Member> _members = new List<Member>(); // Symulacja bazy danych

        public IActionResult List()
        {
            return View(_members);
        }

        public IActionResult Add()
        {
            return View(new Member());
        }

        [HttpPost]
        public IActionResult Add(Member member)
        {
            if (ModelState.IsValid)
            {
                // Dodaj nowego członka do bazy danych (symulacja)
                member.Id = _members.Count + 1;
                _members.Add(member);
                return RedirectToAction("List");
            }

            // Jeśli ModelState nie jest prawidłowy, zwróć formularz z błędami
            return View(member);
        }

        public IActionResult Edit(int id)
        {
            // Pobierz członka do edycji
            var member = _members.FirstOrDefault(m => m.Id == id);

            if (member == null)
            {
                // Obsłuż sytuację, gdy członek nie istnieje
                ViewBag.ErrorMessage = "Członek nie został znaleziony.";
                return View("Error");
            }

            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                // Znajdź indeks członka w liście i zaktualizuj dane
                var existingMember = _members.FirstOrDefault(m => m.Id == member.Id);

                if (existingMember != null)
                {
                    existingMember.Name = member.Name;
                    existingMember.Email = member.Email;
                    // Inne właściwości

                    return RedirectToAction("List");
                }
            }

            // Jeśli ModelState nie jest prawidłowy, zwróć formularz z błędami
            return View(member);
        }

        public IActionResult Delete(int id)
        {
            // Pobierz członka do usunięcia
            var member = _members.FirstOrDefault(m => m.Id == id);

            if (member == null)
            {
                // Obsłuż sytuację, gdy członek nie istnieje
                ViewBag.ErrorMessage = "Członek nie został znaleziony.";
                return View("Error");
            }

            return View(member);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            // Znajdź indeks członka w liście i usuń
            var member = _members.FirstOrDefault(m => m.Id == id);

            if (member != null)
            {
                _members.Remove(member);
            }

            return RedirectToAction("List");
        }
    }
}
