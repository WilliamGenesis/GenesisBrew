using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Application.Validation
{
    public interface IBrandValidation
    {
        Task ValidateBeerExists(Guid beerId);
        Task ValidateBeer(Beer beer);
    }
}
