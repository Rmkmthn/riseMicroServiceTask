using Rise.ContactCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ContactCore.Business
{
    public interface IContactConstService
    {
        IQueryable<Const> GetConsts();
        IQueryable<Const> GetInfoTypes();
    }
    public class ConstService : IContactConstService
    {
        private readonly ApplicationDbContext _ctxApplication;

        public ConstService(ApplicationDbContext ctxApplication)
        {
            _ctxApplication = ctxApplication;
        }

        public IQueryable<Const> GetConsts()
        {
            return _ctxApplication.Consts;
        }

        public IQueryable<Const> GetInfoTypes()
        {
            return _ctxApplication.Consts.Where(c => c.ConstID == "ContactInfoTypes");
        }
    }
}
