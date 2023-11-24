using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.DAL.Entities.Base;

public class BaseEntity<T> where T : struct
{
    [Key]
    public T Id { get; set; }
}