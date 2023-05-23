using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Helpers.Repositories.Product;
using WebApp.Models.Entities.Product;
using WebApp.Models.Product;


namespace WebApp.Helpers.Services.Product
{
    public class ProductService
    {

        #region constructors & private fields

        private readonly DataContext _context;
        private readonly ProductRepo _productRepo;
        private readonly ProductTagRepo _productTagRepo;
        private readonly TagService _tagService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(DataContext context, ProductRepo productRepo, ProductTagRepo productTagRepo, TagService tagService, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _productRepo = productRepo;
            _productTagRepo = productTagRepo;
            _tagService = tagService;
            _webHostEnvironment = webHostEnvironment;
        }


        #endregion

        public async Task<ProductModel> CreateAsync(ProductEntity entity)
        {
            var _entity = await _productRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
            if (_entity == null)
            {
                _entity = await _productRepo.AddAsync(entity);
                if (_entity != null)
                    return _entity;
            }

            return null!;
        }

        public async Task AddTagsAsync(ProductEntity entity, string[] tags)
        {
            foreach(var tag in tags)
            {
                await _productTagRepo.AddAsync(new ProductTagEntity
                {
                    ArticleNumber = entity.ArticleNumber,
                    TagId = int.Parse(tag)
                });
            }
        }

        public async Task<bool> UploadImageAsync(ProductModel product, IFormFile image)
        {
            try
            {
                string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{product.ImageUrl}";
                await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
                return true;
            }
            catch { return false; }

        }


        public async Task<ProductModel> GetAsync(string articleNumber)
        {
            var productEntity = await _context.Products
                .Include(p => p.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .FirstOrDefaultAsync(p => p.ArticleNumber == articleNumber);

            if (productEntity == null)
            {
                return null!;
            }

            var productModel = new ProductModel
            {
                ArticleNumber = productEntity.ArticleNumber,
                Name = productEntity.Name,
                Price = productEntity.Price,
                ImageUrl = productEntity.ImageUrl,
                Description = productEntity.Description,
                Tags = productEntity.ProductTags.Select(pt => new TagModel
                {
                    Id = pt.Tag.Id,
                    TagName = pt.Tag.TagName
                })
            };

            return productModel;
        }


        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            var products = await _productRepo.GetAllAsync();
            var tags = await _tagService.GetTagsAsync();

            return products.Select(product => new ProductModel
            {
                ArticleNumber = product.ArticleNumber,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                Tags = tags.Select(tag => new TagModel
                {
                    Id = int.Parse(tag.Value),
                    TagName = tag.Text

                })
            });
        }

        public async Task<IEnumerable<ProductModel>> GetByTagAsync(string tagName)
        {
            var products = await _context.Products
                .Where(p => p.ProductTags.Any(pt => pt.Tag.TagName == tagName))
                .ToListAsync();

            return products.AsEnumerable()
                .Select(product => new ProductModel
                {
                    ArticleNumber = product.ArticleNumber,
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Description = product.Description,
                    Tags = product.ProductTags.Select(tag => new TagModel
                    {
                        Id = tag.Tag.Id,
                        TagName = tag.Tag.TagName
                    })
                });
        }


        public async Task<bool> DeleteAsync(string ArticleNumber)
        {
            try
            {
                var productEntity = await _context.Products.FindAsync(ArticleNumber);
                if (productEntity != null)
                {
                    _context.Products.Remove(productEntity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
