using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Models
{
    public class Todo
    {
        public string Text { get; set; } = null!;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
