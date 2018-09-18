// <copyright file="GooglePhotosClientSettings.cs" company="The Bald Labs">
// Copyright (c) The Bald Labs. All rights reserved.
// </copyright>

namespace TheBaldLabs.GooglePhotosNet
{
    using System.Net.Http;
    using Google.Apis.Auth.OAuth2;

    /// <summary>
    /// Client class to interact with the Google Photos Library API.
    /// </summary>
    public class GooglePhotosClientSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GooglePhotosClientSettings"/> class.
        /// </summary>
        /// <param name="httpClient">HTTP client used to perform API calls.</param>
        /// <param name="userCredential">User credential used to perform API calls.</param>
        public GooglePhotosClientSettings(HttpClient httpClient, UserCredential userCredential)
        {
            this.HttpClient = httpClient;
            this.UserCredential = userCredential;
        }

        /// <summary>
        /// Gets the HTTP client object used to perform API calls.
        /// </summary>
        public HttpClient HttpClient { get; }

        /// <summary>
        /// Gets the user credential used to perform API calls.
        /// </summary>
        public UserCredential UserCredential { get; }
    }
}
