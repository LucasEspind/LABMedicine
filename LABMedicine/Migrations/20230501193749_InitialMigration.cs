using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LABMedicine.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Codigo_Atendimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador_Medico = table.Column<int>(type: "int", nullable: false),
                    Especialidade_Clinica = table.Column<int>(type: "int", nullable: false),
                    Identificador_Paciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Codigo_Atendimento);
                });

            migrationBuilder.CreateTable(
                name: "Enfermeiros",
                columns: table => new
                {
                    Identificador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instituicao_de_Ensino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cadastro_CRMUF = table.Column<string>(name: "Cadastro_CRM/UF", type: "nvarchar(max)", nullable: false),
                    Nome_Completo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_de_Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeiros", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Identificador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instituicao_de_Ensino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cadastro_CRMUF = table.Column<string>(name: "Cadastro_CRM/UF", type: "nvarchar(max)", nullable: false),
                    Especializacao_Clinica = table.Column<int>(type: "int", nullable: false),
                    Estano_no_Sistema = table.Column<int>(type: "int", nullable: false),
                    Total_de_Atendimentos_Realizados = table.Column<int>(type: "int", nullable: false),
                    Nome_Completo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_de_Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Identificador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contato_de_Emergencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lista_de_Alergias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lista_de_Cuidados_Especificos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Convenio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status_Atendimento = table.Column<int>(type: "int", nullable: false),
                    Total_de_Atendimentos_Realizado = table.Column<int>(type: "int", nullable: false),
                    Nome_Completo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_de_Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Identificador);
                });

            migrationBuilder.InsertData(
                table: "Enfermeiros",
                columns: new[] { "Identificador", "CPF", "Cadastro_CRM/UF", "Data_de_Nascimento", "Genero", "Instituicao_de_Ensino", "Nome_Completo", "Telefone" },
                values: new object[,]
                {
                    { 1, "17486498090", "MG-567890", new DateTime(1990, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Universidade Federal de Minas Gerais", "Camila Rodrigues", "3199887766" },
                    { 2, "45389378008", "RJ-678901", new DateTime(1985, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Universidade Federal do Rio de Janeiro", "Pedro Silva", "2199887766" }
                });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Identificador", "CPF", "Cadastro_CRM/UF", "Data_de_Nascimento", "Especializacao_Clinica", "Estano_no_Sistema", "Genero", "Instituicao_de_Ensino", "Nome_Completo", "Telefone", "Total_de_Atendimentos_Realizados" },
                values: new object[,]
                {
                    { 1, "78901234567", "RJ-123456", new DateTime(1995, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0, "Feminino", "Universidade Federal do Rio de Janeiro", "Fernanda Souza", "2199887766", 0 },
                    { 2, "89012345678", "MG-345678", new DateTime(1980, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Masculino", "Universidade Federal de Minas Gerais", "João Santos", "3199887766", 0 }
                });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Identificador", "CPF", "Contato_de_Emergencia", "Convenio", "Data_de_Nascimento", "Genero", "Lista_de_Alergias", "Lista_de_Cuidados_Especificos", "Nome_Completo", "Status_Atendimento", "Telefone", "Total_de_Atendimentos_Realizado" },
                values: new object[,]
                {
                    { 1, "98765432100", "27987654321", "Bradesco Saúde", new DateTime(1980, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Nenhuma", "Diabético", "Lucas Oliveira", 0, "27999887766", 0 },
                    { 2, "12345678900", "11987654321", "Unimed", new DateTime(1995, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Amendoim", "Asma", "Ana Maria Silva", 0, "11999887766", 0 },
                    { 3, "65432198700", "21987654321", "Amil", new DateTime(1990, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Lactose", "Hipertensão", "Fábio Souza", 0, "2199887766", 0 },
                    { 4, "01234567890", "31987654321", "SulAmérica", new DateTime(1985, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Penicilina", "Gestante", "Renata Santos", 0, "31999887766", 0 },
                    { 5, "56789012345", "41987654321", "Unimed", new DateTime(1970, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Nenhuma", "Asma", "José Silva", 0, "41999887766", 0 },
                    { 6, "23456789012", "21987654321", "Bradesco Saúde", new DateTime(2000, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Nenhuma", "Diabética", "Mariana Oliveira", 0, "2199887766", 0 },
                    { 7, "34567890123", "31987654321", "Unimed", new DateTime(1992, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Nenhuma", "Hipertensão", "Carlos Eduardo", 0, "3199887766", 0 },
                    { 8, "45678901234", "21987654321", "SulAmérica", new DateTime(1988, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Nenhuma", "Gestante", "Juliana Santos", 0, "2199887766", 0 },
                    { 9, "90223096067", "31987654321", "Bradesco Saúde", new DateTime(1985, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Nenhuma", "Diabético", "Ricardo Rodrigues", 0, "3199887766", 0 },
                    { 10, "67890123456", "11987654321", "Amil", new DateTime(1996, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Nenhuma", "Asma", "Thiago Alves", 0, "1199887766", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Enfermeiros");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
