using System;
using NHibernate;
using NHibernate.Cfg;

namespace Library.Net.Data.NHibernate.Factories {

    public sealed class SessionFactoryFactory {

        private readonly ISessionFactory _sessionFactory;

        public ISessionFactory CurrentSessionFactory {
            get { return _sessionFactory; }
        }

        private static volatile SessionFactoryFactory _instance;
        private static readonly object SyncRoot = new Object();

        private SessionFactoryFactory() {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(SessionFactoryFactory).Assembly);

            _sessionFactory = cfg.BuildSessionFactory();
        }

        public static SessionFactoryFactory Instance {
            get {
                if (_instance == null) {
                    lock (SyncRoot) {
                        if (_instance == null)
                            _instance = new SessionFactoryFactory();
                    }
                }

                return _instance;
            }
        }
    }
}