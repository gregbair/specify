using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace Specify.Tests
{
    public class SpecificationContainerTests
    {
        [Fact]
        public void ConstructorThrowsNullList()
        {
            Assert.Throws<ArgumentNullException>("specifications",
                () => new SpecificationContainer<string>((List<ISpecification<string>>) null));
        }

        [Fact]
        public void IsSatisfiedCallsSpecs()
        {
            const string candidate = "foo";
            var mock = new Mock<ISpecification<string>>();
            mock.Setup(x => x.IsSatisfied(candidate)).Returns(false);
            
            var sut = new SpecificationContainer<string>(mock.Object);
            
            Assert.False(sut.IsSatisfied(candidate));
            
            mock.Verify(x=>x.IsSatisfied(candidate),Times.Once);
        }
    }
}