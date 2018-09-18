// <copyright file="GooglePhotosClient.cs" company="The Bald Labs">
// Copyright (c) The Bald Labs. All rights reserved.
// </copyright>

namespace TheBaldLabs.GooglePhotosNet
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Newtonsoft.Json;

    /// <summary>
    /// Client class to interact with the Google Photos Library API.
    /// </summary>
    public class GooglePhotosClient
    {
        private const string ListAlbumsUrl = "https://photoslibrary.googleapis.com/v1/albums?pageSize=" +
            "{pageSize}&pageToken={pageToken}&excludeNonAppCreatedData={excludeNonAppCreatedData}";

        private const string GetAlbumUrl = "https://photoslibrary.googleapis.com/v1/albums/{albumId}";

        private readonly GooglePhotosClientSettings clientSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="GooglePhotosClient"/> class.
        /// </summary>
        /// <param name="clientSettings">Client settings with required objects to perform API calls.</param>
        public GooglePhotosClient(GooglePhotosClientSettings clientSettings)
        {
            this.clientSettings = clientSettings;
        }

        /// <summary>
        /// Lists all albums shown to a user in the Albums tab of the Google Photos app.
        /// </summary>
        /// <param name="pageSize">Maximum number of albums to return in the response. The default number of albums to
        /// return at a time is 20. The maximum 'pageSize' is 50.</param>
        /// <param name="pageToken">A continuation token to get the next page of the results. Adding this to the
        /// request returns the rows after the 'pageToken'. The 'pageToken' should be the value returned in the
        /// 'nextPageToken' parameter in the response to the 'listAlbums' request.</param>
        /// <param name="excludeNonAppCreatedData">If set, the results exclude media items that were not created by
        /// this app. Defaults to false (all albums are returned). This field is ignored if the
        /// photoslibrary.readonly.appcreateddata scope is used.</param>
        /// <returns>A <see cref="ListAlbumsResponse"/> object.</returns>
        public ListAlbumsResponse ListAlbums(
            int pageSize = 20,
            string pageToken = "",
            bool excludeNonAppCreatedData = false)
        {
            // Prepare request
            HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Get,
                ListAlbumsUrl
                    .Replace("{pageSize}", pageSize.ToString())
                    .Replace("{pageToken}", pageToken.ToString())
                    .Replace("{excludeNonAppCreatedData}", excludeNonAppCreatedData.ToString()));
            request.Headers.Authorization =
                GetAuthenticationHeaderValue(this.clientSettings.UserCredential.Token.AccessToken);

            // Execute request
            HttpResponseMessage response = this.clientSettings.HttpClient.SendAsync(request).Result;

            // Analyze response
            string body = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ListAlbumsResponse>(body);
        }

        /// <summary>
        /// Returns the album based on the specified 'albumId'. The 'albumId' should be the ID of an album owned by the
        /// user or a shared album that the user has joined.
        /// </summary>
        /// <param name="albumId">Identifier of the album to be requested.</param>
        /// <returns>An <see cref="Album"/> object.</returns>
        public Album GetAlbum(string albumId)
        {
            // Prepare request
            HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Get,
                GetAlbumUrl.Replace("{albumId}", albumId));
            request.Headers.Authorization =
                GetAuthenticationHeaderValue(this.clientSettings.UserCredential.Token.AccessToken);

            // Execute request
            HttpResponseMessage response = this.clientSettings.HttpClient.SendAsync(request).Result;

            // Analyze response
            string body = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Album>(body);
        }

        private static AuthenticationHeaderValue GetAuthenticationHeaderValue(string accessToken)
        {
            return new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }
}
