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
	public class Faculty_DAL
	{

		SqlConnection sqlObj;
		SqlCommand sqlCmObj;

		public Faculty_DAL()
		{
			sqlObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectX"].ToString());
		}
		public List<Faculty_DTO> GetAllFaculties()
		{
			List<Faculty_DTO> lstFaculty = new List<Faculty_DTO>();
			try
			{
				sqlCmObj = new SqlCommand(@"Select PSNO,EmailID ,FacultyName from Faculty", sqlObj);
				sqlObj.Open();
				SqlDataReader readFaculty = sqlCmObj.ExecuteReader();
				while (readFaculty.Read())
				{
					lstFaculty.Add(
					new Faculty_DTO()
					{
						PSNO = readFaculty["PSNO"].ToString(),
						EmailId = readFaculty["EmailID"].ToString(),
						FacultyName = readFaculty["FacultyName"].ToString()


					});
				}
				return lstFaculty;
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

		public List<CourseFacultyMap_DTO> GetFacultyFromCId(string Cid)
		{
			List<CourseFacultyMap_DTO> lstFaculty = new List<CourseFacultyMap_DTO>();
			try
			{
				sqlCmObj = new SqlCommand(@"Select PSNO from FacultyCourseMapping where CourseId =@Cid ", sqlObj);
				sqlCmObj.Parameters.AddWithValue("@Cid", Cid);
				sqlObj.Open();
				SqlDataReader FacultyFromCourseId = sqlCmObj.ExecuteReader();
				while (FacultyFromCourseId.Read())
				{
					lstFaculty.Add(
						new CourseFacultyMap_DTO
						{
							PSNO = FacultyFromCourseId["PSNO"].ToString()
						});
				}
				return lstFaculty;
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

		public string GetFacultyFromPSNO(string fName)
		{
			try
			{
				sqlCmObj = new SqlCommand("SELECT PSNO FROM Faculty WHERE FacultyName LIKE '" + fName + "'", sqlObj);
				sqlObj.Open();
				string PSNO = sqlCmObj.ExecuteScalar().ToString();
				return PSNO;
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

		public List<CourseFacultyMap_DTO> GetCoursesByFacultyName(string psno)
		{
			List<CourseFacultyMap_DTO> courseList = new List<CourseFacultyMap_DTO>();
			try
			{
				sqlCmObj = new SqlCommand(@"SELECT CourseId FROM FacultyCourseMapping WHERE PSNO=@psno", sqlObj);
				sqlCmObj.Parameters.AddWithValue("@psno", psno);
				sqlObj.Open();
				SqlDataReader CourseRead = sqlCmObj.ExecuteReader();
				while (CourseRead.Read())
				{
					courseList.Add(
						new CourseFacultyMap_DTO
						{
							CourseId = CourseRead["CourseId"].ToString()
						});
				}
				return courseList;
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
