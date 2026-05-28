using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tarifuygulaması.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecurityQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Soru = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Soyad = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    SifreHash = table.Column<string>(type: "TEXT", nullable: false),
                    SecurityQuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    SecurityAnswer = table.Column<string>(type: "TEXT", nullable: false),
                    BasarisizGirisSayisi = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_SecurityQuestions_SecurityQuestionId",
                        column: x => x.SecurityQuestionId,
                        principalTable: "SecurityQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: false),
                    GorselUrl = table.Column<string>(type: "TEXT", nullable: false),
                    HazirlamaSuresi = table.Column<int>(type: "INTEGER", nullable: false),
                    PisirmeSuresi = table.Column<int>(type: "INTEGER", nullable: false),
                    KisiSayisi = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Miktar = table.Column<string>(type: "TEXT", nullable: false),
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false)
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
                table: "Categories",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "Tatlılar" },
                    { 2, "Çorbalar" },
                    { 3, "Etli Yemekler" },
                    { 4, "Mezeler" }
                });

            migrationBuilder.InsertData(
                table: "SecurityQuestions",
                columns: new[] { "Id", "Soru" },
                values: new object[,]
                {
                    { 1, "İlk evcil hayvanınızın adı neydi?" },
                    { 2, "Annenizin kızlık soyadı nedir?" },
                    { 3, "İlk öğretmeninizin adı neydi?" },
                    { 4, "Doğduğunuz şehir neresidir?" },
                    { 5, "Çocukken en sevdiğiniz yemek neydi?" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Aciklama", "Ad", "CategoryId", "GorselUrl", "HazirlamaSuresi", "KisiSayisi", "PisirmeSuresi", "UserId" },
                values: new object[,]
                {
                    { 1, "Yoğun çikolata ve vişne aromasıyla nefis bir tatlı.", "Vişneli Brownie", 1, "/images/visnelibrowie.jpg", 20, 6, 35, null },
                    { 2, "Fırında pişirilmiş geleneksel Türk tatlısı.", "Sütlaç", 1, "/images/sutlac.jpg", 15, 4, 30, null },
                    { 3, "Hafif yanık aromalı yumuşak sütlü tatlı.", "Kazandibi", 1, "/images/kazandibi.jpg", 10, 4, 25, null },
                    { 4, "Kadayıf ve peynirle yapılan sıcak tatlı.", "Künefe", 1, "/images/kunefe.jpg", 15, 2, 20, null },
                    { 5, "Klasik Türk mutfağının vazgeçilmezi.", "Mercimek Çorbası", 2, "/images/mercimek.jpg", 10, 4, 30, null },
                    { 6, "Taze domateslerle yapılan hafif çorba.", "Domates Çorbası", 2, "/images/domates.jpg", 10, 4, 25, null },
                    { 7, "Kırmızı mercimek ve bulgurla dolu lezzetli çorba.", "Ezogelin Çorbası", 2, "/images/ezogelin.jpg", 10, 6, 30, null },
                    { 8, "Yoğurtlu pirinçli geleneksel çorba.", "Yayla Çorbası", 2, "/images/yayla.jpg", 10, 4, 20, null },
                    { 9, "Patlıcan içine kıymalı dolgu ile klasik lezzet.", "Karnıyarık", 3, "/images/karniyarik.jpg", 20, 4, 40, null },
                    { 10, "Sebzeler ve et ile pişirilen fırın yemeği.", "Etli Güveç", 3, "/images/guvec.jpg", 20, 4, 60, null },
                    { 11, "Yoğurt ve tereyağlı soslu dürüm kebabı.", "İskender Kebap", 3, "/images/iskender.jpg", 15, 2, 30, null },
                    { 12, "Közlenmiş patlıcan püresi üstünde et.", "Hünkar Beğendi", 3, "/images/hunkar.jpg", 25, 4, 45, null },
                    { 13, "Yoğurt ve sarımsaklı nefis bir meze.", "Haydari", 4, "/images/haydari.jpg", 10, 4, 0, null },
                    { 14, "Biber ve domates ile hazırlanan baharatlı meze.", "Acılı Ezme", 4, "/images/aciliezme.jpg", 15, 4, 0, null },
                    { 15, "Közlenmiş patlıcanla yapılan soğuk meze.", "Patlıcan Salatası", 4, "/images/patlican.jpg", 20, 4, 15, null },
                    { 16, "Balık yumurtası ile hazırlanan deniz mezesi.", "Tarama", 4, "/images/tarama.jpg", 10, 4, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Ad", "Miktar", "RecipeId" },
                values: new object[,]
                {
                    { 1, "Tereyağı", "125 gr", 1 },
                    { 2, "Bitter Çikolata", "100 gr", 1 },
                    { 3, "Yumurta", "2 adet", 1 },
                    { 4, "Şeker", "1 su bardağı", 1 },
                    { 5, "Un", "2 su bardağı", 1 },
                    { 6, "Vişne", "1 su bardağı", 1 },
                    { 7, "Süt", "1 litre", 2 },
                    { 8, "Pirinç", "2 su bardağı", 2 },
                    { 9, "Şeker", "1 su bardağı", 2 },
                    { 10, "Nişasta", "2 yemek kaşığı", 2 },
                    { 11, "Süt", "1 litre", 3 },
                    { 12, "Şeker", "1 su bardağı", 3 },
                    { 13, "Nişasta", "3 yemek kaşığı", 3 },
                    { 14, "Un", "1 yemek kaşığı", 3 },
                    { 15, "Kadayıf", "250 gr", 4 },
                    { 16, "Peynir", "200 gr", 4 },
                    { 17, "Tereyağı", "100 gr", 4 },
                    { 18, "Şeker", "1 su bardağı", 4 },
                    { 19, "Su", "1 su bardağı", 4 },
                    { 20, "Kırmızı Mercimek", "1.5 su bardağı", 5 },
                    { 21, "Soğan", "1 adet", 5 },
                    { 22, "Havuç", "1 adet", 5 },
                    { 23, "Tereyağı", "2 yemek kaşığı", 5 },
                    { 24, "Tuz", "1 tatlı kaşığı", 5 },
                    { 25, "Domates", "4 adet", 6 },
                    { 26, "Soğan", "1 adet", 6 },
                    { 27, "Tereyağı", "2 yemek kaşığı", 6 },
                    { 28, "Un", "1 yemek kaşığı", 6 },
                    { 29, "Süt", "1 su bardağı", 6 },
                    { 30, "Kırmızı Mercimek", "1 su bardağı", 7 },
                    { 31, "Bulgur", "1 su bardağı", 7 },
                    { 32, "Soğan", "1 adet", 7 },
                    { 33, "Domates Salçası", "1 yemek kaşığı", 7 },
                    { 34, "Nane", "1 tatlı kaşığı", 7 },
                    { 35, "Yoğurt", "2 su bardağı", 8 },
                    { 36, "Pirinç", "1 su bardağı", 8 },
                    { 37, "Yumurta", "1 adet", 8 },
                    { 38, "Nane", "1 tatlı kaşığı", 8 },
                    { 39, "Tereyağı", "1 yemek kaşığı", 8 },
                    { 40, "Patlıcan", "4 adet", 9 },
                    { 41, "Kıyma", "250 gr", 9 },
                    { 42, "Soğan", "1 adet", 9 },
                    { 43, "Domates", "2 adet", 9 },
                    { 44, "Biber", "2 adet", 9 },
                    { 45, "Dana Eti", "500 gr", 10 },
                    { 46, "Patates", "3 adet", 10 },
                    { 47, "Havuç", "2 adet", 10 },
                    { 48, "Soğan", "1 adet", 10 },
                    { 49, "Domates Salçası", "2 yemek kaşığı", 10 },
                    { 50, "Dana Eti", "300 gr", 11 },
                    { 51, "Yoğurt", "1 su bardağı", 11 },
                    { 52, "Tereyağı", "50 gr", 11 },
                    { 53, "Domates Salçası", "1 yemek kaşığı", 11 },
                    { 54, "Pide", "2 adet", 11 },
                    { 55, "Dana Eti", "400 gr", 12 },
                    { 56, "Patlıcan", "3 adet", 12 },
                    { 57, "Süt", "1 su bardağı", 12 },
                    { 58, "Tereyağı", "2 yemek kaşığı", 12 },
                    { 59, "Un", "2 yemek kaşığı", 12 },
                    { 60, "Süzme Yoğurt", "2 su bardağı", 13 },
                    { 61, "Sarımsak", "2 diş", 13 },
                    { 62, "Nane", "1 tatlı kaşığı", 13 },
                    { 63, "Zeytinyağı", "1 yemek kaşığı", 13 },
                    { 64, "Domates", "3 adet", 14 },
                    { 65, "Biber", "3 adet", 14 },
                    { 66, "Soğan", "1 adet", 14 },
                    { 67, "Maydanoz", "1 demet", 14 },
                    { 68, "Zeytinyağı", "2 yemek kaşığı", 14 },
                    { 69, "Patlıcan", "3 adet", 15 },
                    { 70, "Sarımsak", "2 diş", 15 },
                    { 71, "Zeytinyağı", "2 yemek kaşığı", 15 },
                    { 72, "Limon", "1 adet", 15 },
                    { 73, "Balık Yumurtası", "100 gr", 16 },
                    { 74, "Zeytinyağı", "1 su bardağı", 16 },
                    { 75, "Limon", "1 adet", 16 },
                    { 76, "Bayat Ekmek", "2 dilim", 16 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SecurityQuestionId",
                table: "Users",
                column: "SecurityQuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SecurityQuestions");
        }
    }
}
