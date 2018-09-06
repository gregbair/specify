namespace Specify
{
    public interface ISpecification<in TCandidate>
    {
        bool IsSatisfied(TCandidate candidate);
    }
}