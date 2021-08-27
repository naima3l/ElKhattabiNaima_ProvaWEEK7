using Impegni.ADORepositories;
using Impegni.Entities;
using Impegni.ListRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impegni
{
    class CommitmentManager
    {
        //static list
        //public static CommitmentListRepository cr = new CommitmentListRepository();

        //using ADO
        public static CommitmentADORepository cr = new CommitmentADORepository();
        internal static void ShowCommitments()
        {
            List<Commitment> commitments = cr.Fetch();

            foreach(var x in commitments)
            {
                Console.WriteLine(x.Print());
            }
        }

        internal static void UpdateCommitment()
        {
            Commitment commitmentChosen = ChooseCommitment();

            if(commitmentChosen.Status == true)
            {
                Console.WriteLine("L'impegno che stai provando a modificare è già stato portato a termine");
                return;
            }

            if(commitmentChosen.Id == null)
            {
                cr.Delete(commitmentChosen);
            }

            Commitment commitment = ChangeCommitmentData(commitmentChosen);

            cr.Update(commitment);
        }

        private static Commitment ChangeCommitmentData(Commitment commitmentChosen)
        {
            bool check = true;
            int choice;

            do
            {
                Console.WriteLine("Quale dato vuoi modificare? \n1. Titolo \n2. Descrizione \n3. Data di scadenza \n4. Importanza \n0. Non modificare");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4)
                {
                    Console.WriteLine("Scelta non valida. Riprova!");
                }

                switch (choice)
                {
                    case 1:
                        string title = String.Empty;
                        do
                        {
                            Console.WriteLine("Inserisci il titolo");
                            title = Console.ReadLine();

                        } while (String.IsNullOrEmpty(title));
                        commitmentChosen.Title = title;
                        break;
                    case 2:
                        string description = String.Empty;
                        do
                        {
                            Console.WriteLine("Inserisci la descrizione");
                            description = Console.ReadLine();

                        } while (String.IsNullOrEmpty(description));
                        commitmentChosen.Description = description;
                        break;
                    case 3:
                        DateTime date = new DateTime();
                        bool isDate;
                        do
                        {
                            Console.WriteLine("Inserisci la data di scadenza nel formato yy mm dd");

                            isDate = DateTime.TryParse(Console.ReadLine(), out date);

                        } while (!isDate || date < DateTime.Now);
                        commitmentChosen.ExpirationDate = date;
                        break;
                    case 4:
                        int importance = 0;

                        Console.WriteLine("Inserisci l'importanza! 1-> Alta, 2-> Media, 3-> Bassa");
                        while (!int.TryParse(Console.ReadLine(), out importance) || importance < 1 || importance > 3)
                        {
                            Console.WriteLine("Scelta non valida. Riprova!");
                        }
                        commitmentChosen.Importance = (EnumImportance)importance;
                        break;
                    case 0:
                        check = false;
                        break;
                }
            } while (check);
            return commitmentChosen;
        }

        private static Commitment ChooseCommitment()
        {
            List<Commitment> commitments = cr.Fetch();

            int i = 1;
            foreach (var x in commitments)
            {
                Console.WriteLine($"Premi {i} per {x.Print()}");
                i++;
            }

            bool isInt;
            int commitmentChosen;
            do
            {
                Console.WriteLine("Quale impegno vuoi eliminare/modificare?");

                isInt = int.TryParse(Console.ReadLine(), out commitmentChosen);

            } while (!isInt || commitmentChosen <= 0 || commitmentChosen > commitments.Count);

            return commitments.ElementAt(commitmentChosen - 1);
        }

        internal static void DeleteCommitment()
        {
            Commitment commitment = ChooseCommitment();
            cr.Delete(commitment);
        }

        internal static void InsertCommitment()
        {
            Commitment commitment = CommitmentData();
            cr.Insert(commitment);
        }

        private static Commitment CommitmentData()
        {
            Commitment commitment = new Commitment();

            string title = String.Empty;
            do
            {
                Console.WriteLine("Inserisci il titolo");
                title = Console.ReadLine();

            } while (String.IsNullOrEmpty(title));
            commitment.Title = title;

            string description = String.Empty;
            do
            {
                Console.WriteLine("Inserisci la descrizione");
                description = Console.ReadLine();

            } while (String.IsNullOrEmpty(description));
            commitment.Description = description;

            DateTime date = new DateTime();
            bool isDate;
            do
            {
                Console.WriteLine("Inserisci la data di scadenza nel formato yy mm dd");

                isDate = DateTime.TryParse(Console.ReadLine(), out date);

            } while (!isDate || date < DateTime.Now);
            commitment.ExpirationDate = date;

            int importance = 0;

            Console.WriteLine("Inserisci l'importanza! 1-> Alta, 2-> Media, 3-> Bassa");
            while (!int.TryParse(Console.ReadLine(), out importance) || importance < 1 || importance > 3)
            {
                Console.WriteLine("Scelta non valida. Riprova!");
            }
            commitment.Importance = (EnumImportance)importance;

            return commitment;
        }

        internal static void ShowCommitmentsByImportance(EnumImportance importance)
        {
            List<Commitment> commitments = cr.Fetch();
            var commitment = commitments.Where(u => u.Importance == importance);

            if(commitment.Count() == 0)
            {
                Console.WriteLine($"Non esiste nessun impegno con importanza {importance}");
            }
            else
            {
                foreach(var x in commitment)
                {
                    Console.WriteLine(x.Print());
                }
            }
        }

        internal static void UpdateCommitmentStatus()
        {
            Commitment commitmentChosen = ChooseCommitment();
            Commitment commitment = commitmentChosen;

            if (commitmentChosen.Id == null)
            {
                cr.Delete(commitmentChosen);
            }

            if(commitment.Status == true)
            {
                Console.WriteLine("L'impegno che hai scelto è stato già portato a termine");
                return;
            }

            commitment.Status = true;

            cr.Update(commitment);
        }

        //private static Commitment ChooseCommitmentNotDone()
        //{
        //    List<Commitment> commitments = cr.Fetch();
        //    var commitmentsNotDone = commitments.Where(u => u.Status == false);

        //        int i = 1;
        //        foreach (var x in commitmentsNotDone)
        //        {
        //            Console.WriteLine($"Premi {i} per {x.Print()}");
        //            i++;
        //        }

        //        bool isInt;
        //        int commitmentChosen;
        //        do
        //        {
        //            Console.WriteLine("Quale impegno vuoi eliminare/modificare?");

        //            isInt = int.TryParse(Console.ReadLine(), out commitmentChosen);

        //        } while (!isInt || commitmentChosen <= 0 || commitmentChosen > commitmentsNotDone.Count());

        //    return commitmentsNotDone.ElementAt(commitmentChosen - 1);

        //}

        internal static void ShowCommitmentsByStatus()
        {
            List<Commitment> commitments = cr.Fetch();

            int check = 0;

            foreach(var x in commitments)
            {
                if(x.Status == true)
                {
                    Console.WriteLine(x.Print());
                    check++;
                }
            }

            if(check ==0)
            {
                Console.WriteLine("Nessun impegno è stato portato a termine!");
            }
        }

        internal static void ShowCommitmentsByDate(DateTime date)
        {
            List<Commitment> commitments = cr.Fetch();

            foreach (var x in commitments)
            {
                if (x.ExpirationDate >= date)
                {
                    Console.WriteLine(x.Print());
                }
            }
        }
    }
}
