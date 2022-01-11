namespace TLA.Infrastructure.GuidIdentifiers
{
    public interface IGuidProvider
    {
        Guid CreateNew();
    }

    public class GuidProvider : IGuidProvider
    {
        public Guid CreateNew() => Guid.NewGuid();
    }
}
