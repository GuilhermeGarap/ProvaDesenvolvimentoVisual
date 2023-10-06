namespace ProvaApi.Services;
using ProvaApi.Models;
public class _CalculadorFolha

{

    public float CalcularBruto(float valor, float horas)
    {
       float bruto = valor * horas;
       return bruto;
    }

public float CalcularImpostoRenda(float bruto)
{
    float Imposto_Renda = 0;

    if (bruto <= 1903.98)
    {
        Imposto_Renda = 0;
    }
    else if (bruto >= 1903.99 && bruto <= 2826.65)
    {
        Imposto_Renda = (bruto * 0.075f) - 142.80f; 
    }
    else if (bruto >= 2826.66 && bruto <= 3751.05)
    {
        Imposto_Renda = (bruto * 0.15f) - 354.80f; 
    }
    else if (bruto >= 3751.06 && bruto <= 4664.68)
    {
        Imposto_Renda = (bruto * 0.225f) - 636.13f; 
    }
    else if (bruto >= 4664.69)
    {
        Imposto_Renda = (bruto * 0.275f) - 869.36f; 
    }

    return Imposto_Renda;
}

    public float CalcularInss(float bruto) {
           float Inss = 0;

    if (bruto <= 1693.72)
    {
        Inss = bruto*0.08f;
    }
    else if (bruto >= 1693.73 && bruto <= 2822.9)
    {
        Inss = bruto * 0.09f; 
    }
    else if (bruto >= 2822.91 && bruto <= 5645.8)
    {
        Inss = bruto * 0.11f; 
    }
    else if (bruto >= 5645.81)
    {
        Inss = 621.03f; 
    }

    return Inss;
} 

    public float CalcularLiquido(float bruto, float inss, float renda) {
        float liquido = bruto - renda - inss;
        return liquido;
    }

    public float CalcularFgts(float bruto) {
        float fgts = bruto * 0.08f;
        return fgts;
    }
    }

    

