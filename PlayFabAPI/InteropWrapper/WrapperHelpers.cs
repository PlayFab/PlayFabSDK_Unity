#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PlayFab
{
    public struct PFCallbackToken
    {
        internal IntPtr Id;
    }
}

namespace PlayFab.InteropWrapper
{
    internal static class WrapperHelpers
    {
        internal static byte BoolToInterop(bool value)
        {
            return value ? (byte)1 : (byte)0;
        }

        internal static bool InteropToBool(byte value)
        {
            return value != 0;
        }

        internal unsafe static sbyte[] StringToInterop(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);

            return Array.ConvertAll(bytes, b => (sbyte)b);
        }

        /// <summary>
        /// Copies a string to a caller-allocated buffer
        /// </summary>
        /// <param name="str">string to copy</param>
        /// <param name="buffer">buffer allocated with enough space for the given string plus a null terminator</param>
        /// <returns>Pointer to the filled buffer for assignment</returns>
        internal unsafe static void StringToInterop(string? str, sbyte** buffer, DisposableBuffer disposableBuffer)
        {
            if (str == null) return;

            *buffer = (sbyte*)disposableBuffer.AddBuffer(str.Length + 1);

            byte[] bytes = Encoding.Default.GetBytes(str);
            sbyte[] sbytes = Array.ConvertAll(bytes, b => (sbyte)b);

            for (int i = 0; i < sbytes.Length; i++)
            {
                (*buffer)[i] = sbytes[i];
            }

            (*buffer)[sbytes.Length] = 0;
        }

        internal unsafe static void ArrayToInterop<T>(T[] array, T** buffer, DisposableBuffer disposableBuffer)
            where T : unmanaged
        {
            if (array == null) return;

            *buffer = (T*)disposableBuffer.AddBuffer(sizeof(T*) * array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                (*buffer)[i] = array[i];
            }
        }

        internal unsafe static void ArrayToStringInterop(string[] array, sbyte*** buffer, DisposableBuffer disposableBuffer)
        {
            if (array == null) return;

            *buffer = (sbyte**)disposableBuffer.AddBuffer(sizeof(sbyte*) * array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                StringToInterop(array[i], &(*buffer)[i], disposableBuffer);
            }
        }

        internal unsafe static void ArrayToBoolInterop(bool[] array, byte** buffer, DisposableBuffer disposableBuffer)
        {
            if (array == null) return;

            *buffer = (byte*)disposableBuffer.AddBuffer(sizeof(byte*) * array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                (*buffer)[i] = BoolToInterop(array[i]);
            }
        }

        internal unsafe static void ArrayToEnumInterop<TWrapper, TInterop>(TWrapper[]? array, TInterop** buffer, DisposableBuffer disposableBuffer, Func<TWrapper, TInterop> convert)
            where TWrapper : Enum
            where TInterop : unmanaged
        {
            if (array == null) return;

            *buffer = (TInterop*)disposableBuffer.AddBuffer(sizeof(TInterop*) * array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                (*buffer)[i] = convert(array[i]);
            }
        }

        internal unsafe delegate void ToInteropDelegate<TWrapper, TInterop>(TWrapper self, TInterop* interop, DisposableBuffer disposableBuffer)
            where TInterop : unmanaged
            where TWrapper : struct;

        internal unsafe static void ArrayToInterop<TWrapper, TInterop>(TWrapper[] array, TInterop*** buffer, DisposableBuffer disposableBuffer, ToInteropDelegate<TWrapper, TInterop> toInterop)
            where TInterop : unmanaged
            where TWrapper : struct
        {
            if (array == null) return;

            *buffer = (TInterop**)disposableBuffer.AddBuffer(sizeof(TInterop*) * array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                (*buffer)[i] = (TInterop*)disposableBuffer.AddBuffer(sizeof(TInterop));
                toInterop(array[i], (*buffer)[i], disposableBuffer);
            }
        }

        internal unsafe static void DictionaryToInterop<TWrapper, TEntry>(IDictionary<string, TWrapper> dictionary, TEntry** buffer, DisposableBuffer disposableBuffer, Func<KeyValuePair<string, TWrapper>, DisposableBuffer, TEntry> convert)
            where TWrapper : unmanaged
            where TEntry : unmanaged
        {
            if (dictionary == null) return;

            *buffer = (TEntry*)disposableBuffer.AddBuffer(sizeof(TEntry) * dictionary.Count);

            var pairs = dictionary.ToArray();
            for (int i = 0; i < pairs.Length; i++)
            {
                TEntry entry = convert(pairs[i], disposableBuffer);

                (*buffer)[i] = entry;
            }
        }

        internal unsafe static void DictionaryToStringInterop(IDictionary<string, string> dictionary, Interop.PFStringDictionaryEntry** buffer, DisposableBuffer disposableBuffer)
        {
            if (dictionary == null) return;

            *buffer = (Interop.PFStringDictionaryEntry*)disposableBuffer.AddBuffer(sizeof(Interop.PFStringDictionaryEntry) * dictionary.Count);

            var pairs = dictionary.ToArray();
            for (int i = 0; i < pairs.Length; i++)
            {
                Interop.PFStringDictionaryEntry entry = new();
                StringToInterop(pairs[i].Key, &entry.key, disposableBuffer);
                StringToInterop(pairs[i].Value, &entry.value, disposableBuffer);

                (*buffer)[i] = entry;
            }
        }

        internal unsafe static void DictionaryToStructInterop<TWrapper, TEntry>(IDictionary<string, TWrapper> dictionary, TEntry** buffer, DisposableBuffer disposableBuffer, Func<KeyValuePair<string, TWrapper>, DisposableBuffer, TEntry> convert)
            where TWrapper : struct
            where TEntry : unmanaged
        {
            if (dictionary == null) return;

            *buffer = (TEntry*)disposableBuffer.AddBuffer(sizeof(TEntry) * dictionary.Count);

            var pairs = dictionary.ToArray();
            for (int i = 0; i < pairs.Length; i++)
            {
                TEntry entry = convert(pairs[i], disposableBuffer);

                (*buffer)[i] = entry;
            }
        }

        internal static unsafe string InteropToString(sbyte* str)
        {
            return new string(str);
        }

        internal static unsafe T[]? InteropToArray<T>(T* arrayPtr, ulong count)
            where T : unmanaged
        {
            if (arrayPtr == null) return null;

            T[] array = new T[count];
            for (ulong i = 0; i < count; i++)
            {
                array[i] = arrayPtr[i];
            }

            return array;
        }

        internal static unsafe string[]? InteropToStringArray(sbyte** arrayPtr, ulong count)
        {
            if (arrayPtr == null) return null;

            string[] array = new string[count];
            for (ulong i = 0; i < count; i++)
            {
                array[i] = InteropToString(arrayPtr[i]);
            }

            return array;
        }

        internal static unsafe bool[]? InteropToBoolArray(byte* arrayPtr, ulong count)
        {
            if (arrayPtr == null) return null;

            bool[] array = new bool[count];
            for (ulong i = 0; i < count; i++)
            {
                array[i] = InteropToBool(arrayPtr[i]);
            }

            return array;
        }

        internal static unsafe TWrapper[]? InteropToArray<TInterop, TWrapper>(TInterop* arrayPtr, ulong count, Func<TInterop, TWrapper> convert)
            where TInterop : unmanaged
            where TWrapper : struct
        {
            if (arrayPtr == null) return null;

            TWrapper[] array = new TWrapper[count];
            for (ulong i = 0; i < count; i++)
            {
                array[i] = convert(arrayPtr[i]);
            }

            return array;
        }

        internal static unsafe Dictionary<string, TValue>? InteropToDictionary<TPair, TValue>(TPair* dictPtr, ulong count, Func<TPair, (string, TValue)> extract)
            where TPair : unmanaged
        {
            if (dictPtr == null) return null;

            Dictionary<string, TValue> dict = new();
            for (ulong i = 0; i < count; i++)
            {
                (string key, TValue value) = extract(dictPtr[i]);
                dict.Add(new(key), value);
            }

            return dict;
        }

        internal static unsafe Dictionary<string, TValue>? InteropToDictionary<TPair, TValue>(TPair* dictPtr, ulong count)
            where TPair : unmanaged
            where TValue : unmanaged
        {
            if (dictPtr == null) return null;

            Dictionary<string, TValue> dict = new();
            for (ulong i = 0; i < count; i++)
            {
                var keyField = typeof(TPair).GetField("key");
                var valueField = typeof(TPair).GetField("value");
                dict.Add((string)keyField.GetValue(dictPtr[i]), (TValue)valueField.GetValue(dictPtr[i]));
            }

            return dict;
        }

        internal static unsafe byte[] BytePointerToByteArray(byte* bytePtr, ulong length)
        {
            byte[] byteArray = new byte[length];
            Marshal.Copy((IntPtr)bytePtr, byteArray, 0, (int)length);
            return byteArray;
        }
    }

    /// <summary>
    /// Manages a callback across the native boundary.
    /// </summary>
    /// <typeparam name="TDelegate">A delegate that maps to a native callback</typeparam>
    internal class InteropCallbackManager<TDelegate> where TDelegate : Delegate
    {
        protected TDelegate? Callback;
        protected object? Context;

        internal virtual void SetCallback(
            TDelegate callback,
            object context)
        {
            Context = context;
            Callback = callback;
        }

        internal bool TryGetCallback(
            out TDelegate? callback,
            out object? context)
        {
            callback = Callback;
            context = Context;

            return callback != null;
        }

        internal void RemoveCallback()
        {
            Context = null;
            Callback = null;
        }
    }

    /// <summary>
    /// Manages multiple callbacks across the native boundary.
    /// </summary>
    /// <typeparam name="TDelegate">A delegate that maps to a native callback</typeparam>
    internal class InteropMultiCallbackManager<TDelegate> where TDelegate : Delegate
    {
        protected struct HandlerContext
        {
            public TDelegate? Callback;
            public object? Context;
            public IntPtr InternalContext;
        }

        protected readonly Dictionary<IntPtr, IntPtr> InternalContextToCallbackId = new();
        protected readonly Dictionary<IntPtr, HandlerContext> CallbackIdToHandler = new();

        private int _availableContextId = 1000;

        internal IntPtr GetUniqueInternalContext()
        {
            return new IntPtr(_availableContextId++);
        }

        internal virtual PFCallbackToken AddCallbackForId(
            IntPtr callbackId,
            TDelegate? callback,
            object? context,
            IntPtr internalContext)
        {
            InternalContextToCallbackId[internalContext] = callbackId;
            CallbackIdToHandler[callbackId] = new HandlerContext()
            {
                Context = context,
                Callback = callback,
                InternalContext = internalContext
            };

            return new PFCallbackToken()
            {
                Id = callbackId
            };
        }

        internal virtual void RemoveCallback(PFCallbackToken token)
        {
            if (!CallbackIdToHandler.TryGetValue(token.Id, out HandlerContext handler)) return;

            InternalContextToCallbackId.Remove(handler.InternalContext);
            CallbackIdToHandler.Remove(token.Id);
        }

        internal int GetCallback(IntPtr callbackId, out TDelegate? callback, out object? context)
        {
            var callbackContext = CallbackIdToHandler[callbackId];
            callback = callbackContext.Callback;
            context = callbackContext.Context;

            return 0;
        }

        internal object? GetContext(IntPtr internalContext)
        {
            if (InternalContextToCallbackId.TryGetValue(internalContext, out IntPtr callbackId))
            {
                if (CallbackIdToHandler.TryGetValue(callbackId, out HandlerContext handler))
                {
                    return handler.Context;
                }
            }

            return null;
        }
    }
}
