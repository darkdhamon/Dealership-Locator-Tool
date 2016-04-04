using System;
using System.Web.Mvc;
using System.Web.Routing;
using DealershipModel.Abstract;
using Moq;
using Ninject;

namespace DealershipMVC.Infrastructure
{
   public class NinjectControllerFactory : DefaultControllerFactory
   {
      private readonly IKernel ninjectKernal;

      public NinjectControllerFactory()
      {
         ninjectKernal = new StandardKernel();
         AddBindings();
      }

      private void AddBindings()
      {
         
      }

      protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
      {
         return controllerType == null ? null : (IController) ninjectKernal.Get(controllerType);
      }
   }
}