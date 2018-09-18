// <copyright file="GooglePhotosClientTests.cs" company="The Bald Labs">
// Copyright (c) The Bald Labs. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace TheBaldLabs.GooglePhotosNet.UnitTests
{
    using System.Net.Http;
    using Google.Apis.Auth.OAuth2;
    using Moq;
    using Xunit;

    public class GooglePhotosClientTests
    {
        private readonly GooglePhotosClient googlePhotosClient;

        private readonly Mock<HttpClient> httpClient;
        private readonly Mock<UserCredential> userCredential;

        public GooglePhotosClientTests()
        {
            this.httpClient = new Mock<HttpClient>();
            this.userCredential = new Mock<UserCredential>();
            GooglePhotosClientSettings clientSettings = new GooglePhotosClientSettings(
                this.httpClient.Object,
                this.userCredential.Object);
            this.googlePhotosClient = new GooglePhotosClient(clientSettings);
        }

        [Fact]
        public void Test_ListAlbums_Succeeds()
        {
            this.googlePhotosClient.ListAlbums();
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CA1707 // Identifiers should not contain underscores
#pragma warning restore SA1600 // Elements should be documented
