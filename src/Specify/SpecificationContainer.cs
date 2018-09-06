using System;
using System.Collections.Generic;
using System.Linq;

namespace Specify
{
    public class SpecificationContainer<TCandidate> : ISpecification<TCandidate>
    {
        private readonly List<ISpecification<TCandidate>> _specifications;

        public SpecificationContainer(List<ISpecification<TCandidate>> specifications) => _specifications =
            specifications ?? throw new ArgumentNullException(nameof(specifications));

        public SpecificationContainer(params ISpecification<TCandidate>[] specifications)
            : this(specifications.ToList())
        {
        }

        public SpecificationContainer() 
            : this(Array.Empty<ISpecification<TCandidate>>())
        {
        }

        public void AddSpecification(ISpecification<TCandidate> specification) =>
            _specifications.Add(specification ?? throw new ArgumentNullException(nameof(specification)));

        public bool IsSatisfied(TCandidate candidate)
        {
            return _specifications.All(x => x.IsSatisfied(candidate));
        }
    }
}