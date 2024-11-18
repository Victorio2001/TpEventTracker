using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EventTracker.Model
{
    public class EventModel
    {
        [JsonPropertyName("guid")]
        public string Guid { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("location")]
        public LocationModel Location { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("max_participants")]
        public int MaxParticipants { get; set; }

        [JsonPropertyName("current_participants")]
        public int CurrentParticipants { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("prize_pool")]
        public string PrizePool { get; set; }

        [JsonPropertyName("sponsors")]
        public List<string> Sponsors { get; set; }

        [JsonPropertyName("streaming_url")]
        public string StreamingUrl { get; set; }
    }
}