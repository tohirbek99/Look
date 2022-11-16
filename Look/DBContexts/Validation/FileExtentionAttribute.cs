using System.ComponentModel.DataAnnotations;

namespace Look.DBContexts.Validation
{
    public class FileExtentionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extention = Path.GetExtension(file.FileName);

                string[] extentions = { ".jpg", "png" };

                bool result = extentions.Any(x => extention.EndsWith(x));
                if (!result)
                {
                    return new ValidationResult("Allowed extentions are jpg and png");
                }
            }
            return ValidationResult.Success;
        }
    }
}
