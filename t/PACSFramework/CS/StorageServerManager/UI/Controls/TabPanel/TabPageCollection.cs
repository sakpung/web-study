// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using Leadtools.Demos.StorageServer.DataTypes;

namespace Leadtools.Demos.StorageServer.UI
{
   public class TabPageCollection
   {
      List <PageData> _controls ;
      public TabPageCollection()
      {
         _controls = new List<PageData> ( ) ;
      }

      [Browsable(false)]
      public int Count 
      { 
         get { return _controls.Count ; } 
      }

      public bool IsReadOnly 
      { 
         get
         {
            return false ;
         }
      }

      public virtual PageData this[int index] 
      { 
         get 
         { 
            if ( index < 0 || index >= _controls.Count )
            {
               throw new IndexOutOfRangeException ( ) ;
            }

            return _controls [ index ] ;
         } 

         set
         {
            if ( index < 0 || index >= _controls.Count )
            {
               throw new IndexOutOfRangeException ( ) ;
            }

            if ( _controls [ index ] != value )
            {
               PageData oldPage =_controls [ index ] ;

               _controls [ index ] = value ;

               OnPageRemoved ( oldPage ) ;
               OnPageAdded ( value ) ;
            }
         }
      }

      public virtual void Add(PageData value)
      {
         _controls.Add(value);

         OnPageAdded ( value ) ;
      }

      public virtual void Remove(PageData value)
      {
         _controls.Remove(value);

         OnPageRemoved ( value ) ;
      }
      
      public virtual void Clear()
      {
         foreach ( PageData control in _controls.ToArray ( ) )
         {
            Remove ( control ) ;
         }
      }
      
      public bool Contains(PageData page)
      {
         return _controls.Contains ( page ) ;
      }
      
      public IEnumerator GetEnumerator()
      {
         return _controls.GetEnumerator ( ) ;
      }
      
      public int IndexOf(PageData page)
      {
         return _controls.IndexOf ( page ) ;
      }

      internal event EventHandler <DataEventArgs<PageData>> PageAdded ;
      internal event EventHandler <DataEventArgs<PageData>> PageRemoved ;

      private void OnPageAdded ( PageData tabPage )
      {
         if ( null != PageAdded ) 
         {
            PageAdded ( this, new DataEventArgs<PageData> ( tabPage ) ) ;
         }
      }

      private void OnPageRemoved ( PageData tabPage )
      {
         if ( null != PageRemoved ) 
         {
            PageRemoved ( this, new DataEventArgs<PageData> ( tabPage ) ) ;
         }
      }
   }
}
