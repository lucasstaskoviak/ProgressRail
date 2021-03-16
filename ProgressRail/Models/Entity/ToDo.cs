using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressRail.Models.Entity
{
    [Table("ToDo")]
    public class ToDo
    {
        [Display(Description="Identificador")]
        public int Id { get; set; }

        [Display(Description = "Nome da atividade")]
        public string Name { get; set; }

        [Display(Description = "Data")]
        public DateTime Date { get; set; }

        [Display(Description = "Concluído")]
        public bool Finished { get; set; }
    }
}
