﻿namespace UserService.Models.Dto
{
    public class MailSettings
    {
        public string DisplayName { get; set; }
        public string SenderEmail { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }

}
