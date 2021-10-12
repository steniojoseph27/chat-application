
using System.Linq;
using ChatApp.Data;
using ChatApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ChatApp.Infrastructure;
using ChatApp.Infrastructure.Repository;
using Microsoft.AspNetCore.SignalR;
using ChatApp.Hubs;

namespace ChatApp.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IChatRepository _repo;

        public HomeController(IChatRepository repo) => _repo = repo;

        public IActionResult Index()
        {
            var chats = _repo.GetChats(GetUserId());

            return View(chats);
        }

        [HttpGet("{id}")]
        public IActionResult Chat(int id)
        {
            return View(_repo.GetChat(id));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateRoom(string name)
        {
            await _repo.CreateRoom(name, GetUserId());

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> JoinRoom(int id)
        {
            await _repo.JoinRoom(id, GetUserId());

            return RedirectToAction("Chat", "Home", new { id = id });
        }

        public async Task<IActionResult> SendMessage(
            int roomId,
            string message,
            [FromServices] IHubContext<ChatHub> chat)
        {
            var Message = await _repo.CreateMessage(roomId, message, User.Identity.Name);

            await chat.Clients.Group(roomId.ToString())
                .SendAsync("RecieveMessage", new
                {
                    Text = Message.Text,
                    Name = Message.Name,
                    Timestamp = Message.Timestamp.ToString("yyyy/mm/dd hh:mm:ss")
                });
            return Ok();
        }
    }

}

