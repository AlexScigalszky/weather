using Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("WheatherHistory")]
    public partial class Weather : EntityBase
    {

        [ForeignKey("City")]
        public long CityId { get; set; }
        public virtual City City { get; set; }

        public double Temperture { get; set; }

        public double Sensation { get; set; }

        public static Weather Create(long id, long cityId, double temperture, double sensation)
        {
            var user = new Weather
            {
                Id = id,
                CityId = cityId,
                Temperture = temperture,
                Sensation = sensation,
            };
            return user;
        }

    }
}
