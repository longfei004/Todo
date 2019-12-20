using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Models;

namespace Todo.Pages.TodoList
{
    public class DetailsModel : PageModel
    {
        private readonly Todo.Data.TodoContext _context;

        public DetailsModel(Todo.Data.TodoContext context)
        {
            _context = context;
        }

        public TodoItem TodoItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TodoItem = await _context.TodoItems.FirstOrDefaultAsync(m => m.ID == id);

            if (TodoItem == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
