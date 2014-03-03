﻿using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.DAL.Concrete
{
    public class DoctorRepository : IDoctorRepository
    {

        public IEnumerable<DoctorMiniInfoViewModel> getDoctorMiniInfoList()
        {
           using(Entities.Entities ctx=new Entities.Entities ())
           {
              var DoctorsIQ= ctx.Doctors;
              IEnumerable<DoctorMiniInfoViewModel>  DoctorList= (from d in DoctorsIQ
                                                                select new DoctorMiniInfoViewModel{ DoctorID=d.DoctorID, DoctorName = d.Name}).ToList();
              return DoctorList;
           }
        }
    }
}