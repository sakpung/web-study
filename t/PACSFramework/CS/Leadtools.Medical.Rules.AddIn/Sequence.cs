// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;
using Leadtools.Medical.Rules.AddIn.Common;
using System.Diagnostics;
using Leadtools.Logging;

namespace Leadtools.Medical.Rules.AddIn
{   
   public class Sequence
   {
      private long _Tag;
      private DicomDataSet _Dataset;
      private Sequence _Parent = null;      

      public Sequence Parent
      {
         get
         {
            return _Parent;
         }
      }

      public DicomDataSet Dataset
      {
         get
         {
            return _Dataset;
         }
      }

      private int _Index = -1;

      public int Index
      {
         get
         {
            return _Index;
         }
         set
         {
            _Index = value;
         }
      }

      public object this[long tag]
      {
         get
         {
            if (_Dataset != null)
            {
               if (Utils.IsSequence(tag))
                  return new Sequence(tag, _Dataset, this);

               return GetSequenceValue(0,tag, false);
            }
            return null;
         }
         set
         {
            if (_Dataset != null)
            {
               SetSequenceValue(-1, tag, value);
            }
         }
      }

      public int Count
      {
         get
         {
            return GetSequenceCount();
         }
      }

      public object this[int index, int tag]
      {
         get
         {
            if (_Dataset != null)
            {
               if (Utils.IsSequence(tag))
               {
                  Sequence sequence = new Sequence(tag, _Dataset, this);

                  Index = index - 1;
                  return sequence;
               }
               
               return GetSequenceValue(index-1, tag, false);
            }
            return null;
         }
         set
         {
            if (_Dataset != null)
            {
               SetSequenceValue(index - 1, tag, value);
            }
         }
      }

      public Sequence(long tag, DicomDataSet ds)
      {
         _Tag = tag;
         _Dataset = ds;
      }

      public Sequence(long tag, DicomDataSet ds, Sequence parent)
      {
         _Tag = tag;
         _Dataset = ds;
         _Parent = parent;
      }

      /// <summary>
      /// Gets the sequence value.
      /// </summary>
      /// <param name="index">The item index withing the sequence.</param>
      /// <param name="tag">The tag to get.</param>
      /// <param name="list">if set to <c>true</c> [list].</param>
      /// <returns></returns>
      private object GetSequenceValue(int index, long tag, bool list)
      {        
         object value = null;         

         if (_Parent==null)
         {
            _Dataset.BeginReadSequence(_Tag).BeginReadItem(index);
            value = _Dataset.GetElementValue(tag, false);
            _Dataset.EndReadItem().EndReadSequence();            
         }
         else
         {
            List<Sequence> parents = new List<Sequence>();

            try
            {
               AdvanceReadSequence(parents, index);
               value = _Dataset.GetElementValue(tag, false);
            }
            catch (Exception e)
            {
               Logger.Global.SystemException(string.Empty, e);
            }
            finally
            {
               RestoreReadSequence(parents);
            }
         }

         return value;
      }

      /// <summary>
      /// Gets the sequence count.
      /// </summary>
      /// <returns>The number of items in the sequence.</returns>
      private int GetSequenceCount()
      {
         DicomElement seq = _Dataset.FindFirstElement(null, _Tag, false);
         int count = 0;

         if (seq != null)
         {
            DicomElement child = _Dataset.GetChildElement(seq, true);

            while (child != null)
            {
               count++;
               child = _Dataset.GetNextElement(child, true, true);
            }
         }
         return count;
      }

      /// <summary>
      /// Advances the read sequence.
      /// </summary>
      /// <param name="parents">The list of parent sequence item</param>
      /// <param name="index">The find index we should be at with in the finaly sequence.</param>
      private void AdvanceReadSequence(List<Sequence> parents, int index)
      {         
         Sequence parent = _Parent;

         while (parent != null)
         {
            parents.Add(parent);
            parent = parent.Parent;
         }

         parents.Reverse();
         foreach (Sequence item in parents)
         {            
            _Dataset.BeginReadSequence(item._Tag).BeginReadItem(item.Index);
         }
         //
         // Move to the current item
         //
         if (index == -1)
            index = 0;
         _Dataset.BeginReadSequence(_Tag).BeginReadItem(index);
      }

      private void RestoreReadSequence(List<Sequence> parents)
      {
         _Dataset.EndReadItem().EndReadSequence();
         parents.Reverse();
         foreach (Sequence item in parents)
         {
            item.Dataset.EndReadItem().EndReadSequence();
         } 
      }

      private void SetSequenceValue(int index, long tag, object value)
      {         
         if (_Parent == null)
         {
            if(index == -1)
               _Dataset.BeginEditSequence(_Tag).BeginEditItem();
            else
               _Dataset.BeginEditSequence(_Tag).BeginEditItem(index);
            _Dataset.InsertElementAndSetValue(tag, value);            
            _Dataset.EndEditItem().EndEditSequence();
         }
         else
         {
            List<Sequence> parents = new List<Sequence>();

            try
            {
               AdvanceEditSequence(parents, index);
               _Dataset.InsertElementAndSetValue(tag, value);
            }
            catch (Exception e)
            {
               Logger.Global.SystemException(string.Empty, e);
            }
            finally
            {
               RestoreEditSequence(parents);
            }
         }         
      }

      private void AdvanceEditSequence(List<Sequence> parents, int index)
      {
         Sequence parent = _Parent;

         while (parent != null)
         {
            parents.Add(parent);
            parent = parent.Parent;
         }

         parents.Reverse();
         foreach (Sequence item in parents)
         {
            DicomTag t = DicomTagTable.Instance.Find(item._Tag);

            if (t.Name != null)
               Debug.WriteLine(t.Name);
            if (item.Index == -1)
               _Dataset.BeginEditSequence(item._Tag).BeginEditItem();
            else
               _Dataset.BeginEditSequence(item._Tag).BeginEditItem(item.Index);
         }
         //
         // Move to the current item
         //
         if(index == -1)
            _Dataset.BeginEditSequence(_Tag).BeginEditItem();
         else
            _Dataset.BeginEditSequence(_Tag).BeginEditItem(index);
      }

      private void RestoreEditSequence(List<Sequence> parents)
      {
         _Dataset.EndEditItem().EndEditSequence();
         parents.Reverse();
         foreach (Sequence item in parents)
         {
            item.Dataset.EndEditItem().EndEditSequence();
         }
      }
   }
}
