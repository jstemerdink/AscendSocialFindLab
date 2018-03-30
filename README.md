# AscendSocialFindLab

This is the lab I gave in Las Vegas for Ascend 2018.

Don't forget to add your own demo credentials for Find and Social, as you will need them to run the site.

### Instructions for the lab

*	Run the website. (UN: AscendAdmin PW: Ascend20!7)
*	Add some rating blocks to different pages in edit mode.
*	Rate some pages in the frontend.
*	Search for e.g. Alloy.  Maybe write down, or remember the First search results.
*	Update the GetTopRatedPagesForUser method in “EPiServer.SocialAlloy.Web\Social\Repositories\Ratings\PageRatingRepository.cs” to retrieve the top 25 pages the user has rated. You can use the rating service and the content repository for that. 
    *	Get a Reference for the user
    *	Use the RatingFilter
    *	Social gives you the content GUID’s back, so you’ll need to get the actual content from the content repository.
*	Update the GetFavoriteCategoryNamesForUser method in the “EPiServer.SocialAlloy.Web\Social\Repositories\Ratings\PageRatingRepository.cs” to retrieve a dictionary with category names and how many times it has been rated by the user. 
    *	Use the results from the above method 
    *	Use the category repository.
*	Update the AddCategoryBoost(this ITypeSearch<ISearchContent> query,  Dictionary<string, int> favoriteCategories) method in “EPiServer.SocialAlloy.Web\Business\FindExtensions.cs” to add BoostMatching for the categories to the query.
*	In “EPiServer.SocialAlloy.Web\Controllers\FindSearchPageController.cs” add the extension method to the query. The order of the results should change. If the changes are to subtle, you can always multiply the boost factor in the extension method with e.g. 50
*	Run the website.
*	Search for e.g. Alloy. Notice that pages with the same categories as the pages you liked will appear higher in the search results.

Completed files are found here: [Solution Files](https://github.com/jstemerdink/AscendSocialFindLab/blob/master/Solution%20Files/README.md)


> *Powered by ReSharper*
> [![image](https://i0.wp.com/jstemerdink.files.wordpress.com/2017/08/logo_resharper.png)](http://jetbrains.com)
