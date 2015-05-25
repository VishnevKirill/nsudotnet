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
            builder.RegisterType<CrudServiceImpl<countries>>().As<ICrudService<countries>>();
            builder.RegisterType<CrudServiceImpl<goods>>().As<ICrudService<goods>>();
            builder.RegisterType<CrudServiceImpl<managers>>().As<ICrudService<managers>>();
            builder.RegisterType<CrudServiceImpl<orders>>().As<ICrudService<orders>>();
            builder.RegisterType<CrudServiceImpl<providers>>().As<ICrudService<providers>>();
            builder.RegisterType<GoodsServiceImp>().As<IGoodsService>();
            builder.RegisterType<OrdersServeseImpl>().As<IOrdersService>();
            builder.RegisterType<ProvidersServiceImpl>().As<IProvidersService>();
        }
    }
}
