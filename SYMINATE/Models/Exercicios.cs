using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SYMINATE.Models
{
    [Table("tb_exercicio")]
    public class Exercicios
    {
        [Column("Id")]
        [Display(Name = "Código de Identificação")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome do Exercício")]
        public string Nome { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Column("QtdHoras")]
        [Display(Name = "Duração")]
        public int QtdHoras { get; set; }
    }
}
