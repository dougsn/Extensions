using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ramal.Data.Migrations
{
    public partial class AddEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails)_Setores_SetorId",
                table: "Emails)");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emails)",
                table: "Emails)");

            migrationBuilder.RenameTable(
                name: "Emails)",
                newName: "Caixa_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Emails)_SetorId",
                table: "Caixa_Email",
                newName: "IX_Caixa_Email_SetorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Caixa_Email",
                table: "Caixa_Email",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Caixa_Email_Setores_SetorId",
                table: "Caixa_Email",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caixa_Email_Setores_SetorId",
                table: "Caixa_Email");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Caixa_Email",
                table: "Caixa_Email");

            migrationBuilder.RenameTable(
                name: "Caixa_Email",
                newName: "Emails)");

            migrationBuilder.RenameIndex(
                name: "IX_Caixa_Email_SetorId",
                table: "Emails)",
                newName: "IX_Emails)_SetorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emails)",
                table: "Emails)",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails)_Setores_SetorId",
                table: "Emails)",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
