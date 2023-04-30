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
        private readonly labmedicinebdContext labmedicinebd;

        // Construtor recebendo uma instância do contexto de banco de dados
        public MedicosController(labmedicinebdContext labmedicinebd)
        {
            this.labmedicinebd = labmedicinebd;
        }

        // Método Post para cadastrar um médico
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
            MedicosModel medico = new MedicosModel();
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
            if (TryValidateModel(medico))
            {
                labmedicinebd.Medicos.Add(medico);
                labmedicinebd.SaveChanges();
                return StatusCode(201, new { medico.Identificador, medico.TotalAtendimentosRealizados });
            }
            return BadRequest("Há campos preenchidos de forma incorreta.");
        }

        [HttpPut("{identificador}")]
        public ActionResult AtualizarMedico([FromRoute]int? identificador, [FromBody] AtualizarMedicoDTO atualizarMedicoDTO)
        {
            if (identificador < 0 || identificador == null)
            {
                return BadRequest("O identificador informado não existe!");
            }
            var medico = labmedicinebd.Medicos.Find(identificador);
            if (medico == null)
            {
                return NotFound("O identificador inserido não existe no banco de dados!");
            }
            if (medico.CPF.Length != 11)
            {
                return BadRequest("O CPF deve ter 11 números, sem pontos ou traços!");
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
            if (TryValidateModel(medico))
            {
                labmedicinebd.Medicos.Attach(medico);
                labmedicinebd.SaveChanges();
                return Ok("Dados atualizados com sucesso!");
            }
            return BadRequest("Há campos preenchidos de forma incorreta.");
        }

        [HttpPut("{identificador}/status")]
        public ActionResult AtualizarStatusMedico([FromRoute] int? identificador, [FromQuery] EstadoSistemaEnum estadoSistema)
        {

            if (identificador < 0 || identificador == null)
            {
                return BadRequest("O identificador informado não existe!");
            }
            var medico = labmedicinebd.Medicos.Find(identificador);
            if (medico == null)
            {
                return NotFound($"O médico com identificador {identificador} não existe no sistema!");
            }
            if (TryValidateModel(medico))
            {
                medico.EstadoSistema = estadoSistema;
                labmedicinebd.Medicos.Attach(medico);
                labmedicinebd.SaveChanges();
                return Ok("Estado no sistema alterado com sucesso!");
            }
            return BadRequest("Há campos preenchidos de forma incorreta.");
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
                List<MedicosModel> medicos = new List<MedicosModel>();
                foreach (var medico in labmedicinebd.Medicos)
                {
                    medicos.Add(medico);
                }
                if (medicos.Count > 0)
                {
                    return Ok(medicos);
                }
                else
                {
                    return NotFound("Não existem médicos cadastrados no sistema!");
                }
            }
            else
            {
                List<MedicosModel> medicos = new List<MedicosModel>();
                foreach (var medico in labmedicinebd.Medicos)
                {
                    if (medico.EstadoSistema == Estado_Sistema)
                    {
                        medicos.Add(medico);
                    }
                }
                if (medicos.Count > 0)
                {
                    return Ok(medicos);
                }
                else
                {
                    return NotFound("Não existem médicos com o status informado cadastrados no sistema!");
                }
            }
        }

        [HttpGet("{identificador}")]
        public ActionResult MostrarMedicoPorID([FromRoute]int? identificador)
        {
            if (identificador < 0 || identificador == null)
            {
                return BadRequest("O identificador informado não existe!");
            }
            var medico = labmedicinebd.Medicos.Where(x => x.Identificador== identificador).FirstOrDefault();
            if (medico == null)
            {
                return NotFound("Não existe um médico com o identificador informado!");
            }
            return Ok(medico);
        }

        [HttpDelete("{identificador}")]
        public ActionResult ExcluirMedicoPorID([FromRoute] int? identificador)
        {
            if (identificador < 0 || identificador == null)
            {
                return BadRequest("O identificador informado não existe!");
            }
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
