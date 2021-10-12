using Microsoft.EntityFrameworkCore.Migrations;

namespace recipe_helper.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    Food = table.Column<string>(nullable: true),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Name", "Summary" },
                values: new object[] { 1, "Curry", "A yellow curry" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Name", "Summary" },
                values: new object[] { 2, "Vanilla Soy Milk Latte", "A three bean soup" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Name", "Summary" },
                values: new object[] { 3, "Pizza", "Popular Italish-American" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Amount", "Food", "RecipeId" },
                values: new object[,]
                {
                    { 1, 2, "tbs curry powder", 1 },
                    { 2, 5, "cups of rice", 1 },
                    { 3, 2, "pounds of chicken", 1 },
                    { 4, 1, "tsp of salt", 1 },
                    { 5, 1, "vanilla bean", 2 },
                    { 6, 3, "soy beans", 2 },
                    { 7, 68, "coffee beans", 2 },
                    { 8, 1, "cup of water", 2 },
                    { 9, 1, "frozen pizza", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
