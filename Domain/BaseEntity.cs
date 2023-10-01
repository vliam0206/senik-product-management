using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class BaseEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public int? CreatedBy { get; set; }
    public DateTime? ModificationDate { get; set; } = DateTime.Now;
    public int? ModifiedBy { get; set; }
    public DateTime? DeletionDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}
