﻿using DomainServices.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Article.DTO
{
    public class GetArticleDto: IGetArticleDto
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? Image { get; set; }
        public string? Content { get; set; }
    }
}
