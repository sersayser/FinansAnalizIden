using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models
{
    public class Help
    {
        
        [Key]
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string ProblemDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        [Required]
        [MaxLength(80, ErrorMessage = "En fazla 80 karakter olmalıdır")]
        public string Subject { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "En fazla 500 karakter olmalıdır")]
        public string Problem { get; set; }
        public string Solution { get; set; }
        public bool IsSolved { get; set; } = false;
        public string SolvingDate { get; set; } = null;
    }
}
