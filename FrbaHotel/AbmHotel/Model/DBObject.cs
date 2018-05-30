using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.AbmHotel.Model
{
    public class DBObject
    {
        public int Id { get; set; }

        public DBObject(int id)
        {
            Id = id;
        }
    }
}
