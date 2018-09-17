// <copyright file="Album.cs" company="The Bald Labs">
// Copyright (c) The Bald Labs. All rights reserved.
// </copyright>

namespace TheBaldLabs.GooglePhotosNet
{
    using Newtonsoft.Json;

    /// <summary>
    /// Representation of an album in Google Photos. Albums are containers for media items. If an album has been
    /// shared by the application, it contains an extra shareInfo property.
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Gets or sets the identifier for the album. This is a persistent identifier that can be used between
        /// sessions to identify this album.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the album displayed to the user in their Google Photos account. This string
        /// shouldn't be more than 500 characters.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Google Photos URL for the album. The user needs to be signed in to their Google Photos
        /// account to access this link.
        /// </summary>
        [JsonProperty(PropertyName = "productUrl")]
        public string ProductUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether you can create media items in this album. This field is based on
        /// the scopes granted and permissions of the album. If the scopes are changed or permissions of the album are
        /// changed, this field is updated.
        /// </summary>
        [JsonProperty(PropertyName = "isWriteable")]
        public bool IsWriteable { get; set; }

        /// <summary>
        /// Gets or sets information related to shared albums. This field is only populated if the album is a shared
        /// album, the developer created the album and the user has granted the 'photoslibrary.sharing' scope.
        /// </summary>
        [JsonProperty(PropertyName = "shareInfo")]
        public ShareInfo ShareInfo { get; set; }

        /// <summary>
        /// Gets or sets the number of media items in the album.
        /// </summary>
        [JsonProperty(PropertyName = "mediaItemsCount")]
        public string MediaItemsCount { get; set; }

        /// <summary>
        /// Gets or sets a URL to the cover photo's bytes. This shouldn't be used as is. Parameters should be appended
        /// to this URL before use. For example, '=w2048-h1024' sets the dimensions of the cover photo to have a width
        /// of 2048 px and height of 1024 px.
        /// </summary>
        [JsonProperty(PropertyName = "coverPhotoBaseUrl")]
        public string CoverPhotoBaseUrl { get; set; }

        /// <summary>
        /// Gets or sets an identifier for the media item associated with the cover photo.
        /// </summary>
        [JsonProperty(PropertyName = "coverPhotoMediaItemId")]
        public string CoverPhotoMediaItemId { get; set; }
    }
}
