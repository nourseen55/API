using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_Products_ProductId",
                table: "WishlistItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_WishLists_WishlistId",
                table: "WishlistItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishlistItems",
                table: "WishlistItems");

            migrationBuilder.RenameTable(
                name: "WishlistItems",
                newName: "wishlistItems");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItems_WishlistId",
                table: "wishlistItems",
                newName: "IX_wishlistItems_WishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItems_ProductId",
                table: "wishlistItems",
                newName: "IX_wishlistItems_ProductId");

            migrationBuilder.AddColumn<bool>(
                name: "IsInCart",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_wishlistItems",
                table: "wishlistItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_wishlistItems_Products_ProductId",
                table: "wishlistItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wishlistItems_WishLists_WishlistId",
                table: "wishlistItems",
                column: "WishlistId",
                principalTable: "WishLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wishlistItems_Products_ProductId",
                table: "wishlistItems");

            migrationBuilder.DropForeignKey(
                name: "FK_wishlistItems_WishLists_WishlistId",
                table: "wishlistItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_wishlistItems",
                table: "wishlistItems");

            migrationBuilder.DropColumn(
                name: "IsInCart",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "wishlistItems",
                newName: "WishlistItems");

            migrationBuilder.RenameIndex(
                name: "IX_wishlistItems_WishlistId",
                table: "WishlistItems",
                newName: "IX_WishlistItems_WishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_wishlistItems_ProductId",
                table: "WishlistItems",
                newName: "IX_WishlistItems_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishlistItems",
                table: "WishlistItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_Products_ProductId",
                table: "WishlistItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_WishLists_WishlistId",
                table: "WishlistItems",
                column: "WishlistId",
                principalTable: "WishLists",
                principalColumn: "Id");
        }
    }
}
