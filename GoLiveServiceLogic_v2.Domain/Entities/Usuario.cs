using GoLiveServiceLogic_v2.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoLiveServiceLogic_v2.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Job { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public Usuario(int id, string name, string email, string job, bool active, DateTime createDate)
        {
            Validation(name, email, job);
            Name = name;
            Email = email;
            Job = job;
            Active = active;
            CreateDate = createDate;
        }

        public Usuario()
        {
            DomainValidationException.When(Id < 0, "O Id deverá ser maior do que zero");
        }
        private void Validation(string name, string email, string job)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "o nome deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(email), "o email deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(job), "o job deve ser informado");

        }
    }

}
