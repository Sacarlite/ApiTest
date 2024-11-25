using System.Runtime.Serialization;

namespace ApiFramework.Model.ResponseModels
{
    [DataContract]
    public class CompanyModel
    {
        [DataMember(Name = "name")]
        public string? Name { get; set; }

        [DataMember(Name = "catchPhrase")]
        public string? CatchPhrase { get; set; }

        [DataMember(Name = "bs")]
        public string? Bs { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not CompanyModel other)
            {
                return false;
            }

            return string.Equals(Name, other.Name) &&
                   string.Equals(CatchPhrase, other.CatchPhrase) &&
                   string.Equals(Bs, other.Bs);
        }
    }
}
