using Domain;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentApis;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.CreationDate).HasDefaultValueSql("getutcdate()");
        builder.Property(x => x.ModificationDate).HasDefaultValueSql("getutcdate()");
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.Property(x => x.Status).HasDefaultValue(ProductStatusEnum.Active);

        builder.HasData(
            new Product { Id = 1, Name = "Mystical Moonlight Succulent", 
                Image = "https://th.bing.com/th/id/OIP.xMeFmNxgcpdd5sXMfXIi-gHaE7?pid=ImgDet&w=800&h=533&rs=1", 
                Price = 97000, Quantity = 50, Status = ProductStatusEnum.Active, 
                Category = CategoryEnum.Succulent,
                Description = "A stunning succulent that glows like the moonlight."
            },
            new Product { Id = 2, Name = "Desert Mirage Cactus", 
                Image = "https://th.bing.com/th/id/OIP.hNc2N9iLljV8VMWx_BHJ7QEDDw?pid=ImgDet&rs=1", 
                Price = 12000, Quantity = 30, Status = ProductStatusEnum.Active, 
                Category = CategoryEnum.Cactus,
                Description = "An illusionary cactus that appears to shimmer in the desert sun."
            },
            new Product { Id = 3, Name = "Enchanted Forest Fairy Lights", 
                Image = "https://th.bing.com/th/id/OIP.2Kpj8zaosbOUIfX0AmSlMgHaHa?pid=ImgDet&rs=1", 
                Price = 75000, Quantity = 20, Status = ProductStatusEnum.Active, 
                Category = CategoryEnum.Decoration,
                Description = "Create a magical atmosphere with these enchanting fairy lights"
            },
            new Product { Id = 4, Name = "Fire Dragon Succulent", 
                Image = "https://th.bing.com/th/id/OIP.YPEnYKS5Od0Hk2c5x6MH4QHaE8?pid=ImgDet&rs=1", 
                Price = 86000, Quantity = 45, Status = ProductStatusEnum.Active, 
                Category = CategoryEnum.Succulent,
                Description = "A succulent that resembles the fiery scales of a dragon."
            },
            new Product { Id = 5, Name = "Ocean Breeze Glass Vase", 
                Image = "https://i.pinimg.com/originals/ce/ef/a2/ceefa2a3524afedbe6d99fa19bacd437.jpg", 
                Price = 55000, Quantity = 15, Status = ProductStatusEnum.Active, 
                Category = CategoryEnum.Vase,
                Description = "A beautifully crafted glass vase inspired by the ocean."
            },
            new Product { Id = 6, Name = "Neon Glow Cactus", 
                Image = "https://th.bing.com/th/id/R.b8d267e5efaf29425e5b7747cc6fd413?rik=Dj%2fXfb2WHH53wg&riu=http%3a%2f%2fstatic1.squarespace.com%2fstatic%2f51a79166e4b01ba7ba19a0f6%2ft%2f56f9e1101330bacc0f95b928%2f1459216677818%2f&ehk=IAXClID1p4n%2f%2bopYz6b6PwqITx0R9RveUHC1EjxJLFc%3d&risl=&pid=ImgRaw&r=0", 
                Price = 11000, Quantity = 28, Status = ProductStatusEnum.Active, 
                Category = CategoryEnum.Decoration,
                Description = "A cactus that emits a neon-like glow in the dark.",
            },
            new Product { Id = 7, Name = "Starry Night Succulent Garden", 
                Image = "https://i.pinimg.com/736x/37/2f/9f/372f9fa78e0cdf9b0141bce4dfc7dd23.jpg", 
                Price = 275000, Quantity = 40, Status = ProductStatusEnum.Active, 
                Category = CategoryEnum.Succulent,
                Description = "Create your own starry night with this succulent garden."
            },
            new Product { Id = 8, Name = "Crystal Clear Decorative Globe", 
                Image = "https://th.bing.com/th/id/OIP.sJ0mfVF7ptta-BZmzhAcjgAAAA?pid=ImgDet&rs=1", 
                Price = 55000, Quantity = 22, Status = ProductStatusEnum.Active, 
                Category = CategoryEnum.Decoration,
                Description = "A crystal-clear globe that adds elegance to your decor."
            },
            new Product { Id = 9, Name = "Royal Elegance Crystal Vase", 
                Image = "https://a.1stdibscdn.com/archivesE/upload/7977/26_15/2493352/2493352_l.jpeg", 
                Price = 65000, Quantity = 18, Status = ProductStatusEnum.Active, 
                Category = CategoryEnum.Vase,
                Description = "An elegantly designed crystal vase fit for royalty."
            },
            new Product { Id = 10, Name = "Wild West Prickly Pear Cactus", 
                Image = "https://th.bing.com/th/id/OIP.ez7XcMIuvhJd8LERpka5CwHaE7?pid=ImgDet&rs=1", 
                Price = 75000, Quantity = 35, Status = ProductStatusEnum.Active, 
                Category = CategoryEnum.Cactus,
                Description = "A rugged cactus reminiscent of the wild west landscapes.",
            }

        );
    }
}
