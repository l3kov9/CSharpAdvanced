using System;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace LocalPub.Server.ModelBinders
{
    public class DateModelBinder : DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
        {

            if (propertyDescriptor.Name == "OrderDate")
            {
                var form = controllerContext.HttpContext.Request.Form;
                var dateTimeValue = form.Get("OrderDate") as string;
                var value = dateTimeValue.Split('.')
                    .Select(part => int.Parse(part))
                    .ToList();
                propertyDescriptor.SetValue(bindingContext.Model, new DateTime(value[2], value[1], value[0]));
            }

            else
            {
                base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
            }
        }
    }
}