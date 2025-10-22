using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            Expression<Func<TSource, object>> sourceProperty,
             ErrorProvider? errorProvider = null)
            where TControl : Control
            where TSource : class
        {
            var controlPropName = GetPropertyName(destinationProperty);
            var sourcePropName = GetPropertyName(sourceProperty);

            var existing = control.DataBindings[controlPropName];
            if (existing != null)
                control.DataBindings.Remove(existing);

            var binding = new Binding(controlPropName, source, sourcePropName)
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };

            control.DataBindings.Add(controlPropName, source, sourcePropName);

            if (errorProvider != null)
            {
                AddValidation(control, source, sourcePropName, errorProvider);
            }
        }

        /// <summary>
        /// Добавление валидации к контролу
        /// </summary>
        private static void AddValidation<TControl, TSource>(
            TControl control,
            TSource source,
            string sourcePropertyName,
            ErrorProvider errorProvider)
            where TControl : Control
            where TSource : class
        {
            var sourcePropertyInfo = source.GetType().GetProperty(sourcePropertyName);
            if (sourcePropertyInfo == null)
                return;

            // Подписываемся на события валидации
            control.Validating += (sender, e) =>
            {
                ValidateControl(control, source, sourcePropertyName, errorProvider);
            };

            // Также валидируем при изменении значения
            control.Validated += (sender, e) =>
            {
                // Можно очистить ошибку при успешной валидации
                // или оставить для отображения в реальном времени
            };
        }

        /// <summary>
        /// Валидация конкретного контрола
        /// </summary>
        private static void ValidateControl<TControl, TSource>(
            TControl control,
            TSource source,
            string sourcePropertyName,
            ErrorProvider errorProvider)
            where TControl : Control
            where TSource : class
        {
            var sourcePropertyInfo = source.GetType().GetProperty(sourcePropertyName);
            if (sourcePropertyInfo == null)
                return;

            var context = new ValidationContext(source) { MemberName = sourcePropertyName };
            var results = new List<ValidationResult>();

            // Получаем значение свойства
            var propertyValue = sourcePropertyInfo.GetValue(source);

            // Проверяем валидность
            bool isValid = Validator.TryValidateProperty(propertyValue, context, results);

            if (!isValid && results.Count > 0)
            {
                errorProvider.SetError(control, results[0].ErrorMessage);
                // Если нужно предотвратить потерю фокуса при ошибке:
                // control.CausesValidation = true;
            }
            else
            {
                errorProvider.SetError(control, string.Empty);
            }
        }

        /// <summary>
        /// Метод извлечения имени свойства из лямбда-выражения
        /// </summary>
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

