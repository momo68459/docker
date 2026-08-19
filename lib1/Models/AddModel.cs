using System.ComponentModel.DataAnnotations;

public class AddModel
{
    [Display(Name="第一個數字")]   
    [Required(ErrorMessage = "No1 不可空白")]
    public int? No1{get; set;}

    [Display(Name="第二個數字")] 
    [Required(ErrorMessage = "No2 不可空白")]
    public int? No2 {get; set;}

    public int? Answer{get; set;}
}