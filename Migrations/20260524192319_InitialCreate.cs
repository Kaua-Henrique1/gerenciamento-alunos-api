using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamento_alunos_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF OBJECT_ID(N'[Alunos]', 'U') IS NULL
BEGIN
    CREATE TABLE [Alunos] (
        [Id] int NOT NULL IDENTITY(1,1),
        [Nome] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Curso] nvarchar(max) NOT NULL,
        [DataNascimento] date NOT NULL,
        CONSTRAINT [PK_Alunos] PRIMARY KEY ([Id])
    );
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
