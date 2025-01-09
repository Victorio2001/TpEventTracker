using System.ComponentModel.DataAnnotations;

namespace EventTracker.WebUI.Models
{
    public class EventViewModel
    {
        [Required]
        [StringLength(30)]
        public string? Guid { get; set; }

        [Required]
        [StringLength(30)]
        public string? Slug { get; set; }

        [Required]
        [StringLength(30)]
        public string? Name { get; set; }

        [Required]
        [StringLength(30)]
        public DateTime? Date { get; set; }


        public LocationModel? Location { get; set; }

   
        public string? Description { get; set; }

  
        public int? MaxParticipants { get; set; }

    
        public int? CurrentParticipants { get; set; }

 
        public string? Status { get; set; }

        public List<string>? Tags { get; set; }

    
        public string? PrizePool { get; set; }

 
        public List<string>? Sponsors { get; set; }


        public string? StreamingUrl { get; set; }
    }
}