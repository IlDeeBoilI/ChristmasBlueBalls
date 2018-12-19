using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Models
{
    public class Users
    {
        public int      ID          { get; set; }
        public string   Username    { get; set; }
        public string   Password    { get; set; }
        public string   Firstname   { get; set; }
        public string   Lastname    { get; set; }
        public string   Email       { get; set; }
        public int      Role        { get; set; }
    }
}
