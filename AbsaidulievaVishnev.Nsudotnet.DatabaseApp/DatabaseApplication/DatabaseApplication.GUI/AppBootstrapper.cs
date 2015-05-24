using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.GUI.ViewModels;
using DatabaseApplication.Logic.Interfaces;
using DatabaseApplication.Logic.Interfases;
using DatabaseApplication.Logic.Realisations;

namespace DatabaseApplication.GUI
{
    class AppBootstrapper : AutofacBootstrapper<MainViewModel>
    {
        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterType<DataModel>().As<DataModel>().SingleInstance();
            builder.RegisterType<CrudServiseImpl<countries>>().As<ICrudServise<countries>>();
            builder.RegisterType<CrudServiseImpl<goods>>().As<ICrudServise<goods>>();
            builder.RegisterType<CrudServiseImpl<managers>>().As<ICrudServise<managers>>();
            builder.RegisterType<CrudServiseImpl<orders>>().As<ICrudServise<orders>>();
            builder.RegisterType<CrudServiseImpl<providers>>().As<ICrudServise<providers>>();
            builder.RegisterType<GoodsServiseImp>().As<IGoodsServise>();
            builder.RegisterType<OrdersServeseImpl>().As<IOrdersServise>();
            builder.RegisterType<ProvidersServiseImpl>().As<IProvidersServise>();
        }
    }
}
