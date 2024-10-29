using EasyAutomationFramework;

namespace WhatsAppProject
{
    public class WhatsAppSendMessage : Web
    {
        public void SendMessage(string message, string to)
        {
            //StartBrowser(TypeDriver.GoogleChorme, "C:\\Users\\E55570\\AppData\\Local\\Google\\Chrome\\User Data");

            StartBrowser(TypeDriver.GoogleChorme);

            // C:\Users\E55570\AppData\Local\Google\Chrome\User Data


            Navigate("https://web.whatsapp.com/");

            WaitForLoad();

            Thread.Sleep(TimeSpan.FromSeconds(30));

            //WaitForElement(TypeElement.Xpath, "//*[@id=\"side\"]/div[1]/div/div[2]/div[2]/div/div/p");

            var elementSearch = AssignValue(TypeElement.Xpath, "//*[@id=\"side\"]/div[1]/div/div[2]/div[2]/div/div/p", to);
            elementSearch.element.SendKeys(OpenQA.Selenium.Keys.Enter);

            var elementMessage = AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span/div/div[2]/div[1]/div/div[1]/p", message);
            elementMessage.element.SendKeys(OpenQA.Selenium.Keys.Enter);

            //CloseBrowser();
        }


        public void EraseGroups(List<string> groups)
        {

            StartBrowser(TypeDriver.GoogleChorme);

            Navigate("https://web.whatsapp.com/");

            WaitForLoad();

            Thread.Sleep(TimeSpan.FromSeconds(30));

            foreach (var group in groups)
            {
                //WaitForElement(TypeElement.Xpath, "//*[@id=\"side\"]/div[1]/div/div[2]/div[2]/div/div/p");

                // Procura pelo Grupo
                var elementSearch = AssignValue(TypeElement.Xpath, "//*[@id=\"side\"]/div[1]/div/div[2]/div[2]/div/div/p", group);
                elementSearch.element.SendKeys(OpenQA.Selenium.Keys.Enter);

                Thread.Sleep(TimeSpan.FromSeconds(1));

                // Clicar nos 3 pontos
                Click(TypeElement.Xpath, "//*[@id=\"main\"]/header/div[3]/div/div[2]/div/div/span");

                Thread.Sleep(TimeSpan.FromSeconds(1));

                // Botao Clear

                Click(TypeElement.Xpath, "//*[@id=\"app\"]/div/span[5]/div/ul/div/div/li[5]/div");

                Thread.Sleep(TimeSpan.FromSeconds(3));

                //Confirmar Limpar mensagens antigas 
                Click(TypeElement.Xpath, "//*[@id=\"app\"]/div/span[2]/div/div/div/div/div/div/div[2]/div/button[2]/div/div");

                Thread.Sleep(TimeSpan.FromSeconds(1));

                // Clica no X para apagar o nome do grupo corrente
                Click(TypeElement.Xpath, "//*[@id=\"side\"]/div[1]/div/div[2]/span/button/span");
            }

        }


        public void SendMessageWithImage(string message, string pathImage, bool eraseOldMessages, List<string> listGroups)
        {
            // C:\Users\E55570\AppData\Local\Google\Chrome\User Data
            //StartBrowser(TypeDriver.GoogleChorme, "C:\\Users\\E55570\\AppData\\Local\\Google\\Chrome\\User Data");

            StartBrowser(TypeDriver.GoogleChorme);

            Navigate("https://web.whatsapp.com/");

            WaitForLoad();

            Thread.Sleep(TimeSpan.FromSeconds(30));

            foreach (var group in listGroups)
            {
                //WaitForElement(TypeElement.Xpath, "//*[@id=\"side\"]/div[1]/div/div[2]/div[2]/div/div/p");

                // Procura pelo Grupo
                var elementSearch = AssignValue(TypeElement.Xpath, "//*[@id=\"side\"]/div[1]/div/div[2]/div[2]/div/div/p", group);
                elementSearch.element.SendKeys(OpenQA.Selenium.Keys.Enter);

                Thread.Sleep(TimeSpan.FromSeconds(2));

                if (eraseOldMessages)
                {
                    // Clicar nos 3 pontos
                    Click(TypeElement.Xpath, "//*[@id=\"main\"]/header/div[3]/div/div[2]/div/div/span");              

                    Thread.Sleep(TimeSpan.FromSeconds(1));

                    // Botao Clear
                    Click(TypeElement.Xpath, "//*[@id=\"app\"]/div/span[5]/div/ul/div/div/li[6]/div");

                    Thread.Sleep(TimeSpan.FromSeconds(1));

                    //Confirmar Limpar mensagens antigas 
                    Click(TypeElement.Xpath, "//*[@id=\"app\"]/div/span[2]/div/div/div/div/div/div/div[2]/div/button[2]/div/div");

                    Thread.Sleep(TimeSpan.FromSeconds(5));
                }

                // Clicar no botao clip
                Click(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span/div/div[1]/div[2]/div/div/div/span");

                Thread.Sleep(TimeSpan.FromSeconds(2));

                //Adicionar o caminho da Image
                AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span/div/div[1]/div[2]/div/span/div/ul/div/div[2]/li/div/input", pathImage);

                Thread.Sleep(TimeSpan.FromSeconds(2));

                //Adicionar Mensagem junto com a Imagem
                var elementInput = AssignValue(TypeElement.Xpath, "//*[@id=\"app\"]/div/div[2]/div[2]/div[2]/span/div/div/div/div[2]/div/div[1]/div[3]/div/div/div[2]/div[1]/div[1]/p", message);
                elementInput.element.SendKeys(OpenQA.Selenium.Keys.Enter);
                    
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
        }
    }
}
