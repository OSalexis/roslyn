﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Roslyn.Utilities
{
    internal static partial class SpecializedCollections
    {
        private static partial class Singleton
        {
            internal sealed class Collection<T> : ICollection<T>, IReadOnlyCollection<T>
            {
                private T _loneValue;

                public Collection(T value)
                {
                    _loneValue = value;
                }

                public void Add(T item)
                {
                    throw new NotSupportedException();
                }

                public void Clear()
                {
                    throw new NotSupportedException();
                }

                public bool Contains(T item)
                {
                    return EqualityComparer<T>.Default.Equals(_loneValue, item);
                }

                public void CopyTo(T[] array, int arrayIndex)
                {
                    array[arrayIndex] = _loneValue;
                }

                public int Count
                {
                    get { return 1; }
                }

                public bool IsReadOnly
                {
                    get { return true; }
                }

                public bool Remove(T item)
                {
                    throw new NotSupportedException();
                }

                public IEnumerator<T> GetEnumerator()
                {
                    return new Enumerator<T>(_loneValue);
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return GetEnumerator();
                }
            }
        }
    }
}
