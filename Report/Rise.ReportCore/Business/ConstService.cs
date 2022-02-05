using Rise.ReportCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ReportCore.Business
{
    public interface IReportConstService
    {
        IQueryable<Const> GetConsts();
        IQueryable<Const> GetReportStatuses();
    }

    public class ConstService : IReportConstService
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

        public IQueryable<Const> GetReportStatuses()
        {
            return _ctxApplication.Consts.Where(c => c.ConstID == "ReportStatus");
        }
    }
}
