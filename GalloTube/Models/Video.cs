using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GalloTube.Models;

[Table("Video")]
public class Video
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O Nome é obrigatório")]
    [StringLength(100, ErrorMessage = "O nome deve possuir no máximo 100 caracteres")]
    public string Name { get; set; }

    [Display(Name = "Descrição")]
    [Required(ErrorMessage = "A descrição é obrigatória")]
    [StringLength(8000, ErrorMessage = "A descrição deve possuir no máximo 5000 caracteres")]
    public string Description { get; set; }

    [Display(Name = "Duração (em minutos)")]
    [Required(ErrorMessage = "A Duração é obrigatória")]
    public Int16 Duration { get; set; }

    [StringLength(200)]
    [Display(Name = "Foto")]
    public string Thumbnail { get; set; }

    [StringLength(200)]
    [Display(Name = "Arquivo do vídeo")]
    public string  videofile{ get; set; }

    public DateTime UploadDate { get; set; }


    public ICollection<VideoTag> Tag { get; set; }
}