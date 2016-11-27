﻿using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Models
{
    class BudgetContext : DbContext
    {
        public DbSet<Household> Households { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipient> Recipients { get; set; }

        static BudgetContext()
        {
            using (var database = new BudgetContext())
            {
                database.Database.Migrate();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(Path.Combine(DatabaseManager.path, "Filename=Budget.db"));

            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "Budget.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Household
            modelBuilder.Entity<Household>()
                .HasMany<Person>();
                
            // Person
            modelBuilder.Entity<Person>()
                .Property(p => p.PersonId)
                .IsRequired();

            // Income
            modelBuilder.Entity<Income>()
                .Property(p => p.IncomeId)
                .IsRequired();
        }
    }
}