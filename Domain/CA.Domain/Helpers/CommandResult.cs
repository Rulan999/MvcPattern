using System;
namespace CA.Domain.Helpers
{
    public class CommandResult<T>
    {
        public CommandStatus Status { get; set; }
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
    }

    public enum CommandStatus
    {
        Success,
        Error
    }
}
