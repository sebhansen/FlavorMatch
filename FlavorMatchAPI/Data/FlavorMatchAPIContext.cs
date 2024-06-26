﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlavorMatch.Shared.Models;

    public class FlavorMatchAPIContext : DbContext
    {
        public FlavorMatchAPIContext (DbContextOptions<FlavorMatchAPIContext> options)
            : base(options)
        {
        }

        public DbSet<FlavorMatch.Shared.Models.Dishes> Dishes { get; set; } = default!;

public DbSet<FlavorMatch.Shared.Models.Ingredients> Ingredients { get; set; } = default!;
    }
