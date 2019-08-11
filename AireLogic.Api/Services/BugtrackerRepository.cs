using AireLogic.Api.Entities;
using System;
using System.Collections.Generic;

namespace AireLogic.Api.Services
{
    public class BugtrackerRepository
    {
        private BugTrackerContext bugtrackerContext;

        public BugtrackerRepository(BugTrackerContext context)
        {
            bugtrackerContext = context;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return this.bugtrackerContext.People;
        }

        public Person GetPersonById(Guid id)
        {
            return this.bugtrackerContext.People.Find(id);
        }

        public void DeletePerson(Guid id)
        {
            var person = this.bugtrackerContext.People.Find(id);
            this.bugtrackerContext.People.Remove(person);            
        }

        public int SaveChanges()
        {
            return this.bugtrackerContext.SaveChanges();
        }

        public void AddPerson(Person person)
        {
            this.bugtrackerContext.People.Add(person);
        }
    }
}
