// <copyright file="ListAlbumsResponse.cs" company="The Bald Labs">
// Copyright (c) The Bald Labs. All rights reserved.
// </copyright>

namespace TheBaldLabs.GooglePhotosNet
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the response to the ListAlbums API.
    /// </summary>
    public class ListAlbumsResponse
    {
        /// <summary>
        /// Gets or sets the list of albums shown in the Albums tab of the user's Google Photos app.
        /// </summary>
        [JsonProperty(PropertyName = "albums")]
        public IEnumerable<Album> Albums { get; set; }

        /// <summary>
        /// Gets or sets the token to use to get the next set of albums. Populated if there are more albums to retrieve
        /// for this request.
        /// </summary>
        [JsonProperty(PropertyName = "nextPageToken")]
        public string NextPageToken { get; set; }
    }
}
