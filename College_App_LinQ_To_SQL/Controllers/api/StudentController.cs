using College_App_LinQ_To_SQL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace College_App_LinQ_To_SQL.Controllers.api
{
    public class StudentController : ApiController
    {

        static string conString = "Data Source=LAPTOP-P4F5KURV;Initial Catalog=TechCareer;Integrated Security=True;Pooling=False";
        StudentsDBDataContext StudDB = new StudentsDBDataContext(conString);
        // GET: api/Student
        public IHttpActionResult Get()
        {
            try
            {

                List<Student> listo = StudDB.Students.ToList();
                return Ok(new { listo });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("YALLA LEHH");
            }

        }

        // GET: api/Student/5
        public IHttpActionResult Get(int id)
        {
            try
            {

                Student IdentityStud = StudDB.Students.First((item) => item.Id == id);
                return Ok(new { IdentityStud });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("YALLA LEHH");
            }
        }

        // POST: api/Student
        public IHttpActionResult Post([FromBody] Student value)
        {
            try
            {
                StudDB.Students.InsertOnSubmit(value);
                StudDB.SubmitChanges();
                return Ok(new { value });

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("YALLA LEHH");
            }
        }

        // PUT: api/Student/5
        public IHttpActionResult Put(int id, [FromBody] Student value)
        {
            try
            {

                Student editedStud = StudDB.Students.First((item) => item.Id == id);
                editedStud.Id = value.Id;
                editedStud.First_Name = value.First_Name;
                editedStud.Last_Name = value.Last_Name;
                editedStud.Birthday = value.Birthday;
                editedStud.Grade = value.Grade;
                StudDB.SubmitChanges();


                return Ok(new { editedStud });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("YALLA LEHH");
            }
        }

        // DELETE: api/Student/5
        public IHttpActionResult Delete(int id)
        {
            try
            {

                StudDB.Students.DeleteOnSubmit(StudDB.Students.First(item => item.Id == id));
                StudDB.SubmitChanges();
                return Ok(new { StudDB.Students });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("YALLA LEHH");
            }
        }
    }
}
