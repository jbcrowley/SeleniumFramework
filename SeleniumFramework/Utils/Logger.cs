namespace SeleniumFramework.Utils
{
    public class Logger
    {
        /// <summary>
        /// Writes a message to the current test.
        /// </summary>
        /// <param name="message">The message to be written.</param>
        public static void Log(string message)
        {
            TestContext.Out.WriteLine(message);
        }
    }
}