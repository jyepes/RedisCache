using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedisCache.Models
{
    public class StateMaster
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string StateName { get; set; }

        [Required]
        public int CountryId { get; set; }
        public CountryMaster Country { get; set; }
    }
}