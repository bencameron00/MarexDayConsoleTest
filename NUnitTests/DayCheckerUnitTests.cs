using MarexDayTest;
using MarexDayTest.Interfaces;
using Moq;
using NUnitTests.TestTimeProviders;

namespace NUnitTests
{
    public class Tests
    {
        [Test]
        public void TestDayOfWeekEqualsTuesday()
        {
            // Arrange
            Mock<ILongRunningLib> longRunningLibMock = new();

            DayChecker dc = new(longRunningLibMock.Object, new TuesdayTimeProvider());

            // Act
            DayOfWeek? result = dc.CheckDay();

            // Assert
            longRunningLibMock.Verify(m => m.SomeLongRunningThirdPartyTask(), Times.Once);
            Assert.That(result, Is.EqualTo(DayOfWeek.Tuesday)); 
        }

        [Test]
        public void TestDayOfWeekEqualsWednesdayAkaNull()
        {
            // Arrange
            Mock<ILongRunningLib> longRunningLibMock = new();

            DayChecker dc = new(longRunningLibMock.Object, new WednesdayTimeProvider());

            // Act
            DayOfWeek? result = dc.CheckDay();

            // Assert
            longRunningLibMock.Verify(m => m.SomeLongRunningThirdPartyTask(), Times.Never);
            Assert.That(result, Is.Null);
        }
    }
}
