using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Repo.Models
{
    public class Products
    {
        public int      ID              { get; set; }
        public string   Name            { get; set; }

        [AllowHtml]
        public string   Description     { get; set; }
        public string   Image           { get; set; }
        public int?     UserID          { get; set; }
        public int?     TypeID          { get; set; }
        public decimal   Price           { get; set; }
    }
}
