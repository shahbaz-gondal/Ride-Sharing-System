namespace RSS.Data.Interfaces
{
    public interface IUnitOfWork
    {        
        public IOfferRepository offers { get; }
        public IRequestRepository requests { get; }
        public IUserRepository users { get; }

        public int Save();
    }
}
