using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBoard.API.Core.ViewModels;
using MessageBoard.API.Interfaces;
using MessageBoard.API.Models;
using MessageBoard.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace MessageBoard.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageBoardController : ControllerBase
    {
        private IPostService _postService;
        private IHubContext<MessageHub> _messageHub;
        private MessageHub _hub;

        public MessageBoardController(IPostService postService, IHubContext<MessageHub> messageHub)
        {
            _postService = postService;
            _messageHub = messageHub;
           
        }

        public IPostService PostService { get; }

        [HttpGet]
        public ReadPostVM Get([FromQuery] PagingParamsVM pagingParams)
        {
            return _postService.GetAllPosts(pagingParams);
        }     

        [HttpPost]        
        public bool SubmitPost(CreatePostVM newPost)
        {
            _postService.CreateNewPost(newPost);          
            _messageHub.Clients.All.SendAsync("sendToClient", newPost);
            return true;
        }
    }

}
