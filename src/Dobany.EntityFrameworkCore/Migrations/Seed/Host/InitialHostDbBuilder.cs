using Dobany.EntityFrameworkCore;

namespace Dobany.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly DobanyDbContext _context;

        public InitialHostDbBuilder(DobanyDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
