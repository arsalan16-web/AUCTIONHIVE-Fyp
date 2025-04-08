using AUCTIONHIVE.Data;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace AUCTIONHIVE.Models
{
    public class FakeProductGenerator
    {
        public static List<Product> GenerateFakeProducts(int count, string userId)
        {
            var productFaker = new Faker<Product>()
                .RuleFor(p => p.Id, f => Guid.NewGuid().ToString())
                .RuleFor(p => p.Title, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
                .RuleFor(p => p.Price, f => f.Random.Decimal(10, 1000))
                .RuleFor(p => p.CategoryId, f => f.Random.Guid().ToString())
                .RuleFor(p => p.SubCategoryId, f => f.Random.Guid().ToString())
                .RuleFor(p => p.Condition, f => f.PickRandom(new[] { "New", "Used", "Refurbished" }))
                .RuleFor(p => p.Status, f => "Available")
                .RuleFor(p => p.IsAuction, f => f.Random.Bool())
                .RuleFor(p => p.IsVideoStreaming, f => f.Random.Bool())
                .RuleFor(p => p.BiddingFee, f => f.Random.Decimal(1, 50))
                .RuleFor(p => p.Location, f => f.Address.City())
                .RuleFor(p => p.CreatedAt, f => DateTime.UtcNow)
                .RuleFor(p => p.CreatedBy, f => userId)
                .RuleFor(p => p.UpdateAt, f => DateTime.UtcNow)
                .RuleFor(p => p.UpdatedBy, f => userId)
                .RuleFor(p => p.SellerId, f => "ecaff4b8-f5eb-426f-af6e-43c760753e64")
                .RuleFor(p => p.Images, f =>
                {
                    var images = new List<Images>();
                    for (int i = 0; i < f.Random.Int(1, 3); i++)
                    {
                        images.Add(new Images
                        {
                            Id = Guid.NewGuid().ToString(),
                            Image = "/uploads/fake-image-" + f.Random.Int(1000, 9999) + ".jpg",
                            CreatedAt = DateTime.UtcNow,
                            CreatedBy = userId
                        });
                    }
                    return images;
                });

            return productFaker.Generate(count);
        }
    }
    //public class CombinedService
    //{

    //    public ApplicationDbContext _context;
    //    public CombinedService(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<List<Category>> GetCategories()
    //    {
    //        List<Category> categories = await _context.Categories.Include(x => x.SubCategories).ToList() ;


    //    }


    //}
}
