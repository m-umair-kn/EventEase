using EventEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventEase.Services
{
    public class EventService
    {
        private List<Event> _events;

        public EventService()
        {
            // Initialize with mock data
            _events = new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Name = "Annual Tech Conference",
                    Date = DateTime.Now.AddDays(30),
                    Location = "Seattle Convention Center",
                    Description = "Join us for the biggest tech event of the year featuring keynotes from industry leaders.",
                    MaxAttendees = 500,
                    CurrentAttendees = 350
                },
                new Event
                {
                    Id = 2,
                    Name = "Business Networking Mixer",
                    Date = DateTime.Now.AddDays(15),
                    Location = "Downtown Business Club",
                    Description = "Connect with professionals from various industries in a relaxed setting.",
                    MaxAttendees = 100,
                    CurrentAttendees = 65
                },
                new Event
                {
                    Id = 3,
                    Name = "Product Launch Party",
                    Date = DateTime.Now.AddDays(7),
                    Location = "Innovation Hub",
                    Description = "Be the first to experience our revolutionary new product line.",
                    MaxAttendees = 200,
                    CurrentAttendees = 190
                },
                new Event
                {
                    Id = 4,
                    Name = "Career Fair",
                    Date = DateTime.Now.AddDays(45),
                    Location = "University Campus",
                    Description = "Meet with recruiters from top companies across various industries.",
                    MaxAttendees = 1000,
                    CurrentAttendees = 250
                },
                new Event
                {
                    Id = 5,
                    Name = "Charity Gala Dinner",
                    Date = DateTime.Now.AddDays(60),
                    Location = "Grand Hotel Ballroom",
                    Description = "An elegant evening supporting local community initiatives.",
                    MaxAttendees = 300,
                    CurrentAttendees = 120
                }
            };
        }

        public Task<List<Event>> GetEventsAsync()
        {
            // Simulate async operation
            return Task.FromResult(_events);
        }

        public Task<Event> GetEventByIdAsync(int id)
        {
            var @event = _events.FirstOrDefault(e => e.Id == id);
            if (@event == null)
            {
                throw new KeyNotFoundException($"Event with ID {id} not found");
            }
            return Task.FromResult(@event);
        }

        public Task<bool> RegisterForEventAsync(int eventId)
        {
            var @event = _events.FirstOrDefault(e => e.Id == eventId);
            if (@event == null)
            {
                return Task.FromResult(false);
            }

            if (@event.CurrentAttendees < @event.MaxAttendees)
            {
                @event.CurrentAttendees++;
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
