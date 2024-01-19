using FluentValidation.Results;

namespace recipesv2.Helpers
{
    public class ValidationCompleted
    {
        public List<KeyValuePair<string, string>> Errors { get; set; } = new List<KeyValuePair<string, string>>();
    }
}
