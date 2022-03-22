using AireLogic.Api.Entities;
using System;
using System.Collections.Generic;

namespace AireLogic.Api.Services
{
    public interface IBugtrackerRepository
    {
        IEnumerable<Person> GetAllPeople();
        Person GetPersonById(Guid id);
        void DeletePerson(Guid id);
        void AddPerson(Person person);
        int SaveChanges();
        void DeleteBug(Guid id);
        void AddBug(Bug bug);
        IEnumerable<Bug> GetAllBugs();
        Bug GetBugById(Guid id);        
    }

    public class BugtrackerRepository : IBugtrackerRepository
    {
        private BugTrackerContext bugtrackerContext;

        public BugtrackerRepository(BugTrackerContext context)
        {
            bugtrackerContext = context;
        }

        #region people
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

        public void AddPerson(Person person)
        {
            this.bugtrackerContext.People.Add(person);
        }

        #endregion

        public int SaveChanges()
        {
            return this.bugtrackerContext.SaveChanges();
        }       

        #region bugs


        public void DeleteBug(Guid id)
        {
            var bug = this.bugtrackerContext.Bugs.Find(id);
            this.bugtrackerContext.Bugs.Remove(bug);
        }

        public void AddBug(Bug bug)
        {
            this.bugtrackerContext.Bugs.Add(bug);
        }

        public IEnumerable<Bug> GetAllBugs()
        {
            return this.bugtrackerContext.Bugs;
        }

        public Bug GetBugById(Guid id)
        {
            return this.bugtrackerContext.Bugs.Find(id);
        }

        #endregion
    }
}
