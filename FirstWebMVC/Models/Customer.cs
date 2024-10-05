using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FirstWebMVC.Models;

public class Customer
{
   

    [Key]
    [Required(ErrorMessage ="Khong duoc de trong")]
    public string? Hoten{get;set;}
    [MinLength(3)]
    [Required(ErrorMessage = "khong duoc de trong")]
    public string? diachi{get;set;}
    [DataType(DataType.EmailAddress)]
    public string? Email{get;set;}

}