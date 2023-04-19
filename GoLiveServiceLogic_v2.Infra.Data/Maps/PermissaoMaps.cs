using GoLiveServiceLogic_v2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GoLiveServiceLogic_v2.Infra.Data.Maps
{
    public class PermissaoMaps : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.ToTable("TB_PERMISSAO");

            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Id).HasColumnName("SQ_PERMISSAO").UseIdentityColumn();

            builder.Property(x=>x.Description).HasColumnName("DC_DESCRICAO").IsRequired();

            builder.Property(x=>x.Active).HasColumnName("FL_ATIVO").IsRequired();
        }
    }
}
