using MyFriends.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFriends.Models;

namespace MyFriends.Data
{
    public class FriendConfiguration: IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.Property(f => f.Name)
                .IsRequired() 
                .HasMaxLength(50);
        }
        
    }
}