using System.ComponentModel.DataAnnotations;
namespace todoAPI.models
{
    public class taskMain
    {
        [Key]
        public Guid Id { get; set; }
        public string topic { get; set; }
        public string description { get; set; }
    }
}
