using Impegni.Entities;
using Impegni.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impegni.ListRepositories
{
    class CommitmentListRepository : ICommitmentDbManager
    {
        public static List<Commitment> commitments = new List<Commitment>()
        {
            new Commitment("Visita medica", "Visita ortopedica", new DateTime(2021,11,27),EnumImportance.Low,false,null),
            new Commitment("Estetista", "Ceretta", new DateTime(2021,10,2),EnumImportance.Medium,false,null),
            new Commitment("Visita medica", "Visita oculistica", new DateTime(2021,09,27),EnumImportance.High,false,null),
            new Commitment("Tesi", "Consegna tesi", new DateTime(2021,09,15),EnumImportance.High,false,null)

        };

        public void Delete(Commitment commitment)
        {
            commitments.Remove(commitment);
        }

        public List<Commitment> Fetch()
        {
            return commitments;
        }

        public Commitment GetById(int? id)
        {
            return commitments.Find(u => u.Id == id);
        }

        public void Insert(Commitment commitment)
        {
            commitments.Add(commitment);
        }

        public void Update(Commitment commitment)
        {
            Insert(commitment);
        }
    }
}
