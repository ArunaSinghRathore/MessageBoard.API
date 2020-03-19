using MessageBoard.API.Models;
using MessageBoard.API.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard.API.Interfaces { 
   public interface IPostService
    {
        public ReadPostVM GetAllPosts(PagingParamsVM pagingParams);
        public void CreateNewPost(CreatePostVM newPost);
    }
}
