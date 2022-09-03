namespace Domain.BaseDomainAgg
{
    public class DomainBase 
    {
        public string Id { get; private set; }
        public DateTime CreationDate  { get; private set; }

        public DomainBase()
        {
            Id = System.Guid.NewGuid().ToString();
            CreationDate = DateTime.Now;
        }
    }
}
