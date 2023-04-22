using LABMedicine.Context;
using LABMedicine.DTO;
using LABMedicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var cpfExiste = labmedicinebd.Medicos.Find(adicionarMedicoDTO.CPF);
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

        }
    }
}
