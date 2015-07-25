using System;
using System.Collections.Generic;
using System.Linq;
using Akshaya.AppEntities.Entities;

namespace Akshaya.Business.Facade
{
    public class FacadeBase
    {
        protected Context Context;
        protected const string ConnectionStringName = "Akshaya";

        public FacadeBase()
        {
            Context = new Context(ConnectionStringName);
        }
        
        public virtual IList<ModelBase> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual ModelBase Get(long id)
        {
            throw new NotImplementedException();
        }

        public virtual bool Add(ModelBase model)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(ModelBase model)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(ModelBase model)
        {
            throw new NotImplementedException();
        }

    }
}