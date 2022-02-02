using TaleEngine.Domain.Models;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface IEditionService
    {
        Edition GetById(int id);
        int GetCurrentOrLastEdition(int selectedEvent);
    }
}
