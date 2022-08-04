using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class change_keys_in_dto_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectID",
                table: "ProjectTasks");

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "ProjectTasks",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ProjectTasks",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_ProjectID",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_ProjectId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Projects",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectTasks",
                newName: "ProjectID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProjectTasks",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_ProjectID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projects",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectID",
                table: "ProjectTasks",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
