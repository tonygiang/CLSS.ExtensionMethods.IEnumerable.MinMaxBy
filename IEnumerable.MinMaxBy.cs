// A part of the C# Language Syntactic Sugar suite.

using System;
using System.Collections.Generic;

namespace CLSS
{
  public static partial class IEnumerableMinMaxBy
  {
    /// <summary>
    /// Returns the maximum value in a generic sequence according to a specified
    /// key selector function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of
    /// <paramref name="source"/>.</typeparam>
    /// <typeparam name="TKey">The type of key to compare elements by.
    /// </typeparam>
    /// <param name="source">A sequence of values to determine the maximum value
    /// of.</param>
    /// <param name="keySelector">A function to extract the key for each
    /// element.</param>
    /// <returns>The value with the maximum key in the sequence.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or
    /// <paramref name="keySelector"/> is null.</exception>
    /// <exception cref="InvalidOperationException"><paramref name="source"/>
    /// contains no element.</exception>
    public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
      where TKey : IComparable<TKey>
    {
      if (source == null) throw new ArgumentNullException("source");
      if (keySelector == null) throw new ArgumentNullException("keySelector");
      bool hasValue = false;
      var currentMax = default(TSource);
      var currentMaxKey = default(TKey);
      foreach (TSource e in source)
      {
        if (hasValue)
        {
          var selectedKey = keySelector(e);
          if (selectedKey.CompareTo(currentMaxKey) > 0)
          { currentMaxKey = selectedKey; currentMax = e; }
        }
        else
        { currentMaxKey = keySelector(e); currentMax = e; hasValue = true; }
      }
      if (hasValue) return currentMax;
      throw new InvalidOperationException("Sequence contains no elements");
    }

    /// <summary>
    /// Returns the maximum value in a generic sequence according to a specified
    /// key selector function and key comparer.
    /// </summary>
    /// <typeparam name="TSource">
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/typeparam[@name='TSource']"/></typeparam>
    /// <typeparam name="TKey">
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/typeparam[@name='TKey']"/></typeparam>
    /// <param name="source">
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/param[@name='source']"/></param>
    /// <param name="keySelector">
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/param[@name='keySelector']"/></param>
    /// <param name="comparer">The <see cref="IComparer{T}"/> to compare keys.
    /// </param>
    /// <returns>
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/returns"/></returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/>,
    /// <paramref name="keySelector"/> or <paramref name="comparer"/> is null.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/exception[@cref='InvalidOperationException']"/></exception>
    public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException("source");
      if (keySelector == null) throw new ArgumentNullException("keySelector");
      if (comparer == null) throw new ArgumentNullException("comparer");
      bool hasValue = false;
      var currentMax = default(TSource);
      var currentMaxKey = default(TKey);
      foreach (TSource e in source)
      {
        if (hasValue)
        {
          var selectedKey = keySelector(e);
          if (comparer.Compare(selectedKey, currentMaxKey) > 0)
          { currentMaxKey = selectedKey; currentMax = e; }
        }
        else
        { currentMaxKey = keySelector(e); currentMax = e; hasValue = true; }
      }
      if (hasValue) return currentMax;
      throw new InvalidOperationException("Sequence contains no elements");
    }

    /// <summary>
    /// Returns the minimum value in a generic sequence according to a specified
    /// key selector function.
    /// </summary>
    /// <typeparam name="TSource">
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/typeparam[@name='TSource']"/></typeparam>
    /// <typeparam name="TKey">
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/typeparam[@name='TKey']"/></typeparam>
    /// <param name="source">A sequence of values to determine the minimum value
    /// of.</param>
    /// <param name="keySelector">
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/param[@name='keySelector']"/></param>
    /// <returns>The value with the minimum key in the sequence.</returns>
    /// <exception cref="ArgumentNullException">
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/exception[@cref='ArgumentNullException']"/></exception>
    /// <exception cref="InvalidOperationException">
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/exception[@cref='InvalidOperationException']"/></exception>
    public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
      where TKey : IComparable<TKey>
    {
      if (source == null) throw new ArgumentNullException("source");
      if (keySelector == null) throw new ArgumentNullException("keySelector");
      bool hasValue = false;
      var currentMin = default(TSource);
      var currentMinKey = default(TKey);
      foreach (TSource e in source)
      {
        if (hasValue)
        {
          TKey selectedKey = keySelector(e);
          if (selectedKey.CompareTo(currentMinKey) < 0)
          { currentMinKey = selectedKey; currentMin = e; }
        }
        else
        { currentMinKey = keySelector(e); currentMin = e; hasValue = true; }
      }
      if (hasValue) return currentMin;
      throw new InvalidOperationException("Sequence contains no elements");
    }

    /// <summary>
    /// Returns the minimum value in a generic sequence according to a specified
    /// key selector function and key comparer.
    /// </summary>
    /// <typeparam name="TSource">
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/typeparam[@name='TSource']"/></typeparam>
    /// <typeparam name="TKey">
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/typeparam[@name='TKey']"/></typeparam>
    /// <param name="source">
    /// <inheritdoc cref="MinBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/source"/></param>
    /// <param name="keySelector">
    /// <inheritdoc cref="MinBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/param[@name='keySelector']"/></param>
    /// <param name="comparer">
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey}, IComparer{TKey})"
    /// path="/param[@name='comparer']"/></param>
    /// <returns>
    /// <inheritdoc cref="MinBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/returns"/></returns>
    /// <exception cref="ArgumentNullException">
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey}, IComparer{TKey})"
    /// path="/exception[@cref='ArgumentNullException']"/>
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"
    /// path="/exception[@cref='InvalidOperationException']"/></exception>
    public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException("source");
      if (keySelector == null) throw new ArgumentNullException("keySelector");
      if (comparer == null) throw new ArgumentNullException("comparer");
      bool hasValue = false;
      var currentMin = default(TSource);
      var currentMinKey = default(TKey);
      foreach (TSource e in source)
      {
        if (hasValue)
        {
          var selectedKey = keySelector(e);
          if (comparer.Compare(selectedKey, currentMinKey) < 0)
          { currentMinKey = selectedKey; currentMin = e; }
        }
        else
        { currentMinKey = keySelector(e); currentMin = e; hasValue = true; }
      }
      if (hasValue) return currentMin;
      throw new InvalidOperationException("Sequence contains no elements");
    }

    /// <inheritdoc cref="MaxBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey}, IComparer{TKey})"/>
    public static TSource MaxBy<TSource>(this IEnumerable<TSource> source,
      Func<TSource, IComparable> keySelector)
    {
      if (source == null) throw new ArgumentNullException("source");
      if (keySelector == null) throw new ArgumentNullException("keySelector");
      bool hasValue = false;
      var currentMax = default(TSource);
      var currentMaxKey = default(IComparable);
      foreach (TSource e in source)
      {
        if (hasValue)
        {
          var selectedKey = keySelector(e);
          if (selectedKey.CompareTo(currentMaxKey) > 0)
          { currentMaxKey = selectedKey; currentMax = e; }
        }
        else
        { currentMaxKey = keySelector(e); currentMax = e; hasValue = true; }
      }
      if (hasValue) return currentMax;
      throw new InvalidOperationException("Sequence contains no elements");
    }

    /// <inheritdoc cref="MinBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"/>
    public static TSource MinBy<TSource>(this IEnumerable<TSource> source,
      Func<TSource, IComparable> keySelector)
    {
      if (source == null) throw new ArgumentNullException("source");
      if (keySelector == null) throw new ArgumentNullException("keySelector");
      bool hasValue = false;
      var currentMin = default(TSource);
      var currentMinKey = default(IComparable);
      foreach (TSource e in source)
      {
        if (hasValue)
        {
          var selectedKey = keySelector(e);
          if (selectedKey.CompareTo(currentMinKey) < 0)
          { currentMinKey = selectedKey; currentMin = e; }
        }
        else
        { currentMinKey = keySelector(e); currentMin = e; hasValue = true; }
      }
      if (hasValue) return currentMin;
      throw new InvalidOperationException("Sequence contains no elements");
    }
  }
}