﻿using EPiServer.Social.Comments.Core;
using EPiServer.SocialAlloy.Web.Social.Models;
using System.Collections.Generic;

namespace EPiServer.SocialAlloy.Web.Social.Repositories
{
    /// <summary>
    /// The IPageCommentRepository interface defines the operations that can be issued
    /// against a comment repository.
    /// </summary>
    public interface IPageCommentRepository
    {
        /// <summary>
        /// Adds a comment to the underlying comment repository.
        /// </summary>
        /// <param name="comment">The comment to add.</param>
        /// <returns>The added comment.</returns>
        PageComment Add(PageComment comment);

        /// <summary>
        /// Gets comments from the underlying comment repository based on a filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>A list of comments.</returns>
        IEnumerable<PageComment> Get(PageCommentFilter filter);
    }
}