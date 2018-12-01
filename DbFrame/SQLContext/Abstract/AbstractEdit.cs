﻿using System;
using System.Collections.Generic;
namespace DbFrame.SqlContext.Abstract
{
    //
    using DbFrame.SqlContext.Interface;
    using DbFrame.Class;
    using System.Linq.Expressions;

    public abstract class AbstractEdit : BaseCalss, IEdit
    {
        //根据 拉姆达表达式 作为 Where 条件
        public abstract bool Edit<T>(T Set, Expression<Func<T, bool>> Where) where T : BaseEntity<T>, new();

        public abstract bool Edit<T>(Expression<Func<T>> Set, Expression<Func<T, bool>> Where) where T : BaseEntity<T>, new();

        public abstract bool Edit<T>(T Set, Expression<Func<T, bool>> Where, List<SQL> li) where T : BaseEntity<T>, new();

        public abstract bool Edit<T>(Expression<Func<T>> Set, Expression<Func<T, bool>> Where, List<SQL> li) where T : BaseEntity<T>, new();


        //根据ID 作为 Where 条件
        public abstract bool EditById<T>(T Set) where T : BaseEntity<T>, new();

        public abstract bool EditById<T>(Expression<Func<T>> Set) where T : BaseEntity<T>, new();

        public abstract bool EditById<T>(T Set, List<SQL> li) where T : BaseEntity<T>, new();

        public abstract bool EditById<T>(Expression<Func<T>> Set, List<SQL> li) where T : BaseEntity<T>, new();

        //根据sql 语句操作
        public abstract bool Edit<T>(string SetStr, string WhereStr, dynamic Param) where T : BaseEntity<T>, new();

        public abstract bool Edit<T>(string SetStr, string WhereStr, dynamic Param, List<SQL> li) where T : BaseEntity<T>, new();

        bool IEdit.Edit<T>(T Set, Expression<Func<T, bool>> Where)
        {
            return Edit<T>(Set, Where);
        }

        bool IEdit.Edit<T>(Expression<Func<T>> Set, Expression<Func<T, bool>> Where)
        {
            return Edit<T>(Set, Where);
        }

        bool IEdit.Edit<T>(T Set, Expression<Func<T, bool>> Where, List<Class.SQL> li)
        {
            return Edit<T>(Set, Where, li);
        }

        bool IEdit.Edit<T>(Expression<Func<T>> Set, Expression<Func<T, bool>> Where, List<Class.SQL> li)
        {
            return Edit<T>(Set, Where, li);
        }

        bool IEdit.EditById<T>(T Set)
        {
            return EditById<T>(Set);
        }

        bool IEdit.EditById<T>(Expression<Func<T>> Set)
        {
            return EditById<T>(Set);
        }

        bool IEdit.EditById<T>(T Set, List<Class.SQL> li)
        {
            return EditById<T>(Set, li);
        }

        bool IEdit.EditById<T>(Expression<Func<T>> Set, List<Class.SQL> li)
        {
            return EditById<T>(Set, li);
        }

        bool IEdit.Edit<T>(string SetStr, string WhereStr, dynamic Param)
        {
            return Edit<T>(SetStr, WhereStr, Param);
        }

        bool IEdit.Edit<T>(string SetStr, string WhereStr, dynamic Param, List<Class.SQL> li)
        {
            return Edit<T>(SetStr, WhereStr, Param, li);
        }


    }
}
