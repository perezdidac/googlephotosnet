// <copyright file="GooglePhotosClientIntegrationTests.cs" company="The Bald Labs">
// Copyright (c) The Bald Labs. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace TheBaldLabs.GooglePhotosNet.UnitTests
{
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using Google.Apis.Auth.OAuth2;
    using Xunit;

    public class GooglePhotosClientIntegrationTests
    {
        private readonly GooglePhotosClient googlePhotosClient;

        public GooglePhotosClientIntegrationTests()
        {
            HttpClient httpClient = new HttpClient();
            UserCredential userCredential;
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { "https://www.googleapis.com/auth/photoslibrary.readonly" },
                    "user",
                    CancellationToken.None).Result;
            }

            userCredential.RefreshTokenAsync(CancellationToken.None).Wait();
            GooglePhotosClientSettings clientSettings = new GooglePhotosClientSettings(httpClient, userCredential);
            this.googlePhotosClient = new GooglePhotosClient(clientSettings);
        }

        [Fact]
        public void Test_ListAlbums_GetFirstAlbum()
        {
            ListAlbumsResponse listAlbumsResponse = this.googlePhotosClient.ListAlbums();

            foreach (Album album in listAlbumsResponse.Albums)
            {
                Album singleAlbum = this.googlePhotosClient.GetAlbum(album.Id);

                break;
            }
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CA1707 // Identifiers should not contain underscores
#pragma warning restore SA1600 // Elements should be documented
