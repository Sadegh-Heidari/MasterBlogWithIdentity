﻿namespace MasterIdentity.Areas.Admin.Pages.User.Dto
{
    public class GetUserDto
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }    
        public short AccessFieldCount { get; set; }
    }
}
