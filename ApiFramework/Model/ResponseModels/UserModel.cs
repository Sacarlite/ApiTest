using ApiFramework.Converters;
using System.Runtime.Serialization;

namespace ApiFramework.Model.ResponseModels
{
    [DataContract]
    public class UserModel
    {
        [DataMember(Name = "id")]
        public int? Id { get; set; }


        [DataMember(Name = "name")]
        public string? Name { get; set; }


        [DataMember(Name = "username")]
        public string? Username { get; set; }

        [DataMember(Name = "email")]
        public string? Email { get; set; }

        [DataMember(Name = "address")]
        public AddressModel Address { get; set; }

        [DataMember(Name = "phone")]
        public string? Phone { get; set; }

        [DataMember(Name = "website")]
        public string? Website { get; set; }

        [DataMember(Name = "company")]
        public CompanyModel Company { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not UserModel other)
            {
                return false;
            }
            return Nullable.Equals(Id, other.Id) &&
                   string.Equals(Name, other.Name) &&
                   string.Equals(Username, other.Username) &&
                   string.Equals(Email, other.Email) &&
                   Equals(Address, other.Address) &&
                   string.Equals(Phone, other.Phone) &&
                   string.Equals(Website, other.Website) &&
                   Equals(Company, other.Company);
        }
        public override string ToString() => JsonDataConverter.SerializeData(this);
    }
}
