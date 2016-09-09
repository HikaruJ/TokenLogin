using System;
using System.ComponentModel.DataAnnotations;

namespace MailOnRails.Model
{
    public enum ApplicationTypes
    {
        JavaScript = 0,
        NativeConfidential = 1
    };

    public class RefreshToken
    {
        public string ClientId { get; set; }
        public DateTime ExpiresUtc { get; set; }
        public string Id { get; set; }
        public DateTime IssuedUtc { get; set; }
        public string ProtectedTicket { get; set; }
        public string Subject { get; set; }
    }
}