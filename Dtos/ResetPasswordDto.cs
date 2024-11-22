namespace adilapi
{
    public class ResetPasswordDto
    {
        public string? Name { get; set; }  // Name of the person whose password is to be reset
        public string? NewPassword { get; set; }  // New password
    }
}
