using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.CommandHandlers.Model.Responses
{
    public class ModeloResponse
    {
        public int Id { get; set; }
        public int MakeID { get; set; }
        public string Name { get; set; }
    }
}
