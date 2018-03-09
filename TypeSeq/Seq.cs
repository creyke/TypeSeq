using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TypeSeq.Sequencers;

namespace TypeSeq
{
    public class Seq
    {
        private static Dictionary<Type, Type> TypeMap = CreateTypeMap(
            new List<Type>
            {
                typeof(IntSequencer),
                typeof(GuidSequencer),
                typeof(UIntSequencer)
            }
        );

        private Dictionary<Type, Type> typeMap;
        private Dictionary<Type, ISequencer> sequencers;
        private Dictionary<Type, ISequencer> sequencersAssert;

        public Seq()
        {
            sequencers = new Dictionary<Type, ISequencer>();
            sequencersAssert = new Dictionary<Type, ISequencer>();
        }

        public Seq(List<Type> customSequencerTypes) : this()
        {
            typeMap = CreateTypeMap(customSequencerTypes);
        }

        public T Next<T>()
        {
            var sequencer = GetSequencer<T>(sequencers);
            return sequencer.Next();
        }

        public T NextAssert<T>()
        {
            var sequencer = GetSequencer<T>(sequencersAssert);
            return sequencer.Next();
        }

        private ISequencer<T> Create<T>()
        {
            var type = typeof(T);
            return (ISequencer<T>)Activator.CreateInstance(TypeMap[type]);
        }

        private static Dictionary<Type, Type> CreateTypeMap(List<Type> sequencerTypes)
        {
            var typeMap = new Dictionary<Type, Type>();
            foreach (var customSequencerType in sequencerTypes)
            {
                var typeInfo = customSequencerType.GetTypeInfo();
                typeMap.Add(
                    typeInfo.BaseType.GenericTypeArguments.First(),
                    customSequencerType
                );
            }
            return typeMap;
        }

        private ISequencer<T> GetSequencer<T>(Dictionary<Type, ISequencer> sequencerDictionary)
        {
            var type = typeof(T);

            if (!sequencerDictionary.ContainsKey(type))
            {
                sequencerDictionary.Add(type, Create<T>());
            }

            return (ISequencer<T>)sequencerDictionary[type];
        }
    }
}
