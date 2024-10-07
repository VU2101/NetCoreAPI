using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models;
public class Dangnhap
{
    [Key]
    public string CCCD{get;set;}
    public string Hoten{get;set;}
    public string Quequan{get;set;}

}
