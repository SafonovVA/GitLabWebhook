using GitLabWebhook.Requests.Requests;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GitLabWebhook.Binders;

public class GitLabWebhookModelBinder : IModelBinder
{
    private Dictionary<Type, (ModelMetadata, IModelBinder)> binders;

    public GitLabWebhookModelBinder(Dictionary<Type, (ModelMetadata, IModelBinder)> binders)
    {
        this.binders = binders;
    }

    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {

        var modelKindName = ModelNames.CreatePropertyModelName(bindingContext.ModelName, nameof(EventRequest.ObjectKind));
        var modelTypeValue = bindingContext.ValueProvider.GetValue(modelKindName).FirstValue;
        

        IModelBinder modelBinder;
        ModelMetadata modelMetadata;
        Console.WriteLine("modelKindName: " + modelKindName);
        Console.WriteLine("modelTypeValue: " + bindingContext.ValueProvider.GetValue("object_kind").FirstValue);
        Console.WriteLine("modelTypeValue: " + bindingContext.ValueProvider.GetValue("objectKind").FirstValue);
        Console.WriteLine("modelTypeValue: " + bindingContext.ValueProvider.GetValue("ObjectKind").FirstValue);
        Console.WriteLine("modelTypeValue: " + bindingContext.ValueProvider.GetValue("Object_Kind").FirstValue);
        Console.WriteLine("modelTypeValue: " + bindingContext.ValueProvider.GetValue(modelKindName).FirstValue);
        switch (modelTypeValue)
        {
            case "push":
                (modelMetadata, modelBinder) = binders[typeof(Push)];
                break;
            case "note":
                (modelMetadata, modelBinder) = binders[typeof(Note)];
                break;
            default:
                bindingContext.Result = ModelBindingResult.Failed();
                return;
        }

        var newBindingContext = DefaultModelBindingContext.CreateBindingContext(
            bindingContext.ActionContext,
            bindingContext.ValueProvider,
            modelMetadata,
            bindingInfo: null,
            bindingContext.ModelName);

        await modelBinder.BindModelAsync(newBindingContext);
        bindingContext.Result = newBindingContext.Result;

        if (newBindingContext.Result.IsModelSet)
        {
            // Setting the ValidationState ensures properties on derived types are correctly 
            bindingContext.ValidationState[newBindingContext.Result.Model] = new ValidationStateEntry
            {
                Metadata = modelMetadata,
            };
        }
    }
}