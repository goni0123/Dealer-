﻿namespace CarDealerApi.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] salt { get; set; }
        public bool Role { get; set; }
    }
}
