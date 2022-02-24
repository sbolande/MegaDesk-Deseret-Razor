namespace MegaDesk.Models.Helpers
{
    public static class QuoteHelper
    {
        public static decimal CalculateQuote(decimal width, decimal depth, int drawerCount, DesktopMaterial material, int productionDays)
        {
            decimal size = (width * depth);
            decimal basePrice = 200 + size + (50 * drawerCount) + GetDesktopMaterialPrice(material);
            decimal rushPrice = GetRushPrice(productionDays, size);
            var value = basePrice + rushPrice;
            return value;
        }

        public static decimal CalculateQuote(DeskQuote quote)
        {
            decimal size = (quote.Width * quote.Depth);
            decimal basePrice = 200 + size + (50 * quote.DrawerCount) + GetDesktopMaterialPrice(quote.DesktopMaterial);
            decimal rushPrice = GetRushPrice(quote.ProductionDays, size);
            var value = basePrice + rushPrice;
            return value;
        }

        private static decimal GetDesktopMaterialPrice(DesktopMaterial material)
        {
            switch (material)
            {
                case DesktopMaterial.Laminate: return 100;
                case DesktopMaterial.Oak: return 200;
                case DesktopMaterial.Rosewood: return 300;
                case DesktopMaterial.Veneer: return 125;
                case DesktopMaterial.Pine: return 50;
                default: return 0;
            }
        }

        private static decimal GetRushPrice(int productionDays, decimal size)
        {
            int DayPosition;
            int SizePosition;

            if (productionDays < 14) DayPosition = DefineRushDayPosition(productionDays);
            else { return 0; }

            SizePosition = DefineRushSizePosition(size);

            return GetRushOrder(DayPosition, SizePosition);
        }

        private static int DefineRushDayPosition(int productionDays)
        {
            switch (productionDays)
            {
                case 3:
                    return 0;
                case 5:
                    return 1;
                case 7:
                    return 2;
                default:
                    return 0;
            }
        }

        private static int DefineRushSizePosition(decimal productionSize)
        {
            if (productionSize < 1000) return 0;
            else if (productionSize > 1000 && productionSize < 2000) return 1;
            else return 2;
        }

        private static int GetRushOrder(int day, int size)
        {
            int[,] PriceByDays = new int[,] { { 60, 70, 80 }, { 40, 50, 60 }, { 30, 35, 40 } };

            return PriceByDays[day, size];
        }
    }
}
