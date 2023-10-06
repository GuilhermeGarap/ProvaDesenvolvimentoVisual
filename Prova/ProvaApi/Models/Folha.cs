using System.Text.Json.Serialization;
namespace ProvaApi.Models;

public class Folha
{
    public int FolhaId { get; set; }
    public float Valor { get; set; }
    public float Quantidade { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }
    public int FuncionarioId { get; set;}
    public float Salario_Bruto { get; set; }
    public float Imposto_Renda { get; set; }
    public float Inss { get; set; }
    public float Fgts { get; set; }
    public float Salario_Liquido { get; set ;}


    [JsonIgnore]
    public Funcionario? Funcionario { get; set; }
}