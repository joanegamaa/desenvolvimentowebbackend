
using System.ComponentModel.DataAnnotations;
using StrongFit.Models;

namespace StrongFit.Models
{
    public class Aluno
    {
        public int AlunoID { get; set; }
        public string? Nome { get; set; }

        [DataType(DataType.Date)] 
        public DateTime Data_Nascimento { get; set; }

        public string? E_Mail { get; set; }
        public string? Instagram { get; set; }
        public string? Telefone { get; set; }
        public string? Observacoes { get; set; }

        // Chave estrangeira
        public int PersonalID { get; set; }

        public virtual Personal? Personal { get; set; }
        public virtual ICollection<Treino>? Treinos { get; set; } = new List<Treino>();
    }
}
