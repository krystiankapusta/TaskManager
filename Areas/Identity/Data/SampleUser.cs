using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace Project_ToDoList.Areas.Identity.Data;

public class SampleUser : IdentityUser
{
    [Required]

    public String FirstName { get; set; } = string.Empty;
    [Required]

    public String LastName { get; set; } = string.Empty;
}

