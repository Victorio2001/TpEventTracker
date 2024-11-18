using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EventTracker.Model
{
    public class LocationModel
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("postalcode")]
        public string? PostalCode { get; set; }

        [JsonPropertyName("capacity")]
        public int? Capacity { get; set; }
    }
}