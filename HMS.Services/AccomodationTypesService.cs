using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;


namespace HMS.Services
{
    public class AccomodationTypesService
    {
        public List<AccomodationType> GetAllAccomodationTypes()
        {
            var context = new HMSContext();
            return context.AccomodationTypes.AsEnumerable().ToList();
        }

        public IEnumerable<AccomodationType> SearchAccomodationTypes(string searchTerm)
        {
            var context = new HMSContext();
            var accomodationTypes = context.AccomodationTypes.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodationTypes = accomodationTypes.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return accomodationTypes.ToList();
        }

        public AccomodationType GetAllAccomodationTypeByID(int ID)
        {
            var context = new HMSContext();

            return context.AccomodationTypes.Find(ID);
        }

        public bool SaveAccomodationType(AccomodationType accomodationtype)
        {
            var context = new HMSContext();
            context.AccomodationTypes.Add(accomodationtype);

            return context.SaveChanges() > 0;

        }

        public bool UpdateAccomodationType(AccomodationType accomodationtype)
        {
            var context = new HMSContext();
            context.Entry(accomodationtype).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;

        }


        public bool DeleteAccomodationType(AccomodationType accomodationtype)
        {
            var context = new HMSContext();
            context.Entry(accomodationtype).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;

        }
    }

}

