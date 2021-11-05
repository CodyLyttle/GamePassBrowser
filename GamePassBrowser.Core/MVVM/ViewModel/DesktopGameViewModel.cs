using System;
using GamePassBrowser.Core.MVVM.Model;

namespace GamePassBrowser.Core.MVVM.ViewModel
{
    public class DesktopGameViewModel : ViewModelBase
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string OriginalPrice { get; set; }
        public string CurrentPrice { get; set; }
        public bool IsOnSale { get; set; }

        public DesktopGameViewModel(DesktopGame desktopGameModel)
        {
            Title = desktopGameModel.Title;
            
            if(desktopGameModel.ImageInfo != null)
                ImageUrl = desktopGameModel.ImageInfo.Uri.ToString();

            if (desktopGameModel.PriceInfo == null)
            {
                OriginalPrice = "TBC";
            }
            else 
            {
                OriginalPrice = desktopGameModel.PriceInfo.Msrp;
                
                if (desktopGameModel.PriceInfo.IsFree)
                    CurrentPrice = "Free";
                else if (!string.IsNullOrEmpty(desktopGameModel.PriceInfo.SalePrice))
                {
                    CurrentPrice = desktopGameModel.PriceInfo.SalePrice;
                    IsOnSale = true;
                }
            }
        }
    }
}