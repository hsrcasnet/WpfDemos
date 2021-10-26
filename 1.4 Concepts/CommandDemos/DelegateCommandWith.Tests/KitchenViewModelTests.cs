using DelegateCommandWith.Model;
using DelegateCommandWith.Services;
using DelegateCommandWith.ViewModels;
using Moq;
using Xunit;

namespace DelegateCommandWith.Tests
{
    public class KitchenViewModelTests
    {
        [Fact]
        public void ShouldPrepareMeal_IfCookDinnerCommandIsExecuted()
        {
            // Arrange
            var kitchenServiceMock = new Mock<IKitchenService>();
            kitchenServiceMock.Setup(s => s.PrepareMeal(It.IsAny<int>()))
                .ReturnsAsync(new MealDto { Id = 1, Name = "TestDöner" });

            var dialogServiceMock = new Mock<IDialogService>();
            dialogServiceMock.Setup(d => d.ShowMessageBox(It.IsAny<string>()));

            var kitchenViewModel = new KitchenViewModel(kitchenServiceMock.Object, dialogServiceMock.Object);

            // Act
            kitchenViewModel.CookDinnerCommand.Execute(null);

            // Assert
            Assert.False(kitchenViewModel.IsCooking);

            kitchenServiceMock.Verify(s => s.PrepareMeal(It.IsAny<int>()), Times.Once);
            dialogServiceMock.Verify(d => d.ShowMessageBox(It.Is<string>(msg => msg == "Finished cooking: TestDöner is ready!")), Times.Once);
        }
    }
}
