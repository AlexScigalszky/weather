using Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Cities")]
    public class City : EntityBase
    {
        public string Name { get; set; }

        [ForeignKey("Country")]
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }

        public static City Create(long id, string name, long countryId)
        {
            return new City()
            {
                Id = id,
                Name = name,
                CountryId = countryId
            };
        }
    }
}
