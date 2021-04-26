﻿using BlogsNTags.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogsNTags.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService tagService;

        public TagsController(ITagService _tagService)
        {
            tagService = _tagService;
        }

        public ActionResult<List<SharedModels.Tag>> GetTags()
        {
            throw new NotImplementedException();
        }
    }
}
