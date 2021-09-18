namespace Eventures.Controllers
{
    using Eventures.Data;
    using Eventures.Services;
    using Eventures.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : Controller
    {
        private readonly IEventService eventService;
        private readonly EventuresDbContext dbContext;

        public EventsController(
            IEventService eventService, 
            EventuresDbContext dbContext)
        {
            this.eventService = eventService;
            this.dbContext = dbContext;
        }

        [Authorize]
        public IActionResult Events()
        {
            var allEvents = new AllEventsViewModel
            {
                Events = this.eventService.GetAll(),
            };

            return this.View(allEvents);
        }

        [Authorize]
        public IActionResult CreateEvent()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateEvent(EventInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            this.eventService.CreateAsync(input);

            return this.RedirectToAction(nameof(Events));
        }
    }
}
