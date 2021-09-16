using FluentValidation.Results;

namespace LibraryDomain.Interfaces
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}
