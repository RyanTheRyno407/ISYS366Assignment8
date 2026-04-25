using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assignment8.Models;

namespace Assignment8.Data
{
    public class RazorPagesMovieContext : IdentityDbContext
    {
        public RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options) : base(options)
        {
        }

        public DbSet<Assignment8.Models.Movie> Movie { get; set; } = default!;
    }
}
