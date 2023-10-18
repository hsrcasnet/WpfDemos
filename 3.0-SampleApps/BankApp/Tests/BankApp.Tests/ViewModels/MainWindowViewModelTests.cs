using BankApp.ViewModels;
using FluentAssertions;
using Xunit;

namespace BankApp.Tests.ViewModels
{
    public class MainWindowViewModelTests
    {
        [Fact]
        public void ShouldCreateViewModel()
        {
            // Act
            var mainWindowViewModel = new MainWindowViewModel();

            // Assert
            mainWindowViewModel.Title.Should().NotBeNullOrEmpty();
        }
    }
}
