using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class projecttaskdto_projectid_notnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectID",
                table: "ProjectTasks");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "ProjectTasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectID",
                table: "ProjectTasks",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectID",
                table: "ProjectTasks");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "ProjectTasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectID",
                table: "ProjectTasks",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID");
        }
    }
}
