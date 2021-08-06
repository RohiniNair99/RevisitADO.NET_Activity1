using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity1_DTO;
using Activity1_DAL;

namespace Activity1_BL
{
   public class Course_BL
    {
        Course_DAL dalObj = new Course_DAL();
        public List<Course_DTO> GetAllCourses()
        {
            try
            {
                var lstCourse = dalObj.GetAllCourses();
                return lstCourse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
