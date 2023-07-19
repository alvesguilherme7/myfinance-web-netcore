using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace myfinance_web_netcore.Domain
{
    public class EntityBase
    {
        [Key]
        public int? Id { get; set; }
    }
}