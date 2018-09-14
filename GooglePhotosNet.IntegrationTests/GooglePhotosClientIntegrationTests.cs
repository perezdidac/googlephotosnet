// <copyright file="GooglePhotosClientIntegrationTests.cs" company="The Bald Labs">
// Copyright (c) The Bald Labs. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace TheBaldLabs.GooglePhotosNet.UnitTests
{
    using System.Net.Http;
    using Xunit;

    public class GooglePhotosClientIntegrationTests
    {
        private readonly GooglePhotosClient googlePhotosClient;

        public GooglePhotosClientIntegrationTests()
        {
            HttpClient httpClient = new HttpClient();
            this.googlePhotosClient = new GooglePhotosClient(httpClient);
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
