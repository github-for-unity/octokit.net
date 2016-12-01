namespace System
{

#if !SILVERLIGHT
    using System.Runtime.Serialization;
#endif

    using System.Diagnostics;
    internal static class ThrowHelper
    {

        const string ArgumentNull_Key = "Key cannot be null.";
        const string Argument_AddingDuplicate = "An entry with the same key already exists.";
        const string Argument_InvalidValue = "Argument {0} should be larger than {1}.";
        const string ArgumentOutOfRange_NeedNonNegNum = "Index is less than zero.";
        const string ArgumentOutOfRange_InvalidThreshold = "The specified threshold for creating dictionary is out of range.";
        const string InvalidOperation_EnumFailedVersion = "Collection was modified after the enumerator was instantiated.";
        const string InvalidOperation_EnumOpCantHappen = "Enumerator is positioned before the first element or after the last element of the collection.";
        const string Arg_MultiRank = "Multi dimension array is not supported on this operation.";
        const string Arg_NonZeroLowerBound = "The lower bound of target array must be zero.";
        const string Arg_InsufficientSpace = "Insufficient space in the target location to copy the information.";
        const string NotSupported_EnumeratorReset = "Reset is not supported on the Enumerator.";
        const string Invalid_Array_Type = "Target array type is not compatible with the type of items in the collection.";
        const string Serialization_InvalidOnDeser = "OnDeserialization method was called while the object was not being deserialized.";
        const string Serialization_MissingValues = "The values for this collection are missing.";
        const string Serialization_MismatchedCount = "The serialized Count information doesn't match the number of items.";
        const string ExternalLinkedListNode = "The LinkedList node does not belong to current LinkedList.";
        const string LinkedListNodeIsAttached = "The LinkedList node already belongs to a LinkedList.";
        const string LinkedListEmpty = "The LinkedList is empty.";
        const string Arg_WrongType = "The value \"{0}\" isn't of type \"{1}\" and can't be used in this generic collection.";
        const string Argument_ItemNotExist = "The specified item does not exist in this KeyedCollection.";
        const string Argument_ImplementIComparable = "At least one object must implement IComparable.";
        const string InvalidOperation_EmptyCollection = "This operation is not valid on an empty collection.";
        const string InvalidOperation_EmptyQueue = "Queue empty.";
        const string InvalidOperation_EmptyStack = "Stack empty.";
        const string InvalidOperation_CannotRemoveFromStackOrQueue = "Removal is an invalid operation for Stack or Queue.";
        const string ArgumentOutOfRange_Index = "Index was out of range. Must be non-negative and less than the size of the collection.";
        const string ArgumentOutOfRange_SmallCapacity = "capacity was less than the current size.";
        const string Arg_ArrayPlusOffTooSmall = "Destination array is not long enough to copy all the items in the collection. Check array index and length.";
        const string NotSupported_KeyCollectionSet = "Mutating a key collection derived from a dictionary is not allowed.";
        const string NotSupported_ValueCollectionSet = "Mutating a value collection derived from a dictionary is not allowed.";
        const string NotSupported_ReadOnlyCollection = "Collection is read-only.";
        const string NotSupported_SortedListNestedWrite = "This operation is not supported on SortedList nested types because they require modifying the original SortedList.";
        const string Argument_InvalidOffLen = "Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.";
        const string InvalidOperation_EnumNotStarted = "Enumeration has not started.Call MoveNext.";
        const string ArgumentOutOfRange_NeedNonNegNumRequired = "Non-negative number required.";
        const string InvalidOperation_EnumEnded = "The enumeration has already completed.";
        const string ArgumentOutOfRange_BiggerThanCollection = "Larger than collection size.";
        const string ArgumentOutOfRange_Count = "Count must be positive and count must refer to a location within the string/array/collection.";
        const string ArgumentOutOfRange_ListInsert = "Index must be within the bounds of the List.";

        internal static void ThrowWrongKeyTypeArgumentException(object key, Type targetType)
        {
            throw new ArgumentException(String.Format(Arg_WrongType, key, targetType), "key");
        }

        internal static void ThrowWrongValueTypeArgumentException(object value, Type targetType)
        {
            throw new ArgumentException(String.Format(Arg_WrongType, value, targetType), "value");
        }

        internal static void ThrowKeyNotFoundException()
        {
            throw new System.Collections.Generic.KeyNotFoundException();
        }

        internal static void ThrowArgumentException(ExceptionResource resource)
        {
            throw new ArgumentException(String.Format(GetResourceName(resource)));
        }

        internal static void ThrowArgumentNullException(ExceptionArgument argument)
        {
            throw new ArgumentNullException(GetArgumentName(argument));
        }

        internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument)
        {
            throw new ArgumentOutOfRangeException(GetArgumentName(argument));
        }
        internal static void ThrowArgumentOutOfRangeException()
        {
            ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_Index);
        }

        internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
        {
            throw new ArgumentOutOfRangeException(GetArgumentName(argument), String.Format(GetResourceName(resource)));
        }

        internal static void ThrowInvalidOperationException(ExceptionResource resource)
        {
            throw new InvalidOperationException(String.Format(GetResourceName(resource)));
        }

#if !SILVERLIGHT
        internal static void ThrowSerializationException(ExceptionResource resource)
        {
            throw new SerializationException(String.Format(GetResourceName(resource)));
        }
#endif

        internal static void ThrowNotSupportedException(ExceptionResource resource)
        {
            throw new NotSupportedException(String.Format(GetResourceName(resource)));
        }

        // Allow nulls for reference types and Nullable<U>, but not for value types.
        internal static void IfNullAndNullsAreIllegalThenThrow<T>(object value, ExceptionArgument argName)
        {
            // Note that default(T) is not equal to null for value types except when T is Nullable<U>. 
            if (value == null && !(default(T) == null))
                ThrowHelper.ThrowArgumentNullException(argName);
        }

        //
        // This function will convert an ExceptionArgument enum value to the argument name string.
        //
        internal static string GetArgumentName(ExceptionArgument argument)
        {
            string argumentName = null;

            switch (argument)
            {
                case ExceptionArgument.array:
                    argumentName = "array";
                    break;

                case ExceptionArgument.arrayIndex:
                    argumentName = "arrayIndex";
                    break;

                case ExceptionArgument.capacity:
                    argumentName = "capacity";
                    break;

                case ExceptionArgument.collection:
                    argumentName = "collection";
                    break;

                case ExceptionArgument.converter:
                    argumentName = "converter";
                    break;

                case ExceptionArgument.count:
                    argumentName = "count";
                    break;

                case ExceptionArgument.dictionary:
                    argumentName = "dictionary";
                    break;

                case ExceptionArgument.index:
                    argumentName = "index";
                    break;

                case ExceptionArgument.info:
                    argumentName = "info";
                    break;

                case ExceptionArgument.key:
                    argumentName = "key";
                    break;

                case ExceptionArgument.match:
                    argumentName = "match";
                    break;

                case ExceptionArgument.obj:
                    argumentName = "obj";
                    break;

                case ExceptionArgument.queue:
                    argumentName = "queue";
                    break;

                case ExceptionArgument.stack:
                    argumentName = "stack";
                    break;

                case ExceptionArgument.startIndex:
                    argumentName = "startIndex";
                    break;

                case ExceptionArgument.value:
                    argumentName = "value";
                    break;

                case ExceptionArgument.item:
                    argumentName = "item";
                    break;

                default:
                    Debug.Assert(false, "The enum value is not defined, please checked ExceptionArgumentName Enum.");
                    return string.Empty;
            }

            return argumentName;
        }

        //
        // This function will convert an ExceptionResource enum value to the resource string.
        //
        internal static string GetResourceName(ExceptionResource resource)
        {
            string resourceName = null;

            switch (resource)
            {
                case ExceptionResource.Argument_ImplementIComparable:
                    resourceName = Argument_ImplementIComparable;
                    break;

                case ExceptionResource.Argument_AddingDuplicate:
                    resourceName = Argument_AddingDuplicate;
                    break;

                case ExceptionResource.ArgumentOutOfRange_Index:
                    resourceName = ArgumentOutOfRange_Index;
                    break;

                case ExceptionResource.ArgumentOutOfRange_NeedNonNegNum:
                    resourceName = ArgumentOutOfRange_NeedNonNegNum;
                    break;

                case ExceptionResource.ArgumentOutOfRange_NeedNonNegNumRequired:
                    resourceName = ArgumentOutOfRange_NeedNonNegNumRequired;
                    break;

                case ExceptionResource.ArgumentOutOfRange_SmallCapacity:
                    resourceName = ArgumentOutOfRange_SmallCapacity;
                    break;

                case ExceptionResource.Arg_ArrayPlusOffTooSmall:
                    resourceName = Arg_ArrayPlusOffTooSmall;
                    break;

                case ExceptionResource.Arg_RankMultiDimNotSupported:
                    resourceName = Arg_MultiRank;
                    break;

                case ExceptionResource.Arg_NonZeroLowerBound:
                    resourceName = Arg_NonZeroLowerBound;
                    break;

                case ExceptionResource.Argument_InvalidArrayType:
                    resourceName = Invalid_Array_Type;
                    break;

                case ExceptionResource.Argument_InvalidOffLen:
                    resourceName = Argument_InvalidOffLen;
                    break;

                case ExceptionResource.InvalidOperation_CannotRemoveFromStackOrQueue:
                    resourceName = InvalidOperation_CannotRemoveFromStackOrQueue;
                    break;

                case ExceptionResource.InvalidOperation_EmptyCollection:
                    resourceName = InvalidOperation_EmptyCollection;
                    break;

                case ExceptionResource.InvalidOperation_EmptyQueue:
                    resourceName = InvalidOperation_EmptyQueue;
                    break;

                case ExceptionResource.InvalidOperation_EnumOpCantHappen:
                    resourceName = InvalidOperation_EnumOpCantHappen;
                    break;

                case ExceptionResource.InvalidOperation_EnumFailedVersion:
                    resourceName = InvalidOperation_EnumFailedVersion;
                    break;

                case ExceptionResource.InvalidOperation_EmptyStack:
                    resourceName = InvalidOperation_EmptyStack;
                    break;

                case ExceptionResource.InvalidOperation_EnumNotStarted:
                    resourceName = InvalidOperation_EnumNotStarted;
                    break;

                case ExceptionResource.InvalidOperation_EnumEnded:
                    resourceName = InvalidOperation_EnumEnded;
                    break;

                case ExceptionResource.NotSupported_KeyCollectionSet:
                    resourceName = NotSupported_KeyCollectionSet;
                    break;

                case ExceptionResource.NotSupported_SortedListNestedWrite:
                    resourceName = NotSupported_SortedListNestedWrite;
                    break;

#if !SILVERLIGHT
                case ExceptionResource.Serialization_InvalidOnDeser:
                    resourceName = Serialization_InvalidOnDeser;
                    break;

                case ExceptionResource.Serialization_MissingValues:
                    resourceName = Serialization_MissingValues;
                    break;

                case ExceptionResource.Serialization_MismatchedCount:
                    resourceName = Serialization_MismatchedCount;
                    break;
#endif

                case ExceptionResource.NotSupported_ValueCollectionSet:
                    resourceName = NotSupported_ValueCollectionSet;
                    break;

                case ExceptionResource.ArgumentOutOfRange_BiggerThanCollection:
                    resourceName = ArgumentOutOfRange_BiggerThanCollection;
                    break;

                case ExceptionResource.ArgumentOutOfRange_Count:
                    resourceName = ArgumentOutOfRange_Count;
                    break;

                case ExceptionResource.ArgumentOutOfRange_ListInsert:
                    resourceName = ArgumentOutOfRange_ListInsert;
                    break;
                    
                default:
                    Debug.Assert(false, "The enum value is not defined, please checked ExceptionArgumentName Enum.");
                    return string.Empty;
            }

            return resourceName;
        }

    }

    //
    // The convention for this enum is using the argument name as the enum name
    // 
    internal enum ExceptionArgument
    {
        obj,
        dictionary,
        array,
        info,
        key,
        collection,
        match,
        converter,
        queue,
        stack,
        capacity,
        index,
        startIndex,
        value,
        count,
        arrayIndex,
        item,
    }

    //
    // The convention for this enum is using the resource name as the enum name
    // 
    internal enum ExceptionResource
    {
        Argument_ImplementIComparable,
        ArgumentOutOfRange_NeedNonNegNum,
        ArgumentOutOfRange_NeedNonNegNumRequired,
        Arg_ArrayPlusOffTooSmall,
        Argument_AddingDuplicate,
        Serialization_InvalidOnDeser,
        Serialization_MismatchedCount,
        Serialization_MissingValues,
        Arg_RankMultiDimNotSupported,
        Arg_NonZeroLowerBound,
        Argument_InvalidArrayType,
        NotSupported_KeyCollectionSet,
        ArgumentOutOfRange_SmallCapacity,
        ArgumentOutOfRange_Index,
        Argument_InvalidOffLen,
        NotSupported_ReadOnlyCollection,
        InvalidOperation_CannotRemoveFromStackOrQueue,
        InvalidOperation_EmptyCollection,
        InvalidOperation_EmptyQueue,
        InvalidOperation_EnumOpCantHappen,
        InvalidOperation_EnumFailedVersion,
        InvalidOperation_EmptyStack,
        InvalidOperation_EnumNotStarted,
        InvalidOperation_EnumEnded,
        NotSupported_SortedListNestedWrite,
        NotSupported_ValueCollectionSet,
        ArgumentOutOfRange_BiggerThanCollection,
        ArgumentOutOfRange_Count,
        ArgumentOutOfRange_ListInsert
    }

}

