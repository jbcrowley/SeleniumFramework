namespace SeleniumFramework.Common
{
    public class Logger
    {
        /// <summary>
        /// Writes the current NUnit log to file and and attaches it to the current NUnit TestContext.
        /// </summary>
        public static void AttachLog()
        {
            string fullFilePath = $"{GenerateLogPath()}.txt";
            // TODO: Write errors to log and attach to TestContext
            using (StreamWriter outputFile = new(fullFilePath))
            {
                outputFile.WriteLine("test");
            }
            TestContext.AddTestAttachment(fullFilePath);
        }

        /// <summary>
        /// Returns a datetime stamped path in the \Logs folder.
        /// </summary>
        /// <returns>The full file path to the log file.</returns>
        public static string GenerateLogPath()
        {
            string path = $@"{Environment.GetEnvironmentVariable("USERPROFILE")}\Downloads\Logs";
            Directory.CreateDirectory(path);
            string filename = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyy.dd.MM_HH.mm.ss.fff}";

            return Path.Combine(path, filename);
        }

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