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
    public class TeacherController : ApiController
    {
        static string conString = "Data Source=LAPTOP-P4F5KURV;Initial Catalog=TechCareer;Integrated Security=True;Pooling=False";
        TeachersDBDataContext teachersData = new TeachersDBDataContext(conString);
        // GET: api/Teacher
        public IHttpActionResult Get()
        {
            try
            {
                List<Teacher> mylist = teachersData.Teachers.ToList();
                return Ok(new { mylist });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Teacher/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Teacher t = teachersData.Teachers.First(item => item.Id == id);
                return Ok(new { t });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Thats Wrong dude..");
            }
        }

        // POST: api/Teacher
        public IHttpActionResult Post([FromBody] Teacher value)
        {

            try
            {
                teachersData.Teachers.InsertOnSubmit(value);
                teachersData.SubmitChanges();
                return Ok(teachersData);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Teacher/5
        public IHttpActionResult Put(int id, [FromBody] Teacher value)
        {
            try
            {
                Teacher editedTeacher = teachersData.Teachers.First(item => item.Id == id);
                editedTeacher.First_Name = value.First_Name;
                editedTeacher.Last_Name = value.Last_Name;
                editedTeacher.Email = value.Email;
                editedTeacher.Prof = value.Prof;
                editedTeacher.Budget = value.Budget;
                teachersData.SubmitChanges();
                return Ok(new { editedTeacher });

            }
            catch (SqlException ex)
            {
                return (BadRequest(ex.Message));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Teacher/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                teachersData.Teachers.DeleteOnSubmit(teachersData.Teachers.First(t => t.Id == id));
                teachersData.SubmitChanges();
                return Ok(teachersData.Teachers);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
