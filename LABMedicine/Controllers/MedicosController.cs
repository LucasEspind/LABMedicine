using LABMedicine.Context;
using LABMedicine.DTO;
using LABMedicine.Enumerator;
using LABMedicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace LABMedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        labmedicinebdContext labmedicinebd;
        public MedicosController(labmedicinebdContext labmedicinebd)
        {
            this.labmedicinebd = labmedicinebd;
        }

        [HttpPost]
        public ActionResult CadastrarMedico([FromBody] AdicionarMedicoDTO adicionarMedicoDTO)
        {
            if (adicionarMedicoDTO.CPF.Length != 11)
            {
                return BadRequest("O CPF deve ter 11 números, sem pontos ou traços!");
            }
            var cpfExiste = labmedicinebd.Medicos.Where(x => x.CPF == adicionarMedicoDTO.CPF).FirstOrDefault();
            if (cpfExiste != null)
            {
                return Conflict("Cpf já cadastrado no sistema!");
            }
            MedicoModel medico = new MedicoModel();
            medico.CPF = adicionarMedicoDTO.CPF;
            medico.NomeCompleto = adicionarMedicoDTO.Nome;
            medico.Genero = adicionarMedicoDTO.Genero;
            medico.DataNascimento = adicionarMedicoDTO.DataNascimento;
            medico.Telefone = adicionarMedicoDTO.Telefone;
            medico.InstituicaoEnsino = adicionarMedicoDTO.InstituicaoEnsino;
            medico.CadastroCRM_UF = adicionarMedicoDTO.CadastroCRM_UF;
            medico.EspecializacaoClinica = adicionarMedicoDTO.EspecializacaoClinica;
            medico.TotalAtendimentosRealizados = 0;
            medico.EstadoSistema = EstadoSistemaEnum.Ativo;
            labmedicinebd.Medicos.Add(medico);
            labmedicinebd.SaveChanges();
            return StatusCode(201, new { medico.Identificador, medico.TotalAtendimentosRealizados });
        }

        [HttpPut("{identificador}")]
        public ActionResult AtualizarMedico([FromRoute]int identificador, [FromBody] AtualizarMedicoDTO atualizarMedicoDTO)
        {
            if (identificador < 0)
            {
                return BadRequest("O identificador inserido é inválido!");
            }
            var medico = labmedicinebd.Medicos.Find(identificador);
            if (medico == null)
            {
                return NotFound("O identificador inserido não existe no banco de dados!");
            }
            medico.CPF = atualizarMedicoDTO.CPF;
            medico.NomeCompleto = atualizarMedicoDTO.Nome;
            medico.Genero = atualizarMedicoDTO.Genero;
            medico.DataNascimento = atualizarMedicoDTO.DataNascimento;
            medico.Telefone = atualizarMedicoDTO.Telefone;
            medico.InstituicaoEnsino = atualizarMedicoDTO.InstituicaoEnsino;
            medico.CadastroCRM_UF = atualizarMedicoDTO.CadastroCRM_UF;
            medico.EspecializacaoClinica = atualizarMedicoDTO.EspecializacaoClinica;
            medico.TotalAtendimentosRealizados = atualizarMedicoDTO.TotalAtendimentosRealizados;
            medico.EstadoSistema = atualizarMedicoDTO.EstadoSistema;
            labmedicinebd.Medicos.Attach(medico);
            labmedicinebd.SaveChanges();
            return Ok("Dados atualizados com sucesso!");
        }

        [HttpPut("{identificador}/status")]
        public ActionResult AtualizarStatusMedico([FromRoute] int identificador, [FromQuery] EstadoSistemaEnum estadoSistema)
        {
            if (identificador < 0)
            {
                return BadRequest("O identificador informado não existe!");
            }
            var medico = labmedicinebd.Medicos.Find(identificador);
            if (medico == null)
            {
                return NotFound($"O médico com identificador {identificador} não existe no sistema!");
            }
            medico.EstadoSistema = estadoSistema;
            labmedicinebd.Medicos.Attach(medico);
            labmedicinebd.SaveChanges();
            return Ok("Estado no sistema alterado com sucesso!");
        }

        [HttpGet]
        public ActionResult MostrarMedicosPorStatus(EstadoSistemaEnum? Estado_Sistema)
        {
            var existe = labmedicinebd.Medicos.Where(x => x.EstadoSistema == Estado_Sistema);
            if (existe == null)
            {
                return NotFound("Não existem médicos com este status no sistema!");
            }
            if (Estado_Sistema == null)
            {
                List<MedicoModel> medicos = new List<MedicoModel>();
                foreach (var medico in labmedicinebd.Medicos)
                {
                    medicos.Add(medico);
                }
                return Ok(medicos);
            }
            else
            {
                List<MedicoModel> medicos = new List<MedicoModel>();
                foreach (var medico in labmedicinebd.Medicos)
                {
                    if (medico.EstadoSistema == Estado_Sistema)
                    {
                        medicos.Add(medico);
                    }
                }
                return Ok(medicos);
            }
        }

        [HttpGet("{identificador}")]
        public ActionResult MostrarMedicoPorID(int identificador)
        {
            var medico = labmedicinebd.Medicos.Where(x => x.Identificador== identificador).FirstOrDefault();
            if (medico == null)
            {
                return NotFound("Não existe um médico com o identificador informado!");
            }
            return Ok(medico);
        }

        [HttpDelete("{identificador}")]
        public ActionResult ExcluirMedicoPorID(int identificador)
        {
            var medico = labmedicinebd.Medicos.Where(x => x.Identificador == identificador).FirstOrDefault();
            if (medico == null)
            {
                return NotFound("Não existe um médico com o identificador informado!");
            }
            labmedicinebd.Medicos.Remove(medico);
            labmedicinebd.SaveChanges();
            return NoContent();
        }
    }
}
