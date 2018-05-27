using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace DAISPizza.Server.ModelBinders
{
    public class IngredientsCollectionModelBinder : DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
        {

            if (propertyDescriptor.Name == "Ingredients")
            {
                var form = controllerContext.HttpContext.Request.Form;
                var ingredients = form.Get("Ingredients") as string;
                var value = ingredients.Split(',')
                    .Select(ingredient => int.Parse(ingredient))
                    .ToList();
                propertyDescriptor.SetValue(bindingContext.Model, value);
            }

            else
            {
                base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
            }
        }
    }
}