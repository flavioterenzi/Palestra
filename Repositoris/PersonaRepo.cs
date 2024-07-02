using Palestra.Models;

namespace Palestra.Repositoris
{
    public class PersonaRepo
    {
        private readonly GymContext _context;

        public PersonaRepo(GymContext ctx)
        {
            _context = ctx;
        }


        public bool Delete(int id)
        {
            try
            {
                Persona temp = _context.Personas.Single(p => p.IdPers == id);
                _context.Personas.Remove(temp);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public List<Persona> GetAll()
        {
            return _context.Personas.ToList();
        }

        public Persona? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Persona t)
        {
            try
            {
                _context.Personas.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }



        public bool Update(Persona t)
        {
            try
            {
                _context.Update(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }
    }
}
