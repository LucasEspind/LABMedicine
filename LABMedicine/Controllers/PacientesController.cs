using LABMedicine.Context;
using LABMedicine.DTO;
using LABMedicine.Enumerator;
using LABMedicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;

namespace LABMedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly labmedicinebdContext labmedicinebd;

        // Construtor recebendo uma instância do contexto de banco de dados
        public PacientesController(labmedicinebdContext labmedicinebd)
        {
            this.labmedicinebd = labmedicinebd;
        }

        // Método Post que recebe uma DTO de paciente, para a inserção do mesmo no sistema
        [HttpPost]
        public ActionResult AdicionarPaciente([FromBody] AdicionarPacienteDTO pacienteDTO)
        {
            // Verificação padrão do CPF
            if (pacienteDTO.CPF.Length != 11)
            {
                return BadRequest("Verifique se o CPF digitado possui 11 números!");
            }

            // Verificação se existe um Paciente com o mesmo CPF cadastrado no sistema
            var pacienteCPF = labmedicinebd.Pacientes.Where(x => x.CPF == pacienteDTO.CPF).FirstOrDefault();
            if (pacienteCPF != null)
            {
                return Conflict("Paciente já cadastrado no sistema!");
            }

            // Declaração de um novo Paciente e sua Instanciação
            PacientesModel paciente = new();
            paciente.NomeCompleto = pacienteDTO.Nome;
            paciente.Genero = pacienteDTO.Genero;
            paciente.DataNascimento = pacienteDTO.DataNascimento;
            paciente.CPF = pacienteDTO.CPF;
            paciente.Telefone = pacienteDTO.Telefone;
            paciente.ContatoEmergencia = pacienteDTO.ContatoEmergencia;
            paciente.ListaAlergias = string.Join("||", pacienteDTO.ListaAlergias!);
            paciente.ListaCuidadosEspecificos = string.Join("||", pacienteDTO.ListaCuidadosEspecificos!);
            paciente.Convenio = pacienteDTO.Convenio;
            paciente.StatusAtendimento = StatusAtendimentoEnum.AGUARDANDO_ATENDIMENTO;
            paciente.TotalAtendimentosRealizados = 0;

            // Validação de todos os campos inseridos
            if (TryValidateModel(paciente))
            {
                labmedicinebd.Add(paciente);
                labmedicinebd.SaveChanges();

                return StatusCode(201, new { paciente.Identificador, paciente.TotalAtendimentosRealizados });
            }
            // Caso exista algum erro na hora de preencher os dados, retorna uma mensagem de erro
            return BadRequest("Há campos preenchidos de forma incorreta.");

        }

        // Método Put para atualizar os dados de um Paciente, recebendo na rota o identificador do mesmo e no body uma DTO com as possíveis alterações a serem feitas
        [HttpPut("{identificador}")]
        public ActionResult AtualizarDados(int? identificador, [FromBody] AtualizarPacienteDTO paciente)
        {
            // Verificação se o identificador passado é válido
            if (identificador < 0 || identificador == null)
            {
                return BadRequest("O identificador informado não existe!");
            }

            // Busca o paciente com o identificador informado
            foreach (var pacientes in labmedicinebd.Pacientes)
            {
                
                if (pacientes.Identificador == identificador)
                {
                    // Verificação padrão do CPF
                    if (paciente.CPF.Length != 11)
                    {
                        return BadRequest("Verifique se o CPF digitado possui 11 números!");
                    }

                    // Instanciando as atualizações nos dados do paciente
                    pacientes.NomeCompleto = paciente.Nome;
                    pacientes.Genero = paciente.Genero;
                    pacientes.DataNascimento = paciente.DataNascimento;
                    pacientes.CPF = paciente.CPF;
                    pacientes.Telefone = paciente.Telefone;
                    pacientes.ContatoEmergencia = paciente.ContatoEmergencia;
                    pacientes.ListaAlergias = string.Join("|", paciente.ListaAlergias!);
                    pacientes.ListaCuidadosEspecificos = string.Join("|", paciente.ListaCuidadosEspecificos!);
                    pacientes.Convenio = paciente.Convenio;
                    pacientes.StatusAtendimento = paciente.StatusAtendimento;
                    pacientes.TotalAtendimentosRealizados = paciente.TotalAtendimentosRealizados;

                    // Validação de todos os campos inseridos
                    if (TryValidateModel(pacientes))
                    {
                        labmedicinebd.Attach(pacientes);
                        labmedicinebd.SaveChanges();

                        return Ok("Paciente atualizado!");
                    }
                    return BadRequest("Há campos preenchidos de forma incorreta.");
                }
            }
            // Caso não exista uma paciente com o identificador no sistema, retorna uma mensagem de erro
            return NotFound($"Paciente com o identificador {identificador} não foi encontrado no sistema!");
        }

        // Método Put recebendo pela rota o identificador do paciente e por query seu status atualizado
        [HttpPut("{identificador}/status")]
        public ActionResult AtualizarStatus([FromRoute] int? identificador, [FromQuery] StatusAtendimentoEnum status)
        {
            // Verificação se o identificador passado é válido
            if (identificador < 0 || identificador == null)
            {
                return BadRequest("O identificador informado não existe!");
            }
            var pacienteId = labmedicinebd.Pacientes.Find(identificador);
            if (pacienteId != null)
            {
                // Atualiza o status do paciente com o valor passado na query
                pacienteId.StatusAtendimento = status;
                labmedicinebd.Attach(pacienteId);
                labmedicinebd.SaveChanges();
                return Ok("Status Atualizado com sucesso!");
            }
            // Caso não exista uma paciente com o identificador no sistema, retorna uma mensagem de erro
            return BadRequest("Identificador não encontrado!");
        }

        // Método Get que retorna uma lista dos pacientes com o Status informado por query
        [HttpGet]
        public ActionResult ListagemPacientes([FromQuery] StatusAtendimentoEnum status)
        {
            // Procura no banco de dados todos os pacientes
            foreach (var paciente in labmedicinebd.Pacientes)
            {
                // Criação de uma lista que recebe PacienteModel
                List<PacientesModel> pacientes = new();        

                // Verifica se o Paciente encontrado no sistema está com o mesmo status que foi informado por query, se sim adiciona a lista de Pacientes
                if (paciente.StatusAtendimento == status)
                {
                    pacientes.Add(paciente);
                }

                // Verifica se foi adicionado algum registro na lista de pacientes
                // Se foram adicionados, retorna o status Ok com a lista de pacientes
                if (pacientes.Count > 0)
                {
                    return Ok(pacientes);
                }
                // Caso não tenham adicionado, retorna o status NotFound com uma mensagem de erro
                else
                {
                    return NotFound("Não existem pacientes com o status seleicionado!");
                }
            }
            // Se não existe um paciente com o status selecionado, retorna uma mensagem de erro
            return NotFound("Não existem pacientes com o status seleicionado!");
        }

        // Método Get que recebe pela rota um identificador e retorna o paciente que corresponde ao identificador informado
        [HttpGet("{identificador}")]
        public ActionResult ListagemPacientes([FromRoute] int? identificador)
        {
            // Verificação se o identificador passado é válido
            if (identificador < 0 || identificador == null)
            {
                return BadRequest("O identificador informado não existe!");
            }
            // Procura pelo paciente no sistema
            var paciente = labmedicinebd.Pacientes.Find(identificador);

            // Verifica se o paciente existe no sistema, caso exista retorna o mesmo
            if (paciente != null)
            {
                return Ok(paciente);
            }
            // Se não existe um cadastro, retorna uma mensagem de erro
            return NotFound("Não existem pacientes com o identificado informado!");
        }

        // Método Delete para a remoção do cadastro de um paciente, recebendo o seu identificador pela rota
        [HttpDelete("{identificador}")]
        public ActionResult ExcluirPaciente([FromRoute] int? identificador) 
        {
            // Verificação se o identificador passado é válido
            if (identificador < 0 || identificador == null)
            {
                return BadRequest("O identificador informado não existe!");
            }
            // Procura pelo paciente no sistema
            var paciente = labmedicinebd.Pacientes.Find(identificador);

            // Verifica se o paciente existe no sistema. Caso exista, o seu cadastro é excluído.
            if (paciente != null)
            {
                labmedicinebd.Pacientes.Remove(paciente);
                labmedicinebd.SaveChanges();
                return NoContent();
            }
            // Se não existe um cadastro, retorna uma mensagem de erro
            return NotFound("Identificador não existente na base de dados!");
        }
    }
}
