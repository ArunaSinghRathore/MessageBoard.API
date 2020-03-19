using AutoMapper;
using MessageBoard.API.Core.ViewModels;
using MessageBoard.API.Data;
using MessageBoard.API.Interfaces;
using MessageBoard.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard.API.Services
{
    public class PostService : IPostService
    {
        private  AppDbContext dbContext;
        private IMapper _mapper;

        public PostService(AppDbContext _dbContext, IMapper mapper) {
            dbContext = _dbContext;
            _mapper = mapper;
        }
        public void CreateNewPost(CreatePostVM newPost)
        {
            Post createPost = _mapper.Map<Post>(newPost);
            dbContext.Posts.Add(createPost);
            dbContext.SaveChanges();
        }

        public ReadPostVM GetAllPosts(PagingParamsVM pagingParams)
        {
            var dbPosts =  dbContext.Posts
                .OrderByDescending(x=>x.PostDate)
                .Skip((pagingParams.PageIndex) * pagingParams.PageSize)
                .Take(pagingParams.PageSize).ToList();

            var postsCount = dbContext.Posts.Count();

            ReadPostVM posts = new ReadPostVM();
            posts.lstPosts = dbPosts;
            posts.PostsCount = postsCount;

            return posts;
        }
    }
}
