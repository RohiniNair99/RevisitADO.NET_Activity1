using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity1_DTO;
using Activity1_DAL;
using System.Data.SqlClient;
using System.Configuration;

namespace Activity1_DAL
{
    public class Grader_DAL
    {
		SqlConnection sqlObj;
		SqlCommand sqlCmObj;

		public Grader_DAL()
		{
			sqlObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectX"].ToString());
		}

		
		public List<Grader_DTO> GetParticipantsbyCourse(string courseId)
		{
			List<Grader_DTO> listOfParticipants = new List<Grader_DTO>();
			try
			{
				
				sqlCmObj = new SqlCommand(@"Select Grader.PSNO,Grader.Score from Grader inner join BatchCourseFacultyMapping on Grader.BCFId=BatchCourseFacultyMapping.BCFId where BatchCourseFacultyMapping.CourseId=@CId", sqlObj);
				sqlCmObj.Parameters.AddWithValue("@CId", courseId);
				sqlObj.Open();
				SqlDataReader drParticipants = sqlCmObj.ExecuteReader();
				while (drParticipants.Read())
				{
					listOfParticipants.Add(
						new Grader_DTO
						{
							
							PSNO = Convert.ToInt32(drParticipants["PSNO"].ToString()),
							Score = Convert.ToInt32(drParticipants["Score"].ToString())
						});
				}
				return listOfParticipants;
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

        public List<Grader_DTO> TopPerformers(string cid)
        {
            List<Grader_DTO> lstToppers = new List<Grader_DTO>();
            
                try
                {
                    sqlCmObj = new SqlCommand(@"Select TOP 5 Grader.PSNO,Grader.Score from Grader inner join BatchCourseFacultyMapping on Grader.BCFId=BatchCourseFacultyMapping.BCFId where BatchCourseFacultyMapping.CourseId=@cId ORDER BY Score DESC", sqlObj);
                sqlCmObj.Parameters.AddWithValue("@cId", cid);
                sqlObj.Open();
                    SqlDataReader BottomPerformerRead = sqlCmObj.ExecuteReader();
                    while (BottomPerformerRead.Read())
                    {
                        lstToppers.Add(
                            new Grader_DTO
                            {
                                PSNO = Convert.ToInt32(BottomPerformerRead["PSNO"].ToString()),
                                Score = Convert.ToDouble(BottomPerformerRead["Score"].ToString())
                            });
                    }
                    return lstToppers;
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

        public List<Grader_DTO> BottomPerformance(string cid)
        {
            List<Grader_DTO> lstBottomPerformers = new List<Grader_DTO>();
            try
            {
                sqlCmObj = new SqlCommand(@"Select TOP 5 Grader.PSNO,Grader.Score from Grader inner join BatchCourseFacultyMapping on Grader.BCFId=BatchCourseFacultyMapping.BCFId where BatchCourseFacultyMapping.CourseId=@CId ORDER BY Score ASC", sqlObj);
                sqlCmObj.Parameters.AddWithValue("@CId", cid);
                sqlObj.Open();
                SqlDataReader BottomPerformerRead = sqlCmObj.ExecuteReader();
                while (BottomPerformerRead.Read())
                {
                    lstBottomPerformers.Add(
                        new Grader_DTO
                        {
                            PSNO=Convert.ToInt32(BottomPerformerRead["PSNO"].ToString()),
                            Score = Convert.ToDouble(BottomPerformerRead["Score"].ToString())
                        });
                }
                return lstBottomPerformers;
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

        public List<Grader_DTO> GetCoursesFromFacultyId(string psno)
        {
            List<Grader_DTO> lstGraderCourses = new List<Grader_DTO>();
            try
            {
                sqlCmObj = new SqlCommand(@"Select Grader.PSNO,Grader.Score,BatchCourseFacultyMapping.CourseId from Grader inner join BatchCourseFacultyMapping on Grader.BCFId=BatchCourseFacultyMapping.BCFId where BatchCourseFacultyMapping.FacultyId=@PSNO", sqlObj);
                sqlCmObj.Parameters.AddWithValue("@PSNO", psno);
                sqlObj.Open();
                SqlDataReader GraderRead = sqlCmObj.ExecuteReader();
                while (GraderRead.Read())
                {
                    lstGraderCourses.Add(
                        new Grader_DTO
                        {
                            PSNO = Convert.ToInt32(GraderRead["PSNO"].ToString()),
                            Score = Convert.ToDouble(GraderRead["Score"].ToString()),
                            CourseId = GraderRead["CourseId"].ToString()
                        }); ;
                }
                return lstGraderCourses;
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
