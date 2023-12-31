using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Display(Name = "Membership Start Date")]
        [DataType(DataType.Date)]
        public DateTime MembershipStartDate { get; set; }

        [Display(Name = "Membership End Date")]
        [DataType(DataType.Date)]
        public DateTime MembershipEndDate { get; set; }

        public bool IsActive
        {
            get { return DateTime.Now >= MembershipStartDate && DateTime.Now <= MembershipEndDate; }
        }

        public List<Book> CheckedOutBooks { get; set; }

        // Inne właściwości i metody

        public void CheckOutBook(Book book)
        {
            if (CheckedOutBooks == null)
            {
                CheckedOutBooks = new List<Book>();
            }

            CheckedOutBooks.Add(book);
        }

        public void ReturnBook(Book book)
        {
            CheckedOutBooks?.Remove(book);
        }
    }
}
