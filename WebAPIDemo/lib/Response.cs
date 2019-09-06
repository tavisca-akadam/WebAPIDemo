using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Model;

namespace WebAPIDemo.lib
{
    public class Response
    {
        public List<string> Error { get; set; }
        public Book Book { get; set; }
    }
}
