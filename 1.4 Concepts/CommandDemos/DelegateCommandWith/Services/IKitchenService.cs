using System.Collections.Generic;
using System.Threading.Tasks;
using DelegateCommandWith.Model;

namespace DelegateCommandWith.Services
{
    public interface IKitchenService
    {
        Task<MealDto> PrepareMeal(int numberOfPersons);
    }
}