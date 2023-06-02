﻿using ExtratoSalarial.Core.Domain.Enums;

namespace ExtratoSalarial.Core.Domain.Entities
{
    public class Paycheck : Entity
    {
        public Paycheck() { }
        public Paycheck(
            string funcionarioId,
            DateTime mesReferencia,
            decimal salarioBruto,
            decimal totalDeDescontos,
            decimal salarioLiquido,
            List<EntriesData> lancamentos)
        {
            FuncionarioId = funcionarioId;
            MesReferencia = mesReferencia;
            SalarioBruto = salarioBruto;
            TotalDeDescontos = totalDeDescontos;
            SalarioLiquido = salarioLiquido;
            Lancamentos = lancamentos;
            Initialize();
        }

        public string FuncionarioId { get; set; }
        public DateTime MesReferencia { get; set; }
        public decimal SalarioBruto { get; set; }
        public decimal TotalDeDescontos { get; set; }
        public decimal SalarioLiquido { get; set; }
        public List<EntriesData> Lancamentos { get; set; }



    }

    public class EntriesData
    {
        public EEntriesType Tipo { get; set; }
        public decimal Valor { get; set; }
        public EDescriptionType Descricao { get; set; }
    }
}
