﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BiM.Protocol.Data;
using BiM.Protocol.Tools;
using NLog;

namespace BiM.Behaviors.Data
{
    public class D2OSource : IDataSource
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private Dictionary<Type, D2OReader> m_readers = new Dictionary<Type, D2OReader>();
        private List<Type> m_ignoredTyes = new List<Type>(); 

        public void AddReaders(string directory)
        {
            foreach (var d2oFile in Directory.EnumerateFiles(directory).Where(entry => entry.EndsWith(".d2o")))
            {
                var reader = new D2OReader(d2oFile);

                AddReader(reader);
            }
        }

        public void AddReader(D2OReader d2oFile)
        {
            var classes = d2oFile.Classes;

            foreach (var @class in classes)
            {
                if (m_ignoredTyes.Contains(@class.Value.ClassType))
                    continue;

                if (m_readers.ContainsKey(@class.Value.ClassType))
                {
                    // this classes are not bound to a single file, so we ignore them
                    m_ignoredTyes.Add(@class.Value.ClassType);
                    m_readers.Remove(@class.Value.ClassType);
                }
                else
                {
                    m_readers.Add(@class.Value.ClassType, d2oFile);
                }
            }
            
        }

        public bool DoesHandleType(Type type)
        {
            return m_readers.ContainsKey(type);
        }

        public T ReadObject<T>(int id) where T : class, IDataObject
        {
            if (!m_readers.ContainsKey(typeof(T)))
                throw new ArgumentException("Cannot find data corresponding to type : " + typeof(T));

            var reader = m_readers[typeof(T)];

            return reader.ReadObject<T>(id);
        }
    }
}