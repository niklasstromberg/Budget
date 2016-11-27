using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Budget.Models;

namespace Budget.Migrations
{
    [DbContext(typeof(BudgetContext))]
    [Migration("20160613120401_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("Budget.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryId");
                });

            modelBuilder.Entity("Budget.Models.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Notes");

                    b.Property<int>("PersonId");

                    b.Property<int>("RecipientId");

                    b.HasKey("ExpenseId");
                });

            modelBuilder.Entity("Budget.Models.Household", b =>
                {
                    b.Property<int>("HouseholdId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HouseholdName");

                    b.HasKey("HouseholdId");
                });

            modelBuilder.Entity("Budget.Models.Income", b =>
                {
                    b.Property<int>("IncomeId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<string>("IncomeDescription");

                    b.Property<int>("PersonId");

                    b.HasKey("IncomeId");
                });

            modelBuilder.Entity("Budget.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("HouseholdHouseholdId");

                    b.Property<int?>("HouseholdHouseholdId1");

                    b.Property<string>("Name");

                    b.HasKey("PersonId");
                });

            modelBuilder.Entity("Budget.Models.Recipient", b =>
                {
                    b.Property<int>("RecipientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RecipientName");

                    b.HasKey("RecipientId");
                });

            modelBuilder.Entity("Budget.Models.Expense", b =>
                {
                    b.HasOne("Budget.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Budget.Models.Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("Budget.Models.Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId");
                });

            modelBuilder.Entity("Budget.Models.Income", b =>
                {
                    b.HasOne("Budget.Models.Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Budget.Models.Person", b =>
                {
                    b.HasOne("Budget.Models.Household")
                        .WithMany()
                        .HasForeignKey("HouseholdHouseholdId");

                    b.HasOne("Budget.Models.Household")
                        .WithMany()
                        .HasForeignKey("HouseholdHouseholdId1");
                });
        }
    }
}
