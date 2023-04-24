using LABMedicine.Context;
using LABMedicine.DTO;
using LABMedicine.Enumerator;
using LABMedicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LABMedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentosController : ControllerBase
    {
        labmedicinebdContext labmedicinebd;
        public AtendimentosController(labmedicinebdContext labmedicinebd)
        {
            this.labmedicinebd = labmedicinebd;
        }

        [HttpPut]
        public ActionResult Atendimento([FromBody] IdentificadorPacienteMedicoDTO identificadorPacienteMedicoDTO)
        {
            AtendimentoModel atendimento = new AtendimentoModel();
            var paciente = labmedicinebd.Pacientes.Find(identificadorPacienteMedicoDTO.Identificador_Paciente);
            var medico = labmedicinebd.Medicos.Find(identificadorPacienteMedicoDTO.Identificador_Medico);
            if (paciente == null)
            {
                return NotFound("Identificador do paciente não existe no sistema!");
            }
            else if(medico == null){
                return NotFound("Identificador do médico não existe no sistema!");
            }
            if (medico.EstadoSistema == EstadoSistemaEnum.Inativo)
            {
                return BadRequest("O médico com o identificador informado está com o estados INATIVO, por tanto não pode realizar o atendimento!");
            }
            // Atualização do Paciente
            paciente.StatusAtendimento = StatusAtendimentoEnum.ATENDIDO;
            paciente.TotalAtendimentosRealizados += 1;
            labmedicinebd.Pacientes.Attach(paciente);

            // Atualização do Médico
            medico.TotalAtendimentosRealizados += 1;
            labmedicinebd.Medicos.Attach(medico);

            // Atualização da Tabela Atendimento
            atendimento.Identificador_Medico = medico.Identificador;
            atendimento.Identificador_Paciente = paciente.Identificador;
            atendimento.especializacaoClinica = medico.EspecializacaoClinica;
            labmedicinebd.Atendimentos.Add(atendimento);

            // Save Changes para Atualização do médico e paciente. Adicionando o Histórico de atendimento no sistema!
            labmedicinebd.SaveChanges();
            return Ok("Atendimento realizado com sucesso! Os dados no sistema foram alterados!");
        }
    }
}
