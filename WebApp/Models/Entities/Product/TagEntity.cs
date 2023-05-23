using Azure;
using WebApp.Models.Product;

namespace WebApp.Models.Entities.Product
{
    public class TagEntity
    {
        public int Id { get; set; }
        public string TagName { get; set; } = null!;

        public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();

        #region imolicit operators 
        public static implicit operator TagModel(TagEntity entity)
        {
 
            return new TagModel
            {
                Id = entity.Id,
                TagName = entity.TagName
            };
     
        }
        #endregion

    }
}
