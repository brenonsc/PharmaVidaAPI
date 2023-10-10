using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using PharmaVida.Util;

namespace PharmaVida.Model;

public class Produto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    [Column(TypeName = "varchar")]
    [StringLength(100)]
    public string Titulo { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar")]
    [StringLength(100)]
    public string Fabricante { get; set; } = string.Empty;
    
    [Column(TypeName = "integer")]
    public int DosagemEmMg { get; set; }
    
    [Column(TypeName = "bit")]
    public bool PrecisaReceita { get; set; }
    
    [Column(TypeName = "date")]
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateTime DataVencimento { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }
}