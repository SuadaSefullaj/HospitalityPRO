using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HumanResourceProject.Models
{
    public partial class Client
    {
        public Client()
        {
            NotificationReceiverClients = new HashSet<Notification>();
            NotificationSenderClients = new HashSet<Notification>();
            Reservations = new HashSet<Reservation>();
            RefreshTokens = new HashSet<RefreshToken>(); // Added for refresh tokens
        }

        public int ClientId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime Birth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Role { get; set; } = "Client";
        public DateTime LastLogin { get; set; }

        [JsonIgnore]
        public byte[] PasswordHash { get; set; } = null!;

        [JsonIgnore]
        public byte[] PasswordSalt { get; set; } = null!;

        public virtual ICollection<Notification> NotificationReceiverClients { get; set; }
        public virtual ICollection<Notification> NotificationSenderClients { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
