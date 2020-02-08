using System;

namespace BullMarket.Web.Models
{
    public class Corretagem
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; } = DateTime.Today;
        public CorretoraEnum Corretora { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorAgora { get; set; }

        public decimal Diferenca
        {
            get
            {
                return ValorAgora - ValorCompra;
            }
        }

        public decimal PorcentagemRetorno
        {
            get
            {
                return ((ValorAgora * 100) / ValorCompra) / 100;
            }
        }

        public decimal ValorTotalCompra
        {
            get
            {
                return ValorCompra * Quantidade;
            }
        }

        public decimal ValorTotalAgora
        {
            get
            {
                return ValorAgora * Quantidade;
            }
        }

        public decimal LucroReal
        {
            get
            {
                return ValorTotalAgora - ValorTotalCompra;
            }
        }

        public decimal Custos { get; set; }
        public StatusEnum Status { get; set; }

        public int AcaoId { get; set; }
        public Empresa Acao { get; set; }
    }
}
