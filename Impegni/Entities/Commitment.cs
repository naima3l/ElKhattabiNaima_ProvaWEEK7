using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impegni.Entities
{
    class Commitment
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public EnumImportance Importance { get; set; }
        public bool Status { get; set; } = false;

        public int? Id { get; set; }

        public Commitment()
        { }

        public Commitment(string title, string description, DateTime expirationDate,EnumImportance importance, bool status, int? id)
        {
            Title = title;
            Description = description;
            ExpirationDate = expirationDate;
            Importance = importance;
            Status = status;
            Id = id;
        }

        public string Print()
        {
            return $"Titolo : {Title}, Descrizione : {Description}, Data di scadenza : {ExpirationDate.ToShortDateString()}, Importanza : {Importance}, Portato a termine : {Status}";
        }
    }

    enum EnumImportance
    {
        High = 1,
        Medium = 2,
        Low = 3
    }
}
