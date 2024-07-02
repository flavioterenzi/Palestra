using Palestra.Models;
using Palestra.Repositoris;

namespace Palestra.Services
{
    public class PersonaService
    {
        private readonly PersonaRepo _repository;

        public PersonaService(PersonaRepo repo)
        {
            _repository = repo;
        }

        public List<Persona> ElencoTuttePersona()
        {
            return _repository.GetAll();
        }

        public bool InserisciPersona(Persona per)
        {
            return _repository.Insert(per);
        }

        public bool ModificaPersona(Persona vecchio, Persona nuovo)
        {
            vecchio.Email = nuovo.Email;
            vecchio.Password = nuovo.Password;
            //...

            return _repository.Update(vecchio);
        }
    }
}
