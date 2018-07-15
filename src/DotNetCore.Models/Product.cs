using System;

namespace DotNetCore.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? EffectiveDate;
        public string EffectiveDateStr;
        public DateTimeOffset? UpdatedDate;
        public string UpdatedDateStr;

    }
}
