using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using EFConsole9.View;

namespace EFConsole9.ViewMap
{
    public class DonatorViewInfoMap : EntityTypeConfiguration<DonatorViewInfo>
    {
        public DonatorViewInfoMap()
        {
            HasKey(d => d.DonatorId);
            ToTable("DonatorView");
        }
    }
}
