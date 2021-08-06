using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity1_DAL;
using Activity1_DTO;

namespace Activity1_BL
{
  public class Grader_BL
    {
        Grader_DAL dalObj = new Grader_DAL();
        public List<Grader_DTO> GetParticipants(string courseid)
        {
            try
            {
                var participantList = dalObj.GetParticipantsbyCourse(courseid);
                return participantList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grader_DTO> TopPerformers(string courseid)
        {
            try
            {
                var result = dalObj.TopPerformers(courseid);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grader_DTO> BottomPerformers(string courseid)
        {
            try
            {
                var result = dalObj.BottomPerformance(courseid);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grader_DTO> GetCourseFromFacultyId(string psno)
        {
            try
            {
                var listofCourse = dalObj.GetCoursesFromFacultyId(psno);
                return listofCourse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
