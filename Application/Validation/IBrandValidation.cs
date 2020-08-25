using Domain.Models;
using System.Threading.Tasks;

namespace Application.Validation
{
    public interface IBrandValidation
    {
        Task ValidateBeer(Beer beer);
    }
}
