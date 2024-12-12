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
            //Fluent API can be used here to specify additional requirements on entities, like FK, rename...
            builder.Property(f => f.Name)
                .IsRequired() 
                .HasMaxLength(50);
        }
        
    }
}