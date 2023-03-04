using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Models {
    public class Despesa {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Valor { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime DataCobranca { get; set; }
        public int QntdParcelas { get; set; }
    }
}
