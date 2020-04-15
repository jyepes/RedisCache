using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedisCache.Models
{
    public class CountryMaster
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string CountryName { get; set; }

        public List<StateMaster> States { get; set; }
    }
}