using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Models {
    public class Transação {
        public int Id { get; set; }
        public float Valor { get; set; }
        public string Identificacao { get; set; }
        public string? Descricao { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime Data { get; set; }
    }
}
