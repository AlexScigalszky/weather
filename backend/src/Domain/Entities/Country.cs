using Core.Entities.Base;

namespace Domain.Entities
{
    public class Country : EntityBase
    {
        public string Name { get; set; }

        public static Country Create(long id, string name)
        {
            return new Country()
            {
                Id = id,
                Name = name
            };
        }
    }
}
