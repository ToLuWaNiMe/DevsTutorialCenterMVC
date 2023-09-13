using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevsTutorialCenterMVC.Data.MethodExtensions
{
    public static class ModelStateExtension
    {
        public static List<object> AllErrors(this ModelStateDictionary modelState)
        {
            var result = new List<object>();
            var erroneousFields = modelState.Where(ms => ms.Value!.Errors.Any())
                                            .Select(x => new { x.Key, x.Value!.Errors });

            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key;
                var fieldErrors = erroneousField.Errors
                                   .Select(error => new { fieldKey, error.ErrorMessage} );
                result.AddRange(fieldErrors);
            }

            return result;
        }
    }
}
