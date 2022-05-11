using OpenAI_API;

namespace GPT3_Digital_Assistant
{
    public class OpenAiAPI
    {
        public static double creativityLevel = 0.0;
        public static string engine = "text-davinci-001";
        public static int maxTokens = 100;

        /// <summary>
        /// Method that will authenticate to the openAI API and return a session
        /// </summary>
        /// <returns></returns>
        public static OpenAIAPI AuthenticateToOpenAI(bool ChangeEngine = false, string RequestedEngine = "")
        {
            try
            {
                if (ChangeEngine)
                    engine = RequestedEngine;
                
                OpenAIAPI api = new OpenAIAPI(new APIAuthentication(Properties.Settings.Default.APIKey), new Engine(engine));
                return api;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// This controls the temperature of the AI. Typically, higher the number the more random the model will be
        /// </summary>
        /// <param name="Level"></param>
        public static void SetAICreativityLevel(string Level)
        {
            try
            {
                switch (Level)
                {
                    case "Minimal":
                        creativityLevel = 0.0;
                        break;
                    case "Medium:":
                        creativityLevel = 0.7;
                        break;
                    case "Maximum":
                        creativityLevel = 1.0;
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Method that will change the engine of the AI. Some engines are more capable than others, hence "intelligence"
        /// </summary>
        /// <param name="Level"></param>
        public static void SetAIIntelligenceLevel(string Level)
        {
            try
            {
                switch (Level)
                {
                    case "Low":
                        engine = "text-ada-001";
                        break;
                    case "Medium":
                        engine = "text-babbage-001";
                        break;
                    case "High":
                        engine = "text-curie-001";
                        break;
                    case "Musk":
                        engine = "text-davinci-001";
                        break;
                }
            }
            catch (Exception Ex)
            {

            }
        }

        /// <summary>
        /// Method that sets the response length of the AI
        /// </summary>
        /// <param name="Length"></param>
        public static void SetAIResponseLength(string Length)
        {
            try
            {
                switch (Length)
                {
                    case "Short":
                        maxTokens = 50;
                        break;
                    case "Medium":
                        maxTokens = 100;
                        break;
                    case "Long":
                        maxTokens = 150;
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Method that runs the completions endpoint
        /// </summary>
        /// <param name="api"></param>
        /// <param name="Request"></param>
        /// <returns></returns>
        public static async Task<CompletionResult> RunCompletionAsync(OpenAIAPI api, string Request)
        {
            try
            {
                var response = await api.Completions.CreateCompletionAsync(new CompletionRequest(Request, temperature: creativityLevel, max_tokens: maxTokens));
                return response;
            }
            catch (Exception ex)
            {
                return new CompletionResult();
            }
        }



    }
}
