using System;
using System.Collections;
using System.IO;

namespace WhatsAppProject
{
    public static class GroupsImport
    {

        public static void ImportGroups(List<string> listaGrupos, string caminho)
        {

            if (!File.Exists(caminho))
                return;

            // Instancia um FileStream e um StreamReader
            FileStream fs = File.OpenRead(caminho);
            StreamReader sr = new StreamReader(fs);

            // String para receber as linhas do ficheiro
            string linha;
            // String com 3 campos para separar os dados de cada linha
            // $"{Id} - {Nome} - {TotalDeHoras} horas";
 //           string[] arrayDisciplina = new string[3];

            // Percorre o ficheiro, le os dados das disciplinass, cria disciplinas e os inseri na lista de disciplinas
            while (!sr.EndOfStream)
            {
                // Cria uma nova disciplina
 //               Disciplina disciplina = new Disciplina();
                // Le informações de cada linha
                linha = sr.ReadLine();
 //               arrayDisciplina = linha.Split(',');
                // Popula a disciplina
 //               disciplina.Id = Convert.ToInt32(arrayDisciplina[0]);
  //              disciplina.Nome = arrayDisciplina[1];
  //              disciplina.TotalDeHoras = (float)Convert.ToDouble(arrayDisciplina[2]);
                // Adiciona o disciplina na lista de disciplinas
 //               disciplinas.Add(disciplina);


                listaGrupos.Add(linha);
            }

            sr.Close();

            foreach (string str in listaGrupos)
            {
                Console.WriteLine(str);
            }
            return;
        }

    }
}
