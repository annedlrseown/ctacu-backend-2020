using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MyFirstApi.DataLayer;
using MyFirstApi.Domain.Interfaces;
using Unity;
using Xunit;

namespace MyFirstApi.Services.UnitTests
{
    public class ValueServiceUnitTests
    {
        private IValueService _serviceUnderTest;
        private Mock<IValueStorage> _mockedValueStorage;

        public ValueServiceUnitTests()
        {
            var container = UnityConfig.Container;

            _mockedValueStorage = new Mock<IValueStorage>();
            container.RegisterInstance(_mockedValueStorage.Object);

            _serviceUnderTest = container.Resolve<IValueService>();
        }

        public class GetValues : ValueServiceUnitTests
        {
            [Fact]
            public void WHEN_GetValues_is_called_THEN_correct_data_returned()
            {
                // Arrange
                _mockedValueStorage
                    .Setup(x => x.GetValues())
                    .Returns(new List<string>
                    {
                        "One",
                        "Two"
                    });

                // Act
                var actual = _serviceUnderTest.GetValues();

                // Assert
                var expected = new List<string>
                {
                    "ONE",
                    "TWO"
                };
                Assert.Equal(expected, actual);
            }


            [Fact]
            public void GIVEN_no_values_WHEN_GetValues_is_called_THEN_Exception_thrown()
            {
                // Arrange
                _mockedValueStorage
                    .Setup(x => x.GetValues())
                    .Returns(new List<string>());

                // Act
                var actual = Assert.Throws<Exception>(() => _serviceUnderTest.GetValues());

                // Assert
                var expected = new Exception("No values found");
                Assert.Equal(expected.Message, actual.Message);
            }
        }
    }
}
