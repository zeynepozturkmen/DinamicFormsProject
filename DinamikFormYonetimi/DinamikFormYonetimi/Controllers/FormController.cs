using DinamikFormYonetimi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DinamikFormYonetimi.Controllers
{

    [Authorize]

    public class FormController : Controller
    {
        FormDBEntities db = new FormDBEntities();

    
        //yorumm
        public ActionResult Index()
        {
            //List<Form> frmList = db.Forms.ToList();

            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;

            //form.createdBy = userId;

            List<Form> frmList = db.Forms.Where(x => x.createdBy==userId).ToList();


            return View(frmList);
        }
        // GET: Form
        public ActionResult FormYonetim()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult FormYonetim(string name, string description,DateTime createdAt, string[] fields )
        {

           
            Form form = new Form();
            form.name = name;
            form.description = description;
            form.createdAt =Convert.ToDateTime(createdAt);

            //Form eklendiğinde sisteme login olan kullanıcının "UserID"si bilgisi "createdBy"a eklendi
            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;

            form.createdBy = userId; 


            db.Forms.Add(form);
            db.SaveChanges();

            Form form2 = new Form();
            form2 =db.Forms.OrderByDescending(x=>x.id).FirstOrDefault();
            
            int lastAddId = form2.id;
            //databaseden son eklenen formun Id sini al 

            for (int i=0;i<fields.Length;i++)
            {
                string[] degerler = fields[i].Split(',');
                string alanAdi = degerler[0];
                string type = degerler[1];
                string required = degerler[2];

                Field field = new Field();

                field.name = alanAdi;
                field.dataType = type;
                if (required=="true")
                {
                    field.required = true;    
                }
                else
                {
                    field.required = false;
                }
                
                field.formId = lastAddId;
                db.Fields.Add(field);
                db.SaveChanges();

               

                //database ekleme işlemleri
                //alınan ıd yi de ekle
            }


            //string message = "Kaydedildi";
            //ViewBag.Message = message;

            //return View();
          

           return RedirectToAction("Index","Form");

        }


        public ActionResult FormDataInput()
        {
            int formID = Convert.ToInt32(Request.QueryString["frmID"].ToString());
            Form frm = db.Forms.Where(x => x.id == formID).FirstOrDefault();

            ViewBag.fieldList = frm.Fields.ToList();


            return View(frm);
        }

    }
}