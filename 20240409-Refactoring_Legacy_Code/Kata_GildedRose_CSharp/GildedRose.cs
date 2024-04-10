using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (IsSulfuras(item))
                {
                    continue;
                }
                
                DecreaseSellIn(item);
                
                if (IsAgedBrie(item))
                {
                    UpdateAgedBrie(item);
                }
                else if (IsBackstagePass(item))
                {
                    UpdateBackstagePass(item);
                }
                else
                {
                    UpdateNormalItem(item);
                }
            }
        }

        private void UpdateNormalItem(Item item)
        {
            DecreaseQuality(item);
            if (item.SellIn < 0)
                DecreaseQuality(item);
        }

        private void UpdateAgedBrie(Item item)
        {
            IncreaseQuality(item);

            if (item.SellIn < 0)
                IncreaseQuality(item);
        }

        private void UpdateBackstagePass(Item item)
        {
            IncreaseQuality(item);

            if (item.SellIn < 10)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < 5)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < 0)
                item.Quality = 0;
        }

        private static bool IsBackstagePass(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static bool IsAgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private static bool IsSulfuras(Item item) {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private void IncreaseQuality(Item item) {
            if (item.Quality < 50) {
                item.Quality = item.Quality + 1;
            }
        }

        private void DecreaseQuality(Item item){
            if (item.Quality > 0) {
                item.Quality = item.Quality - 1;
            }
        }

         private void DecreaseSellIn(Item item){
            item.SellIn = item.SellIn - 1;
        }
    }
}
