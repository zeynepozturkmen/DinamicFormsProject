using DinamikFormYonetimi.App_Classes;
using DinamikFormYonetimi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DinamikFormYonetimi.Controllers
{
    
    public class MemberController : Controller
    {
        // GET: Member
        FormDBEntities db = new FormDBEntities();

     

        

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User uc,string ConfirmPassword)
        {

            if (uc.Password == ConfirmPassword)
            {


                Membership.CreateUser(uc.UserName, uc.Password, uc.Email, uc.PasswordQuestion, uc.PasswordAnswer,
                    true, out MembershipCreateStatus status);

                string createmessage = "";

                switch (status)
                {
                    case MembershipCreateStatus.Success: //basarılı   
                        break;
                    case MembershipCreateStatus.InvalidUserName:
                        createmessage = "Gerçersiz kullanıcı adı.";
                        break;

                    case MembershipCreateStatus.InvalidPassword:
                        createmessage = "Gerçersiz şifre adı.";
                        break;



                    case MembershipCreateStatus.InvalidQuestion:
                        createmessage = "Gerçersiz gizli soru ";
                        break;
                    case MembershipCreateStatus.InvalidAnswer:
                        createmessage = "Gerçersiz gizli cevap";
                        break;
                    case MembershipCreateStatus.InvalidEmail:
                        createmessage = "Gerçersiz email";
                        break;
                    case MembershipCreateStatus.DuplicateUserName:
                        createmessage = "Kullanılmıs kullanıcı adı.";
                        break;
                    case MembershipCreateStatus.DuplicateEmail:
                        createmessage = "Kullanılmış email adresi";
                        break;
                    case MembershipCreateStatus.UserRejected:
                        createmessage = "Kullanıcı engellendi";
                        break;
                    case MembershipCreateStatus.InvalidProviderUserKey:
                        createmessage = "Geçersiz kullanıcı anahtarı";
                        break;
                    case MembershipCreateStatus.DuplicateProviderUserKey:
                        createmessage = "Tekrarlanmış kullanıcı anahtarı";
                        break;
                    case MembershipCreateStatus.ProviderError:
                        createmessage = "Sağlayıcı hatası.";
                        break;
                    default:
                        break;
                }


                ViewBag.createMessage = createmessage;

                if (createmessage == "")
                {
                    ViewBag.Message = "Kullanıcı kaydedildi.";
                    return View(); //hata yoksa kullanıcı giriş sayfasına gelicek.
                }
                else
                {
                    return View();
                    //eger hata varsa oldugu sayfada kalsın
                }

            }

            else
            {
                ViewBag.createMessage = "Şifreler uyuşmuyor.";
                return View();
            }

        }

        public ActionResult MemberLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberLogin(User uc)
        {


            bool validationResult = Membership.ValidateUser(uc.UserName, uc.Password);

            if (validationResult == true)
            {
                //Girilen kullanıcı ve şifre bilgileri doğru ise, kullanıcının web sitemize giriş yapabilmesi gerekir.
                //Bunun için öncelikle web.config dosyasında authorization ayarlarının yapılması gerekir.
                //Ayarlar yapıldıktan sonra FormsAuthentication.RedirectFromLoginPage() metodu çağrılacak.
                /* <authentication mode="Forms" (roleManger'ın altına ekliyoruz.>

                 <forms    defaultUrl="/Home/Index" loginUrl="/Member/MemberLogin" timeout="30" slidingExpiration="true">
                 </forms>
                </authentication>
                */
                FormsAuthentication.RedirectFromLoginPage(uc.UserName, false);

                return RedirectToAction("Index", "Form");

            }
            else
            {
                ViewBag.Message = "Kullanıcı adı ya da parola hatalı.";
                return View();
            }
          

        }

        public ActionResult MemberLogout()
        {

            FormsAuthentication.SignOut();

            return RedirectToAction("MemberLogin", "Member");
        }

    }
}