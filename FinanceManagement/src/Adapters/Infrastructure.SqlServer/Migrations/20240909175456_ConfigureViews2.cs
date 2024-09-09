using Application.Contracts;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureViews2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                DROP VIEW IF EXISTS {nameof(ViewModel.CategoryViewModel)}
                GO
                CREATE VIEW {nameof(ViewModel.CategoryViewModel)} AS
                SELECT
                    c.BudgetId AS AccountId,
                    c.Name AS Name,
                    c.Limit AS Limit
                FROM
                    [Category] c
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DROP VIEW IF EXISTS {nameof(ViewModel.CategoryViewModel)}");
        }
    }
}
