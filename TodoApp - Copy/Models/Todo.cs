using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TodoApp.Models
{
    public class Todo
    {
    public int Id { get; set; }

    [Required]
    public IdentityUser Owner { get; set; }= null!;

    [Required]
    [StringLength(200, MinimumLength = 1)]
    public required string Task { get; set; }

    [Required]
    [Range(typeof(DateTime), "2000-01-01", "2099-12-31", ErrorMessage = "DueDate must be between 2000 and 2099.")]
    public DateTime DueDate { get; set; }
    public bool IsDone { get; set; }
    }
}