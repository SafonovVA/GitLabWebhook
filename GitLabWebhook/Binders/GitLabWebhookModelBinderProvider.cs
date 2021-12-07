using GitLabWebhook.Requests.Requests;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GitLabWebhook.Binders;

public class GitLabWebhookModelBinderProvider : IModelBinderProvider
{
    private readonly Logger<GitLabWebhookModelBinderProvider> _logger;

    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        
        if (context.Metadata.ModelType != typeof(EventRequest))
        {
            return null;
        }
        
        var subclasses = new[] { typeof(Push), typeof(Note), };

        var binders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();
        foreach (var type in subclasses)
        {
            var modelMetadata = context.MetadataProvider.GetMetadataForType(type);
            binders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
        }
        
        return new GitLabWebhookModelBinder(binders);
    }
}