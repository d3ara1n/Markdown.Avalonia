using Avalonia;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Data.Core;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Markdown.Avalonia.Extensions
{
    public class DivideColorExtension : MarkupExtension
    {
        private readonly string _frmKey;
        private readonly string _toKey;
        private readonly double _relate;

        public DivideColorExtension(string frm, string to, double relate)
        {
            this._frmKey = frm;
            this._toKey = to;
            this._relate = relate;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            BindingBase left;
            if (Color.TryParse(_frmKey, out var leftColor))
            {
                // Create a binding to a static object that holds the color value
                var leftSource = new ColorHolder(leftColor);
                left = new Binding(nameof(ColorHolder.Color)) { Source = leftSource };
            }
            else
            {
                var lftExt = new DynamicResourceExtension(_frmKey);
                left = (BindingBase)lftExt.ProvideValue(serviceProvider);
            }

            BindingBase right;
            if (Color.TryParse(_toKey, out var rightColor))
            {
                var rightSource = new ColorHolder(rightColor);
                right = new Binding(nameof(ColorHolder.Color)) { Source = rightSource };
            }
            else
            {
                var rgtExt = new DynamicResourceExtension(_toKey);
                right = (BindingBase)rgtExt.ProvideValue(serviceProvider);
            }

            return new MultiBinding()
            {
                Bindings = new BindingBase[] { left, right },
                Converter = new DivideConverter(_relate)
            };
        }
    }

    public class ColorHolder
    {
        public Color Color { get; }

        public ColorHolder(Color color)
        {
            Color = color;
        }
    }

    class DivideConverter : IMultiValueConverter
    {
        public double Relate { get; }

        public DivideConverter(double relate)
        {
            Relate = relate;
        }

        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            Color colL;
            if (values[0] is ISolidColorBrush bl)
                colL = bl.Color;
            else if (values[0] is Color cl)
                colL = cl;
            else
                return values[0];

            Color colR;
            if (values[1] is ISolidColorBrush br)
                colR = br.Color;
            else if (values[1] is Color cr)
                colR = cr;
            else
                return values[0];

            static byte Calc(byte l, byte r, double d)
                => (byte)(l * (1 - d) + r * d);

            return new SolidColorBrush(
                        Color.FromArgb(
                            Calc(colL.A, colR.A, Relate),
                            Calc(colL.R, colR.R, Relate),
                            Calc(colL.G, colR.G, Relate),
                            Calc(colL.B, colR.B, Relate)));
        }
    }
}
