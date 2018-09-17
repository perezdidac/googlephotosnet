// <copyright file="SharedAlbumOptions.cs" company="The Bald Labs">
// Copyright (c) The Bald Labs. All rights reserved.
// </copyright>

namespace TheBaldLabs.GooglePhotosNet
{
    using Newtonsoft.Json;

    /// <summary>
    /// Options that control the sharing of an album.
    /// </summary>
    public class SharedAlbumOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether the shared album allows collaborators (users who have joined
        /// the album) to add media items to it. Defaults to false.
        /// </summary>
        [JsonProperty(PropertyName = "isCollaborative")]
        public bool IsCollaborative { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the shared album allows the owner and the collaborators
        /// (users who have joined the album) to add comments to the album. Defaults to false.
        /// </summary>
        [JsonProperty(PropertyName = "isCommentable")]
        public bool IsCommentable { get; set; }
    }
}
