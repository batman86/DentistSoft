// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using DentistManager.DentistUI.Models;
using StructureMap;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.DAL.Concrete;
using DentistManager.Domain.BL.Abstract;
using DentistManager.Domain.BL.Concrete;
using DentistManager.DentistUI.Infrastructure;

namespace DentistManager.DentistUI.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<IDoctorRepository>().Use<DoctorRepository>();
                            x.For<IimagesRepository>().Use<ImagesRepository>();
                            x.For<IAppointmentRepository>().Use<AppointmentRepository>();
                            x.For<IPatientRepository>().Use<PatientRepository>();
                            x.For<ISeassionStateBL>().Use<SeassionStateBL>();
                            x.For<ISessionStateManger>().Use<SessionStateManger>();
                            x.For<ITreatmentRepository>().Use<TreatmentRepository>();
                            x.For<IOpperationRepository>().Use<OpperationRepository>();
                            x.For<ITreatmentBL>().Use<TreatmentBL>();
                            x.For<IMaterialRepository>().Use<MaterialRepository>();
                            x.For<ICustomMatrialRepository>().Use<CustomMatrialRepository>();
                            x.For<IPrescriptionRepository>().Use<PrescriptionRepository>();
                            x.For<IMedicineRepository>().Use<MedicineReposditory>();
                            x.For<IPaymentReceiptRerpository>().Use<PaymentReceiptRerpository>();
                            x.For<IPatientPaymentBL>().Use<PatientPaymentBL>();
                            x.For<IMatrailBL>().Use<MatrailBL>();

                            x.For<Microsoft.AspNet.Identity.IUserStore<ApplicationUser>>()
                            .Use<Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>>();

                            x.For<System.Data.Entity.DbContext>().Use(() => new ApplicationDbContext());
                        });
            return ObjectFactory.Container;
        }
    }
}