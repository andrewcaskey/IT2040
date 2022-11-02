using System;
using System.Linq;

namespace LINQPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product(1252, ProductCategory.Computers, "Logitech M510 Wireless Computer Mouse", 18.49, 25),
                new Product(1343, ProductCategory.Computers, "Redragon K552 KUMARA LED Backlit Mechanical Gaming Keyboard", 29.99, 9),
                new Product(1542, ProductCategory.Computers, "Corsair Vengeance LPX 16GB (2x8GB) DDR4 DRAM 3000MHz", 139.99, 42),
                new Product(1721, ProductCategory.Computers, "USB 3.0 A to A Cable Type A Male to Male, 3 feet", 7.29, 112),
                new Product(2231, ProductCategory.Computers, "USB C to USB A", 10.99, 84),
                new Product(2405, ProductCategory.Computers, "EVGA GeForce GTX 1050 Ti Gaming Video Card, 4GB GDDR5", 169.99, 25),
                new Product(2502, ProductCategory.Computers, "ASUS ROG Strix Z370-E Motherboard LGA1151 ", 209.99, 8),
                new Product(3152, ProductCategory.Electronics, "Tascam DR05 Stereo Portable Digital Recorder", 92.99, 14),
                new Product(3178, ProductCategory.Electronics, "Toshiba 43LF621U19 43-inch 4K Ultra HD Smart LED TV HDR", 319.99, 23),
                new Product(3556, ProductCategory.Electronics, "Crown XLS1502 Two-channel, 525W at 4Ω Power Amplifier", 399.00, 17),
                new Product(4339, ProductCategory.Kitchen, "KitchenAid KSM150PSER Artisan Tilt-Head Stand Mixer", 278.63, 36),
                new Product(4411, ProductCategory.Kitchen, "Hamilton Beach 62682RZ Hand Mixer", 14.99, 67),
                new Product(4523, ProductCategory.Kitchen, "Tovolo Flex-Core All Silicone Spatula", 10.49, 98),
                new Product(5134, ProductCategory.Kitchen, "Circulon Symmetry Hard Anodized Nonstick Skillet", 49.95, 62),
                new Product(5216, ProductCategory.Pet, "Neater Feeder Express Pet Bowls", 22.99, 6),
                new Product(5678, ProductCategory.Pet, "Magic Roller Ball Dog Toy", 10.80, 9),
                new Product(6123, ProductCategory.Pet, "Pillow Pets Signature Cozy Cow Plush Toy", 19.99, 17),
                new Product(6732, ProductCategory.Pet, "Evriholder FURemover Broom with Squeegee ", 15.99, 21),
                new Product(7128, ProductCategory.Pet, "Fabreze Pet Oder Eliminator", 4.94, 33),
                new Product(7231, ProductCategory.Pet, "Professional Pet Slicker Rug Brush for Dogs", 7.59, 17)
            };
        }
    }
}
