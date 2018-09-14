// <copyright file="GooglePhotosClient.cs" company="The Bald Labs">
// Copyright (c) The Bald Labs. All rights reserved.
// </copyright>

namespace TheBaldLabs.GooglePhotosNet
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Util.Store;

    /// <summary>
    /// Client class to interact with the Google Photos Library API.
    /// </summary>
    public class GooglePhotosClient
    {
        private const string ListAlbumsUrl = "https://photoslibrary.googleapis.com/v1/albums";

        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="GooglePhotosClient"/> class.
        /// </summary>
        /// <param name="httpClient">HTTP client used to perform API calls.</param>
        public GooglePhotosClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Fetches the list of albums.
        /// </summary>
        /// <returns>A <see cref="ListAlbumsResponse"/> object.</returns>
        public ListAlbumsResponse ListAlbums()
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { "https://www.googleapis.com/auth/photoslibrary.readonly" },
                    "user",
                    CancellationToken.None).Result;
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, ListAlbumsUrl);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", credential.Token.AccessToken);
            HttpResponseMessage response = this.httpClient.SendAsync(request).Result;
            return new ListAlbumsResponse();
        }
    }
}
