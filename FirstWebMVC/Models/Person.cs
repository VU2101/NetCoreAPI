using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FirstWebMVC.Models;

[Table("Persons")]
public class Person
{
   

    [Key]

    public string? PersonId{get;set;}
    public string? FullName{get;set;}
    public string? Address{get;set;}
}