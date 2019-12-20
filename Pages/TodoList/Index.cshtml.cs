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
    public class IndexModel : PageModel
    {
        private readonly Todo.Data.TodoContext _context;

        public IndexModel(Todo.Data.TodoContext context)
        {
            _context = context;
        }

        public IList<TodoItem> TodoItem { get;set; }

        [BindProperty (SupportsGet = true)]
        public string SearchContent { get; set; }

        public async Task OnGetAsync()
        {
            var TodoList = from t in _context.TodoItems
                           select t;

            if(!string.IsNullOrEmpty(SearchContent))
            {
                TodoList = TodoList.Where(s => s.Content.Contains(SearchContent));
            }

            TodoItem = await TodoList.ToListAsync();
        }
    }
}
