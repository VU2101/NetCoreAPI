using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Person 
    {
    [Key]
    public string PersonID { get; set; }
    public string Hoten { get; set; }
    public string Quequan { get; set; }
    }
}
