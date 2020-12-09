using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class Sauvegarde
    {
        private string compteFile = "comptes.csv";

        private string operationFile = "operations.csv";

        public List<Compte> GetComptes()
        {
            List<Compte> liste = new List<Compte>();
            if(File.Exists(compteFile))
            {
                StreamReader reader = new StreamReader(compteFile);
                string ligne = reader.ReadLine();
                while(ligne != null)
                {
                    ligne = reader.ReadLine();
                    if(ligne != null)
                    {
                        string[] content = ligne.Split(';');
                        int numero;
                        decimal solde;
                        Int32.TryParse(content[0], out numero);
                        Decimal.TryParse(content[1], out solde);
                        string nom = content[2];
                        string prenom = content[3];
                        string telephone = content[4];
                        Client client = new Client(nom, prenom, telephone);
                        Compte compte = new Compte(numero, client, solde);

                        //Récuperer les opérations à partir du fichier des opérations
                        compte.Operations = GetOperations(numero);
                        liste.Add(compte);
                    }
                }
                reader.Close();
            }
            return liste;
        }

        public List<Operation> GetOperations(int numero)
        {
            List<Operation> operations = new List<Operation>();
            //if(File.Exists(operationFile))
            //{
            //    StreamReader reader = new StreamReader(operationFile);
            //    string ligne = reader.ReadLine();
            //    while(ligne != null)
            //    {
            //        ligne = reader.ReadLine();
            //        if(ligne != null)
            //        {
            //            string[] content = ligne.Split(';');
            //            int numeroCompte;
            //            Int32.TryParse(content[0], out numeroCompte);
            //            if(numeroCompte == numero)
            //            {
            //                int numeroOperation;
            //                DateTime dateOperation;
            //                decimal montant;
            //                Int32.TryParse(content[1], out numeroOperation);
            //                DateTime.TryParse(content[2], out dateOperation);
            //                Decimal.TryParse(content[3], out montant);
            //                Operation o = new Operation(numeroOperation, dateOperation, montant);
            //                operations.Add(o);
            //            }
            //        }
            //    }
            //    reader.Close();
            //}
            return operations;
        }

        public void Save(List<Compte> comptes)
        {
            StreamWriter compteWriter = new StreamWriter(compteFile);
            StreamWriter operationWriter = new StreamWriter(operationFile);
            compteWriter.WriteLine("numero;solde;nom;prenom;telephone");
            operationWriter.WriteLine("numeroCompte;numero;date;montant");
            foreach(Compte c in comptes)
            {
                compteWriter.WriteLine($"{c.Numero};{c.Solde};{c.Client.Nom};{c.Client.Prenom};{c.Client.Telephone}");
                foreach(Operation o in c.Operations)
                {
                    operationWriter.WriteLine($"{c.Numero};{o.Id};{o.DateOperation};{o.Montant}");
                }
            }
            compteWriter.Close();
            operationWriter.Close();
        }

        
    }
}
