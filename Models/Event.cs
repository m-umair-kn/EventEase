using System;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Event name is required")]
        [StringLength(100, ErrorMessage = "Event name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Event location is required")]
        [StringLength(200, ErrorMessage = "Location cannot exceed 200 characters")]
        public string Location { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;

        public int MaxAttendees { get; set; }

        public int CurrentAttendees { get; set; }

        public bool IsRegistrationOpen => CurrentAttendees < MaxAttendees;
    }
}
