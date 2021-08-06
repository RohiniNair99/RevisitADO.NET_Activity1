using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity1_DTO;


namespace Activity1_DAL
{

    public class Course_DAL
    {


		SqlConnection sqlObj;
		SqlCommand sqlCmObj;

		public Course_DAL()
        {
			sqlObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectX"].ToString());
		}
		public List<Course_DTO> GetAllCourses()
		{
			List<Course_DTO> lstOfCourse = new List<Course_DTO>();
			try
			{
				sqlCmObj = new SqlCommand(@"Select CourseId,CourseTitle,CourseDuration,CourseMode from Courses", sqlObj);
				sqlObj.Open();
				SqlDataReader readCourse = sqlCmObj.ExecuteReader();
				while (readCourse.Read())
				{
					lstOfCourse.Add(
					new Course_DTO()
					{
						CourseId = readCourse["CourseId"].ToString(),
						CourseTitle = readCourse["CourseTitle"].ToString(),
						CourseDuration = Convert.ToInt32(readCourse["CourseDuration"].ToString()),
						CourseMode = readCourse["CourseMode"].ToString()
					});
				}
				return lstOfCourse;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				sqlObj.Close();
			}
		}
	}
}
