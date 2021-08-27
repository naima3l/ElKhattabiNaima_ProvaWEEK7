using Impegni.Entities;
using System;

namespace Impegni
{
    internal class Menu
    {
        internal static void Start()
        {
            bool check = true;
            int choice;
            do
            {
                Console.WriteLine("BENVENUTO! \nPremi 1 per visualizzare tutti gli impegni \nPremi 2 per modificare un impegno \nPremi 3 per eliminare un impegno \nPremi 4 per inserire un nuovo impegno \nPremi 5 per visualizzare gli impegni per data maggiore o uguale alla data inserita \nPremi 6 per visualizzare gli impegni per il livello di importanza inserito \nPremi 7 per visualizzare gli impegni portati a termine \nPremi 8 per portare a termine un impegno \nPremi 0 per uscire");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 8)
                {
                    Console.WriteLine("Scelta non valida! Riprova.");
                }

                switch (choice)
                {
                    case 1:
                        CommitmentManager.ShowCommitments();
                        break;
                    case 2:
                        CommitmentManager.UpdateCommitment();
                        break;
                    case 3:
                        CommitmentManager.DeleteCommitment();
                        break;
                    case 4:
                        CommitmentManager.InsertCommitment();
                        break;
                    case 5:
                        ShowCommitmentsByDate();
                        break;
                    case 6:
                        ShowCommitmentsByImportance();
                        break;
                    case 7:
                        CommitmentManager.ShowCommitmentsByStatus();
                        break;
                    case 8:
                        CommitmentManager.UpdateCommitmentStatus();
                        break;
                    case 0:
                        Console.WriteLine("Ciao ciao!");
                        check = false;
                        break;
                }
            } while (check);
        }

        private static void ShowCommitmentsByImportance()
        {
            int importance = 0;
            Console.WriteLine("Inserisci l'importanza per cui vuoi visualizzare gli impegni! \n1-> Alta, 2-> Media, 3-> Bassa");
            while (!int.TryParse(Console.ReadLine(), out importance) || importance < 1 || importance > 3)
            {
                Console.WriteLine("Scelta non valida. Riprova!");
            }
            CommitmentManager.ShowCommitmentsByImportance((EnumImportance)importance);
        }


        private static void ShowCommitmentsByDate()
        {
            Console.WriteLine("Inserisci la data per cui vuoi visualizzare gli impegni con data uguale o maggiore. \nRicorda che puoi inserire una data posteriore a quella di oggi");

            DateTime date = new DateTime();

            while(!DateTime.TryParse(Console.ReadLine(),out date) || date <= DateTime.Now)
            {
                Console.WriteLine("Data non valida. Riprova!");
            }

            CommitmentManager.ShowCommitmentsByDate(date);
        }
    }
}