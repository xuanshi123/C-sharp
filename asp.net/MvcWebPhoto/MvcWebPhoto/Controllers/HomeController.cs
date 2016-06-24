using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebPhoto.Models.Interfaces;
using MvcWebPhoto.Models;
using System.Net.Mail;
using System.Text;
using System.Net;
using MvcWebPhoto.Models.Entities;
using System.Data;

namespace MvcWebPhoto.Controllers
{
    public class HomeController : Controller
    {
        public ISysManage ServerSysManage { get; set; }
        public IFAQ ServerFAQ { get; set; }
        public ISupplier ServerSupplier { get; set; }
        public IContactUs ServerContactUs { get; set; }
        public IArticle ServerArticle { get; set; }
        public ICatalog ServerCatalog { get; set; }
        public IComment ServerComment { get; set; }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (ServerSysManage == null)
            {
                ServerSysManage = ServerBuilder.BuilerSysManage();
            }
            if (ServerFAQ == null)
            {
                ServerFAQ = ServerBuilder.BuilderFAQ();
            }
            if (ServerSupplier == null)
            {
                ServerSupplier = ServerBuilder.BuilerSupplier();
            }
            if (ServerContactUs == null)
            {
                ServerContactUs = ServerBuilder.BuilerContactUs();
            }
            if (ServerArticle == null)
            {
                ServerArticle = ServerBuilder.BuilderArticle();
            }
            if (ServerCatalog == null)
            {
                ServerCatalog = ServerBuilder.BuilderCatalog();
            }
            if (ServerComment == null)
            {
                ServerComment = ServerBuilder.BuilerComment();
            }

            ViewData["WebBottom"] = ServerSysManage.GetModel(2).Content;
            ViewData["SupplierList"] = ServerSupplier.GetList(string.Empty);
            ViewData["WebTitle"] = ServerSysManage.GetModel(1).Content;
            ViewData["CategoriesList"] = ServerCatalog.GetList(string.Empty);

            base.Initialize(requestContext);
        }

        public ActionResult Index()
        {
            Response.Redirect("/Home/Default");
            return View();
        }

        public ActionResult Default()
        {
            object id = Request.RequestContext.RouteData.Values["id"];
            object type = Request.RequestContext.RouteData.Values["type"];
            int pagesize = 5;
            int totalcount;

            int currentpage = 1;
            if (type != null && type.ToString().Length != 0)
            {
                currentpage = Convert.ToInt32(type.ToString().Substring(4));
            }

            if (id == null || Convert.ToInt32(id) == 0)
            {
                ViewData["id"] = 0;
                ViewData["Article"] = ServerArticle.GetList(string.Empty, pagesize, currentpage);
                totalcount = ServerArticle.GetCount(string.Empty);
            }
            else
            {
                ViewData["id"] = id;
                ViewData["Article"] = ServerArticle.GetList(" [CatalogID]=" + id, pagesize, currentpage);
                totalcount = ServerArticle.GetCount(" [CatalogID]=" + id);
            }

            ViewData["CurrentPage"] = currentpage;
            ViewData["Count"] = totalcount;
            ViewData["TotalPage"] = Math.Ceiling(Convert.ToDecimal(totalcount / Convert.ToDecimal(pagesize)));

            return View();
        }

        public ActionResult FAQ()
        {
            ViewData["FAQList"] = ServerFAQ.GetWholeList(string.Empty);

            return View();
        }

        public ActionResult ArticleDetail()
        {
            int id = int.Parse(Request.RequestContext.RouteData.Values["id"].ToString());

            if (Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                string creator = Request.Form["Creator"];
                string content = Request.Form["Content"];

                if (content.Length == 0)
                {
                    ModelState.AddModelError("validationContent", "请输入评论内容！");
                }
                if (ModelState.IsValid)
                {
                    MvcWebPhoto.Models.Entities.Comment mod_comment = new Comment();
                    mod_comment.ArticleID = id;
                    mod_comment.Creator = creator;
                    mod_comment.Content = content;

                    ServerComment.Add(mod_comment);

                    return Content("<script>alert('发表评论成功，谢谢您对本站的支持！');location.href='" + Request.Url.PathAndQuery + "';</script>", "text/html");
                }
            }

            Article model = ServerArticle.GetModel(id);
            if (model != null)
            {
                ViewData["Title"] = model.Title;
                ViewData["Content"] = model.Content;
                ViewData["CreateDate"] = model.CreateDate;

                DataTable dt = ServerComment.GetList("ArticleID=" + model.ID);
                ViewData["CommentData"] = dt;
            }

            return View();
        }

        public ActionResult ContactUs()
        {
            if (Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                MvcWebPhoto.Models.Entities.ContactUs model = new Models.Entities.ContactUs();

                model.Name = Request.Form["Name"];
                if (string.IsNullOrEmpty(model.Name))
                {
                    ModelState.AddModelError("validationName", "请输入您的名称");
                }
                model.Email = Request.Form["Email"];
                if (string.IsNullOrEmpty(model.Email))
                {
                    ModelState.AddModelError("validationEmail", "请输入您的邮箱");
                }
                model.Mobile = Request.Form["Mobile"];
                if (string.IsNullOrEmpty(model.Mobile))
                {
                    ModelState.AddModelError("validationMobile", "请输入您的手机");
                }
                model.Content = Request.Form["Content"];
                if (string.IsNullOrEmpty(model.Content))
                {
                    ModelState.AddModelError("validationContent", "请输入您的信息");
                }

                if (ModelState.IsValid)
                {
                    ServerContactUs.Add(model);

                    Models.Entities.EmailAccounts model_emailAccounts = ServerContactUs.GetModelByEmailAccounts();

                    MailMessage mail = new MailMessage();
                    mail.Subject = "您有来自网站的新留言";

                    StringBuilder content = new StringBuilder();
                    content.Append("姓名：").Append(model.Name).Append("<br />");
                    content.Append("邮箱：").Append(model.Email).Append("<br />");
                    content.Append("手机：").Append(model.Mobile).Append("<br />");
                    content.Append("信息：").Append(model.Content).Append("<br />");

                    mail.Body = content.ToString();
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;

                    MailAddress mailaddress = new MailAddress(model_emailAccounts.SendAccounts);
                    mail.From = mailaddress;

                    MailAddress mailaddress_receive = new MailAddress(model_emailAccounts.ReceiveAccounts);
                    mail.To.Add(mailaddress_receive);

                    SmtpClient client = new SmtpClient();
                    client.Host = model_emailAccounts.SendAddress;
                    client.Port = model_emailAccounts.Port;
                    client.Credentials = new NetworkCredential(model_emailAccounts.SendUser, model_emailAccounts.SendPassword);
                    client.Send(mail);

                    return Content("<script>alert('提交留言成功，谢谢对我们支持，我们会根据您提供联系方式尽快与您取的联系！');location.href='ContactUs';</script>", "text/html");
                }
            }
            return View();
        }
    }
}
