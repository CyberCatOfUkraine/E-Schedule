using System;
using System.Collections.Generic;
using AutoMapper;
using E_Schedule_BLL.Entities;
using E_Schedule_DAL;

namespace E_Schedule_BLL
{
    public partial class BLL : IBLL
    {
        IUoW UoW;

        public BLL(IUoW UoW)
        {
            this.UoW = UoW;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                if (disposing)
                {
                    UoW.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}