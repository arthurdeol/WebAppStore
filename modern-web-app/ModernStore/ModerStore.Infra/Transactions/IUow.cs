namespace ModerStore.Infra.Transactions
{
    public interface IUow
    {
        void Commit();
        void RollBack();
    }
}
