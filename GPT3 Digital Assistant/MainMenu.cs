using OpenAI_API;

namespace GPT3_Digital_Assistant
{
    public partial class MainMenuForm : Form
    {
        OpenAIAPI api;

        #region MainMenu

        /// <summary>
        /// Main form constructor
        /// </summary>
        public MainMenuForm()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Main form loader 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            try
            {
                api = OpenAiAPI.AuthenticateToOpenAI();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Method that handles general questions from the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GeneralQuestionTB_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    GeneralQuestionTB.Enabled = false;
                    var response = await OpenAiAPI.RunCompletionAsync(api, GeneralQuestionTB.Text);
                    ResponseTB.Text = response.ToString();
                    GeneralQuestionTB.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralQuestionTB.Enabled = true;
            }
        }

        /// <summary>
        /// Event Handler for settings button on main page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsPanel.BringToFront();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Event handler for the more button on the main page. This brings you other options that the assistant can do
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoreBtn_Click(object sender, EventArgs e)
        {
            try
            {
                MorePanel.BringToFront();
            }
            catch (Exception ex)
            {

            }
        }


        #endregion MainMenu

        #region General

        /// <summary>
        /// Event handler for return home button. This brings you back to the main page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnHome_Click(object sender, EventArgs e)
        {
            try
            {
                MainPanel.BringToFront();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion General

        #region Settings

        /// <summary>
        /// Event handler for the creativity combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreativityCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OpenAiAPI.SetAICreativityLevel(CreativityCB.Text);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Event handler for intelligence combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntelligenceCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OpenAiAPI.SetAIIntelligenceLevel(IntelligenceCB.Text);
                api = OpenAiAPI.AuthenticateToOpenAI();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Event handler for response length combobox. Sets length of AI response.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResponseLengthTB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OpenAiAPI.SetAIResponseLength(ResponseLengthCB.Text);
            }
            catch (Exception ex)
            {

            }
        }

        #endregion Settings

        #region MoreScreen

        /// <summary>
        /// Event handler for sql query button. Brings up sql query screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SQLQueryBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SQLQueryPanel.BringToFront();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Event handler for explain code button. Opens the explain code screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExplainCodeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ExplainCodePanel.BringToFront();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Event handler for correct grammar button. Show the correct grammar screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CorrectGrammarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CorrectGrammarPanel.BringToFront();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Event handler for summarize button click. Shows the summarize screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SummarizeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SummarizePanel.BringToFront();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Event handler for write code button click. Brings write code panel to front.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteCodeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                WriteCodePanel.BringToFront();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion MoreScreen

        #region SQLQuery

        /// <summary>
        /// Event handler that listens for the enter key in the sql window. Will then take the users input and run it against the completion model.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void QueryInputTB_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    QueryInputTB.Enabled = false;
                    var response = await OpenAiAPI.RunCompletionAsync(api, $"Create a SQL Query that does the following: {QueryInputTB.Text}");
                    QueryOutputTB.Text = response.ToString();
                    QueryInputTB.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                QueryInputTB.Enabled = true;
            }
        }

        #endregion SQLQuery

        #region CodeExplanation

        /// <summary>
        /// Event handler for code input. Once enter key is pressed it will take the users code and evaluate it against the code engine for an explanation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CodeInputTB_KeyDown(object sender, KeyEventArgs e)
        {
            string currentEngine = OpenAiAPI.engine;

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    OpenAiAPI.AuthenticateToOpenAI(true, "code-davinci-001");
                    CodeInputTB.Enabled = false;
                    var response = await OpenAiAPI.RunCompletionAsync(api, $"Explain this code: {CodeInputTB.Text}");
                    CodeOutputTB.Text = response.ToString();
                    CodeInputTB.Enabled = true;
                    OpenAiAPI.AuthenticateToOpenAI(true, currentEngine);
                }
            }
            catch (Exception ex)
            {
                OpenAiAPI.AuthenticateToOpenAI(true, currentEngine);
            }
        }

        #endregion CodeExplanation

        #region CorrectGrammar

        /// <summary>
        /// Method that gets the users clipboard data and puts it in the grammar input CB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrammarClipboardBtn_Click(object sender, EventArgs e)
        {
            try
            {
                GrammarInputTB.Text = Clipboard.GetText();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Method that launches file explorer and filters on text documents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrammarFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string fileText = string.Empty;
                string filePath = string.Empty;
                OpenFileDialog Dialog = new OpenFileDialog();
                Dialog.Title = "Select a file";
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = Dialog.FileName;
                    fileText = File.ReadAllText(filePath);
                    GrammarInputTB.Text = fileText;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Method that takes the input from the grammar textbox and will correct grammar (and spelling if asked) of the text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ConvertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string command = string.Empty;
                
                if (GrammarYesRB.Checked)
                    command = $"Correct the following to standard english and correct the spelling: {GrammarInputTB.Text}"; 
                else
                    command = $"Correct the following to standard english: {GrammarInputTB.Text}";

                GrammarInputTB.Enabled = false;
                var response = await OpenAiAPI.RunCompletionAsync(api, command);
                GrammarOutputTB.Text = response.ToString();
                GrammarInputTB.Enabled = true;
            }
            catch (Exception ex)
            {
                GrammarInputTB.Enabled = true;
            }
        }



        #endregion CorrectGrammar

        #region Summarize

        /// <summary>
        /// Event handler for summarize btn that will summarize given text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SummarizeConvertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string command = $"Summarize the following text for me: {SummarizeInputTB.Text}";
                SummarizeInputTB.Enabled = false;
                var response = await OpenAiAPI.RunCompletionAsync(api, command);
                SummarizeOutputTb.Text = response.ToString();
                SummarizeInputTB.Enabled = true;
            }
            catch (Exception ex)
            {
                SummarizeInputTB.Enabled = true;
            }
        }







        #endregion Summarize

        #region WriteCode

        /// <summary>
        /// Event handler for generate code button click. This takes the input from the user and writes it in the desired language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GenerateCodeBtn_Click(object sender, EventArgs e)
        {
            string currentEngine = OpenAiAPI.engine;
            try
            {
                OpenAiAPI.AuthenticateToOpenAI(true, "code-davinci-001");
                WriteCodeInputTB.Enabled = false;
                var response = await OpenAiAPI.RunCompletionAsync(api, $"Write the following code in {CodeLanguageCB.Text}: {WriteCodeInputTB.Text}");
                WriteCodeOutputTB.Text = response.ToString();
                WriteCodeInputTB.Enabled = true;
                OpenAiAPI.AuthenticateToOpenAI(true, currentEngine);
            }
            catch (Exception ex)
            {
                OpenAiAPI.AuthenticateToOpenAI(true, currentEngine);
            }
        }

        #endregion WriteCode


    }
}