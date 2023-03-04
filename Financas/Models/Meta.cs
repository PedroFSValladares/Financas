namespace Financas.Models {
    public class Meta {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
        public Prioridade Prioridade { get; set; }
        public bool Realizada { get; set; }
    }
}
