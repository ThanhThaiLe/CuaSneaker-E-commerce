using Microsoft.EntityFrameworkCore;

namespace software.database.Provider
{
    public partial class SoftwareDefautTable : DbContext
    {
        public SoftwareDefautTable(DbContextOptions<SoftwareDefautTable> options)
          : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            erpTableBuilder(builder);
            systemTableBuilder(builder);
            OnModelCreatingPartial(builder);
        }
        partial void OnModelCreatingPartial(ModelBuilder builder);
    }
}
