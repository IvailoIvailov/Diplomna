using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.vModel
{
    public class Image
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }

        public int Length { get; set; }

        public string ContentType { get; set; }

        public int ItemId { get; set; }
    }
}
