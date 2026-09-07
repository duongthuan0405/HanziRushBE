using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Infrastructure.Data
{
    public class HanziRushDbContext : DbContext
    {
        public HanziRushDbContext(DbContextOptions<HanziRushDbContext> options) : base(options)
        {
        }
    }
}
