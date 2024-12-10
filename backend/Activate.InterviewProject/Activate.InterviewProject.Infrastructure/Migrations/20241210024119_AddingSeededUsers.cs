using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Activate.InterviewProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingSeededUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "RefreshToken", "RefreshTokenExpiryTime", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("145aa9ed-7adb-427a-bab2-84e1ff4ece9f"), "amy@planetexpress.com", "c6b53113-56c1-4494-bf99-e0944c825ca2", null, null, null, "amy" },
                    { new Guid("20bac1cb-deb9-4498-bc2b-8562d6bfc344"), "hermes@planetexpress.com", "5263a605-3c69-4237-b754-27232c5c1978", null, null, null, "hermes" },
                    { new Guid("5c3267cd-4935-47da-8279-c37eb3c10e95"), "fry@planetexpress.com", "a37d2472-c93a-4a60-b075-69874c79fb9c", null, null, null, "fry" },
                    { new Guid("868b7692-8b2c-457c-8ecc-9f216c364087"), "farnsworth@planetexpress.com", "0803d48a-35b4-476c-994a-558128f11a15", null, null, "admin", "professor" },
                    { new Guid("8f06de97-49ec-409c-8e53-e924542c4608"), "bender@planetexpress.com", "63212b3e-d9be-4607-8896-e60fb1b20af8", null, null, null, "bender" },
                    { new Guid("958591fe-68a1-4fea-a5ba-4db02202608d"), "leela@planetexpress.com", "c14e7462-3f8b-4d94-8f1d-1f91ef93eac1", null, null, null, "leela" },
                    { new Guid("addd92a4-8360-4317-bc0e-89bf8c45fada"), "zoidberg@planetexpress.com", "1dd1c2fa-1460-4133-b40b-62e88fdb8ef8", null, null, null, "zoidberg" },
                    { new Guid("b7887b3d-ef1b-449c-a45e-3cf466ddf9d8"), "zapp@doop.com", "40e8fcbd-fc62-47f4-ae22-7e3bfa4c42c3", null, null, null, "zapp" },
                    { new Guid("f2cbd456-1161-45c1-831a-28477cd49193"), "kif@doop.com", "4146b3bc-60cc-4212-a15f-27286d306eb0", null, null, null, "kif" },
                    { new Guid("f7be131a-42b9-4de9-8356-efa7e6fd2fda"), "mom@momcorp.com", "214f2758-a579-436c-88a4-dbf60ddbf1c3", null, null, null, "mom" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("145aa9ed-7adb-427a-bab2-84e1ff4ece9f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20bac1cb-deb9-4498-bc2b-8562d6bfc344"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5c3267cd-4935-47da-8279-c37eb3c10e95"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("868b7692-8b2c-457c-8ecc-9f216c364087"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8f06de97-49ec-409c-8e53-e924542c4608"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("958591fe-68a1-4fea-a5ba-4db02202608d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("addd92a4-8360-4317-bc0e-89bf8c45fada"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b7887b3d-ef1b-449c-a45e-3cf466ddf9d8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f2cbd456-1161-45c1-831a-28477cd49193"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f7be131a-42b9-4de9-8356-efa7e6fd2fda"));

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
