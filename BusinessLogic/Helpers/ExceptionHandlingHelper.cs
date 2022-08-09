namespace BusinessLogic.Helpers
{
    public static class ExceptionHandlingHelper
    {
        public static Exception ExceptionWithCustomCodeAndMessage(int code, string message)
        {
            var ex = new Exception(message);
            ex.Data.Add(code, message);
            return ex;
        }
    }
}