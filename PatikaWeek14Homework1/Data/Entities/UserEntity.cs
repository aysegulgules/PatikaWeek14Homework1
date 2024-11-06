using PatikaWeek14Homework1.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaWeek14Homework1.Data.Entities
{
    public class UserEntity:BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
    }

    public class UserConfiguration : BaseConfiguration<UserEntity>
    {

        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(60);

           

            base.Configure(builder);
        }

    }
}
