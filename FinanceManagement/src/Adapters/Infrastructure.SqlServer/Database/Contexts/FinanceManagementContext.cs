﻿using Application.Contracts;
using Domain.Modules.Accounts.Aggregates;
using Domain.Modules.Accounts.Entities.Profile;
using Domain.Modules.Accounts.ValueObjects.Address;
using Domain.Modules.Budgets.Aggregates;
using Domain.Modules.Budgets.ValueObjects.Categories;
using Domain.Modules.Budgets.ValueObjects.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Database.Contexts;

public class FinanceManagementContext : DbContext
{
    #region Account
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    #endregion

    #region Budget
    public DbSet<Budget> Budgets { get; set; }
    public DbSet<Category> Categories { get; set; }
    #endregion

    #region Views
    public DbSet<ViewModel.BalanceViewModel> BalanceViewModel { get; set; }
    public DbSet<ViewModel.CategoryViewModel> CategoryViewModel { get; set; }
    public DbSet<ViewModel.TransactionViewModel> TransactionViewModel { get; set; }
    #endregion

    public FinanceManagementContext(DbContextOptions options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.Entity<ViewModel.BalanceViewModel>().HasNoKey().ToView(nameof(ViewModel.BalanceViewModel));
        modelBuilder.Entity<ViewModel.CategoryViewModel>().HasNoKey().ToView(nameof(ViewModel.CategoryViewModel));
        modelBuilder.Entity<ViewModel.TransactionViewModel>().HasNoKey().ToView(nameof(ViewModel.TransactionViewModel));
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        => configurationBuilder
            .Properties<string>()
            .AreUnicode(false)
            .HaveMaxLength(1024);
}
