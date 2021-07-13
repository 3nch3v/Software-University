﻿namespace Eventures.Controllers
{
    using Eventures.Services;
    using Eventures.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : Controller
    {
        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [Authorize]
        public IActionResult Events()
        {
            return this.View();
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

            //this.eventService.CreateAsync(input);

            return this.RedirectToAction(nameof(Events));
        }
    }
}
