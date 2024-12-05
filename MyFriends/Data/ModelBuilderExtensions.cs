using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFriends.Models;
using Microsoft.EntityFrameworkCore;
namespace MyFriends.Data;
public static class ModelBuilderExtensions
{
      public static ModelBuilder Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Friend>().HasData(
            new Friend { Id = 1, Name = "John Doe", Age = 25 },
            new Friend { Id = 2, Name = "Jane Smith", Age = 30 },
            new Friend { Id = 3, Name = "Michael Johnson", Age = 45 },
            new Friend { Id = 4, Name = "Emily Davis", Age = 22 },
            new Friend { Id = 5, Name = "David Wilson", Age = 34 },
            new Friend { Id = 6, Name = "Sarah Brown", Age = 28 },
            new Friend { Id = 7, Name = "Chris Evans", Age = 33 },
            new Friend { Id = 8, Name = "Olivia Martinez", Age = 27 },
            new Friend { Id = 9, Name = "Liam Lee", Age = 24 },
            new Friend { Id = 10, Name = "Sophia Harris", Age = 29 }
        );
        return modelBuilder;
    }  
}
