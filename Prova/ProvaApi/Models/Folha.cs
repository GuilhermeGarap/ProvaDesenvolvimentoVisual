namespace ProvaApi.Models;

using Models.Funcionario

public class Folha
{
    public int FolhaId { get; set; }
    public float Valor { get; set; }
    public float QuantHoras { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }
    public Funcionario FuncionarioId { get; set;}
}