using System.Runtime.Serialization;

namespace ApiFramework.Model.ResponseModels
{
    [DataContract]
    public class AddressModel
    {
        [DataMember(Name = "street")]
        public string? Street { get; set; }

        [DataMember(Name = "suite")]
        public string? Suite { get; set; }

        [DataMember(Name = "city")]
        public string? City { get; set; }

        [DataMember(Name = "zipcode")]
        public string? Zipcode { get; set; }

        [DataMember(Name = "geo")]
        public GeoModel Geo { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not AddressModel other)
            {
                return false;
            }

            return string.Equals(Street, other.Street) &&
                   string.Equals(Suite, other.Suite) &&
                   string.Equals(City, other.City) &&
                   string.Equals(Zipcode, other.Zipcode) &&
                   Equals(Geo, other.Geo);
        }
    }
}
