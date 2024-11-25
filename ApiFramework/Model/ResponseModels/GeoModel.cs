using System.Runtime.Serialization;

namespace ApiFramework.Model.ResponseModels
{
    [DataContract]
    public class GeoModel
    {
        [DataMember(Name = "lat")]
        public string? Lat { get; set; }

        [DataMember(Name = "lng")]
        public string? Lng { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not GeoModel other)
            {
                return false;
            }

            return string.Equals(Lat, other.Lat) &&
                   string.Equals(Lng, other.Lng);
        }
    }
}
