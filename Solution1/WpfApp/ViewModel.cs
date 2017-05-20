using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged 
            = delegate { };

        private int value1;

        public int Value1
        {
            get { return value1; }
            set { value1 = value;
                OnPropertyCahnged(nameof(Value1));
                OnPropertyCahnged(nameof(Sum));
            }
        }

        private int value2;
        public int Value2
        {
            get { return value2; }
            set { value2 = value;
                OnPropertyCahnged(nameof(Value2));
                OnPropertyCahnged(nameof(Sum));
            }
        }

        public int Sum { get { return value1 + value2; } }

        public virtual int Div(int a, int b)
        {
            return a / b;
        }

        public int Function(int a, int b, int c)
        {
            return c + Div(a, b);
        }

        private void OnPropertyCahnged(string propName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
