using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.vModel;

namespace Warehouse.Views.BaseViewPage
{
    public abstract class BaseViewPage : WebViewPage
    {
        public virtual new User User
        {
            get { return Session["USER"] as User; }
        }
    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual new User User
        {
            get { return Session["USER"] as User; }
        }
    }
}