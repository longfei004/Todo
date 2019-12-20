using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Todo.Data;
using Todo.Models;

namespace Todo.Pages.TodoList
{
    public class CreateModel : PageModel
    {
        private readonly Todo.Data.TodoContext _context;

        public CreateModel(Todo.Data.TodoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TodoItem TodoItem { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TodoItems.Add(TodoItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
