﻿namespace ClinicService.Models.Requests
{
    public class CreatePetsRequest
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }
    }
}
