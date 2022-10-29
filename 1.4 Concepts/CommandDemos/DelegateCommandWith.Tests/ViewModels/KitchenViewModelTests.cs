using DelegateCommandWith.Model;
using DelegateCommandWith.Services;
using DelegateCommandWith.ViewModels;
using Moq;
using Xunit;

namespace DelegateCommandWith.Tests.ViewModels
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

            var kitchenViewModel = new KitchenViewModel(kitchenServiceMock.Object, dialogServiceMock.Object);

            // Act
            kitchenViewModel.CookDinnerCommand.Execute(null);

            // Assert
            Assert.False(kitchenViewModel.IsCooking);

            kitchenServiceMock.Verify(s => s.PrepareMeal(It.IsAny<int>()), Times.Once);
            kitchenServiceMock.VerifyNoOtherCalls();

            dialogServiceMock.Verify(d => d.ShowMessageBox("Finished cooking: TestDöner is ready!"), Times.Once);
            dialogServiceMock.VerifyNoOtherCalls();
        }
    }
}
