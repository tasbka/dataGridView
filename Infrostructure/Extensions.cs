using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataGridView.App.Infrostructure
{
    public static class Extensions
    {
        public static void AddBinding<TControl, TSource>(
            this TControl control,
            Expression<Func<TControl, object>> destinationProperty,
            TSource source,
            Expression<Func<TSource, object>> sourceProperty)
            where TControl : Control
            where TSource : class
        {
            string controlPropName = GetPropertyName(destinationProperty);
            string sourcePropName = GetPropertyName(sourceProperty);

            control.DataBindings.Add(controlPropName, source, sourcePropName);

        }
        private static string GetPropertyName<TType>(Expression<Func<TType, object>> expression)
        {
            Expression body = expression.Body;
            if (body is UnaryExpression unary && unary.Operand is MemberExpression memberExp)
            {
                return memberExp.Member.Name;
            }


            if (body is MemberExpression member)
            {
                return member.Member.Name;
            }

            throw new ArgumentException("Expression is not a property", nameof(expression));
        }

    }
}

