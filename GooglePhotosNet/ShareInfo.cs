// <copyright file="ShareInfo.cs" company="The Bald Labs">
// Copyright (c) The Bald Labs. All rights reserved.
// </copyright>

namespace TheBaldLabs.GooglePhotosNet
{
    using Newtonsoft.Json;

    /// <summary>
    /// Information about albums that are shared. This information is only included if you created the album, it is
    /// shared and you have the sharing scope.
    /// </summary>
    public class ShareInfo
    {
        /// <summary>
        /// Gets or sets the options that control the sharing of an album.
        /// </summary>
        [JsonProperty(PropertyName = "sharedAlbumOptions")]
        public SharedAlbumOptions SharedAlbumOptions { get; set; }

        /// <summary>
        /// Gets or sets a link to the album that's now shared on the Google Photos website and app. Anyone with the
        /// link can access this shared album and see all of the items present in the album.
        /// </summary>
        [JsonProperty(PropertyName = "shareableUrl")]
        public string ShareableUrl { get; set; }

        /// <summary>
        /// Gets or sets a token that can be used by other users to join this shared album via the API.
        /// </summary>
        [JsonProperty(PropertyName = "shareToken")]
        public string ShareToken { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user has joined the album. This is always true for the
        /// owner of the shared album.
        /// </summary>
        [JsonProperty(PropertyName = "isJoined")]
        public bool IsJoined { get; set; }
    }
}
