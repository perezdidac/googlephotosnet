// <copyright file="GooglePhotosClientTests.cs" company="The Bald Labs">
// Copyright (c) The Bald Labs. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace TheBaldLabs.GooglePhotosNet.UnitTests
{
    using System.Net.Http;
    using Moq;
    using Xunit;

    public class GooglePhotosClientTests
    {
        private readonly GooglePhotosClient googlePhotosClient;

        private readonly Mock<HttpClient> httpClient;

        public GooglePhotosClientTests()
        {
            this.httpClient = new Mock<HttpClient>();
            this.googlePhotosClient = new GooglePhotosClient(this.httpClient.Object);
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
