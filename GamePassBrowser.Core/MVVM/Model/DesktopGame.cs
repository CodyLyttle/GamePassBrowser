using System;
using System.Linq;
using GamePassBrowser.Core.Json.Model;

namespace GamePassBrowser.Core.MVVM.Model
{
    public class DesktopGame
    {
        public string ProductID { get; set; }
        public string Title { get; set; }
        public GamePassPrice PriceInfo { get; set; }
        public GamePassImage ImageInfo { get; set; }

        internal DesktopGame(GamePassProduct product)
        {
            if (!product.AllowedPlatforms.Contains("Windows.Desktop"))
                throw new ArgumentOutOfRangeException(nameof(product), "Game is not available on PC");

            ProductID = product.StoreId;
            Title = product.ProductTitle;
            PriceInfo = product.Price;
            ImageInfo = product.ImagePoster;
        }
    }
}