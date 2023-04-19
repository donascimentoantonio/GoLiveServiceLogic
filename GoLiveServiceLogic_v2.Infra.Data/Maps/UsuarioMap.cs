using GoLiveServiceLogic_v2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoLiveServiceLogic_v2.Infra.Data.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USUARIO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("SQ_USUARIO").UseIdentityColumn();

            builder.Property(x => x.Name).HasColumnName("DC_NAME").IsRequired();
            builder.Property(x => x.Email).HasColumnName("DC_EMAIL");
            builder.Property(x => x.Job).HasColumnName("DC_OCUPACAO");
            builder.Property(x => x.CreateDate).HasColumnName("DT_CREATE").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Active).HasColumnName("FL_ATIVO").HasDefaultValue(true);
        }
    }
}
