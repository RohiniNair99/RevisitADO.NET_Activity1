using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity1_DTO;
using Activity1_BL;

namespace Activity1
{
    class Program
    {
        static void Main(string[] args)
        {

            Faculty_BL facultyblObj;
            Course_BL courseblObj;
            Grader_BL graderblObj;
            try
            {
                facultyblObj = new Faculty_BL();
                var resultFaculty = facultyblObj.GetAllFaculties();
                Console.WriteLine("__________Faculties_______________");
                if (resultFaculty != null)
                {
                    foreach (var item in resultFaculty)
                    {
                        Console.WriteLine(item.PSNO + "|" + item.EmailId + "|" + item.FacultyName);
                    }
                }
                else
                {
                    Console.WriteLine("No faculties available.\n");
                }

                Console.WriteLine("_______________________Courses__________________________");
                courseblObj = new Course_BL();
                var resultCourse = courseblObj.GetAllCourses();
                if (resultCourse != null)
                {
                    foreach (var item in resultCourse)
                    {
                        Console.WriteLine(item.CourseId + "|" + item.CourseTitle + "|" + item.CourseDuration + "|" + item.CourseMode);
                    }
                }
                else
                {
                    Console.WriteLine("No Course available.\n");
                }

                Console.WriteLine("\nEnter CourseId to obtain corresponding faculty list: ");
                string courseId = Console.ReadLine();
                var resultFacultyName = facultyblObj.GetFacultiesByCourseId(courseId);
                if (resultFacultyName != null)
                {
                    foreach (var item in resultFacultyName)
                    {
                        Console.WriteLine(item.PSNO);
                    }
                }
                else
                {
                    Console.WriteLine("No faculty assigned for this course.\n");
                }

                Console.WriteLine("Enter faculty name to obtain corresponding courses.");
                string name = Console.ReadLine();
                var lstCourse = facultyblObj.GetCoursesByFacultyName(name);
                if (lstCourse != null)
                {
                    foreach (var item in lstCourse)
                    {
                        Console.WriteLine(item.CourseId);
                    }
                }
                else
                {
                    Console.WriteLine("No course assigned to this faculty.\n");
                }

                Grader_BL graderBlObj = new Grader_BL();
                Console.WriteLine("Enter the Courseid for which you want the Participants and score:");
                string courseid = Console.ReadLine();
                var lstParticipant = graderBlObj.GetParticipants(courseid);
                if (lstParticipant != null)
                {
                    foreach (var item in lstParticipant)
                    {
                        Console.WriteLine("PSNO => "+item.PSNO + "|" +"SCORE=>"+ item.Score);
                    }
                }
                else
                {
                    Console.WriteLine("No participants for this course!");
                }

                Console.WriteLine("\nEnter the CourseID for top 5 bottom and top performers: ");
                graderblObj = new Grader_BL();
                string cid = Console.ReadLine();
                var topPerformers = graderblObj.TopPerformers(cid);
                Console.WriteLine("____________TOP 5 Performers:_______________________");
                if (topPerformers != null)
                {
                    foreach (var item in topPerformers)
                    {
                        Console.WriteLine(item.PSNO+"  | "+item.Score);
                    }
                }
                else
                {
                    Console.WriteLine("No records available!");
                }
                var bottomPerformers = graderblObj.BottomPerformers(cid);
                Console.WriteLine("____________________BOTTOM 5 Performers:___________________");
                if (bottomPerformers != null)
                {
                    foreach (var item in bottomPerformers)
                    {
                        Console.WriteLine(item.PSNO + "  | " + item.Score);
                    }
                }
                else
                {
                    Console.WriteLine("No records available!");
                }

                Console.WriteLine("\nEnter the PSNumber for which you want the courses and the score:");
                string psno = Console.ReadLine();
                var resultCoursesFromFId = graderblObj.GetCourseFromFacultyId(psno);
                if (resultCoursesFromFId != null)
                {
                    foreach (var item in resultCoursesFromFId)
                    {
                        Console.WriteLine(item.CourseId + "|" + item.PSNO+ "|" +item.Score);
                    }
                }
                else
                {
                    Console.WriteLine("No courses or participants under this faculty!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong!!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}



