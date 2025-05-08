using Microsoft.EntityFrameworkCore;

namespace API_Har2
{
    public class QuestDB : DbContext
    {
        public QuestDB(DbContextOptions<QuestDB> options)
            : base(options) { }

        public DbSet<Quest> Quests => Set<Quest>();
    }
}
