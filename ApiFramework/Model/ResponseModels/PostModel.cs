using ApiFramework.Converters;
using System.Runtime.Serialization;

namespace ApiFramework.Model.ResponseModels
{
    [DataContract]
    public class PostModel
    {
        [DataMember(Name = "userId")]
        public int? UserId { get; set; }


        [DataMember(Name = "id")]
        public int? Id { get; set; }


        [DataMember(Name = "title")]
        public string? Title { get; set; }


        [DataMember(Name = "body")]
        public string? Body { get; set; }
        public override string ToString() => JsonDataConverter.SerializeData(this);
    }
}
