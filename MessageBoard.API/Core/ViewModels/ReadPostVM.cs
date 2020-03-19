using MessageBoard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard.API.Core.ViewModels
{
    public class ReadPostVM
    {
        public IEnumerable<Post> lstPosts { get; set; }
        public int PostsCount { get; set; }
    }
}
