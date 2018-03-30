﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Find;
using EPiServer.Find.Api.Querying.Queries;
using EPiServer.Find.UnifiedSearch;
using EPiServer.ServiceLocation;

namespace EPiServer.SocialAlloy.Web.Business
{
    public static class FindExtensions
    {

        /// <summary>
        /// Adds category boosts to the search.
        /// </summary>
        /// <typeparam name="T">The type to query for.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="favoriteCategories">The categories to boost, with the boost factor.</param>
        /// <returns>The <see cref="IQueriedSearch{T}"/> with added BoostMatching.</returns>
        /// <remarks><para>The BoostMatching method must be called before any method not related to the search query (such as Filter, Take, and Skip).</para>
        /// <para>This is enforced by the fact that the For method in the above sample returns a IQueriedSearch object.</para>
        /// </remarks>
        public static IQueriedSearch<T> AddCategoryBoosts<T>(
            this IQueriedSearch<T> query,
            Dictionary<int, int> favoriteCategories)
            where T : ICategorizable
        {
            ////return query;
            return favoriteCategories.Aggregate(
                query,
                (current, favoriteCategory) => current.BoostMatching(x => x.Category.In(new[] { favoriteCategory.Key }), favoriteCategory.Value));
        } 
        
        public static ITypeSearch<ISearchContent> AddCategoryBoost(
            this ITypeSearch<ISearchContent> query,
            Dictionary<string, int> favoriteCategories)
        {
            return favoriteCategories.Aggregate(
                query,
                (current, favoriteCategory) => current.BoostMatching(x => x.SearchCategories.In(new[] { favoriteCategory.Key }), favoriteCategory.Value));
        }

        /// <summary>
        /// Adds content type boosts to the search.
        /// </summary>
        /// <typeparam name="T">The type to query for.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="favoriteUserContent">The content types to boost, with the boost factor.</param>
        /// <returns>The <see cref="IQueriedSearch{T}"/> with added BoostMatching.</returns>
        /// <remarks><para>The BoostMatching method must be called before any method not related to the search query (such as Filter, Take, and Skip).</para>
        /// <para>This is enforced by the fact that the For method in the above sample returns a IQueriedSearch object.</para>
        /// </remarks>
        public static IQueriedSearch<T> AddContentTypeBoosts<T>(
            this IQueriedSearch<T> query,
            Dictionary<int, int> favoriteUserContent)
            where T : IContent
        {
            ////return query;
            return favoriteUserContent.Aggregate(
                query,
                (current, favoriteContent) => current.BoostMatching(x => x.ContentTypeID.Match(favoriteContent.Key), favoriteContent.Value));
        }
    }
}