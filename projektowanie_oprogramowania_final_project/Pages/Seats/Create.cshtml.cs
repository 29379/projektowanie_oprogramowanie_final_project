﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projektowanie_oprogramowania_final_project;
using projektowanie_oprogramowania_final_project.Models;

namespace projektowanie_oprogramowania_final_project.Pages.Seats
{
    [Authorize(Roles = "Admin, Employee")]
    public class CreateModel : PageModel
    {
        private readonly CinemaDbContext _context;

        public CreateModel(CinemaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? cinema_id)
        {
            ViewData["Cinemas"] = _context.Cinemas.ToList();
            ViewData["RoomId"] = new SelectList(_context.Rooms
                .Include(r => r.Cinema)
                .Where(r => r.CinemaId == cinema_id), "RoomId", null);
            return Page();
        }

        [BindProperty]
        public Seat Seat { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Seats.Add(Seat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
