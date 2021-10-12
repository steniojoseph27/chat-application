using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ChatApp.Data.Entities
{
    public class User : IdentityUser
    {
        public ICollection<ChatUser> Chats {get; set;}
    }
}