using LABMedicine.Context;
using LABMedicine.DTO;
using LABMedicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace LABMedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermeirosController : ControllerBase
    {
        private readonly labmedicinebdContext labmedicinebd;

        // Construtor recebendo uma instância do contexto de banco de dados
        public EnfermeirosController(labmedicinebdContext labmedicinebd)
        {
            this.labmedicinebd = labmedicinebd;
        }
        [HttpPost]
        public ActionResult AdicionarEnfermeiro([FromBody] AdicionarEnfermeiroDTO enfermeiroDTO)
        {
            if (enfermeiroDTO.CPF.Length != 11)
            {
                return BadRequest("O CPF deve ter 11 números, sem pontos ou traços!");
            }
            var existeSistema = labmedicinebd.Enfermeiros.Where(x => x.CPF == enfermeiroDTO.CPF).FirstOrDefault();
            if (existeSistema != null)
            {
                return Conflict("Já existe um infermeiro com este CPF no sistema!");
            }
            EnfermeirosModel enfermeiro = new EnfermeirosModel();
            enfermeiro.CPF = enfermeiroDTO.CPF;
            enfermeiro.NomeCompleto = enfermeiroDTO.Nome;
            enfermeiro.Genero = enfermeiroDTO.Genero;
            enfermeiro.DataNascimento = enfermeiroDTO.DataNascimento;
            enfermeiro.Telefone = enfermeiroDTO.Telefone;
            enfermeiro.CadastroCRM_UF = enfermeiroDTO.CadastroCRM_UF;
            enfermeiro.InstituicaoEnsino = enfermeiroDTO.InstituicaoEnsino;
            if (TryValidateModel(enfermeiro))
            {
                labmedicinebd.Enfermeiros.Add(enfermeiro);
                labmedicinebd.SaveChanges();
                return StatusCode(201, new { enfermeiro.Identificador });
            }
            return BadRequest("Há campos preenchidos de forma incorreta.");
        }

        [HttpPut("{identificador}")]
        public ActionResult AtualizarEnfermeiro([FromRoute]int? identificador, [FromBody] AtualizarEnfermeiroDTO enfermeiroDTO)
        {
            if (identificador < 0 || identificador == null)
            {
                return BadRequest("O identificador informado não existe!");
            }
            var enfermeiro = labmedicinebd.Enfermeiros.Find(identificador);
            if (enfermeiro == null)
            {
                return NotFound("Não existe um Enfermeiro com o identificador informado!");
            }
            if (enfermeiroDTO.CPF.Length != 11)
            {
                return BadRequest("O CPF deve ter 11 números, sem pontos ou traços!");
            }
            enfermeiro.CPF = enfermeiroDTO.CPF;
            enfermeiro.NomeCompleto = enfermeiroDTO.Nome;
            enfermeiro.Genero = enfermeiroDTO.Genero;
            enfermeiro.DataNascimento = enfermeiroDTO.DataNascimento;
            enfermeiro.Telefone = enfermeiroDTO.Telefone;
            enfermeiro.InstituicaoEnsino = enfermeiroDTO.InstituicaoEnsino;
            enfermeiro.CadastroCRM_UF = enfermeiroDTO.CadastroCRM_UF;
            if (TryValidateModel(enfermeiro))
            {
                labmedicinebd.Enfermeiros.Attach(enfermeiro);
                labmedicinebd.SaveChanges();
                return Ok("Dados do Enfermeiro atualizados com sucesso!");
            }
            return BadRequest("Há campos preenchidos de forma incorreta.");
        }

        [HttpGet]
        public ActionResult MostrarTodosEnfermeiros()
        {
            List<EnfermeirosModel> enfermeiros = new List<EnfermeirosModel>();
            foreach(var enfermeiro in labmedicinebd.Enfermeiros)
            {
                enfermeiros.Add(enfermeiro);
            }
            if (enfermeiros.Count > 0)
            {
                return Ok(enfermeiros);
            }
            else
            {
                return NotFound("Não existem enfermeiros cadastrados no sistema!");
            }
        }


        [HttpGet("{identificador}")]
        public ActionResult MostrarTodosEnfermeiros([FromRoute] int? identificador)
        {
            if (identificador < 0 || identificador == null)
            {
                return BadRequest("O identificador informado não existe!");
            }
            var enfermeiro = labmedicinebd.Enfermeiros.Find(identificador);
            if (enfermeiro == null)
            {
                return NotFound("Não existe um enfermeiro com o identificador informado!");
            }
            return Ok(enfermeiro);
        }

        [HttpDelete("{identificador}")]
        public ActionResult RemoverEnfermeiro(int? identificador)
        {
            if (identificador < 0 || identificador == null)
            {
                return BadRequest("O identificador informado não existe!");
            }
            var enfermeiro = labmedicinebd.Enfermeiros.Find(identificador);
            if (enfermeiro == null)
            {
                return NotFound("Não existe um enfermeiro com este identificador!");
            }
            labmedicinebd.Enfermeiros.Remove(enfermeiro);
            labmedicinebd.SaveChanges();
            return NoContent();
        }
    }
}
