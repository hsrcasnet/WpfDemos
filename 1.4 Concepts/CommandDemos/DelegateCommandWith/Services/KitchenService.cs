using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DelegateCommandWith.Model;

namespace DelegateCommandWith.Services
{
    public class KitchenService : IKitchenService
    {
        public async Task<MealDto> PrepareMeal(int numberOfPersons)
        {
            await Task.Delay(2000);
            return new MealDto { Id = 1, Name = "Rindsgschnätzletzs" };
        }
    }
}