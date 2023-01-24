using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category : IEntity //diğer paketlerdende erişilebilsin diye public yaptık defaulttda internal erişim belirleyicisi
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
