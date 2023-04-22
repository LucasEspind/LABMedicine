using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LABMedicine.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enfermeiro",
                columns: table => new
                {
                    Identificado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instituicao_de_Ensino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cadastro_CRMUF = table.Column<string>(name: "Cadastro_CRM/UF", type: "nvarchar(max)", nullable: false),
                    Nome_Completo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_de_Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeiro", x => x.Identificado);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Identificado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instituicao_de_Ensino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cadastro_CRMUF = table.Column<string>(name: "Cadastro_CRM/UF", type: "nvarchar(max)", nullable: false),
                    Especializacao_Clinica = table.Column<int>(type: "int", nullable: false),
                    Estano_no_Sistema = table.Column<int>(type: "int", nullable: false),
                    Total_de_Atendimentos_Realizados = table.Column<int>(type: "int", nullable: false),
                    Nome_Completo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_de_Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Identificado);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Identificado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contato_de_Emergencia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lista_de_Alergias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lista_de_Cuidados_Especificos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Convenio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status_Atendimento = table.Column<int>(type: "int", nullable: false),
                    Total_de_Atendimentos_Realizado = table.Column<int>(type: "int", nullable: false),
                    Nome_Completo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_de_Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Identificado);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enfermeiro");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
