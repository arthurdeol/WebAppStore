using ModerStore.Infra.Contexts;

namespace ModerStore.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly ModernStoreDataContext _context;
        public Uow(ModernStoreDataContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RollBack()
        {
            //Do nothing
        }
    }
}
