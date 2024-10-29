using System.Diagnostics.Metrics;

namespace WhatsAppProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WhatsAppSendMessage w = new WhatsAppSendMessage();

            string pathImage = "D:\\dev\\WhatsAppProject\\Image.jpeg";


            string message = "*Lavadora Brastemp 12Kg - Último modelo*         Telefone/WhatsApp: 31 9 9447-5050";


            //string caminho = @"D:\dev\WhatsAppProject\ListaGrupos.txt";
            string caminho = @"D:\dev\WhatsAppProject\Mega.txt";
                                   
            
            List<string> ListGroups = new List<string>();
            

            // Metodo estatico que importa os grupos e insere na lista de grupos
            GroupsImport.ImportGroups(ListGroups, caminho);


            bool eraseOldMessages = false;

            //w.EraseGroups(ListGroups);

            w.SendMessageWithImage(message, pathImage, eraseOldMessages, ListGroups);

           // w.SendMessage(message, "GroupTest");
        }
    }
}