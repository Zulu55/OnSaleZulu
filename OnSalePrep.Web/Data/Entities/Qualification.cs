using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnSalePrep.Web.Data.Entities
{
    public class Qualification
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Score { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
    }
}
