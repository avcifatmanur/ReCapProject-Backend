﻿using Core.Entities;

namespace Entities.DTOs
{
    public class UserForRegisterDto:IDto
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
