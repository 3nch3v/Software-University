using Eventures.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventures.Services
{
    public interface IEventService
    {
        void CreateAsync(EventInputModel input);

        ICollection<EventViewModel> GetAll();
    }
}
