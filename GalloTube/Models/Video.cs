using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GalloTube.Models;

public class Video
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(8000)]
    public string Description { get; set; }

    [Required]
    public DateTime UploadDate { get; set; }

    [Required]
    public Int16 Duration { get; set; }

    [StringLength(200)]
    public string Thumbnail { get; set; }

    [Required]
    [StringLength(200)]
    public string VideoFile { get; set; }

    [NotMapped]
    public string HourDuration { get {
        return TimeSpan.FromMinutes(Duration).ToString(@"%h'h 'mm'min'");
    } }

    [NotMapped]
    public List<Tag> Tags { get; set; }
}