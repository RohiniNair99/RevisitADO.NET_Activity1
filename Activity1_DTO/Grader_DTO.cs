using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity1_DTO
{
    public class Grader_DTO
    {
       public int BCFId { get; set; }
        public int PSNO { get; set; }
        public double Score { get; set; }
        public int GId { get; set; }

        public string CourseId { get; set; }
    }
}
