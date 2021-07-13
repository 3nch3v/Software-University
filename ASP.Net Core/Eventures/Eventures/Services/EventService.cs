namespace Eventures.Services
{
    using System.Threading.Tasks;

    using Eventures.ViewModels;
    using System.Collections.Generic;
   
    public class EventService : IEventService
    {
        public Task CreateAsync(EventInputModel input)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<EventViewModel> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
