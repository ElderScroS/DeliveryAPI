using Delivery.Core.Domain.Entities;
using Delivery.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Infrastructure.DbContext;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();

       // var cat1 = new Category()
       //  {
       //      Name = "Vegetables",
       //      ImageUrl = new Uri("https://cdn.britannica.com/17/196817-050-6A15DAC3/vegetables.jpg?w=400&h=300&c=crop")
       //  };
       //
       //  var cat2 = new Category()
       //  {
       //      Name = "Fruits",
       //      ImageUrl = new Uri("https://www.healthyeating.org/images/default-source/home-0.0/nutrition-topics-2.0/general-nutrition-wellness/2-2-2-3foodgroups_fruits_detailfeature.jpg?sfvrsn=64942d53_4")
       //  };
       //
       //  var cat3 = new Category()
       //  {
       //      Name = "Breads",
       //      ImageUrl = new Uri("https://insanelygoodrecipes.com/wp-content/uploads/2022/08/Mixed-Breads-in-Basket-and-Wooden-Cutting-Board.jpg")
       //  };
       //
       //  var cat4 = new Category()
       //  {
       //      Name = "Dairy",
       //      ImageUrl = new Uri("https://www.dairyfoods.com/ext/resources/DF/2020/August/df-100/GettyImages-1194287257.jpg?t=1597726305&width=696")
       //  };
       //  
       //  AddRange(cat1, cat2, cat3, cat4);
       //  
       //  //Vegetables
       //  
       //  var type1 = new ProductType()
       //  {
       //      Name = "Cucumbers",
       //  };
       //
       //  var type6 = new ProductType()
       //  {
       //      Name = "Carrots"
       //  };
       //  
       //  var type7 = new ProductType()
       //  {
       //      Name = "Lettuce"
       //  };
       //  
       //  var type10 = new ProductType()
       //  {
       //      Name = "Tomatoes"
       //  };
       //  
       //  //Fruits
       //  
       //  var type2 = new ProductType()
       //  {
       //      Name = "Apples"
       //  };
       //
       //  var type4 = new ProductType()
       //  {
       //      Name = "Oranges"
       //  };
       //
       //  var type5 = new ProductType()
       //  {
       //      Name = "Bananas"
       //  };
       //  
       //  var type3 = new ProductType()
       //  {
       //      Name = "Dark Breads"
       //  };
       //
       //  //Breads 
       //
       //  var br1 =  new ProductType()
       //  {
       //      Name = "Baguette"
       //  };
       //
       //  var br2 = new ProductType()
       //  {
       //      Name = "Sourdough"
       //  };
       //
       //  var br3 = new ProductType()
       //  {
       //      Name = "Multigrain"
       //  };
       //
       //  var br4 = new ProductType()
       //  {
       //      Name = "Whole Wheat"
       //  };
       //  
       //  //Dairy
       //
       //  var dr1 = new ProductType()
       //  {
       //      Name = "Milk"
       //  };
       //  
       //  var dr2 = new ProductType()
       //  {
       //      Name = "Cheese"
       //  };
       //  
       //  var dr3 = new ProductType()
       //  {
       //      Name = "Yogurt"
       //  };
       //  
       //  var dr4 = new ProductType()
       //  {
       //      Name = "Butter"
       //  };
       //  
       //  var prod1 = new Products()
       //  {
       //      Name = "Red Delicious",
       //      Price = 5,
       //      Category = cat2,
       //      ManufactureCountry = "Azerbaijan",
       //      ImageUrls = new List<ProductImageUrl>()
       //      {
       //          new ProductImageUrl()
       //          {
       //              Url = new Uri("https://specialtyproduce.com/sppics/2011.png")
       //          }
       //      },
       //      Currency = "$",
       //      SellingType = "Kg",
       //      Weight = "80",
       //      Description = "Red apples are one of the most popular varieties of apples, known for their vibrant red color and sweet flavor. " +
       //                    "They are widely cultivated around the world and come in various cultivars, each with its own unique taste and texture. " +
       //                    "Some common types of red apples include Fuji, Gala, Red Delicious, and Jonathan.\n\nThese apples are not only delicious but also nutritious. " +
       //                    "They are rich in dietary fiber, vitamins, and antioxidants, making them a healthy snack choice. " +
       //                    "The antioxidants in red apples, such as flavonoids and polyphenols, may help reduce the risk of chronic diseases and promote overall health.",
       //      ProductType = type2
       //  };
       //  
       //  var prod2 = new Products()
       //  {
       //      Name = "Golden Delicious",
       //      Price = 7,
       //      Category = cat2,
       //      ManufactureCountry = "Ukraine",
       //      ImageUrls = new List<ProductImageUrl>()
       //      {
       //          new ProductImageUrl()
       //          {
       //              Url = new Uri("https://specialtyproduce.com/sppics/2011.png")
       //          }
       //      },
       //      Currency = "$",
       //      SellingType = "Kg",
       //      Weight = "78",
       //      Description = "Red apples are one of the most popular varieties of apples, known for their vibrant red color and sweet flavor. " +
       //                    "They are widely cultivated around the world and come in various cultivars, each with its own unique taste and texture. " +
       //                    "Some common types of red apples include Fuji, Gala, Red Delicious, and Jonathan.\n\nThese apples are not only delicious but also nutritious. " +
       //                    "They are rich in dietary fiber, vitamins, and antioxidants, making them a healthy snack choice. " +
       //                    "The antioxidants in red apples, such as flavonoids and polyphenols, may help reduce the risk of chronic diseases and promote overall health.",
       //      ProductType = type2
       //  };
       //  
       //  var prod3 = new Products()
       //  {
       //      Name = "Gala",
       //      Price = 6,
       //      Category = cat2,
       //      ManufactureCountry = "Russia",
       //      ImageUrls = new List<ProductImageUrl>()
       //      {
       //          new ProductImageUrl()
       //          {
       //              Url = new Uri("https://specialtyproduce.com/sppics/20111.png")
       //          }
       //      },
       //      Currency = "$",
       //      SellingType = "Kg",
       //      Weight = "78",
       //      Description = "Red apples are one of the most popular varieties of apples, known for their vibrant red color and sweet flavor. " +
       //                    "They are widely cultivated around the world and come in various cultivars, each with its own unique taste and texture. " +
       //                    "Some common types of red apples include Fuji, Gala, Red Delicious, and Jonathan.\n\nThese apples are not only delicious but also nutritious. " +
       //                    "They are rich in dietary fiber, vitamins, and antioxidants, making them a healthy snack choice. " +
       //                    "The antioxidants in red apples, such as flavonoids and polyphenols, may help reduce the risk of chronic diseases and promote overall health.",
       //      ProductType = type2
       //  };
       //  
       //  var prod4 = new Products()
       //  {
       //      Name = "Jonagold",
       //      Price = 6,
       //      Category = cat2,
       //      ManufactureCountry = "Russia",
       //      ImageUrls = new List<ProductImageUrl>()
       //      {
       //          new ProductImageUrl()
       //          {
       //              Url = new Uri("https://specialtyproduce.com/sppics/20111.png")
       //          }
       //      },
       //      Currency = "$",
       //      SellingType = "Kg",
       //      Weight = "78",
       //      Description = "Red apples are one of the most popular varieties of apples, known for their vibrant red color and sweet flavor. " +
       //                    "They are widely cultivated around the world and come in various cultivars, each with its own unique taste and texture. " +
       //                    "Some common types of red apples include Fuji, Gala, Red Delicious, and Jonathan.\n\nThese apples are not only delicious but also nutritious. " +
       //                    "They are rich in dietary fiber, vitamins, and antioxidants, making them a healthy snack choice. " +
       //                    "The antioxidants in red apples, such as flavonoids and polyphenols, may help reduce the risk of chronic diseases and promote overall health.",
       //      ProductType = type2
       //  };
    }
    
    public DbSet<ProductImageUrl> ImageUrls => Set<ProductImageUrl>();

    public DbSet<Product> Products => Set<Product>();

    public DbSet<ProductType> ProductTypes => Set<ProductType>();

    public DbSet<Category> Categories => Set<Category>();
    
    public DbSet<Order> Orders => Set<Order>();
}