using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query.EFCORE.DTO
{
    public class CommentQueryDTO:IDisposable
    {
        public string? Name { get; set; }
        public string? CreationDate { get; set; }
        public string? Message { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
