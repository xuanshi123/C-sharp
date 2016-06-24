using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebPhoto.Models.Entities;
using MvcWebPhoto.Models.Interfaces;
using MvcWebPhoto.Models;
using System.Data;
using System.IO;

namespace MvcWebPhoto.Controllers
{
    public class ManageController : Controller
    {
        public IUser ServerUser { get; set; }
        public IFAQ ServerFAQ { get; set; }
        public ICatalog ServerCatalog { get; set; }
        public IArticle ServerArticle { get; set; }
        public ISysManage ServerSysManage { get; set; }
        public ISupplier ServerSupplier { get; set; }
        public IContactUs ServerContactUs { get; set; }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (ServerUser == null)
            {
                ServerUser = ServerBuilder.BuilderUser();
            }

            if (ServerFAQ == null)
            {
                ServerFAQ = ServerBuilder.BuilderFAQ();
            }

            if (ServerCatalog == null)
            {
                ServerCatalog = ServerBuilder.BuilderCatalog();
            }

            if (ServerArticle == null)
            {
                ServerArticle = ServerBuilder.BuilderArticle();
            }

            if (ServerSysManage == null)
            {
                ServerSysManage = ServerBuilder.BuilerSysManage();
            }

            if (ServerSupplier == null)
            {
                ServerSupplier = ServerBuilder.BuilerSupplier();
            }

            if (ServerContactUs == null)
            {
                ServerContactUs = ServerBuilder.BuilerContactUs();
            }

            ViewData["WebTitle"] = ServerSysManage.GetModel(1).Content;

            base.Initialize(requestContext);
        }

        private int GetUrlID()
        {
            int ID = 0;
            if (Request.RequestContext.RouteData.Values["id"] != null)
            {
                int.TryParse(Request.RequestContext.RouteData.Values["id"].ToString(), out ID);
            }
            return ID;
        }

        private string GetUrlType()
        {
            string type = string.Empty;
            if (Request.RequestContext.RouteData.Values["type"] != null)
            {
                type = Request.RequestContext.RouteData.Values["type"].ToString();
            }
            return type;
        }

        #region Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            if (string.IsNullOrEmpty(model.UserID))
            {
                ModelState.AddModelError("validationUserID", "请输入登录用户");
            }
            else if (string.IsNullOrEmpty(model.PassWord))
            {
                ModelState.AddModelError("validationPassword", "请输入登录密码");
            }
            else
            {
                if (ServerUser.Login(model.UserID, model.PassWord))
                {
                    return RedirectToAction("Default", "Manage");
                }
                else
                {
                    ModelState.AddModelError("validationLoginError", "登陆失败，请检查用户名与密码！");
                }
            }
            return View(model);
        }
        #endregion

        #region Default
        public ActionResult Default()
        {
            ViewData[ControllersUtility.Add_Url] = "";
            return View();
        }
        #endregion

        #region FAQ
        public ActionResult FAQList()
        {
            ViewData["FAQList"] = ServerFAQ.GetList(string.Empty);
            ViewData[ControllersUtility.Add_Url] = "FAQEdit";
            return View();
        }

        [HttpGet]
        public ActionResult FAQEdit()
        {
            string type = GetUrlType();
            int ID = GetUrlID();

            if (type.Equals("del", StringComparison.OrdinalIgnoreCase) && ID != 0)
            {
                ServerFAQ.Delete(ID);
                Response.Redirect("/Manage/FAQList", true);
            }
            else
            {
                SetFAQToUrl();
                SetFAQToViewData(ID);
            }

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult FAQEdit(FAQ model)
        {
            ViewData[ControllersUtility.Add_Url] = "FAQEdit";
            ViewData[ControllersUtility.Update_Method] = "FAQEdit";

            int ID = GetUrlID();

            model.ID = ID;
            model.Title = Request.Form["Title"];
            model.Content = Request.Form["Content"];

            if (string.IsNullOrEmpty(model.Title))
            {
                ModelState.AddModelError("validationTitle", "*请输入FAQ标题");
            }

            if (string.IsNullOrEmpty(model.Content))
            {
                ModelState.AddModelError("validationContent", "*请输入FAQ内容");
            }

            if (ModelState.IsValid)
            {
                if (ID == 0)
                {
                    ServerFAQ.Add(model);
                    ID = ServerFAQ.GetMaxID();
                }
                else
                {
                    ServerFAQ.Update(model);
                }
            }

            SetFAQToUrl();
            SetFAQToViewData(ID);

            return View();
        }

        private void SetFAQToUrl()
        {
            ViewData[ControllersUtility.Add_Url] = "FAQEdit/";
            ViewData[ControllersUtility.Update_Method] = "FAQEdit";

            int ID = GetUrlID();
            ViewData[ControllersUtility.Delete_Url] = "/Manage/FAQEdit/" + ID + "/del";
        }

        private void SetFAQToViewData(int id)
        {
            FAQ model = ServerFAQ.GetModel(id);
            if (model != null)
            {
                ViewData["Title"] = model.Title;
                ViewData["Content"] = model.Content;
                ViewData["CreateDate"] = model.CreateDate;
            }
            else
            {
                ViewData["Title"] = string.Empty;
                ViewData["Content"] = string.Empty;
                ViewData["CreateDate"] = string.Empty;
            }
        }
        #endregion

        #region Catalog
        public ActionResult CatalogList()
        {
            ViewData["CatalogList"] = ServerCatalog.GetList(string.Empty);
            ViewData[ControllersUtility.Add_Url] = "CatalogEdit";
            return View();
        }

        [HttpGet]
        public ActionResult CatalogEdit()
        {
            int ID = GetUrlID();
            string type = GetUrlType();

            if (type.Equals("del", StringComparison.OrdinalIgnoreCase) && ID != 0)
            {
                if (ServerArticle.GetList("CatalogID=" + ID).Rows.Count > 0)
                {
                    ModelState.AddModelError("validationDelError", "该分类下包含文章,删除失败!");
                }
                else
                {
                    ServerCatalog.Delete(ID);
                    Response.Redirect("/Manage/CatalogList");
                }
            }

            SetCatalogToUrl();
            SetCatalogToViewData(ID);

            return View();
        }

        [HttpPost]
        public ActionResult CatalogEdit(Catalog model)
        {
            int ID = GetUrlID();

            model.ID = ID;
            model.CatalogName = Request.Form["CatalogName"];

            if (string.IsNullOrEmpty(model.CatalogName))
            {
                ModelState.AddModelError("validationCatalogName", "请输入分类标题");
            }

            if (ModelState.IsValid)
            {
                if (ID == 0)
                {
                    ServerCatalog.Add(model);
                    ID = ServerCatalog.GetMaxID();
                }
                else
                {
                    ServerCatalog.Update(model);
                }
            }

            SetCatalogToUrl();
            SetCatalogToViewData(ID);

            return View();
        }

        private void SetCatalogToViewData(int ID)
        {
            Catalog model = ServerCatalog.GetModel(ID);
            if (model == null)
            {
                ViewData["CatalogName"] = string.Empty;
                ViewData["CreateDate"] = string.Empty;
            }
            else
            {
                ViewData["CatalogName"] = model.CatalogName;
                ViewData["CreateDate"] = model.CreateDate;
            }
        }

        private void SetCatalogToUrl()
        {
            ViewData[ControllersUtility.Add_Url] = "CatalogEdit/";
            ViewData[ControllersUtility.Update_Method] = "CatalogEdit";

            int ID = GetUrlID();
            ViewData[ControllersUtility.Delete_Url] = "/Manage/CatalogEdit/" + ID + "/del";
        }
        #endregion

        #region Article
        public ActionResult ArticleList()
        {
            ViewData["ArticleList"] = ServerArticle.GetList(string.Empty);
            ViewData[ControllersUtility.Add_Url] = "ArticleEdit";

            return View();
        }

        [HttpGet]
        public ActionResult ArticleEdit()
        {
            int ID = GetUrlID();
            string type = GetUrlType();

            if (type.Equals("del", StringComparison.OrdinalIgnoreCase) && ID != 0)
            {
                ServerArticle.Delete(ID);
                Response.Redirect("/Manage/ArticleList");
            }
            else
            {
                SetArticleToViewData(ID);
                SetArticleToUrl();
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ArticleEdit(Article model)
        {
            int ID = GetUrlID();
            model.ID = ID;
            model.CatalogID = int.Parse(Request.Form["CatalogID"]);
            model.Title = Request.Form["Title"];
            model.Content = Request.Form["Content"];

            if (string.IsNullOrEmpty(model.Title))
            {
                ModelState.AddModelError("validationTitle", "请输入文章标题");
            }

            if (model.CatalogID == 0)
            {
                ModelState.AddModelError("validationCatalog", "请选择文章分类");
            }

            if (string.IsNullOrEmpty(model.Content))
            {
                ModelState.AddModelError("validationContent", "请输入文章内容");
            }

            if (ModelState.IsValid)
            {
                if (model.ID == 0)
                {
                    ServerArticle.Add(model);
                    ID = ServerArticle.GetMaxID();
                }
                else
                {
                    ServerArticle.Update(model);
                }

                return Content("<script>alert('保存成功！');location.href='" + Request.Url.PathAndQuery + "';</script>");
            }

            SetArticleToViewData(ID);
            SetArticleToUrl();

            return View();
        }

        private void SetArticleToViewData(int ID)
        {
            Catalog categoriesModel;
            List<Catalog> list = new List<Catalog>();
            DataTable dt = ServerCatalog.GetList(string.Empty);

            categoriesModel = new Catalog();
            categoriesModel.CatalogName = "--请选择--";
            categoriesModel.ID = 0;
            list.Add(categoriesModel);

            foreach (DataRow dr in dt.Rows)
            {
                categoriesModel = new Catalog();
                categoriesModel.CatalogName = dr["CatalogName"].ToString();
                categoriesModel.ID = int.Parse(dr["ID"].ToString());

                list.Add(categoriesModel);
            }

            SelectList selectlist = new SelectList(list, "ID", "CatalogName");
            ViewData["Categories"] = selectlist;

            Article model = ServerArticle.GetModel(ID);
            if (model == null)
            {
                ViewData["Title"] =
                    ViewData["Content"] =
                    ViewData["CatalogID"] =
                    ViewData["CreateDate"] = string.Empty;
            }
            else
            {
                ViewData["Title"] = model.Title;
                ViewData["Content"] = model.Content;
                ViewData["CatalogID"] = model.CatalogID;
                ViewData["CreateDate"] = model.CreateDate;
            }
        }

        private void SetArticleToUrl()
        {
            ViewData[ControllersUtility.Add_Url] = "ArticleEdit/";
            ViewData[ControllersUtility.Update_Method] = "ArticleEdit";

            int ID = GetUrlID();
            ViewData[ControllersUtility.Delete_Url] = "/Manage/ArticleEdit/" + ID + "/del";
        }
        #endregion

        #region SysManage
        [ValidateInput(false)]
        public ActionResult SysManage()
        {
            ViewData["IsDeleteDel"] = true;
            ViewData["IsDeleteAdd"] = true;
            int Identity = GetUrlID();

            if (Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                SysManage model = new SysManage();
                model.Identity = Identity;
                model.Content = Request.Form["Content"];

                if (string.IsNullOrEmpty(model.Content))
                {
                    ModelState.AddModelError("validationContent", "请输入内容");
                }
                else
                {
                    ServerSysManage.Update(model);
                    return Content("<script>alert('保存成功！');location.href='" + Request.Url.PathAndQuery + "';</script>", "text/html");
                }
            }

            SetSysManageToUrl();
            SetSysManageToViewData(Identity);

            return View();
        }

        private void SetSysManageToUrl()
        {
            ViewData[ControllersUtility.Update_Method] = "SysManage";
        }

        private void SetSysManageToViewData(int Identity)
        {
            SysManage model = ServerSysManage.GetModel(Identity);
            if (model != null)
            {
                ViewData["ExPlain"] = model.Explain;
                ViewData["Content"] = model.Content;
            }
            else
            {
                ViewData["ExPlain"] =
                ViewData["Content"] = string.Empty;
            }
        }
        #endregion

        #region EmailAccounts
        public ActionResult EmailAccounts()
        {
            ViewData["IsDeleteDel"] = false;
            ViewData["IsDeleteAdd"] = false;
            ViewData[ControllersUtility.Update_Method] = "EmailAccounts";

            if (Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                MvcWebPhoto.Models.Entities.EmailAccounts model = new EmailAccounts();
                model.SendAccounts = Request.Form["SendAccounts"];
                model.SendAddress = Request.Form["SendAddress"];
                model.SendPassword = Request.Form["SendPassword"];
                model.SendUser = Request.Form["SendUser"];
                model.ReceiveAccounts = Request.Form["ReceiveAccounts"];

                if (model.SendAddress.Length == 0)
                {
                    ModelState.AddModelError("validationSendAddress", "请输入发送邮箱地址");
                }
                if (Request.Form["Port"].Length == 0)
                {
                    ModelState.AddModelError("validationSendPort", "请输入发送邮箱端口");
                }
                else
                {
                    int port = 0;
                    if (!int.TryParse(Request.Form["Port"], out port))
                    {
                        ModelState.AddModelError("validationSendPort", "请输入正确的发送邮箱端口");
                    }
                    else
                    {
                        model.Port = port;
                    } 
                }
                if (model.SendAccounts.Length == 0)
                {
                    ModelState.AddModelError("validationSendAccounts", "请输入发送邮箱帐号");
                }
                if (model.SendUser.Length == 0)
                {
                    ModelState.AddModelError("validationSendUser", "请输入用户名");
                }
                if (model.SendPassword.Length == 0)
                {
                    ModelState.AddModelError("validationSendPassword", "请输入用户密码");
                }
                if (model.ReceiveAccounts.Length == 0)
                {
                    ModelState.AddModelError("validationReceiveAccounts", "请输入接收邮箱帐号");
                }
                if (ModelState.IsValid)
                {
                    ServerContactUs.UpdateEmailAccounts(model);
                }
            }

            MvcWebPhoto.Models.Entities.EmailAccounts model_get = ServerContactUs.GetModelByEmailAccounts();
            ViewData["SendAccounts"] = model_get.SendAccounts;
            ViewData["SendAddress"] = model_get.SendAddress;
            ViewData["SendPassword"] = model_get.SendPassword;
            ViewData["SendUser"] = model_get.SendUser;
            ViewData["ReceiveAccounts"] = model_get.ReceiveAccounts;
            ViewData["Port"] = model_get.Port;

            return View();
        }
        #endregion

        #region Supplier
        public ActionResult SupplierList()
        {
            ViewData["SupplierList"] = ServerSupplier.GetList(string.Empty);
            ViewData[ControllersUtility.Add_Url] = "SupplierEdit";

            return View();
        }

        [HttpGet]
        public ActionResult SupplierEdit()
        {
            int ID = GetUrlID();
            string type = GetUrlType();

            if (type.Equals("del", StringComparison.OrdinalIgnoreCase) && ID != 0)
            {
                ServerSupplier.Delete(ID);
                Response.Redirect("/Manage/SupplierList");
            }
            else
            {
                SetSupplierToViewData(ID);
                SetSupplierToUrl();
            }

            return View();
        }

        public ActionResult SupplierEdit(Supplier model)
        {
            int ID = GetUrlID();
            model.ID = ID;
            model.SupplierName = Request.Form["SupplierName"];
            model.SupplierUrl = Request.Form["SupplierUrl"];

            if (string.IsNullOrEmpty(model.SupplierName))
            {
                ModelState.AddModelError("validationSupplierUrl", "请输入供应商名称");
            }

            if (string.IsNullOrEmpty(model.SupplierUrl))
            {
                ModelState.AddModelError("validationSupplierUrl", "请输入供应商地址");
            }
            else if (model.SupplierUrl.Length <= 7 || !model.SupplierUrl.Substring(0, 7).Equals("http://", StringComparison.OrdinalIgnoreCase))
            {
                ModelState.AddModelError("validationSupplierUrl", "请输入正确的供应商地址(必须以http://开头)");
            }

            if (ModelState.IsValid)
            {
                if (model.ID == 0)
                {
                    ServerSupplier.Add(model);
                    ID = ServerSupplier.GetMaxID();
                }
                else
                {
                    ServerSupplier.Update(model);
                }
            }

            SetSupplierToViewData(ID);
            SetSupplierToUrl();

            return View();
        }

        private void SetSupplierToViewData(int ID)
        {
            Supplier model = ServerSupplier.GetModel(ID);
            if (model == null)
            {
                ViewData["SupplierName"] =
                    ViewData["SupplierUrl"] =
                    ViewData["CreateDate"] = string.Empty;
            }
            else
            {
                ViewData["SupplierName"] = model.SupplierName;
                ViewData["SupplierUrl"] = model.SupplierUrl;
                ViewData["CreateDate"] = model.CreateDate;
            }
        }

        private void SetSupplierToUrl()
        {
            ViewData[ControllersUtility.Add_Url] = "SupplierEdit/";
            ViewData[ControllersUtility.Update_Method] = "SupplierEdit";

            int ID = GetUrlID();
            ViewData[ControllersUtility.Delete_Url] = "/Manage/SupplierEdit/" + ID + "/del";
        }

        #endregion

        #region ActicleImage
        public ActionResult ActicleImage(string Action)
        {
            ViewData[ControllersUtility.Update_Method] = "ActicleImage";
            ViewData["IsDeleteAdd"] = "true";
            ViewData["IsDeleteDel"] = "true";

            if (Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                if (Action == "上传")
                {
                    if (Request.Files.Count != 0)
                    {
                        HttpPostedFileBase file = Request.Files["uploadpic"];
                        string Extension = Path.GetExtension(file.FileName);

                        if (!Extension.Equals(".gif") && !Extension.Equals(".jpeg") && !Extension.Equals(".jpg"))
                        {
                            return Content("<script>alert('只能上传gif|jpeg|jpg类型图片！');location.href='ActicleImage';</script>");
                        }
                        else
                        {
                            string pathname = Path.Combine(Server.MapPath("/Content/ActicleImage/"), file.FileName);
                            file.SaveAs(pathname);
                            ViewData["ImageUrl"] = "/Content/ActicleImage/" + file.FileName;
                        }
                    }
                }
            }

            return View();
        }
        #endregion

        #region Logo
        [HttpGet]
        public ActionResult Logo()
        {
            ViewData[ControllersUtility.Update_Method] = "Logo";
            ViewData["IsDeleteAdd"] = "true";
            ViewData["IsDeleteDel"] = "true";

            return View();
        }

        [HttpPost]
        public ActionResult Logo(string Action)
        {
            ViewData[ControllersUtility.Update_Method] = "Logo";
            ViewData["IsDeleteAdd"] = "true";
            ViewData["IsDeleteDel"] = "true";

            switch (Action)
            {
                case "保存":
                    {
                        if (Request.Files.Count != 0)
                        {
                            HttpPostedFileBase file = Request.Files["uploadpic"];
                            string Extension = Path.GetExtension(file.FileName);
                            string newFileName = "logo" + Extension;

                            if (!Extension.Equals(".gif"))
                            {
                                ModelState.AddModelError("validationLogoError", "只能上传gif类型图片");
                            }
                            else
                            {
                                file.SaveAs(Path.Combine(Server.MapPath("/Content/Logo/"), newFileName));
                                return Content("<script>alert('保存成功！');location.href='logo';</script>");
                            }
                        }
                        break;
                    }
                case "保存1":
                    {
                        if (Request.Files.Count != 0)
                        {
                            HttpPostedFileBase file = Request.Files["uploadpic1"];
                            string Extension = Path.GetExtension(file.FileName);
                            string newFileName = "1" + Extension;

                            if (!Extension.Equals(".gif"))
                            {
                                ModelState.AddModelError("validationLogoError1", "只能上传gif类型图片");
                            }
                            else
                            {
                                file.SaveAs(Path.Combine(Server.MapPath("/Content/Logo/"), newFileName));
                                return Content("<script>alert('保存成功！');location.href='logo';</script>");
                            }
                        }
                        break;
                    }
                case "保存2":
                    {
                        if (Request.Files.Count != 0)
                        {
                            HttpPostedFileBase file = Request.Files["uploadpic2"];
                            string Extension = Path.GetExtension(file.FileName);
                            string newFileName = "2" + Extension;

                            if (!Extension.Equals(".gif"))
                            {
                                ModelState.AddModelError("validationLogoError2", "只能上传gif类型图片");
                            }
                            else
                            {
                                file.SaveAs(Path.Combine(Server.MapPath("/Content/Logo/"), newFileName));
                                return Content("<script>alert('保存成功！');location.href='logo';</script>");
                            }
                        }
                        break;
                    }
                case "保存3":
                    {
                        if (Request.Files.Count != 0)
                        {
                            HttpPostedFileBase file = Request.Files["uploadpic3"];
                            string Extension = Path.GetExtension(file.FileName);
                            string newFileName = "3" + Extension;

                            if (!Extension.Equals(".gif"))
                            {
                                ModelState.AddModelError("validationLogoError3", "只能上传gif类型图片");
                            }
                            else
                            {
                                file.SaveAs(Path.Combine(Server.MapPath("/Content/Logo/"), newFileName));
                                return Content("<script>alert('保存成功！');location.href='logo';</script>");
                            }
                        }
                        break;
                    }
                case "保存4":
                    {
                        if (Request.Files.Count != 0)
                        {
                            HttpPostedFileBase file = Request.Files["uploadpic4"];
                            string Extension = Path.GetExtension(file.FileName);
                            string newFileName = "4" + Extension;

                            if (!Extension.Equals(".gif"))
                            {
                                ModelState.AddModelError("validationLogoError4", "只能上传gif类型图片");
                            }
                            else
                            {
                                file.SaveAs(Path.Combine(Server.MapPath("/Content/Logo/"), newFileName));
                                return Content("<script>alert('保存成功！');location.href='logo';</script>");
                            }
                        }
                        break;
                    }
            }

            return View();
        }
        #endregion
    }
}