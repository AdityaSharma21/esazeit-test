using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using test.DbContext;
using test.Models;

namespace test.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        public ActionResult studentlist()
        {
            List<StudentData> studentslist = new List<StudentData>();
            try
            {
                demoEntities db = new demoEntities();
                studentslist = (from tbl in db.mst_student select new StudentData { student_id = tbl.student_id, student_name = tbl.student_name }).ToList();
            }
            catch (Exception ex)
            {

            }
            return View(studentslist);
        }

        [HttpGet]
        public ActionResult Add()
        {
            mst_student studentData = new mst_student();
            try
            {
            }
            catch (Exception ex)
            {
            }
            return View(studentData);
        }
        [HttpPost]
        public ActionResult Add(mst_student studentData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    demoEntities db = new demoEntities();
                    db.mst_student.Add(studentData);
                    db.SaveChanges();
                    return RedirectToAction("studentlist");
                }
                else
                {
                    return View(studentData);
                }
            }
            catch (Exception ex)
            {
                return View(studentData);
            }
        }

        [HttpGet]
        public ActionResult Edit(long ? id)
        {
            mst_student studentData = new mst_student();
            try
            {
                    demoEntities db = new demoEntities();
                    studentData=  db.mst_student.First(c => c.student_id == id);    
            }
            catch (Exception ex)
            {
            }
            return View(studentData);
        }

        [HttpPost]
        public ActionResult Edit(mst_student studentData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                        demoEntities db = new demoEntities();
                        mst_student student = db.mst_student.First(c => c.student_id == studentData.student_id);
                        student.student_name = studentData.student_name;
                        db.SaveChanges();
                        return RedirectToAction("studentlist");
                }
                else
                {
                    return View(studentData);
                }
            }
            catch (Exception ex)
            {
                return View(studentData);
            }
            
        }

         
        public ActionResult Delete(long? id)
        {
            try
            {
                    demoEntities db = new demoEntities();
                    mst_student student = db.mst_student.First(c => c.student_id == id);
                    db.mst_student.Remove(student);
                    db.SaveChanges();
                    return RedirectToAction("studentlist");
            }
            catch (Exception ex)
            {
                return RedirectToAction("studentlist");
            }

        }

        public JsonResult getstudentsubjectdetails(string data)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
           List<mst_subjectmarks> subjectmarksdatalist = new List<mst_subjectmarks>();
            try
            {
                if (!string.IsNullOrEmpty(data))
                {
                    IDictionary<string, object> param = JsonConvert.DeserializeObject<Dictionary<string, object>>(Uri.UnescapeDataString(data));
                    if (param.ContainsKey("student_id"))
                    {
                        long student_id=Convert.ToInt64(param["student_id"].ToString());
                        demoEntities db = new demoEntities();
                        var subjectdata = (from tbl in db.mst_subjectmarks where tbl.student_id == student_id select new { student_id = tbl.student_id, subject_id = tbl.subject_id, subject_name = tbl.subject_name, marks=tbl.marks }).ToList();
                        subjectmarksdatalist = JsonConvert.DeserializeObject<List<mst_subjectmarks>>(JsonConvert.SerializeObject(subjectdata).ToString()).ToList();
                    }
                }

                response["status"] = true;
                response["data"] = subjectmarksdatalist;
            }
            catch (Exception ex)
            {
                response["status"] = false;
                response["data"]=subjectmarksdatalist;
            }
            return Json(response,JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult SubjectAdd(long id)
        {
            mst_subjectmarks subjectData = new mst_subjectmarks();
            try
            {
                subjectData.student_id = id;
            }
            catch (Exception ex)
            {
            }
            return View(subjectData);
        }


        [HttpPost]
        public ActionResult SubjectAdd(mst_subjectmarks subjectData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    demoEntities db = new demoEntities();
                    db.mst_subjectmarks.Add(subjectData);
                    db.SaveChanges();
                    return RedirectToAction("studentlist");
                }
                else
                {
                    return View(subjectData);
                }
            }
            catch (Exception ex)
            {
                return View(subjectData);
            }
            
        }

        [HttpGet]
        public ActionResult SubjectEdit(long? id)
        {
            mst_subjectmarks subjectData = new mst_subjectmarks();
            try
            {
                    demoEntities db = new demoEntities();
                    subjectData = db.mst_subjectmarks.First(c => c.subject_id == id);    
            }
            catch (Exception ex)
            {
            }
            return View(subjectData);
        }

        [HttpPost]
        public ActionResult SubjectEdit(mst_subjectmarks subjectData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    demoEntities db = new demoEntities();
                    mst_subjectmarks subject = db.mst_subjectmarks.First(c => c.subject_id == subjectData.subject_id);
                    subject.subject_name = subjectData.subject_name;
                    subject.marks = subjectData.marks;
                    db.SaveChanges();
                    return RedirectToAction("studentlist");
                }
                else
                {
                    return View(subjectData);
                }
            }
            catch (Exception ex)
            {
                return View(subjectData);
            }

        }


        public ActionResult SubjectDelete(long? id)
        {
            try
            {
                    demoEntities db = new demoEntities();
                    mst_subjectmarks subject = db.mst_subjectmarks.First(c => c.subject_id == id);
                    db.mst_subjectmarks.Remove(subject);
                    db.SaveChanges();
                    return RedirectToAction("studentlist");
            }
            catch (Exception ex)
            {
                return RedirectToAction("studentlist");
            }

        }

    }
}
