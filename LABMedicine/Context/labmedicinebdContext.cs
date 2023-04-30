using LABMedicine.Enumerator;
using LABMedicine.Models;
using Microsoft.EntityFrameworkCore;

namespace LABMedicine.Context
{
    public class labmedicinebdContext : DbContext
    {
        public labmedicinebdContext(DbContextOptions<labmedicinebdContext> options) : base(options)
        {

        }
        public DbSet<PacientesModel> Pacientes { get; set; }
        public DbSet<MedicosModel> Medicos { get; set; }
        public DbSet<EnfermeirosModel> Enfermeiros { get; set; }
        public DbSet<AtendimentosModel> Atendimentos { get; set; }

        // Seeder de dados iniciais requisitados pelo cliente segundo documentação
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PacientesModel>().HasData(
                new PacientesModel
                {
                    Identificador = 1,
                    NomeCompleto = "Lucas Oliveira",
                    Genero = "Masculino",
                    DataNascimento = new DateTime(1980, 02, 22),
                    CPF = "98765432100",
                    Telefone = "27999887766",
                    ContatoEmergencia = "27987654321",
                    ListaAlergias = "Nenhuma",
                    ListaCuidadosEspecificos = "Diabético",
                    Convenio = "Bradesco Saúde",
                    StatusAtendimento = StatusAtendimentoEnum.AGUARDANDO_ATENDIMENTO,
                    TotalAtendimentosRealizados = 0
                },
                new PacientesModel
                {
                    Identificador = 2,
                    NomeCompleto = "Ana Maria Silva",
                    Genero = "Feminino",
                    DataNascimento = new DateTime(1995, 11, 12),
                    CPF = "12345678900",
                    Telefone = "11999887766",
                    ContatoEmergencia = "11987654321",
                    ListaAlergias = "Amendoim",
                    ListaCuidadosEspecificos = "Asma",
                    Convenio = "Unimed",
                    StatusAtendimento = StatusAtendimentoEnum.AGUARDANDO_ATENDIMENTO,
                    TotalAtendimentosRealizados = 0
                },
                new PacientesModel
                {
                    Identificador = 3,
                    NomeCompleto = "Fábio Souza",
                    Genero = "Masculino",
                    DataNascimento = new DateTime(1990, 06, 10),
                    CPF = "65432198700",
                    Telefone = "2199887766",
                    ContatoEmergencia = "21987654321",
                    ListaAlergias = "Lactose",
                    ListaCuidadosEspecificos = "Hipertensão",
                    Convenio = "Amil",
                    StatusAtendimento = StatusAtendimentoEnum.AGUARDANDO_ATENDIMENTO,
                    TotalAtendimentosRealizados = 0
                },
                new PacientesModel
                {
                    Identificador = 4,
                    NomeCompleto = "Renata Santos",
                    Genero = "Feminino",
                    DataNascimento = new DateTime(1985, 05, 02),
                    CPF = "01234567890",
                    Telefone = "31999887766",
                    ContatoEmergencia = "31987654321",
                    ListaAlergias = "Penicilina",
                    ListaCuidadosEspecificos = "Gestante",
                    Convenio = "SulAmérica",
                    StatusAtendimento = StatusAtendimentoEnum.AGUARDANDO_ATENDIMENTO,
                    TotalAtendimentosRealizados = 0
                },
                new PacientesModel
                {
                    Identificador = 5,
                    NomeCompleto = "José Silva",
                    Genero = "Masculino",
                    DataNascimento = new DateTime(1970, 12, 30),
                    CPF = "56789012345",
                    Telefone = "41999887766",
                    ContatoEmergencia = "41987654321",
                    ListaAlergias = "Nenhuma",
                    ListaCuidadosEspecificos = "Asma",
                    Convenio = "Unimed",
                    StatusAtendimento = StatusAtendimentoEnum.AGUARDANDO_ATENDIMENTO,
                    TotalAtendimentosRealizados = 0
                },
                new PacientesModel
                {
                    Identificador = 6,
                    NomeCompleto = "Mariana Oliveira",
                    Genero = "Feminino",
                    DataNascimento = new DateTime(2000, 09, 15),
                    CPF = "23456789012",
                    Telefone = "2199887766",
                    ContatoEmergencia = "21987654321",
                    ListaAlergias = "Nenhuma",
                    ListaCuidadosEspecificos = "Diabética",
                    Convenio = "Bradesco Saúde",
                    StatusAtendimento = StatusAtendimentoEnum.AGUARDANDO_ATENDIMENTO,
                    TotalAtendimentosRealizados = 0
                },
                new PacientesModel
                {
                    Identificador = 7,
                    NomeCompleto = "Carlos Eduardo",
                    Genero = "Masculino",
                    DataNascimento = new DateTime(1992, 04, 01),
                    CPF = "34567890123",
                    Telefone = "3199887766",
                    ContatoEmergencia = "31987654321",
                    ListaAlergias = "Nenhuma",
                    ListaCuidadosEspecificos = "Hipertensão",
                    Convenio = "Unimed",
                    StatusAtendimento = StatusAtendimentoEnum.AGUARDANDO_ATENDIMENTO,
                    TotalAtendimentosRealizados = 0
                },
                new PacientesModel
                {
                    Identificador = 8,
                    NomeCompleto = "Juliana Santos",
                    Genero = "Feminino",
                    DataNascimento = new DateTime(1988, 07, 14),
                    CPF = "45678901234",
                    Telefone = "2199887766",
                    ContatoEmergencia = "21987654321",
                    ListaAlergias = "Nenhuma",
                    ListaCuidadosEspecificos = "Gestante",
                    Convenio = "SulAmérica",
                    StatusAtendimento = StatusAtendimentoEnum.AGUARDANDO_ATENDIMENTO,
                    TotalAtendimentosRealizados = 0
                },
                new PacientesModel
                {
                    Identificador = 9,
                    NomeCompleto = "Ricardo Rodrigues",
                    Genero = "Masculino",
                    DataNascimento = new DateTime(1985, 11, 23),
                    CPF = "90223096067",
                    Telefone = "3199887766",
                    ContatoEmergencia = "31987654321",
                    ListaAlergias = "Nenhuma",
                    ListaCuidadosEspecificos = "Diabético",
                    Convenio = "Bradesco Saúde",
                    StatusAtendimento = StatusAtendimentoEnum.AGUARDANDO_ATENDIMENTO,
                    TotalAtendimentosRealizados = 0
                },
                new PacientesModel
                {
                    Identificador = 10,
                    NomeCompleto = "Thiago Alves",
                    Genero = "Masculino",
                    DataNascimento = new DateTime(1996, 02, 10),
                    CPF = "67890123456",
                    Telefone = "1199887766",
                    ContatoEmergencia = "11987654321",
                    ListaAlergias = "Nenhuma",
                    ListaCuidadosEspecificos = "Asma",
                    Convenio = "Amil",
                    StatusAtendimento = StatusAtendimentoEnum.AGUARDANDO_ATENDIMENTO,
                    TotalAtendimentosRealizados = 0
                }
                );
            builder.Entity<EnfermeirosModel>().HasData(
                new EnfermeirosModel
                {
                    Identificador = 1,
                    NomeCompleto = "Camila Rodrigues",
                    Genero = "Feminino",
                    DataNascimento = new DateTime(1990, 03, 18),
                    CPF = "17486498090",
                    Telefone = "3199887766",
                    InstituicaoEnsino = "Universidade Federal de Minas Gerais",
                    CadastroCRM_UF = "MG-567890"
                },
                new EnfermeirosModel
                {
                    Identificador = 2,
                    NomeCompleto = "Pedro Silva",
                    Genero = "Masculino",
                    DataNascimento = new DateTime(1985, 07, 25),
                    CPF = "45389378008",
                    Telefone = "2199887766",
                    InstituicaoEnsino = "Universidade Federal do Rio de Janeiro",
                    CadastroCRM_UF = "RJ-678901"
                }
                );

            builder.Entity<MedicosModel>().HasData(
                new MedicosModel
                {
                    Identificador = 1,
                    NomeCompleto = "Fernanda Souza",
                    Genero = "Feminino",
                    DataNascimento = new DateTime(1995, 06, 30),
                    CPF = "78901234567",
                    Telefone = "2199887766",
                    InstituicaoEnsino = "Universidade Federal do Rio de Janeiro",
                    CadastroCRM_UF = "RJ-123456",
                    EspecializacaoClinica = Enumerator.EspecializacaoClinicaEnum.Pediatria,
                    EstadoSistema = Enumerator.EstadoSistemaEnum.Ativo,
                    TotalAtendimentosRealizados = 0
                },
                new MedicosModel
                {
                    Identificador = 2,
                    NomeCompleto = "João Santos",
                    Genero = "Masculino",
                    DataNascimento = new DateTime(1980, 12, 12),
                    CPF = "89012345678",
                    Telefone = "3199887766",
                    InstituicaoEnsino = "Universidade Federal de Minas Gerais",
                    CadastroCRM_UF = "MG-345678",
                    EspecializacaoClinica = Enumerator.EspecializacaoClinicaEnum.Clinico_Geral,
                    EstadoSistema = Enumerator.EstadoSistemaEnum.Ativo,
                    TotalAtendimentosRealizados = 0
                }
                );
        }

    }
}
