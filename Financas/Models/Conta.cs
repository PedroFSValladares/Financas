using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Models {
    public class Conta {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public float Saldo { get; set; }
        [NotMapped]
        public float TotalDeDespesas { get; set; }
        [NotMapped]
        public float BalançoDeSaldoComDespesa { get; set; }

        public List<Transação>? Transacoes { get; set; }
        public List<Despesa>? Despesas { get; set; }
        public List<Meta>? Metas { get; set; }
    }
}
