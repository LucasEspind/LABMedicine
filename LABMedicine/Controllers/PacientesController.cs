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
        labmedicinebdContext labmedicinebd;
        public PacientesController(labmedicinebdContext labmedicinebd)
        {
            this.labmedicinebd = labmedicinebd;
        }


        [HttpPost]
        public ActionResult AdicionarPaciente([FromBody] AdicionarPacienteDTO pacienteDTO)
        {
            if (pacienteDTO.CPF.Length != 11)
            {
                return BadRequest("Verifique se o CPF digitado possui 11 números!");
            }
            var pacienteCPF = labmedicinebd.Pacientes.Where(x => x.CPF == pacienteDTO.CPF).FirstOrDefault();
            if (pacienteCPF != null)
            {
                return Conflict("Paciente já cadastrado no sistema!");
            }
            PacienteModel paciente = new();
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
            if (TryValidateModel(paciente))
            {
                labmedicinebd.Add(paciente);
                labmedicinebd.SaveChanges();

                return StatusCode(201, new { paciente.Identificador, paciente.TotalAtendimentosRealizados });
            }
            return BadRequest("Há campos preenchidos de forma incorreta.");

        }

        [HttpPut("{identificador}")]
        public ActionResult AtualizarDados(int? identificador, [FromBody] AtualizarPacienteDTO paciente)
        {
            if (identificador < 0 || identificador == null)
            {
                return BadRequest("O identificador informado não existe!");
            }
            foreach (var pacientes in labmedicinebd.Pacientes)
            {
                if (pacientes.Identificador == identificador)
                {
                    if (paciente.CPF.Length != 11)
                    {
                        return BadRequest("Verifique se o CPF digitado possui 11 números!");
                    }
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
                    if (TryValidateModel(pacientes))
                    {
                        labmedicinebd.Attach(pacientes);
                        labmedicinebd.SaveChanges();

                        return Ok("Paciente atualizado!");
                    }
                    return BadRequest("Há campos preenchidos de forma incorreta.");
                }
            }
            return NotFound($"Paciente com o identificador {identificador} não foi encontrado no sistema!");
        }

        [HttpPut("{identificador}/status")]
        public ActionResult AtualizarStatus([FromRoute] int? identificador, [FromQuery] StatusAtendimentoEnum status)
        {
            if (identificador < 0 || identificador == null)
            {
                return BadRequest("O identificador informado não existe!");
            }
            var pacienteId = labmedicinebd.Pacientes.Find(identificador);
            if (pacienteId != null)
            {
                pacienteId.StatusAtendimento = status;
                labmedicinebd.Attach(pacienteId);
                labmedicinebd.SaveChanges();
                return Ok("Status Atualizado com sucesso!");
            }
            return BadRequest("Identificador não encontrado!");
        }

        [HttpGet]
        public ActionResult ListagemPacientes([FromQuery] StatusAtendimentoEnum status)
        {
            foreach (var paciente in labmedicinebd.Pacientes)
            {
                List<PacienteModel> pacientes = new();             
                if (paciente.StatusAtendimento == status)
                {
                    pacientes.Add(paciente);
                }
                if (pacientes.Count > 0)
                {
                    return Ok(pacientes);
                }
                else
                {
                    return NotFound("Não existem pacientes com o status seleicionado!");
                }
            }
            return NotFound("Não existem pacientes com o status seleicionado!");
        }

        [HttpGet("{identificador}")]
        public ActionResult ListagemPacientes([FromRoute] int? identificador)
        {
            if (identificador < 0 || identificador == null)
            {
                return BadRequest("O identificador informado não existe!");
            }
            var paciente = labmedicinebd.Pacientes.Find(identificador);
            if (paciente != null)
            {
                return Ok(paciente);
            }
            return NotFound("Não existem pacientes com o identificado informado!");
        }

        [HttpDelete("{identificador}")]
        public ActionResult ExcluirPaciente([FromRoute] int? identificador) 
        {
            if (identificador < 0 || identificador == null)
            {
                return BadRequest("O identificador informado não existe!");
            }
            var paciente = labmedicinebd.Pacientes.Find(identificador);
            if (paciente != null)
            {
                labmedicinebd.Pacientes.Remove(paciente);
                labmedicinebd.SaveChanges();
                return NoContent();
            }
            return NotFound("Identificador não existente na base de dados!");
        }
    }
}
