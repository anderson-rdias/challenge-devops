using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SYMINATE.Models
{
    [Table("tb_diario")]
    public class Diario
    {
        [Column("Id")]
        [Display(Name = "Código de Identificação")]
        public int Id { get; set; }

        [Column("Sentimento")]
        [Display(Name = "Sentimento")]
        public string Nome { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Column("Data")]
        [Display(Name = "Data")]
        public string Data { get; set; }
    }
}
