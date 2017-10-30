﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyToDoList.Entities;

namespace MyToDoList.DbContexts
{
    public class MyToDoListDbContext:DbContext
    {
        public MyToDoListDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Duty> Duties { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}