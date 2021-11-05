using System;
using System.Threading;
using System.Threading.Tasks;
using GamePassBrowser.Core.Json.Model;
using GamePassBrowser.Core.MVVM.Model;
using Xunit;

namespace GamePassBrowser.Core.Tests
{
    public class MicrosoftStoreApiTests
    {
        private static readonly CancellationTokenSource TokenSource = new();
        private static GamePassCatalog _cachedDesktopGamesCatalog;

        [Fact]
        public async Task GetDesktopGamesCatalog_ReturnsGamePassCatalog()
        {
            GamePassCatalog catalog = await MicrosoftStoreApi.GetDesktopGamesCatalog(TokenSource.Token);
            Assert.NotEmpty(catalog.ProductIDs);
        }

        [Fact]
        public async Task GetDesktopGames_MultipleIDs_ReturnsDesktopGamesAssociatedWithIDs()
        {
            GamePassCatalog catalog = await GetDesktopGamesCatalog();

            string[] productIDs = new[]
            {
                catalog.ProductIDs[0],
                catalog.ProductIDs[1]
            };

            DesktopGame[] games = await MicrosoftStoreApi.GetDesktopGames(productIDs, TokenSource.Token);
            for (var i = 0; i < games.Length; i++)
            {
                Assert.Equal(games[i].ProductID, productIDs[i]);
            }
        }

        [Fact]
        public async Task GetAllDesktopGames_ReturnAllDesktopGames()
        {
            DesktopGame[] games = await MicrosoftStoreApi.GetAllDesktopGames(TokenSource.Token);
            Assert.NotNull(games);
        }

        private static async Task<GamePassCatalog> GetDesktopGamesCatalog()
        {
            return _cachedDesktopGamesCatalog ??=
                await MicrosoftStoreApi.GetDesktopGamesCatalog(TokenSource.Token);
        }
    }
}