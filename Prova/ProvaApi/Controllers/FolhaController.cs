namespace ProvaApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ProvaApi.Data;
    using ProvaApi.Models;
    using ProvaApi.Services;

[ApiController]
[Route("api/folha")]
public class FolhaController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public FolhaController(AppDataContext context)
    {
        _ctx = context;
    }

// GET: api/folha/listar
[HttpGet]
[Route("listar")]
public ActionResult Listar()
{
    try
    {
        List<Folha> folhas = _ctx.Folhas.ToList();

    var calculadorFolha = new _CalculadorFolha();
        // Calcule o INSS para cada folha
        foreach (var folha in folhas)
        {
            folha.Salario_Bruto = calculadorFolha.CalcularBruto(folha.Quantidade, folha.Valor);
            folha.Imposto_Renda = calculadorFolha.CalcularImpostoRenda(folha.Salario_Bruto);
            folha.Inss = calculadorFolha.CalcularInss(folha.Salario_Bruto);
            folha.Fgts = calculadorFolha.CalcularFgts(folha.Salario_Bruto);
            folha.Salario_Liquido = calculadorFolha.CalcularLiquido(folha.Salario_Bruto, folha.Inss, folha.Imposto_Renda);
        }

        return folhas.Count == 0 ? NotFound() : Ok(folhas);
    }
    catch (Exception e)
    {
        return BadRequest(e.Message);
    }
}


// [HttpGet]
// [Route("buscar/{cpf}/{mes}/{ano}")]
// public ActionResult Buscar([FromRoute] string cpf, int mes, int ano)
// {
//     try
//     {
//         // Encontre o funcionário pelo CPF
//         Funcionario funcionario = _ctx.Funcionarios.FirstOrDefault(f => f.Cpf == cpf);

//         if (funcionario != null)
//         {
//             // Agora que você tem o funcionário, encontre as folhas de pagamento associadas a ele para o mês e ano especificados
//             Folha folhaCadastrada = _ctx.Folhas.FirstOrDefault(f => f.Mes == mes && f.Ano == ano && f.FuncionarioId == funcionario.FuncionarioId);

//             if (folhaCadastrada != null)
//             {
//                 var calculadorFolha = new CalculadorFolha(); // Crie uma instância da classe CalculadorFolha

//                 // Calcula os valores da folha de pagamento usando a instância de calculadorFolha
//                 folhaCadastrada.Salario_Bruto = calculadorFolha.CalcularBruto(folhaCadastrada.Quantidade, folhaCadastrada.Valor);
//                 folhaCadastrada.Imposto_Renda = calculadorFolha.CalcularImpostoRenda(folhaCadastrada.Salario_Bruto);
//                 folhaCadastrada.Inss = calculadorFolha.CalcularInss(folhaCadastrada.Salario_Bruto);
//                 folhaCadastrada.Fgts = calculadorFolha.CalcularFgts(folhaCadastrada.Salario_Bruto);
//                 folhaCadastrada.Salario_Liquido = calculadorFolha.CalcularLiquido(folhaCadastrada.Salario_Bruto, folhaCadastrada.Inss, folhaCadastrada.Imposto_Renda);

//                 return Ok(folhaCadastrada);
//             }
//         }

//         return NotFound();
//     }
//     catch (Exception e)
//     {
//         return BadRequest(e.Message);
//     }
// }


//         return NotFound();
//     }
//     catch (Exception e)
//     {
//         return BadRequest(e.Message);
//     }
// }



    // POST: api/folha/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public ActionResult Cadastrar([FromBody] Folha folha)
    {
        try
        {
            _ctx.Folhas.Add(folha);
            _ctx.SaveChanges();
            return Created("", folha);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    }
}
