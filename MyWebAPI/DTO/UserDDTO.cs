﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyWebAPI
{
    public class UserDTO
    { 
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("status")]
        public bool Status { get; set; }
    }
}
