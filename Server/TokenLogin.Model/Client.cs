using System;

namespace MailOnRails.Model
{
    [Serializable]
    public class Client
    {
        public bool Active { get; set; }
        public string AllowedOrigin { get; set; }

        public int ApplicationTypeId { get; set; }
        public ApplicationTypes ApplicationType { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        public string Secret { get; set; }
    }
}