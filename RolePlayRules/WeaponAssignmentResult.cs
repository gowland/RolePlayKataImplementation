namespace RolePlayRules
{
    public class WeaponAssignmentResult
    {
        public WeaponAssignmentResult(string message)
            : this (false, message)
        {
        }

        private WeaponAssignmentResult(bool isSuccess, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; }
        public string Message { get; }

        public static WeaponAssignmentResult Success = new WeaponAssignmentResult(true);
    }
}